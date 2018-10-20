# CSVExtractor

A totally awesome csv parser project!!Begin here and never regret another github clone.

## Summary

A `console program` that will:
Read `CSV` files, set the file path configurable so the program can read any `LP` and `TOU` files;
For each file, calculate the median value using 
-  The `Data Value` column for the `LP` file type or 
-  The `Energy` column for the `TOU` file type;
Find values that are 20% above or below the median, and print to the console using the following format:
{file name} {datetime} {value} {median value}


## Solution

Solution|Authors
--------|-----------
ERM.CSV.Extactor|Rabia Williams

## Configuration 
e.g to run this app, add appsettings with keys and values as below

FilePath|Percentage
--------|-----------
D:/files|20

## Features

- Works
- Logs <Find them in `bin\Debug\Logs`>
- Tests  


## Assumptions 

- Created an interactive Console app for fun  < don't we all feel nerdy with a console apps with colours :) >
- The Above  and Below range is rounded to 3 decimal places 
- The file names will always have either  `LP` OR `TOU` to represent what kind of information it gives
- The files will always have a header and they are csv files at all times <Nope ! excels please excuse..>
- The files will be in the same system locally or in an equally accessible system where the console app is run
- The file header order will be `MeterPoint Code,Serial Number,Plant Code,Date/Time,Data Type,Data Value,Units,Status` for `LP` files
- The file header order will be `MeterPoint Code,Serial Number,Plant Code,Date/Time,Data Type,Energy,Maximum Demand,Time of Max Demand,Units,Status,Period,DLS Active,Billing Reset Count,Billing Reset Date/Time,Rate` for `TOU` files


## Disclaimer
**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT. In short use at your own risk !!!**


