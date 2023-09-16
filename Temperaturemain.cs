//****************************************************************************************************************************
//Program name: "Tempeature Conversion Computing System".  This programs will coert a Fareneit temperature from the user and     *
//then outputs the celsius corresponding to that integer.                                                          *
//Copyright (C) 2023 Alyssa Barrientos                                                                                       *
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License  *
//version 3 as published by the Free Software Foundation.                                                                    *
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied         *
//warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.     *
//A copy of the GNU General Public License v3 is available here:  <https://www.gnu.org/licenses/>.                           *
//****************************************************************************************************************************








//Ruler:=1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3**

//Author: Alyssa Brrientos
//Mail: alybar@csu.fullerton.edu

//Program name: Tempeature Conversion Computing System
//Programming language: C Sharp
//Date development of program began: 2023-Aug-29
//Date of last update: 2023-Sep-5

//Purpose: This programs will coert a Fareneit temperature from the user and then outputs the celsius corresponding to that integer. 

//Files in project: Temperaturemain.cs, Temperaturelogic.cs, Temperatureinterface.cs, build.sh

//This file's name: Temperaturemain.cs
//This file purpose: This file will activate the user interface
//Date last modified: 2023-Sep-5

//To compile Temperaturelogic.cs:   
//     mcs -target:library -out:Temperaturelogic.dll Temperaturelogic.cs
//To compile Temperatureinterface.cs: [The next line uses a continuation to the following line]
//     mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:Temperaturelogic.dll -out:Temperatureinterface.dll Temperatureinterface.cs
//To compile  and link Temperaturemain.cs:    
//     mcs -r:System -r:System.Windows.Forms -r:Temperatureinterface.dll -out:Tempo.exe Temperaturemain.cs
//To execute this program:
//     ./Tempo.exe

//Hardcopy of source files: The sources files of this program are best printed using 7-point monospaced font in protrait orientation.
//
using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Temperaturemain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Temperature program.");
    Temperatureinterface Tempapp = new Temperatureinterface();
    Application.Run(Tempapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of Temperaturemain

//=================================================================================================================================

//Notes to the C# programming class
//This is a sample programming to use for learning to construct user interfaces with C#
//You are free to re-use and parts of this program in your own homework.  That is what an open source licensing agreement intends to do.
//Some things you should notice:
//   The program contains 3 files.  Together they make one program.
//   There is a main function.  Its main job is to activate the user interface in the file "interface.cs".
//   The UI seen by the human user is constructed in layers.
//   The base layer is a bare form: usually it is a gray rectangle.
//   This program places on top of the base form three panels called headerpanel, displaypanel, and controlpanel.
//   The panels can be thought of as "layer 2".
//   On top of each individual panel there are attached some 'objects'.  The objects are layer three.
//   On top of the headerpanel there are some informative messages and nothing more.
//   On top of the displaypanel there is a input box known as a "text box".
//   Also on the displaypanel there is extra space to display output data.
//   On the controlpanel there are three buttons
//   Everything in sight has lots of colors because we want the customer to like to use our software.
//That summarizes the structure of the UI of this program.  That same structure of UI will be re-used in many (or even most) of the 
//programs you will create in this course.