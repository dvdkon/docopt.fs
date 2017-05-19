#I "packages/FAKE/tools"
#r "FakeLib.dll"

open Fake
open System

let inline ( +/ ) lhs rhs = IO.Path.Combine(lhs, rhs)

let buildDir = __SOURCE_DIRECTORY__ +/ "Build"
let srcDir = __SOURCE_DIRECTORY__ +/ "src"
let docoptProject = srcDir +/ "Docopt" +/ "docopt.fsproj"

//--------------------------------------------------------------------------
// Rule definition

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "Build" (fun _ ->
    MSBuildRelease buildDir "Release" [docoptProject]
    |> ignore
)

//--------------------------------------------------------------------------
// Dependency tree

"Clean" ?=> "Build"

"Clean"
  ==> "Build"

RunTargetOrDefault "Build"
