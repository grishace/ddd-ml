#load "../LinearRegression/Setup.fsx"

let x = [| [| 0.0; 0.0 |]; [| 0.0; 1.0 |]; [| 1.0; 0.0 |]; [| 1.0; 1.0 |] |]
let y = [| [| 0.0 |]; [| 1.0 |]; [| 1.0 |]; [| 0.0 |] |]

open System
open Accord.Neuro
open Accord.Neuro.Learning

let network = ActivationNetwork(SigmoidFunction(), 2, [| 2; 1 |])
let teacher = new ParallelResilientBackpropagationLearning(network)

let rec run (perr:float) (err:float) =
  let aerr = Math.Abs(perr-err)
  if aerr < 1e-5 * perr then () else run err (teacher.RunEpoch(x, y))  

run 0.0 Double.PositiveInfinity

network.Compute([| 0.0; 0.0 |])
network.Compute([| 0.0; 1.0 |])
network.Compute([| 1.0; 0.0 |])
network.Compute([| 1.0; 1.0 |])
