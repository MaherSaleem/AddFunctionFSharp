module ConsoleApplication2.Functions
open System

let add (s : String) : int =
    if s.Equals("") then
        0
    elif s.Contains(",") then
        let twoNumbers = s.Split [| ',' |]
        (int (twoNumbers.[0]) + int (twoNumbers.[1]))
    else
        int (s)

