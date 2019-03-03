module ConsoleApplication2.TestAddFunction
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
    