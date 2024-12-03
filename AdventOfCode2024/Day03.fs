module AdventOfCode2024.Day03

open System.IO
open System.Text.RegularExpressions

let getMulResult (input: string) : int =
    Regex.Matches(input, "mul\((\d{1,3}),(\d{1,3})\)")
    |> Seq.map (fun x -> (int x.Groups[1].Value) * (int x.Groups[2].Value))
    |> Seq.sum

let part1 (inputFile: string) =
    inputFile |> File.ReadAllText |> getMulResult

let removeDonts input =
    Regex.Replace(input, "don't\(\)(.\s?)*?((do\(\))|$)", "")

let part2 (inputFile: string) =
    inputFile |> File.ReadAllText |> removeDonts |> getMulResult
