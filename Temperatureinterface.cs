//****************************************************************************************************************************
//Program name: "Tempeature Conversion Computing System".  This programs will coert a Fahreneit temperature from the user and     *
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

//Purpose:  This program will compute a Temperature number given its celsius counterpart of fahrnheit numbers.

//Files in project: Temperaturemain.cs, Temperaturelogic.cs, Temperatureinterface.cs

//This file's name: Temperatureinterface.cs
//This file purpose: This file describes the structure of the user interface window.
//Date last modified: 2023-Sep-5

//To compile Temperatureinterface.cs:
//     mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:Temperaturelogic.dll -out:Temperatureinterface.dll Temperatureinterface.cs

//Function: The Temperature numerical calculator.  Enter a non-negative sequence integer in the input field, then
//click on the compute button, and the result will appear as a string.

//The Formula to calculate fahrenheit to celsius: c=(f-32)*5/9
// c= celsius
// f=fahrenheit
// using doubles?
//lookat logic

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;




public class Temperatureinterface: Form
{private Label welcome = new Label();
 private Label author = new Label();
 private Label sequencemessage = new Label();
 private TextBox sequenceinputarea = new TextBox();
 private Label outputinfo = new Label();
 private Button computebutton = new Button();
 private Button clearbutton = new Button();
 private Button exitbutton = new Button();
 private Panel headerpanel = new Panel();
 private Graphicpanel displaypanel = new Graphicpanel();
 private Panel controlpanel = new Panel();
 private Size maximumtemperatureinterfacesize = new Size(1024,800);
 private Size minimumtemperatureinterfacesize = new Size(1024,800);
 private enum Status {Initial_display,Successful_calculation,Error};
 private static Status outcome = Status.Initial_display;
 private enum Execution_state {Executing, Waiting_to_terminate};             //<== New in version 2.2
 private Execution_state current_state = Execution_state.Executing;
 private static System.Timers.Timer exit_clock = new System.Timers.Timer();  //<== New in version 2.2
 

 public Temperatureinterface()  //Constructor begins here
   {//Set the size of the user interface box.
    MaximumSize = maximumtemperatureinterfacesize;
    MinimumSize = minimumtemperatureinterfacesize;
    //Initialize text strings
    Text = "Temperature Conversion Computing System";
    welcome.Text = "Welcome to the Temperature Conversion Calculator";
    author.Text = "By Alyssa Barrientos";
    sequencemessage.Text = "Enter Fahrenheit:";
    sequenceinputarea.Text = "Enter Fahrenheit Degrees";
    outputinfo.Text = "Result will display here.";
    computebutton.Text = "Compute";
    clearbutton.Text = "Clear";
    exitbutton.Text = "Exit";
    
    //Set sizes
    Size = new Size(400,240);
    welcome.Size = new Size(800,44);
    author.Size = new Size(320,34);
    sequencemessage.Size = new Size(400,36);
    sequenceinputarea.Size = new Size(350,30);
    outputinfo.Size = new Size(900,80);   //This label has a large height to accommodate 2 lines output text. 
    computebutton.Size = new Size(120,60);
    clearbutton.Size = new Size(120,60);
    exitbutton.Size = new Size(120,60);
    headerpanel.Size = new Size(1024,200);
    displaypanel.Size = new Size(1024,400);
    controlpanel.Size = new Size(1024,200);
    
    //Set colors
    headerpanel.BackColor = Color.DeepSkyBlue;
    displaypanel.BackColor = Color.AliceBlue;
    controlpanel.BackColor = Color.SandyBrown;
    computebutton.BackColor = Color.SkyBlue;
    clearbutton.BackColor = Color.SkyBlue;
    exitbutton.BackColor = Color.SkyBlue;
    
    //Set fonts
    welcome.Font = new Font("Fira Code",27,FontStyle.Bold);
    author.Font = new Font("Fira Code",19,FontStyle.Regular);
    sequencemessage.Font = new Font("Consolas",26,FontStyle.Regular);
    sequenceinputarea.Font = new Font("Consolas",18,FontStyle.Regular);
    outputinfo.Font = new Font("Consolas",26,FontStyle.Regular);
    computebutton.Font = new Font("Cascadia Mono",15,FontStyle.Regular);
    clearbutton.Font = new Font("Cascadia Mono",15,FontStyle.Regular);
    exitbutton.Font = new Font("Cascadia Mono",15,FontStyle.Regular);
    
    //Set position of text within a label
    welcome.TextAlign = ContentAlignment.MiddleCenter;
    author.TextAlign = ContentAlignment.MiddleCenter;
    sequencemessage.TextAlign = ContentAlignment.MiddleLeft;
    outputinfo.TextAlign = ContentAlignment.MiddleLeft;

    //Set locations
    headerpanel.Location = new Point(0,0);
    welcome.Location = new Point(125,26);
    author.Location = new Point(330,100);
    sequencemessage.Location = new Point(100,60);
    sequenceinputarea.Location = new Point(600,60);
    outputinfo.Location = new Point(100,200);
    computebutton.Location = new Point(200,50);
    clearbutton.Location = new Point(450,50);
    exitbutton.Location = new Point(720,50);
    headerpanel.Location = new Point(0,0);
    displaypanel.Location = new Point(0,200);
    controlpanel.Location = new Point(0,600);

    //Associate the Compute button with the Enter key of the keyboard
    AcceptButton = computebutton;

    //Add controls to the form
    Controls.Add(headerpanel);
    headerpanel.Controls.Add(welcome);
    headerpanel.Controls.Add(author);
    Controls.Add(displaypanel);
    displaypanel.Controls.Add(sequencemessage);
    displaypanel.Controls.Add(sequenceinputarea);
    displaypanel.Controls.Add(outputinfo);
    Controls.Add(controlpanel);
    controlpanel.Controls.Add(computebutton);
    controlpanel.Controls.Add(clearbutton);
    controlpanel.Controls.Add(exitbutton);

    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
    computebutton.Click += new EventHandler(FahrenheitToCelsius);
    clearbutton.Click += new EventHandler(cleartext);
    exitbutton.Click += new EventHandler(stoprun);  //The '+' is required.

    //Configure the clock that controls the shutdown      //<== New in version 2.2
    exit_clock.Enabled = false;     //Clock is turned off at start program execution.
    exit_clock.Interval = 7500;     //7500ms = 7.5seconds.  Clock will tick at intervals of 7.5 seconds
    exit_clock.Elapsed += new ElapsedEventHandler(shutdown);   //Attach a method to the clock.

    //Open this user interface window in the center of the display.
    CenterToScreen();

   }//End of constructor Temperatureinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click
 protected void FahrenheitToCelsius(Object sender, EventArgs events)
   {int sequencenum;        
    string output;
    int maxValue = 2147483647;  
    maxValue += 1;  
    try
       {sequencenum = int.Parse(sequenceinputarea.Text);
        if(sequencenum < 0)
            {Console.WriteLine("Negative integer input received.  Please try again.");
             output = "Negative integer received.  Please try again.";
             outcome = Status.Error;
            }
        else
            {double tempnum = Temperaturelogic.FahreheitToCelsiusLogic(sequencenum);
             if (tempnum == maxValue)
                   {output = "The Temperature number is too large for 64-bit \nunsigned long integers.";
                    //The next assignment is need to avoid the sequence of a large number input (error) followed by
                    //a small number input without first clicking "Clear".
                    sequencenum = 0;
                    outcome = Status.Error;
                   }
             else
                   {output = "The Celsius Temperature number is " + tempnum;
                    outcome = Status.Successful_calculation;
                   }
            }
       }//End of try
    catch(FormatException malformed_input)
       {Console.WriteLine("Non-integer input received.  Please try again.\n{0}",malformed_input.Message);
        output = "Invalid input: no valid fahrenheit number recieved.";
        outcome = Status.Error;
       }//End of catch
     catch(OverflowException too_big)
       {Console.WriteLine("The value inputted is greater than the largest 32-bit integer.  Try again.\n{0}",too_big.Message);
        output = "The input number was too large for 32-bit integers.";
        outcome = Status.Error;
       }//End of catch
    outputinfo.Text = output;
    displaypanel.Invalidate();
   }//End of FahrenheitToCelsius
   
 //Method to execute when the clear button receives an event, namely: receives a mouse click
 protected void cleartext(Object sender, EventArgs events)
   {sequenceinputarea.Text = ""; //Empty string
    outputinfo.Text = "Result will display here.";
    outcome = Status.Initial_display;
    displaypanel.Invalidate();
   }//End of cleartext

//Method to execute when the exit button receives an event, namely: receives a mouse click  <== New in version 2.2
protected void stoprun(Object sender, EventArgs events)
   {switch(current_state)
    {case Execution_state.Executing:
             exit_clock.Interval= 7500;     //7500ms = 7.5 seconds
             exit_clock.Enabled = true;
             exitbutton.Text = "Resume";
             current_state = Execution_state.Waiting_to_terminate;
             break;
     case Execution_state.Waiting_to_terminate:
             exit_clock.Enabled = false;
             exitbutton.Text = "Quit";
             current_state = Execution_state.Executing;
             break;
     }//End of switch statement
  }//End of method stoprun.  In C Sharp language "method" means "function".

protected void shutdown(System.Object sender, EventArgs even)                   //<== Revised for version 2.2
    {//This function is called when the clock makes its first "tick", 
     //which occurs 3.5 seconds after the clock starts.
     Close();       //That means close the main user interface window.
    }//End of method shutdown

 public class Graphicpanel: Panel
 {private Brush paint_brush = new SolidBrush(System.Drawing.Color.Green);
  public Graphicpanel() 
        {Console.WriteLine("A graphic enabled panel was created");}  //Constructor writes to terminal
  protected override void OnPaint(PaintEventArgs ee)
  {  Graphics graph = ee.Graphics;
     switch(outcome)
     {case Status.Initial_display: Console.WriteLine("Initial view of the UI is displayed");
           break;
      case Status.Successful_calculation: graph.FillEllipse(paint_brush,100,280,100,100);
           break;
      case Status.Error: graph.FillEllipse(Brushes.Red,800,280,100,100);
           break;
  }//End of switch
  //The next statement looks like recursion, but it really is not recursion.
  //In fact, it calls the method with the same name located in the super class.
  base.OnPaint(ee);
  }//End of OnPaint
 }//End of class Graphicpanel

}//End of clas Temperatureinterface

