#load "../LinearRegression/Setup.fsx"

open FSharp.Data
open Accord.Statistics.Models.Regression.Linear

[<Literal>]
let DataPath = __SOURCE_DIRECTORY__ + "/../datasets/ex1data2.txt"

type DataSet2 = CsvProvider<DataPath>
let data = DataSet2.Load(DataPath)

let xs = Array.ofSeq(seq { for r in data.Rows -> [| float r.Size; float r.Bedrooms |] })
let y = Array.ofSeq(seq { for r in data.Rows -> float r.Price })

let mlr = MultipleLinearRegression(2, true)
let sse = mlr.Regress(xs, y)
let mse = sse/float xs.Length
let rmse = sqrt mse
let r2 = mlr.CoefficientOfDetermination(xs, y)

mlr.Compute([| 2500.0; 3.0 |])
