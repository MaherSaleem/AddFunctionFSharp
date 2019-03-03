module ConsoleApplication2.Functions
open System
open System.Text.RegularExpressions

let add (s : String) : int =
    if s.Equals("") then
        0
    else
        //default values for input strings and delimiter
        let mutable inputString = s
        let mutable delimiter = ','
        //check it the string starts with custom delimater
        if Regex.Match(s, "^//.\n").Success then
            delimiter <- s.[2]
            inputString <- s.[4..]

        let numbers = inputString.Split [| delimiter; '\n' |]
        //check that there are no two delimiters after each other
        if numbers |> Array.exists (fun num -> num.Equals("")) then
            printfn "Invalid string"
            -1
        else
            let sum = numbers |> Array.map (fun num -> int (num)) |> Array.reduce (+)
            sum


