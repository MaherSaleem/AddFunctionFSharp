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

        //function to get the regex that matches multi-delimiter 
        let getRegexPattern : String =
            let numberOfOpenBrackets = s |> String.filter (fun c -> c = '[') |> String.length
            let mutable regexPattern = "^//"
            for i in [ 1..numberOfOpenBrackets ] do
                regexPattern <- regexPattern + "(\[[^][\n]*\])"
            regexPattern <- regexPattern + "\n(.*)"
            regexPattern
            
            
        let regexPattern = getRegexPattern
        let checkDelimiterRegex = Regex.Match(s, regexPattern)
        //check if there are multi-delimiter
        if checkDelimiterRegex.Success then
            let numberOfDelimiters = checkDelimiterRegex.Groups.Count - 2 // -2 since first one is the full match, and last one is the original stirng to be calcualted
            inputString <- checkDelimiterRegex.Groups.Item(numberOfDelimiters + 1).ToString()
            for i in [ 1..numberOfDelimiters ] do
                //get the current delimiter
                let multiCharDelimiter = checkDelimiterRegex.Groups.Item(i).ToString().Trim([|'['; ']'|])
                //Replace all types of delimiters with ,
                inputString <- inputString.Replace(multiCharDelimiter, ",")

        let numbers = inputString.Split [| delimiter; '\n' |]
        //check that there are no two delimiters after each other
        if numbers |> Array.exists (fun num -> num.Equals("")) then
            printfn "Invalid string"
            -1
        else
            let sum = numbers
                      |> Array.map (fun num -> int (num)) // map string to integer
                      |> Array.filter (fun num -> num <= 1000) // remove number that are greater than 1000
                      |> Array.reduce (+) // sum all filtered data

            sum


