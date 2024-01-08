# MassExtractBinder
Mass extracts BND3 and BND4 into a single extraction folder.  
Folders or files can be input.  
If a folder is provided, a "mass-extract" folder will be present in it with extracted files.  
If a file is provided, a "mass-extract" folder is added into the folder where it is present.  
A list of folders and files can be provided if wanted, it will process them all.  

If a file already exists, it will be overwritten.  
The preferred method of using this program is to drag and drop folders and/or files onto it.  
If that cannot be done, provide file paths to the program in a terminal.

# Supported Platforms
As this program was made as a C# console app targetting .net8.0 in Visual Studio 2022, it should work on:  
Windows  
Linux  
MacOS  

I have only tested it on Windows.

# Building
This program makes use of a SoulsFormats library fork known as SoulsFormatsExtended,  
But any fork of SoulsFormats supporting BND3 and BND4 should be supported if edits are made to include them instead.  
To build it:  
1. Get [SoulsFormatsExtended][0]  
2. Place SoulsFormatsExtended into the directory this repo's directory is in, or make the project target it somewhere else.  
3. Press build for this repo in Visual Studio 2022.  

[0]: https://www.github.com/WarpZephyr/SoulsFormatsExtended