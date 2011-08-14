// From http://laurent.le-brun.eu/site/index.php/2010/06/08/55-fsharp-getopt-to-parse-the-command-line

open System
open Microsoft.FSharp.Text

let compile s = printfn "Compiling %s..." s
 
let outputName = ref "a.out"
let verbose = ref false
let warningLevel = ref 0
let specs =
    ["-o", ArgType.String (fun s -> outputName := s), "Name of the output"
     "-v", ArgType.Set verbose, "Display additional information"
     "--warn", ArgType.Int (fun i -> warningLevel := i), "Set warning level"
     "--", ArgType.Rest compile, "Stop parsing command line"
    ] |> List.map (fun (sh, ty, desc) -> ArgInfo(sh, ty, desc))

let () = 
    ArgParser.Parse(specs, compile)

