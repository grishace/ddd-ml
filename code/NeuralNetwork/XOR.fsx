#load "../LinearRegression/Setup.fsx"

let x = [| [| 0.0; 0.0 |]; [| 0.0; 1.0 |]; [| 1.0; 0.0 |]; [| 1.0; 1.0 |] |]
let y = [| [| 0.0 |]; [| 1.0 |]; [| 1.0 |]; [| 0.0 |] |]

open System
open Accord.Neuro
open Accord.Neuro.Learning

let network = ActivationNetwork(SigmoidFunction(), 2, [| 2; 1 |])
let teacher = new ParallelResilientBackpropagationLearning(network)

let rec run (err:float) =
  if err < 1e-5 then () else run (teacher.RunEpoch(x, y))  

run Double.PositiveInfinity

network.Compute([| 0.0; 0.0 |])
network.Compute([| 0.0; 1.0 |])
network.Compute([| 1.0; 0.0 |])
network.Compute([| 1.0; 1.0 |])
