module ConsoleApplication2.Functions
open System

let add (s : String) : int =
    if s.Equals("") then
        0
    elif s.Contains(",") then
        let charToInt c = int c - int '0'
        ((charToInt s.[0]) + (charToInt s.[2]))
    else
        int (s)

