module Day01Test
open AdventOfCode2024
open Day01

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day01Example.txt"))
    |> should equal 11

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day01Example.txt"))
    |> should equal 31