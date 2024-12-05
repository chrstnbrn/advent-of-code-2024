module AdventOfCode2024.Day05

open System.IO

type OrderingRule = int * int
type Update = int[]

let parseInput (file: string) : (OrderingRule Set * Update seq) =
    let text = File.ReadAllText file
    let parts = text.Split("\n\n") |> Array.map _.Split("\n")

    let orderingRules =
        parts[0]
        |> Seq.map (fun line -> line.Split("|") |> (fun x -> int x[0], int x[1]))
        |> Set

    let updates = parts[1] |> Seq.map (fun line -> line.Split(",") |> Array.map int)
    orderingRules, updates

let compare (orderingRules: OrderingRule Set) a b =
    if Set.contains (a, b) orderingRules then -1
    else if Set.contains (b, a) orderingRules then 1
    else 0

let sort (orderingRules: OrderingRule Set) (update: Update) =
    update |> Array.sortWith (compare orderingRules)

let isCorrectlyOrdered (orderingRules: OrderingRule Set) (update: Update) = (update |> sort orderingRules) = update

let getMiddleNumber (update: Update) = update[update.Length / 2]

let part1 (inputFile: string) =
    let orderingRules, updates = parseInput inputFile

    updates
    |> Seq.filter (isCorrectlyOrdered orderingRules)
    |> Seq.map getMiddleNumber
    |> Seq.sum

let part2 (inputFile: string) =
    let orderingRules, updates = parseInput inputFile

    updates
    |> Seq.filter (isCorrectlyOrdered orderingRules >> not)
    |> Seq.map (sort orderingRules >> getMiddleNumber)
    |> Seq.sum
