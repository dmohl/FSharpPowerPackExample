// This sample is a modified version of one of the unit tests found in ControlTests.fs 
// at http://fsharppowerpack.codeplex.com/SourceControl/changeset/view/64420#685261
open System.IO

async {
    async {
        let buffer = "F# is fun!"B
        use! is = File.AsyncOpenWrite "test.txt"
        do! is.AsyncWrite(buffer, 0, buffer.Length) 
        printfn "File written" } 
    |> Async.RunSynchronously

    async { 
        let buffer = Array.zeroCreate<byte>(7)
        use! is = File.AsyncOpenRead "test.txt"
        let! count = is.AsyncRead(buffer, 0, 7)
        printfn "File read"
        return count, buffer }
    |> Async.RunSynchronously |> ignore
} 
|> Async.Start

printfn "Starting to write then read a file asynchronously..."

System.Console.Read()