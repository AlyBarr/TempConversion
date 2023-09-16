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

//This file's name: Temperaturelogic.cs
//This file purpose: This file contains the alogrithm for computing the correct conversion of Temperature
//Date last modified: 2023-Sep-5
//
//
//To compile Temperaturelogic.cs:   
//          mcs -target:library -out:Temperaturelogic.dll Temperaturelogic.cs
//
////Ref: for data types uint and ulong see Gittleman, p. 149
//
using System; //Gets double input to work

public class Temperaturelogic
{
   public static double FahreheitToCelsiusLogic(int sequencenum){
         
      double fahrenheit = Convert.ToDouble(sequencenum);
      
      double Celsius = Math.Round(Conversion(fahrenheit), 4);
      
      return Celsius;
   }
   
   private static double Conversion(double fahrenheit){
      return (fahrenheit-32)*5/9;

   }

}

/*Previous
//If the following loop terminates with future < present then the computed value 'future' has overflowed the capacity of ulong type.
//After overflow occurs any additional computation is simply noise.
 do {past = present;
    present = future;
    future = past+present;
    sequencenum--;
 }while(sequencenum > 0 && future > present);

 if(future < present)
    return 0;      //Return zero indicates overflow of type ulong (unsigned long).
 else
    return present;

    
   }//End of computetemperaturenumber

}//End of Temperaturelogic
*/