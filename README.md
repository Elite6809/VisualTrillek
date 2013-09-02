Visual Trillek
=============

Visual Trillek is an editor for the assembly language of the fictional DCPU-16 instruction set used in the games *0x10<sup>c</sup>* and *Project Trillek*.

Help
----

VT is still very much a work in development. The IDE is designed to be as intuitive as possible (like an MDI version of Notepad) but still be powerful and usable. Syntax highlighting specifically for the DCPU-16 assembler syntax is also implemented which makes editing code seem more natural.

Plugins
-------

There is plugin functionality via reflection already implemented. Extensibility is one of the goals of this program so I aim to make it as powerful as possible and, besides core functionality, make the entire program modular.

To enable a plugin, put a plugin DLL file (like the sample one provided) into the Plugins\ directory in the same directory as the EXE of the program. The Plugins\ directory is usually auto generated upon execution. The plugin syntax is completely object oriented and uses attributes to help you describe your plugin. It has the power to manipulate the working environment like the main program would.

Event hooks for the main program aren't very extensive at the moment. Feel free to add some of your own.
