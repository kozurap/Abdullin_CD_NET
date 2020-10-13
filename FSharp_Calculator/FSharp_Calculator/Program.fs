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
let add x y = x+y
let subtract x y =x-y
let multiply x y = x*y
let divide x y =
    match y with
    |0.0 -> None
    |_ -> Some(x/y)
    
let calculate op x y=
            match op with
            | "+" -> Some(add x y)               
            | "-" -> Some(subtract x y)    
            | "/" -> divide x y
            | "*" -> Some(multiply x y)    
            | _ -> None
            
[<EntryPoint>]
let main args=
    let x = Console.ReadLine()|> tryParseWith Double.TryParse
    let op = Console.ReadLine()
    let y = Console.ReadLine()|>tryParseWith Double.TryParse
    let result = maybe{
        let! a = x
        let! b = y
        let! calc = calculate op a b
        return calc
    }
    match result with
    |None-> printf"Error"
    |Some a -> printf "%f" a
    0
