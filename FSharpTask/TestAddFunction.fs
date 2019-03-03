module ConsoleApplication2.TestAddFunction
open Functions
open System
open NUnit.Framework

[<TestFixture>]
type TestAddFunction() =

    [<Test>]
    member this.testAddOfEmptyString() =
        let s = ""
        let expectedResult = 0
        Assert.AreEqual(expectedResult, (add (s)))
