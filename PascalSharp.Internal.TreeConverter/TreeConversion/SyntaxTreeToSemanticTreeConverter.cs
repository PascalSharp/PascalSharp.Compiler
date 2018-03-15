// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

/***************************************************************************
 *   
 *   Интерфейс конвертора синтаксического дерева в семантическое для Compiler   
 *   Зависит от Errors,SemanticTree,PascalABCCompiler.SyntaxTree
 *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using PascalABCCompiler.SystemLibrary;
using PascalSharp.Internal.Errors;
using PascalSharp.Internal.SyntaxTree;
using PascalSharp.Internal.TreeConverter.SymbolTable;
using PascalSharp.Internal.TreeConverter.TreeConversion;
using PascalSharp.Internal.TreeConverter.TreeRealization;
using compiler_directive = PascalSharp.Internal.SyntaxTree.compiler_directive;

namespace PascalSharp.Internal.TreeConverter
{
	public class SyntaxTreeToSemanticTreeConverter 
	{
        private PascalSharp.Internal.TreeConverter.syntax_tree_visitor stv=new PascalSharp.Internal.TreeConverter.syntax_tree_visitor();

        public SyntaxTreeToSemanticTreeConverter()
        {
            //(ssyy) запоминаем visitor
            SystemLibrary.syn_visitor = stv;
        }

        //TODO: Разобраться, где использутеся.
		public TreeConverterSymbolTable SymbolTable
		{
			get
			{
				return stv.SymbolTable;
			}
		}

        void SetSemanticRules(compilation_unit SyntaxUnit)
        {
            SemanticRules.ClassBaseType = SystemLibrary.object_type;
            SemanticRules.StructBaseType = SystemLibrary.value_type;
            switch (SyntaxUnit.Language)
            {
                case LanguageId.PascalABCNET:
                    SemanticRules.AddResultVariable = true;
                    SemanticRules.NullBasedStrings = false;
                    SemanticRules.FastStrings = false;
                    SemanticRules.InitStringAsEmptyString = true;
                    SemanticRules.UseDivisionAssignmentOperatorsForIntegerTypes = false;
                    SemanticRules.ManyVariablesOneInitializator = false;
                    SemanticRules.OrderIndependedMethodNames = true;
                    SemanticRules.OrderIndependedFunctionNames = false;
                    SemanticRules.OrderIndependedTypeNames = false;
                    SemanticRules.EnableExitProcedure = true;
                    SemanticRules.StrongPointersTypeCheckForDotNet = true;
                    SemanticRules.AllowChangeLoopVariable = false;
                    SemanticRules.AllowGlobalVisibilityForPABCDll = true;
                    break;
                case LanguageId.C:
                    SemanticRules.AddResultVariable = false;
                    SemanticRules.NullBasedStrings = true;
                    SemanticRules.InitStringAsEmptyString = false;
                    SemanticRules.UseDivisionAssignmentOperatorsForIntegerTypes = true;
                    SemanticRules.ManyVariablesOneInitializator = false;
                    SemanticRules.OrderIndependedMethodNames = false;
                    SemanticRules.OrderIndependedFunctionNames = false;
                    SemanticRules.OrderIndependedTypeNames = false;
                    SemanticRules.EnableExitProcedure = false;
                    SemanticRules.StrongPointersTypeCheckForDotNet = false;
                    SemanticRules.AllowGlobalVisibilityForPABCDll = false;
                    break;
            }
        }


        //TODO: Исправить коллекцию модулей.
        public PascalSharp.Internal.TreeConverter.TreeRealization.common_unit_node CompileInterface(compilation_unit SyntaxUnit,
            PascalSharp.Internal.TreeConverter.TreeRealization.unit_node_list UsedUnits, List<Error> ErrorsList, List<CompilerWarning> WarningsList, SyntaxError parser_error,
            System.Collections.Hashtable bad_nodes, using_namespace_list namespaces, Dictionary<syntax_tree_node,string> docs, bool debug, bool debugging)
		{
            //convertion_data_and_alghoritms.__i = 0;
			stv.parser_error=parser_error;
            stv.bad_nodes_in_syntax_tree = bad_nodes;
			stv.referenced_units=UsedUnits;
			//stv.comp_units=UsedUnits;
			//stv.visit(SyntaxUnit
            //stv.interface_using_list = namespaces;
            stv.using_list.clear();
            stv.interface_using_list.clear();
            stv.using_list.AddRange(namespaces);
            stv.current_document = new document(SyntaxUnit.file_name);
            stv.ErrorsList = ErrorsList;
            stv.WarningsList = WarningsList;
            stv.SymbolTable.CaseSensitive = SemanticRules.SymbolTableCaseSensitive;
            stv.docs = docs;
            stv.debug = debug;
            stv.debugging = debugging;
			SystemLibrary.syn_visitor = stv;
            SetSemanticRules(SyntaxUnit);
            

            foreach (var cd in SyntaxUnit.compiler_directives)
                cd.visit(stv);

            stv.DirectivesToNodesLinks = CompilerDirectivesToSyntaxTreeNodesLinker.BuildLinks(SyntaxUnit, ErrorsList);  //MikhailoMMX добавил передачу списка ошибок (02.10.10)

            SyntaxUnit.visit(stv);
			/*SyntaxTree.program_module pmod=SyntaxUnit as SyntaxTree.program_module;
			if (pmod!=null)
			{
				stv.visit(pmod);
			}
			else
			{
				SyntaxTree.unit_module umod=SyntaxUnit as SyntaxTree.unit_module;
				if (umod==null)
				{
					throw new PascalSharp.Internal.TreeConverter.CompilerInternalError("Undefined module type (not program and not unit)");
				}
				stv.visit(umod);
			}*/
			//stv.visit(SyntaxUnit);
			//if (ErrorsList.Count>0) throw ErrorsList[0];
			return stv.compiled_unit;
		}

        public void CompileImplementation(PascalSharp.Internal.TreeConverter.TreeRealization.common_unit_node SemanticUnit,
			compilation_unit SyntaxUnit,PascalSharp.Internal.TreeConverter.TreeRealization.unit_node_list UsedUnits,List<Error> ErrorsList,List<CompilerWarning> WarningsList,
            SyntaxError parser_error, System.Collections.Hashtable bad_nodes, using_namespace_list interface_namespaces, using_namespace_list imlementation_namespaces,
           Dictionary<syntax_tree_node,string> docs, bool debug, bool debugging)
		{
			//if (ErrorsList.Count>0) throw ErrorsList[0];
			stv.parser_error=parser_error;
            stv.bad_nodes_in_syntax_tree = bad_nodes;
            stv.referenced_units = UsedUnits;

            stv.using_list.clear();
            stv.using_list.AddRange(interface_namespaces);
            stv.interface_using_list.AddRange(interface_namespaces);
            stv.using_list.AddRange(imlementation_namespaces);
            stv.ErrorsList = ErrorsList;
            stv.WarningsList = WarningsList;
            stv.SymbolTable.CaseSensitive = SemanticRules.SymbolTableCaseSensitive;
            if (docs != null)
            stv.docs = docs;
            stv.debug = debug;
            stv.debugging = debugging;
			SystemLibrary.syn_visitor = stv;
            SetSemanticRules(SyntaxUnit);

			unit_module umod = SyntaxUnit as unit_module;
			if (umod==null)
			{
                throw new PascalSharp.Internal.TreeConverter.CompilerInternalError("Program has not implementation part");
			}
            //TODO: Переделать, чтобы Сашин код работал с common_unit_node.
			stv.compiled_unit=(PascalSharp.Internal.TreeConverter.TreeRealization.common_unit_node)SemanticUnit;
            stv.current_document = new document(SyntaxUnit.file_name);

            foreach (compiler_directive cd in umod.compiler_directives)
                cd.visit(stv);

			stv.visit_implementation(umod);

			//stv.visit(SyntaxUnit);
			//return stv.compiled_unit;
		}
		public void Reset()
		{
			stv.reset();
            //stv = new syntax_tree_visitor(); // SSM 14/07/13 - может, будет занимать больше памяти, зато все внутренние переменные будут чиститься
            //SystemLibrary.syn_visitor = stv;

		}
	}
}
