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

        let getRegexPattern : String =
            let numberOfOpenBrackets = s |> String.filter (fun c -> c = '[') |> String.length
            let mutable regexPattern = "^//"
            for i in [ 1..numberOfOpenBrackets ] do
                regexPattern <- regexPattern + "(\[[^][\n]*\])"
            regexPattern <- regexPattern + "\n(.*)"
            regexPattern
        let regexPattern = getRegexPattern

        let checkDelimiterRegex = Regex.Match(s, regexPattern)
        if checkDelimiterRegex.Success then
            let numberOfDelimiters = checkDelimiterRegex.Groups.Count - 2
            inputString <- checkDelimiterRegex.Groups.Item(numberOfDelimiters + 1).ToString()
            for i in [ 1..numberOfDelimiters ] do
                let multiCharDelimiter = checkDelimiterRegex.Groups.Item(i).ToString().Trim([|'['; ']'|])
                inputString <- inputString.Replace(multiCharDelimiter, ",")

        let numbers = inputString.Split [| delimiter; '\n' |]
        //check that there are no two delimiters after each other
        if numbers |> Array.exists (fun num -> num.Equals("")) then
            printfn "Invalid string"
            -1
        else
            let sum = numbers
                      |> Array.map (fun num -> int (num))
                      |> Array.filter (fun num -> num <= 1000)
                      |> Array.reduce (+)

            sum


