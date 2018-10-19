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
Note: to get {datetime} use `Date/Time` column in a csv file (for both file types).

## Solution

Solution|Authors
--------|-----------
ERM.CSV.Extactor|Rabia Williams

## Configuration 
e.g to run this app, add appsettings with keys and values as below

FilePath|Percentage
--------|-----------
D:/files|20

## Disclaimer
**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT. In short use at your own risk !!!**


