module ConsoleApplication2.Functions
open System

let add (s : String) : int =
    if s.Equals("") then
        0
    else
        int (s)

