module AdventOfCode2024.Day01

open System.IO

let getLists (inputFile: string) =
    File.ReadAllLines inputFile
    |> Seq.map _.Split("   ")
    |> Seq.map (fun x -> int x.[0], int x.[1])
    |> (fun x -> Seq.map fst x, Seq.map snd x)

let part1 (inputFile: string) =
    let leftList, rightList = getLists inputFile

    Seq.zip (Seq.sort leftList) (Seq.sort rightList)
    |> Seq.map (fun (a, b) -> abs (a - b))
    |> Seq.sum

let part2 (inputFile: string) =
    let leftList, rightList = getLists inputFile

    leftList
    |> Seq.map (fun left -> left * (rightList |> Seq.filter ((=) left) |> Seq.length))
    |> Seq.sum
