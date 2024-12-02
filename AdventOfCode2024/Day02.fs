module AdventOfCode2024.Day02

open System.IO

type Report = int list

let getReports (inputFile: string) =
    File.ReadAllLines inputFile
    |> Seq.map (fun x -> x.Split(" ") |> Seq.map int |> Seq.toList)

let isSafe (report: Report) : bool =
    let ascending = report[0] < report[1]

    report
    |> Seq.pairwise
    |> Seq.map (fun (a, b) -> if ascending then b - a else a - b)
    |> Seq.forall (fun diff -> diff = 1 || diff = 2 || diff = 3)

let getVariants (report: Report) : Report seq =
    report |> Seq.mapi (fun i _ -> report[.. i - 1] @ report[i + 1 ..])

let isSafe2 (report: Report) : bool =
    report |> getVariants |> Seq.exists isSafe

let part1 (inputFile: string) =
    inputFile |> getReports |> Seq.filter isSafe |> Seq.length

let part2 (inputFile: string) =
    inputFile |> getReports |> Seq.filter isSafe2 |> Seq.length
