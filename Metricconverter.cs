//****************************************************************************************************************************
//Program name: "Simple Converter".  This programs accepts a non-negative number from the user and     *
//then outputs the equivalent converted number into meters.                                                           *
//Copyright (C) 2020  Vong Chen                                                                                        *
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License  *
//version 3 as published by the Free Software Foundation.                                                                    *
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied         *
//warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.     *
//A copy of the GNU General Public License v3 is available here:  <https://www.gnu.org/licenses/>.                           *
//****************************************************************************************************************************

//Ruler:=1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3**

//Author: Vong Chen
//Mail: vchen7@csu.fullerton.edu

//Program name:  Simple Converter
//Programming language: C Sharp
//Date development of program began: 2020-October-2
//Date of last update: 2020-October-10
//Course ID: CPSC 223N-01
//Assignment number: 01
//Date assignment is due: 2020-October-10

//Purpose:  This program will convert the user input number (in inches) to meters

//Files in project: Metricconverter.cs, Metricmain.cs, Metricinterface.cs

//This file's name: Metricconverterlogic.cs
//This file purpose: This file contains the algorithm for converting from inches to meters
//Date last modified: 2020-October-10
//To compile:
//              mcs -target:library -out:Metricconverterlogic.dll Metricconverter.cs

public class Metricconverter
{
    public static double convertToMetric(double inchtometers)
    {
        double _ismeters = inchtometers / 39.37;
        return _ismeters;
    }
}
