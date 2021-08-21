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

//This file's name: Metricinterface.cs
//This file purpose: This file contains the structures of the user interface window
//Date last modified: 2020-October-10
//To compile Metricinterface.cs:
//              mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:Metricconverter.dll -out:Metricinterface.dll Metricinterface.cs

//Function: This file will take input from user as in inches, then display results in meters.
//Negative numbers and invalid input will not be converted.

﻿using System;
using System.Drawing;
using System.Windows.Forms;

public class Metricinterface : Form
{
    private Label welcome = new Label();
    private Label author = new Label();
    private Label sequencemessage = new Label();
    private TextBox sequenceinputarea = new TextBox();
    private Label outputinfo = new Label();
    private Button computebutton = new Button();
    private Button clearbutton = new Button();
    private Button exitbutton = new Button();
    private Panel headerpanel = new Panel();
    private Panel displaypanel = new Panel();
    private Panel controlpanel = new Panel();
    private Size maximuminterfacesize = new Size(1024, 800);
    private Size minimuminterfacesize = new Size(1024, 800);

    public Metricinterface()  //Constructor
    {//Set the size of the user interface box.
        MaximumSize = maximuminterfacesize;
        MinimumSize = minimuminterfacesize;
        //Initialize text strings
        Text = "Simple Converter";
        welcome.Text = "Imperial to Metric Converter";
        author.Text = "Author: Vong Chen";
        sequencemessage.Text = "Enter inches:";
        sequenceinputarea.Text = "";
        outputinfo.Text = "The metric equivalent will be displayed here";
        computebutton.Text = "Compute";
        clearbutton.Text = "Clear";
        exitbutton.Text = "Exit";

        //Set sizes
        Size = new Size(400, 240);
        welcome.Size = new Size(800, 44);
        author.Size = new Size(320, 44);
        sequencemessage.Size = new Size(300, 36);
        sequenceinputarea.Size = new Size(500, 30);
        outputinfo.Size = new Size(900, 80);   //This label has a large height to accommodate 2 lines output text. 
        computebutton.Size = new Size(120, 60);
        clearbutton.Size = new Size(120, 60);
        exitbutton.Size = new Size(120, 60);
        headerpanel.Size = new Size(1024, 200);
        displaypanel.Size = new Size(1024, 400);
        controlpanel.Size = new Size(1024, 200);

        //Set colors
        headerpanel.BackColor = Color.Blue;
        displaypanel.BackColor = Color.BlueViolet;
        controlpanel.BackColor = Color.DarkBlue;
        computebutton.BackColor = Color.Cornsilk;
        clearbutton.BackColor = Color.Gold;
        exitbutton.BackColor = Color.Red;

        //Set fonts
        welcome.Font = new Font("Times New Roman", 33, FontStyle.Bold);
        author.Font = new Font("Times New Roman", 26, FontStyle.Regular);
        sequencemessage.Font = new Font("Arial", 26, FontStyle.Regular);
        sequenceinputarea.Font = new Font("Arial", 19, FontStyle.Regular);
        outputinfo.Font = new Font("Arial", 26, FontStyle.Regular);
        computebutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);
        clearbutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);
        exitbutton.Font = new Font("Liberation Serif", 15, FontStyle.Regular);

        //Set locations
        headerpanel.Location = new Point(0, 0);
        welcome.Location = new Point(225, 26);
        author.Location = new Point(360, 120);
        sequencemessage.Location = new Point(100, 60);
        sequenceinputarea.Location = new Point(400, 60);
        outputinfo.Location = new Point(100, 200);
        computebutton.Location = new Point(200, 50);
        clearbutton.Location = new Point(450, 50);
        exitbutton.Location = new Point(720, 50);
        headerpanel.Location = new Point(0, 0);
        displaypanel.Location = new Point(0, 200);
        controlpanel.Location = new Point(0, 600);

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
        computebutton.Click += new EventHandler(computemetricconverter);
        clearbutton.Click += new EventHandler(cleartext);
        exitbutton.Click += new EventHandler(stoprun);  //The '+' is required.

        //Open this user interface window in the center of the display.
        CenterToScreen();

    }//End of constructor Fibuserinterface

    //Method to execute when the compute button receives an event, namely: receives a mouse click
    protected void computemetricconverter(Object sender, EventArgs events)
    {
        double _number;        //Formerly: uint sequencenum;
        string output;
        try
        {
            _number = double.Parse(sequenceinputarea.Text);
            if (_number < 0)
            {
                Console.WriteLine("Negative input received.  Please try again.");
                output = "Negative number received.  Please try again.";
            }
            else
            {
                double convertedNumber = Metricconverter.convertToMetric(_number);
                output = "The metric value is: " + String.Format("{0:0.0000}",convertedNumber) + " meters";
            }
        }//End of try
        catch (FormatException malformed_input)
        {
            Console.WriteLine("Invalid input received.  Please try again.\n{0}", malformed_input.Message);
            output = "Invalid input. Please try again.";
        }//End of catch
        catch (OverflowException too_big)
        {
            Console.WriteLine("The value inputted is greater than the largest 32-bit integer.  Try again.\n{0}", too_big.Message);
            output = "The input number was too large for 32-bit integers.";
        }//End of catch
        outputinfo.Text = output;
    }//End of computefibnumber


    //Method to execute when the clear button receives an event, namely: receives a mouse click
    protected void cleartext(Object sender, EventArgs events)
    {
        sequenceinputarea.Text = ""; //Empty string
        outputinfo.Text = "Result will display here.";
    }//End of cleartext

    //Method to execute when the exit button receives an event, namely: receives a mouse click
    protected void stoprun(Object sender, EventArgs events)
    {
        Close();
    }//End of stoprun

}//End of clas Fibuserinterface
