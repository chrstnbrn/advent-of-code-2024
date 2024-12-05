module Day04Test
open AdventOfCode2024
open Day04

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day04Example.txt"))
    |> should equal 18

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day04Example.txt"))
    |> should equal 9
