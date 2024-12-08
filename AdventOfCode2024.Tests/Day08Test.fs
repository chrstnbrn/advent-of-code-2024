module Day08Test
open AdventOfCode2024
open Day08

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day08Example.txt"))
    |> should equal 14

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day08Example.txt"))
    |> should equal 34
