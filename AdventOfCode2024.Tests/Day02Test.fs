module Day02Test
open AdventOfCode2024
open Day02

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day02Example.txt"))
    |> should equal 2

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day02Example.txt"))
    |> should equal 4