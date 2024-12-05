module Day05Test
open AdventOfCode2024
open Day05

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day05Example.txt"))
    |> should equal 143

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day05Example.txt"))
    |> should equal 123
