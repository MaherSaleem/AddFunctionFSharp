module ConsoleApplication2.Functions
open System
open System.Text.RegularExpressions


let add (s : String) : int =
    if s.Equals("") then
        0
    else
        //default values for input strings and delimiter
        let mutable inputString = s.Replace('\n', ' ') // since dot in regex can't match new line
        let mutable delimiter = ','
        //check it the string starts with custom delimater

        //function to get the regex that matches multi-delimiter
        let getRegexPattern : String =
            let mutable numberOfOpenBrackets = inputString |> String.filter (fun c -> c = '[') |> String.length

            //assuming that there are at least one (to keep step 4 wroking)
            if numberOfOpenBrackets = 0 then
                numberOfOpenBrackets <- 1
            let mutable regexPattern = "^//"
            for i in [ 1..numberOfOpenBrackets ] do
                regexPattern <- regexPattern + "(\[?[^][ ]*\]?)"
            regexPattern <- regexPattern + " (.*)"
            regexPattern


        let regexPattern = getRegexPattern
        let checkDelimiterRegex = Regex.Match(inputString, regexPattern)
        //check if there are multi-delimiter
        if checkDelimiterRegex.Success then
            let numberOfDelimiters = checkDelimiterRegex.Groups.Count - 2 // -2 since first one is the full match, and last one is the original stirng to be calcualted
            inputString <- checkDelimiterRegex.Groups.Item(numberOfDelimiters + 1).ToString()
            for i in [ 1..numberOfDelimiters ] do
                //get the current delimiter
                let multiCharDelimiter = checkDelimiterRegex.Groups.Item(i).ToString().Trim([| '['; ']' |])
                //Replace all types of delimiters with ,
                inputString <- inputString.Replace(multiCharDelimiter, delimiter.ToString())

        let numbers = inputString.Split [| delimiter; ' ' |]
        
        let negativeNumbers = numbers |> Array.filter(fun num -> num.StartsWith("-"))
        if negativeNumbers.Length > 0 then
                raise ( new InvalidOperationException ("Can't Pass Negative Numbers" + Array.fold(fun concat num -> concat + num + ", " ) "" negativeNumbers)  )

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


