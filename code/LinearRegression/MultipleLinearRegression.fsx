﻿#load "../LinearRegression/Setup.fsx"

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

let example = [| 2500.0; 3.0 |]
mlr.Compute(example)

open System.Data
open Accord.Statistics.Filters

let nt = new DataTable()
nt.Columns.Add("Size", typeof<float>)
nt.Columns.Add("Bedrooms", typeof<float>)
for x in xs do
    nt.Rows.Add(x.[0], x.[1]) |> ignore

let norm = Normalization(nt)

let nms = norm.["Size"].Mean
let nstdds = norm.["Size"].StandardDeviation
let nmb = norm.["Bedrooms"].Mean
let nstddb = norm.["Bedrooms"].StandardDeviation

let ns = norm.Apply(nt)

let nxs = Array.ofSeq(seq { for r in ns.Rows -> [| unbox<float> r.["Size"]; unbox<float> r.["Bedrooms"] |] })

let mlrn = MultipleLinearRegression(2, true)
let nsse = mlrn.Regress(nxs, y)
let nmse = nsse/float nxs.Length
let nrmse = sqrt nmse
let nr2 = mlr.CoefficientOfDetermination(nxs, y)

let nts = new DataTable()
nts.Columns.Add("Size", typeof<float>)
nts.Columns.Add("Bedrooms", typeof<float>)
nts.Rows.Add(example.[0], example.[1]) |> ignore
let norms = norm.Apply(nts)

mlrn.Compute([| unbox<float> norms.Rows.[0].["Size"]; unbox<float> norms.Rows.[0].["Bedrooms"] |])