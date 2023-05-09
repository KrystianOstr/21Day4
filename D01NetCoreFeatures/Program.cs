﻿// See https://aka.ms/new-console-template for more information
using C10Constructors;
using System.Net;

Console.WriteLine("Hello, World!");

// main differences between .net core and .net framework are 

// 1) cross - platform 
// 2) open-source 
// 3) modularity 


//WeatherManager weatherManager = new WeatherManager();

//double temp=  weatherManager.GetTemperature("warsaw");
//Console.WriteLine(temp);

WebClient webClient = new WebClient();

string address = $"https://www.google.com/search?q=weather+";
string city = "warsaw";
string text = webClient.DownloadString(address + city);

File.WriteAllText("output.html", text);
//Console.ReadKey();


// dictionary: 

//!-exclamation mark
//@ - at sign

//# - hash, pound, or octothorpe
//$ - dollar sign
//% - percent sign
//^ - caret or circumflex
//& - ampersand

//* asterisk or star
//( - left parenthesis or open parenthesis
//) -right parenthesis or close parenthesis
// - hyphen or minus
// + plus sign
// = - equals sign
// , - comma
// . - period or dot
// / - forward slash or solidus
// < - less-than sign
// > greater-than sign
// ; -semicolon
// : -colon
// [- left bracket or open bracket
// ] - right bracket or close bracket
// { - left brace or open brace
// } - right brace or close brace
// ` - backtick or grave accent
// ? question mark.