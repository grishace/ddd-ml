#load "../LinearRegression/Setup.fsx"

open System
open FSharp.Data
open FSharp.Data.CsvExtensions
open Accord.Neuro
open Accord.Neuro.Learning

let train = CsvFile.Load(__SOURCE_DIRECTORY__ + "/../datasets/train.csv").Cache()

let y = Array.ofSeq(seq { for r in train.Rows ->
                                        let d = r.[0].AsFloat()
                                        Array.ofSeq(seq { for i in 0 .. 9 -> if float i = d then 1.0 else 0.0 })})

let x = Array.ofSeq(seq { for r in train.Rows ->
                                        Array.ofSeq(seq { for i in 1 .. 784 -> r.[i].AsFloat() })})

let v = Array.ofSeq(seq { for r in train.Rows -> r.[0].AsInteger() })

open System.Drawing
open FSharp.Charting

let digit n = 
    let points = 
        [|
            for i in 0 .. 27 do
                    for j in 0 .. 27 do
                        let idx = i * 28 + j
                        if x.[n].[idx] <> 0.0 then yield (j, -i) 
        |]
    Chart.Point(points).WithMarkers(Size=15,Color=Color.Black)


let network = ActivationNetwork(IdentityFunction(), 784, [| 5; 7; 10 |])
let teacher = new ParallelResilientBackpropagationLearning(network)

let rec run (perr:float) (err:float) =
  let aerr = Math.Abs(perr-err)
  printfn "%f" aerr
  if aerr < 0.000001 * perr then () else run err (teacher.RunEpoch(x, y))  

run 0.0 Double.PositiveInfinity

let maxi(a) = 
  let m = Array.max a
  Array.findIndex (fun i -> i = m) a

let mutable c = 0
for i in 0..x.Length-1 do
    let n = maxi(network.Compute(x.[i]))
    if v.[i] = n then c <- c + 1 else ()
