# Pascal# (PascalSharp)
Modern Pascal language on .NET platform for all. Supports Windows & Linux & macOS, .NET Framework & Mono, Console Applications & 2D & 3D, Windows Forms & WPF & Avalonia.

## Purpose
This project has started since there was no real progress in the original PascalABC.NET tooling and IDE. Since then, following things have been done:
* Upgrade to modern .NET SDK project system (Microsoft.NET.Sdk)
* Upgrade NRefactory to latest 4.x version
* Build the majority of 3rd-party non-UI libraries from source
* Build multiple binaries, targetting net40 and net471
* Upgrade visual outlook of the Lite IDE
* Upgrade all 3rd-party libraries to their latest versions (Mono.Cecil, DockPanelSuite, DLR)
* Split repo into logical components
* Rename output assemblies for consistency
* Refactor namespaces to match files location

## Building
Pascal# is being developed in Visual Studio Community 2017. Use IDE or MSBuild command line to build Pascal# solution. Do not forget to add `/restore` command line key to MSBuild.

Use any modern (5.8+) [Mono](http://www.mono-project.com/download/) MSBuild (not xbuild) to build Pascal# on non-Windows platforms.

## Architecture
* Lite IDE (PascalSharp.IDE.Lite, Windows-only)
* Console compiler (PascalSharp.Console or pabcnetc.exe)
* Runtime Library
* SharpDevelop libraries (ICSharpCode.* dlls)
* Internal language compiler facilities (this repository)
* Lite IDE Plugins
* PT4 taskbook (PT4Provider, PT4Tools, PT4/* folder)
* 3rd-party libraries (DockPanelSuite, DLR, Microsoft.Build, Mono.Cecil, SharpDisasm)

## Tests
Tests are located in the directory "TestSuite".