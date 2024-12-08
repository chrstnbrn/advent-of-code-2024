module AdventOfCode2024.Day08

open System.IO

let findAntennaPositions grid =
    grid
    |> Array2D.mapi (fun i j x -> (i, j, x))
    |> Seq.cast<int * int * char>
    |> Seq.filter (fun (_, _, x) -> x <> '.')
    |> Seq.map (fun (i,j,_) -> (i,j))

let getAntennaPairs grid =
    grid
    |> findAntennaPositions
    |> Seq.groupBy (fun (i, j) -> grid[i, j])
    |> Seq.collect (fun (_, antennas) -> Seq.allPairs antennas antennas |> Seq.filter (fun (a, b) -> a <> b))

let isInBounds grid (i, j) =
    i >= 0 && i < Array2D.length1 grid && j >= 0 && j < Array2D.length2 grid

let getAntinodes (x1, y1) (x2, y2) grid =
    [ (x1 + x1 - x2, y1 + y1 - y2) ] |> List.filter (isInBounds grid)

let getAntinodes2 (x1, y1) (x2, y2) grid =
    Seq.initInfinite id
    |> Seq.map (fun i -> (x1 + i * (x1 - x2), y1 + i * (y1 - y2)))
    |> Seq.takeWhile (isInBounds grid)

let findAntinodes (grid: char[,]) =
    grid
    |> getAntennaPairs
    |> Seq.collect (fun (a,b) -> getAntinodes a b grid)
    |> Set

let findAntinodes2 (grid: char[,]) =
    grid
    |> getAntennaPairs
    |> Seq.collect (fun (a, b) -> getAntinodes2 a b grid)
    |> Set

let part1 (inputFile: string) =
    inputFile |> File.ReadAllLines |> array2D |> findAntinodes |> Seq.length

let part2 (inputFile: string) =
    inputFile |> File.ReadAllLines |> array2D |> findAntinodes2 |> Seq.length
