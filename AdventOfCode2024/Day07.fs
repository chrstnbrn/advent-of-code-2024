module AdventOfCode2024.Day07

open System
open System.IO

type Equation = { TestValue: int64; Operands: int64[] }

let parseEquation (text: string) : Equation =
    let parts =
        text.Split([| ": "; " " |], StringSplitOptions.TrimEntries) |> Array.map int64

    { TestValue = Array.head parts
      Operands = Array.tail parts }

let getEquations inputFile =
    inputFile |> File.ReadAllLines |> Array.map parseEquation

let evaluate1 a b = [ a * b; a + b ]

let evaluate2 a b =
    [ a * b; a + b; int64 (a.ToString() + b.ToString()) ]

let evaluateEquation (evaluate: int64 -> int64 -> int64 list) (testValue: Equation) =
    testValue.Operands
    |> Array.tail
    |> Seq.fold
        (fun results value -> results |> List.collect (fun result -> evaluate result value))
        [ testValue.Operands[0] ]
    |> Seq.contains testValue.TestValue

let part1 (inputFile: string) =
    inputFile
    |> getEquations
    |> Seq.filter (evaluateEquation evaluate1)
    |> Seq.map _.TestValue
    |> Seq.sum

let part2 (inputFile: string) =
    inputFile
    |> getEquations
    |> Seq.filter (evaluateEquation evaluate2)
    |> Seq.map _.TestValue
    |> Seq.sum
