﻿// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using PascalABCCompiler.SemanticTree;
using PascalABCCompiler.SystemLibrary;
using PascalSharp.Internal.TreeConverter;
using PascalSharp.Internal.TreeConverter.SymbolTable;
using PascalSharp.Internal.TreeConverter.TreeRealization;
using SymbolTable;

namespace PascalSharp.Compiler.PCU
{
    /*public interface IWrappedNodeWithOffset
    {
        public PCUReader pcuReader
        {
            get;
            set;
        }

        public int offset
        {
            get;
            set;
        }
    }*/

    public class WrappedUnitInterfaceScope : UnitInterfaceScope
    {
        protected PCUReader pr;

        public WrappedUnitInterfaceScope(PCUReader pr)
            : base(SystemLibrary.symtab, null, new Scope[0] { })
        {
            this.pr = pr;
        }

        public override SymbolInfoList Find(string name)
        {
            SymbolInfoList sil = SymbolTable.Find(this, name);
            if (sil == null) return null;
            foreach(SymbolInfo tsi in sil.list)
            {
                if (tsi.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    wrapped_definition_node wdn = (wrapped_definition_node)tsi.sym_info;
                    if (wdn.is_synonim)
                    	tsi.sym_info = wdn.PCUReader.CreateTypeSynonim(wdn.offset, name);
                    else
                    	tsi.sym_info = wdn.PCUReader.CreateInterfaceMember(wdn.offset, name);
                }
            }
            return sil;
        }

        public override SymbolInfoList FindOnlyInScope(string name)
        {
            SymbolInfoList sil = SymbolTable.FindOnlyInScope(this, name, false);
            
            if (sil == null) return sil;
            foreach(SymbolInfo tsi in sil.list)
            {
                if (tsi.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    wrapped_definition_node wdn = (wrapped_definition_node)tsi.sym_info;
                    if (wdn.is_synonim)
                        tsi.sym_info = wdn.PCUReader.CreateTypeSynonim(wdn.offset, name);
                    else
                    	tsi.sym_info = wdn.PCUReader.CreateInterfaceMember(wdn.offset,name);
                }
            }
            return sil;
        }

        //нужно для перегруженных методов
        public SymbolInfoList FindWithoutCreation(string name)
        {
            return SymbolTable.FindOnlyInType(this, name);
        }
    }

    //ssyy
    public class WrappedUnitImplementationScope : UnitImplementationScope
    {
        protected PCUReader pr;

        public WrappedUnitImplementationScope(PCUReader pr, Scope TopScope)
            : base(SystemLibrary.symtab, TopScope, new Scope[0] { })
        {
            this.pr = pr;
        }

        public override SymbolInfoList Find(string name)
        {
            SymbolInfoList sil = SymbolTable.Find(this, name);
            if (sil == null) return null;
            foreach(SymbolInfo tsi in sil.list)
            {
                if (tsi.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    wrapped_definition_node wdn = (wrapped_definition_node)tsi.sym_info;
                    if (wdn.is_synonim)
                    	tsi.sym_info = wdn.PCUReader.CreateTypeSynonim(wdn.offset, name);
                    else
                    	tsi.sym_info = wdn.PCUReader.CreateImplementationMember(wdn.offset);
                }
            }
            return sil;
        }

        public override SymbolInfoList FindOnlyInScope(string name)
        {
            SymbolInfoList sil = SymbolTable.FindOnlyInScope(this, name, false);

            if (sil == null) return sil;
            foreach(SymbolInfo tsi in sil.list)
            {
                if (tsi.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    wrapped_definition_node wdn = (wrapped_definition_node)tsi.sym_info;
                    if (wdn.is_synonim)
                        tsi.sym_info = wdn.PCUReader.CreateTypeSynonim(wdn.offset, name);
                    else
                        tsi.sym_info = wdn.PCUReader.CreateImplementationMember(wdn.offset);
                }
            }
            return sil;
        }

        //нужно для перегруженных методов
        public SymbolInfoList FindWithoutCreation(string name)
        {
            return SymbolTable.FindOnlyInType(this, name);
        }
    
    }
    //\ssyy

    public class WrappedClassScope : ClassScope
    {
        protected PCUReader pr;
        
        public WrappedClassScope(PCUReader pr, Scope top_scope, Scope up_scope)
            : base(SystemLibrary.symtab, top_scope, up_scope)
        {
            this.pr = pr;
        }

        public override SymbolInfoList Find(string name)
        {
            SymbolInfoList sil = SymbolTable.Find(this, name);
            if (PartialScope != null)
            {
                if (sil == null)
                    sil = SymbolTable.Find(PartialScope, name);
                else
                    sil.Add(SymbolTable.Find(PartialScope, name));
            }
            if (sil == null) return sil;
            //если это заглушка, то разворачиваем сущность
            foreach (SymbolInfo tsi in sil.list)
            {
                if (tsi.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    wrapped_definition_node wdn = (wrapped_definition_node)tsi.sym_info;
                    tsi.sym_info = wdn.PCUReader.CreateInterfaceInClassMember(wdn.offset, name);
                }
            }
            return sil;
        }

        public void RestoreMembers(string name)
        {
            SymbolInfoList sil = SymbolTable.FindOnlyInThisClass(this, name);
            //если это заглушка, то разворачиваем сущность
            foreach(SymbolInfo tsi in sil.list)
            {
                if (tsi.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    PCUSymbolInfo pcu_tsi = tsi as PCUSymbolInfo;
                    if (!(pcu_tsi != null && pcu_tsi.semantic_node_type == semantic_node_type.common_method_node && !pcu_tsi.virtual_slot) || pr.comp.CompilerOptions.OutputFileType == CompilerOptions.OutputType.ClassLibrary)
                    {
                        wrapped_definition_node wdn = (wrapped_definition_node)tsi.sym_info;
                        tsi.sym_info = wdn.PCUReader.CreateInterfaceInClassMember(wdn.offset, name);
                    }
                    else
                    {

                    }
                }
            }
        }

        public override SymbolInfoList Find(string name, Scope CurrentScope)
        {
            return Find(name);
        }

        public SymbolInfoList FindWithoutCreation(string name)
        {
            return SymbolTable.FindOnlyInScope(this,name, false);
        }

    }

    //ssyy
    public class WrappedInterfaceScope : WrappedClassScope, IInterfaceScope
    {
        private Scope[] _TopInterfaceScopeArray;
        public virtual Scope[] TopInterfaceScopeArray
        {
            get
            {
                return _TopInterfaceScopeArray;
            }
            set
            {
                _TopInterfaceScopeArray = value;
            }
        }

        public WrappedInterfaceScope(PCUReader pr, Scope TopScope, Scope[] vTopInterfaceScopeArray)
            :
            base(pr, TopScope, null)
        {
            _TopInterfaceScopeArray = vTopInterfaceScopeArray;
        }

        public WrappedInterfaceScope(PCUReader pr, Scope TopScope, Scope BaseClassScope, Scope[] vTopInterfaceScopeArray)
            :
            base(pr, TopScope, BaseClassScope)
        {
            _TopInterfaceScopeArray = vTopInterfaceScopeArray;
        }
    }
    //\ssyy
	
    public class wrapped_type_synonym : wrapped_definition_node
    {
        public string name;
        
        public wrapped_type_synonym(PCUReader pr, string name, int offset):base(offset,pr)
        {
        	this.name = name;
        	is_synonim = true;
        }
    }

    public class wrapped_expression : expression_node
    {
        private PCUReader pr;

        public int offset;

        public wrapped_expression(PCUReader pr, int offset)
        {
            this.pr = pr;
            this.offset = offset;
        }

        public override semantic_node_type semantic_node_type
        {
            get
            {
                return semantic_node_type.wrapped_expression;
            }
        }

        public expression_node restore()
        {
            return pr.GetExpression(offset);
        }
    }

    public class wrapped_function_body : wrapped_statement
    {
        private PCUReader pr;

        public int offset;

        public wrapped_function_body(PCUReader pr, int offset):base(null)
        {
            this.pr = pr;
            this.offset = offset;
        }

        public override statement_node restore()
        {
            return pr.GetCode(offset);
        }

    }

    public class wrapped_common_type_node : common_type_node
    {
        private PCUReader pr;

        public int offset;

        public wrapped_common_type_node(PCUReader pr, type_node base_type, string name, type_access_level type_access_level,
            common_namespace_node comprehensive_namespace, ClassScope cs, location loc, int offset) :
            base(base_type, name, type_access_level, comprehensive_namespace, cs, loc)
        {
            this.pr = pr;
            this.offset = offset;
        }

        public override SymbolInfoList find_in_type(string name, bool no_search_in_extension_methods = false)
        {
            return find_in_type(name, null, no_search_in_extension_methods);
        }
        public override SymbolInfoList find_in_type(string name, Scope CurrentScope, bool no_search_in_extension_methods = false)
        {
            SymbolInfoList sil = scope.FindOnlyInType(name, CurrentScope);
            if (sil == null)
            {
                if (base_type != null && base_type.IsDelegate)
                    return base_type.find_in_type(name, CurrentScope, no_search_in_extension_methods);
                return sil;
            }
                
            foreach(SymbolInfo si in sil.list)
            {
                if (si.sym_info.semantic_node_type == semantic_node_type.wrap_def)
                {
                    wrapped_definition_node wdn = (wrapped_definition_node)si.sym_info;
                    si.sym_info = wdn.PCUReader.CreateInterfaceInClassMember(wdn.offset, name);
                }
            }
            return sil;
        }

    }
	
}

