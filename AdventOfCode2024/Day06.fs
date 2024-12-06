module AdventOfCode2024.Day06

open System.IO

type Map = char[,]

type Direction =
    | Top
    | Right
    | Bottom
    | Left

type Position = int * int

type GuardState = Direction * Position

let rec move (map: Map) (guardState: GuardState) : GuardState option =
    let direction, position = guardState
    let i, j = position

    match direction with
    | Direction.Top ->
        if i = 0 then
            None
        else if map[i - 1, j] <> '#' then
            Some(direction, (i - 1, j))
        else
            move map (Direction.Right, position)
    | Direction.Right ->
        if j = (Array2D.length1 map - 1) then
            None
        else if map[i, j + 1] <> '#' then
            Some(direction, (i, j + 1))
        else
            move map (Direction.Bottom, position)
    | Direction.Bottom ->
        if i = (Array2D.length2 map - 1) then
            None
        else if map[i + 1, j] <> '#' then
            Some(direction, (i + 1, j))
        else
            move map (Direction.Left, position)
    | Direction.Left ->
        if j = 0 then
            None
        else if map[i, j - 1] <> '#' then
            Some(direction, (i, j - 1))
        else
            move map (Direction.Top, position)

let findGuardState (map: Map) : GuardState =
    map
    |> Array2D.mapi (fun i j x -> i, j, x)
    |> Seq.cast<int * int * char>
    |> Seq.find (fun (_, _, x) -> x = '^')
    |> (fun (i, j, _) -> (Direction.Top, (i, j)))

let getGuardPath (map: Map) (initialGuardState: GuardState) : Position list =
    let mutable guardState = Some initialGuardState
    let mutable positions = []

    while Option.isSome guardState do
        positions <- positions @ [ snd guardState.Value ]
        guardState <- move map guardState.Value

    positions

let part1 (inputFile: string) =
    let map = inputFile |> File.ReadAllLines |> array2D
    let guardState = findGuardState map
    let guardPath = getGuardPath map guardState
    guardPath |> Set |> Set.count

let hasLoop (map: Map) (guardState: GuardState) (additionalPos: int * int) : bool =
    let modifiedMap =
        map
        |> Array2D.mapi (fun i j _ -> if (i, j) = additionalPos then '#' else map[i, j])

    let mutable guardStates = Set [ guardState ]
    let mutable lastGuardState = guardState
    let mutable result: bool option = None

    while result.IsNone do
        let newGuardState = move modifiedMap lastGuardState

        if newGuardState.IsSome && Set.contains newGuardState.Value guardStates then
            result <- Some true
        else if newGuardState.IsSome then
            guardStates <- Set.add newGuardState.Value guardStates
            lastGuardState <- newGuardState.Value
        else
            result <- Some false

    result.Value

let part2 (inputFile: string) =
    let map = inputFile |> File.ReadAllLines |> array2D
    let guardState = findGuardState map
    let guardPath = getGuardPath map guardState

    guardPath
    |> Set
    |> Set.remove (snd guardState)
    |> Set.filter (hasLoop map guardState)
    |> Set.count
