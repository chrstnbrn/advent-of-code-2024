module Day03Test
open AdventOfCode2024
open Day03

open System.IO
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Part 1`` () =
    part1 (Path.Combine(__SOURCE_DIRECTORY__, "Day03Example1.txt"))
    |> should equal 161

[<Fact>]
let ``Part 2`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day03Example2.txt"))
    |> should equal 48

[<Fact>]
let ``Part 2 - multiline`` () =
    part2 (Path.Combine(__SOURCE_DIRECTORY__, "Day03Example3.txt"))
    |> should equal 58