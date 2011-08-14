open System
open System.IO
open System.Text

let text = [ new String([|for i in 1..1022 do yield 'x'|])
             new String([|for i in 1..1022 do yield 'y'|])
             new String([|for i in 1..1022 do yield 'z'|]) ].ToString()  

use stream = new MemoryStream()
stream.Write(Encoding.UTF8.GetBytes(text), 0, text.Length)
stream.Position <- 0L
let reader = new AsyncStreamReader(stream, Encoding.UTF8)          
async { let rec readAllChars () =
            async {
                let! eof = reader.EndOfStream
                if not eof then
                    let! character = reader.Read()
                    do printf "%s" (character.ToString())
                    return! readAllChars () 
                else 
                    printfn "%sRead complete" Environment.NewLine           
            }
        do! readAllChars ()
} 
|> Async.Start

printfn "Started reading the memory stream"

Console.Read()
    
                 