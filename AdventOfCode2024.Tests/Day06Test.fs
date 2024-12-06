module Day06Test
open AdventOfCode2024
open Day06

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day06Example.txt"))
    |> should equal 41

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day06Example.txt"))
    |> should equal 6
