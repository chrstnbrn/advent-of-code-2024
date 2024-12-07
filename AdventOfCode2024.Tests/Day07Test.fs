module Day07Test
open AdventOfCode2024
open Day07

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day07Example.txt"))
    |> should equal 3749L

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day07Example.txt"))
    |> should equal 11387L
