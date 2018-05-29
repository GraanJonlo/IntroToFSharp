module HelloWorld =
    let greet name =
        printfn "Hello %s from F#!" name

module Primitives =
    let anInt = 4
    let aString = "Some string"
    let mutable mutableInt = 4
    mutableInt <- 5

    let add x y = x + y
    let five = add 2 3
    let add2 x = add 2 x
    let partialAdd = add 2

module TypesAndFunctions =
    let aTuple = (1,2)
    let anotherTuple = 5,"string",true

    let add x =
        (fst x) + (snd x)
    let addTuple (x,y) =
        x + y
    let five = addTuple (2,3)

    type ARecord = { firstName: string; lastName: string }
    let aRecord = { firstName = "Andy"; lastName = "Grant" }
    let greet person =
        printfn "Hello %s %s" person.firstName person.lastName

    let (<+>) x y = x + y
    let fiveAgain = 2 <+> 3

module Collections =
    let anArray = [| 1; 2; 3; 4; 5 |]
    let one = anArray.[0]
    anArray.[0] <- 6

    let aList = [ 1; 2; 3; 4; 5 ]
    let aList2 = 0 :: aList

    let fruit = Map.ofList [ 1, "Apple"; 2, "Pear" ]
    let fruitier = Map.add 3 "Banana" fruit
    
    let oneAgain = List.head aList
    let plusOne x = List.map (fun x -> x + 1) x
    let evens x = List.filter (fun x -> x % 2 = 0) x
    let sum x = List.reduce (fun acc item -> acc + item) x

    let addOneGetEvensAndSum x =
        sum (evens (plusOne x))

    let (|>) x f = f x

    let better x =
        x |> plusOne |> evens |> sum
    
    let (>>) fn1 fn2 x =
        fn1 x |> fn2
    
    let betterStill =
        plusOne >> evens >> sum

module DiscriminatedUnions =
    type TelephoneNumber =
        | Mobile of string
        | Landline of string
    
    type ContactInfo =
        | Telephone of TelephoneNumber
        | Email of string
    
    let contact x =
        match x with
        | Mobile no -> printfn "Texting %s" no
        | Landline no -> printfn "Calling %s" no
    
    type Option<'T> =
        | None
        | Some of 'T
    
    type Result<'T,'TError> =
        | Success of 'T
        | Error of 'TError


[<EntryPoint>]
let main argv =
    HelloWorld.greet "World"
    0