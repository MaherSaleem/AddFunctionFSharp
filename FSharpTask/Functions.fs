module ConsoleApplication2.Functions
open System

let add (s : String) : int =
    if s.Equals("") then
        0
    else
        let sum = s.Split [| ','; '\n' |] |> Array.map (fun num -> int (num)) |> Array.reduce (+)
        sum


