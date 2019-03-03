module ConsoleApplication2.Functions
open System

let add (s : String) : int =
    if s.Equals("") then
        0
    elif s.Contains(",") then
        let sum = s.Split [| ',' |] |> Array.map (fun num -> int (num)) |> Array.reduce (+)
        sum
    else
        int (s)

