open System
open FSharp.Data

type AsyncMaybeBuilder() =
    member this.Bind(x, f) =
        async {
            let! x' = x

            match x' with
            | Some v -> return! f v
            | None -> return None
        }

    member this.Return x = async { return x }

let asyncMaybe = AsyncMaybeBuilder()
let CreateAnswerAsync(response) =
    async{
        return
            match response.StatusCode with
            | 404 -> None
            | 400 -> Some "Error. Probably you tried to divide by 0 or inputted invalid number or operator"
            | 500 -> Some "Server error"
            | 200 -> Some response.Headers.["Calc_res"]
            | _ -> None
    }
let write (s: string option) =
    match s with
    | Some x -> Console.WriteLine(x)
    | None ->
        Console.WriteLine
            "Computational error. Probably you tried to divide by 0 or inputted invalid number or operator"

[<EntryPoint>]
let main args =

    let a = Console.ReadLine()
    let op = Console.ReadLine()
    let b = Console.ReadLine()
    let formattedOp =
        match op with
        | "/" -> "%2F"
        | "+" -> "%2B"
        | _ -> op
    let url = String.Format("https://localhost:5001/?param1={0}&op={1}&param2={2}", a, formattedOp, b)
    let expression = Async.RunSynchronously (asyncMaybe{
        let address = url
        let! a = async{
            let! res = Http.AsyncRequestStream(url, silentHttpErrors=true)
            let res = Some res
            return res
        }
        let! b = CreateAnswerAsync a
        return Some b
    })
    write expression

    0