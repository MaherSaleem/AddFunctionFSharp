﻿module ConsoleApplication2.TestAddFunction
open Functions
open System
open NUnit.Framework

[<TestFixture>]
type TestAddFunction() =

    [<Test>]
    member this.AddOfEmptyString() =
        let s = ""
        let expectedResult = 0
        Assert.AreEqual(expectedResult, (add (s)))

    [<Test>]
    member this.AddOfOneNumberAndItIsNumber2() =
        let s = "2"
        let expectedResult = 2
        Assert.AreEqual(expectedResult, (add (s)))

    [<Test>]
    member this.AddOfOneNumberAndItIsNumber5() =
        let s = "5"
        let expectedResult = 5
        Assert.AreEqual(expectedResult, (add (s)))

    [<Test>]
    member this.AddTwoNumbers3And4SeperatedByComma() =
        let s = "3,4"
        let expectedResult = 7
        Assert.AreEqual(expectedResult, (add (s)))
        
    [<Test>]
    member this.AddTwoNumbersMoreThanOneDigit15And13SeperatedByComma() =
        let s = "15,13"
        let expectedResult = 28
        Assert.AreEqual(expectedResult, (add (s)))
        
    [<Test>]
    member this.AddFiveNumberEachOfThemMoreThanOneDigit() =
        let s = "15,13,12,20,100"
        let expectedResult = 160
        Assert.AreEqual(expectedResult, (add (s)))
        
    [<Test>]
    member this.AddFourNumbersThatHaveNewLineInsideTheString() =
        let s = "15\n13,12\n20"
        let expectedResult = 60
        Assert.AreEqual(expectedResult, (add (s)))

