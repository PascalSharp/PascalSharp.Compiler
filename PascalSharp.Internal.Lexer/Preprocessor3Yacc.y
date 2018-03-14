%{
	public List<compiler_directive> compilerDirectives;
    public PreprocessorParser(PreprocessorScanner scanner) : base(scanner) { }
%}

%output=Preprocessor3Yacc.cs 
%partial
%parsertype PreprocessorParser

%namespace PascalSharp.Internal.Lexer

%using PascalSharp.Internal.SyntaxTree;

%YYSTYPE Directive

%start directives

%token DIRECTIVE NODIRECTIVE

%%
directives
    : 
		{ 
			Directive.dirs.Clear(); 
		}
    | directives DIRECTIVE 
		{ 
			compilerDirectives.Add(PreprocessorTools.MakeDirective($2.text, $2.loc));
		}
    | directives NODIRECTIVE 
		{ }
    ;

%%

