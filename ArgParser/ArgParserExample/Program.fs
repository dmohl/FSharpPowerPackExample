// From http://laurent.le-brun.eu/site/index.php/2010/06/08/55-fsharp-getopt-to-parse-the-command-line

open System
open System.Collections.Generic
open Microsoft.FSharp.Text

let compile s = printfn "Compiling %s..." s

// create a reference cell (an encapsulated mutable value) to store the argument values 
let outputName = ref "a.out"
let verbose = ref false
let warningLevel = ref 0
let specs =
    ["-o", ArgType.String (fun s -> outputName := s), "Name of the output"
     "-v", ArgType.Set verbose, "Display additional information"
     "-warn", ArgType.Int (fun i -> warningLevel := i), "Set warning level"
     "--", ArgType.Rest compile, "Stop parsing command line" ] 
    |> List.map (fun (argument, argType, helpDescription) -> ArgInfo(argument, argType, helpDescription))

ArgParser.Parse(specs, compile)

// Do your work and use the provided command-line arguments as needed

// "!" allows you to dereference the previously defined reference cell
if (!verbose) then printfn "Verbose mode is enabled"
printfn "Output is set to %s" !outputName
printfn "Warning Level is set to %i" !warningLevel

