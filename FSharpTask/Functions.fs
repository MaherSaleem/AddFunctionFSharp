module ConsoleApplication2.Functions
open System
open System

let add (s : String) : int =
    if s.Equals("") then
        0
    else
        let numbers = s.Split [| ','; '\n' |]
        //check that there are no two delimiters after each other
        if numbers |> Array.exists (fun num -> num.Equals("")) then
            printfn "Invalid string"
            -1
        else
            let sum = numbers |> Array.map (fun num -> int (num)) |> Array.reduce (+)
            sum


