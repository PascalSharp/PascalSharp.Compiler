// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.IO;
using PascalSharp.Internal.Errors;
using PascalSharp.Internal.ParserTools;
using PascalSharp.Internal.SyntaxTree;

namespace PascalSharp.Internal.ParserTools
{
	public class Controller
	{
        public const char HideParserExtensionPostfixChar = '_';
        public delegate void ParserConnectedDeleagte(IParser Parser);
        public event ParserConnectedDeleagte ParserConnected;
        public List<IParser> Parsers = new List<IParser>();
        public IParser LastParser;
		public void Reload()
		{
            Parsers.Clear();
            LastParser = null;
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] dllfiles = di.GetFiles("*Lexer.dll");
            System.Reflection.Assembly asssembly = null;
            Type constr = null;
            IParser pc = null;
            foreach (FileInfo fi in dllfiles)
            {
            	/*if (Path.GetFileName(fi.FullName)=="PascalABCParser.dll" && 
            	    string.Compare(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().ManifestModule.FullyQualifiedName),"PascalABCNET.exe",true)==0)
            		continue;
            	else
            	if (Path.GetFileName(fi.FullName)=="PascalABCPartParser.dll" && 
            	    string.Compare(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().ManifestModule.FullyQualifiedName),"pabcnetc.exe",true)==0)
            		continue;*/
            	//if (Path.GetFileName(fi.FullName) != "PascalABCParser.dll" && Path.GetFileName(fi.FullName) != "VBNETParser.dll")
            	//	continue;
            	//if (Path.GetFileName(fi.FullName) == "VBNETParser.dll" || Path.GetFileName(fi.FullName) == "PascalABCPartParser.dll")
            	//if (Path.GetFileName(fi.FullName) != "PascalABCParser.dll" && Path.GetFileName(fi.FullName) != "VBNETParser.dll")
            	//	continue;
            	//if (Path.GetFileName(fi.FullName) == "PascalABCPartParser.dll")
            	//	continue;
            	//if (Path.GetFileName(fi.FullName) != "PascalABCParser.dll" /*&& Path.GetFileName(fi.FullName) != "VBNETParser.dll"*/)
            	//	continue;
                if (Path.GetFileName(fi.FullName) == "VBNETParser.dll" || Path.GetFileName(fi.FullName) == "PascalABCPartParser.dll")
                    continue;
            	asssembly = System.Reflection.Assembly.LoadFile(fi.FullName);
                try
                {
                    Type[] types = asssembly.GetTypes();
                    if (asssembly != null)
                    {
                        foreach (Type type in types)
                        {
                            if (type.Name.IndexOf("LanguageParser") >= 0)
                            {
                                Object obj = Activator.CreateInstance(type);
                                if (obj is IParser)
                                {
                                    LastParser = (IParser)obj;
                                    Parsers.Add(LastParser);
                                    LastParser.Reset();//Здесь поисходит инициализация парсеров
                                    LastParser.SourceFilesProvider = sourceFilesProvider;
                                    if (ParserConnected != null)
                                        ParserConnected(LastParser);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Parser {0} loading error {1}", Path.GetFileName(fi.FullName),e);
                }
            }
            LastParser = null;
		}
        public Controller()
        {
            sourceFilesProvider = SourceFilesProviders.DefaultSourceFilesProvider;
        }
        SourceFilesProviderDelegate sourceFilesProvider = null;
        public SourceFilesProviderDelegate SourceFilesProvider
        {
            get
            {
                return sourceFilesProvider;
            }
            set
            {
                sourceFilesProvider = value;
                foreach (IParser parser in Parsers)
                {
                    parser.SourceFilesProvider = value;
                }
            }
        }
        public IParser selectParser(string ext)
        {
            foreach (IParser pc in Parsers)
                foreach (string sfext in pc.FilesExtensions)
                    if (sfext.ToLower() == ext)
                        return pc;
            return null;
        }
        public bool ParserExists(string ext)
        {
            return selectParser(ext) != null;
        }
        //public Keyword[] GetKeywordsForExtension(string extension)
        //{
        //    IParser p = selectParser(extension);
        //    if (p != null)
        //        return p.Keywords;
        //    return null;
        //}
        public syntax_tree_node Compile(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings, ParseMode ParseMode, List<string> DefinesList = null)
        {
            LastParser = selectParser(Path.GetExtension(FileName).ToLower());
            if (LastParser == null)
                throw new ParserBadFileExtension(FileName);
            LastParser.Errors = Errors;
            LastParser.Warnings = Warnings;
            return LastParser.BuildTree(FileName, Text, ParseMode, DefinesList);
        }
        public compilation_unit GetCompilationUnitSpecial(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings)
        {
            syntax_tree_node cu = Compile(FileName, Text, Errors, Warnings, ParseMode.Special);
            if (cu == null)
                return null;
            if (cu is compilation_unit)
                return cu as compilation_unit;
            Errors.Add(new UnexpectedNodeType(FileName, cu.source_context,null));
            return null;
            //throw new Errors.CompilerInternalError("Parsers.Controller.GetComilationUnit", new Exception("bad node type"));
        }
        public compilation_unit GetCompilationUnit(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings, List<string> DefinesList = null)
        {
            syntax_tree_node cu = Compile(FileName, Text, Errors, Warnings, ParseMode.Normal, DefinesList);
            if (cu == null)
                return null;
            if (cu is compilation_unit)
                return cu as compilation_unit;
            Errors.Add(new UnexpectedNodeType(FileName, cu.source_context,null));
            return null;
            //throw new Errors.CompilerInternalError("Parsers.Controller.GetComilationUnit", new Exception("bad node type"));
        }
        public compilation_unit GetCompilationUnitForFormatter(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings)
        {
            syntax_tree_node cu = Compile(FileName, Text, Errors, Warnings, ParseMode.ForFormatter);
            if (cu == null)
                return null;
            if (cu is compilation_unit)
                return cu as compilation_unit;
            Errors.Add(new UnexpectedNodeType(FileName, cu.source_context, null));
            return null;
        }
        public expression GetExpression(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings)
        {
            syntax_tree_node cu = Compile(FileName, Text, Errors, Warnings, ParseMode.Expression);
            if (cu == null)
                return null;
            if (cu is expression)
                return cu as expression;
            Errors.Add(new UnexpectedNodeType(FileName, cu.source_context, null));
            return null;
            //throw new Errors.CompilerInternalError("Parsers.Controller.GetComilationUnit", new Exception("bad node type"));
        }
        public expression GetTypeAsExpression(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings)
        {
            syntax_tree_node cu = Compile(FileName, Text, Errors, Warnings, ParseMode.TypeAsExpression);
            if (cu == null)
                return null;
            if (cu is expression)
                return cu as expression;
            Errors.Add(new UnexpectedNodeType(FileName, cu.source_context, null));
            return null;
            //throw new Errors.CompilerInternalError("Parsers.Controller.GetComilationUnit", new Exception("bad node type"));
        }
        public statement GetStatement(string FileName, string Text, List<Error> Errors, List<CompilerWarning> Warnings)
        {
            syntax_tree_node cu = Compile(FileName, Text, Errors, Warnings, ParseMode.Statement);
            if (cu == null)
                return null;
            if (cu is statement)
                return cu as statement;
            Errors.Add(new UnexpectedNodeType(FileName, cu.source_context, null));
            return null;
            //throw new Errors.CompilerInternalError("Parsers.Controller.GetComilationUnit", new Exception("bad node type"));
        }
        public void Reset()
		{
		}
	
	}
}
