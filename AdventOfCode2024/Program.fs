module AdventOfCode2024.Program

open System.IO
open AdventOfCode2024.Day01

let input = (Path.Combine(__SOURCE_DIRECTORY__, "Day01.txt"))
part1 input |> printfn "%i"
part2 input |> printfn "%i"
