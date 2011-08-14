open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core.Lazy

// Example of HashMultiMap
let hashSeq = 
    seq { for i in 1..100 do 
            yield ("key" + i.ToString()), ("value" + i.ToString())}
let hashMultiMap = HashMultiMap<string, string>(hashSeq, HashIdentity.Structural)
 
printfn "The value from the HashMultiMap for key:key5 is %s" (hashMultiMap.Item "key5")


// Example of LazyList
seq { for i in 1..10 do yield ("value" + i.ToString())}
|> LazyList.ofSeq
|> LazyList.iter(fun v -> printfn "The value from the LazyList is %s" v)
 
System.Console.Read()
