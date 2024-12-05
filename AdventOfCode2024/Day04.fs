module AdventOfCode2024.Day04

open System.IO
open System.Text.RegularExpressions

let reverse (text: string) : string =
    text |> Seq.rev |> Seq.toArray |> System.String

let countXmas (text: string) : int =
    Regex.Matches(text, "XMAS") |> Seq.length

let countXmasInTexts (texts: string seq) =
    let countForwards = texts |> Seq.map countXmas |> Seq.sum
    let countBackwards = texts |> Seq.map reverse |> Seq.map countXmas |> Seq.sum
    countForwards + countBackwards

let getDiagonalsDescending (arr: char[,]) =
    let m = Array2D.length1 arr

    [ for i in (-m + 1) .. (m - 1) do
          [| for j in 0 .. (m - abs i - 1) do
                 let row = if i < 0 then j else i + j
                 let col = if i > 0 then j else abs i + j
                 arr[row, col] |]
          |> System.String ]

let getDiagonalsAscending (arr: char[,]) =
    let m = Array2D.length1 arr

    [ for d in 0 .. (m + m - 2) do
          [| for i in (max 0 (d - m + 1)) .. (min (m - 1) d) do
                 arr[i, d - i] |]

          |> System.String ]

let part1 (inputFile: string) =
    let rows = File.ReadAllLines inputFile

    let countHorizontal = countXmasInTexts rows

    let columns =
        [ 0 .. rows[0].Length - 1 ]
        |> Seq.map (fun column -> rows |> Array.map (fun row -> row[column]) |> System.String)

    let countVertical = countXmasInTexts columns

    let arr = array2D rows
    let countDiagonalsDescending = arr |> getDiagonalsDescending |> countXmasInTexts
    let countDiagonalsAscending = arr |> getDiagonalsAscending |> countXmasInTexts

    countHorizontal
    + countVertical
    + countDiagonalsDescending
    + countDiagonalsAscending

let hasXAt i j arr =
    let m = Array2D.length1 arr

    if i < 1 || i >= m - 1 || j < 1 || j >= m - 1 then
        false
    else
        let diagonal1 =
            [| arr[i - 1, j - 1]; arr[i, j]; arr[i + 1, j + 1] |] |> System.String

        let diagonal2 =
            [| arr[i + 1, j - 1]; arr[i, j]; arr[i - 1, j + 1] |] |> System.String

        (diagonal1 = "MAS" || diagonal1 = "SAM")
        && (diagonal2 = "MAS" || diagonal2 = "SAM")

let part2 (inputFile: string) =
    let arr = inputFile |> File.ReadAllLines |> array2D

    arr
    |> Array2D.mapi (fun i j _ -> hasXAt i j arr)
    |> Seq.cast<bool>
    |> Seq.filter id
    |> Seq.length
