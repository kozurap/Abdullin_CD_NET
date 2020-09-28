open System
let tryParseWith(tryParseFunc:string-> bool * _) = tryParseFunc >> function
    | true, v -> Some v
    |false, _ -> None
type MaybeBuilder() =
    member this.Bind(x, f)=
        match x with
        |None->None
        |Some a ->f a
    member this.Return(x) =
        Some x
let maybe = new MaybeBuilder()
let add x y = maybe{
    let! a = x
    let! b = y
    return a+b
    }
let subtract x y =maybe{
    let! a = x
    let! b = y
    return a-b
}
let multiply x y =maybe{
    let! a = x
    let! b = y
    return a*b
}
let divide x y =
    maybe
        {
        let! a = x
        let! b = y
        let! b2 =
            match b with
            |0.0 -> None
            |c->Some c
        return a/b2
        }
    
let calculate op x y=
            match op with
            | "+" -> add x y              
            | "-" -> subtract x y
            | "/" -> divide x y
            | "*" -> multiply x y
            | _ -> None
            
[<EntryPoint>]
let main args=
    let x= Console.ReadLine()|> tryParseWith Double.TryParse
    let op = Console.ReadLine()
    let y = Console.ReadLine()|>tryParseWith Double.TryParse
    let result = calculate op x y
    match result with
    |None-> printf"Error"
    |Some a -> printf "%f" a
    0
