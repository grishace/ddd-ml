#load "../LinearRegression/Setup.fsx"

open FSharp.Data
open FSharp.Charting

[<Literal>]
let DataPath = @"C:\DenverDevDay\MachineLearning\datasets\ex1data1.txt"

type DataSet1 = CsvProvider<DataPath>
let data = DataSet1.Load(DataPath)

[<Literal>]
let XTitle = "Population of City in 10,000s"
[<Literal>]
let YTitle = "Profit in $10,000s"

Chart.Point(seq { for r in data.Rows -> (r.Population, r.Profit) })
    .WithXAxis(Title=XTitle)
    .WithYAxis(Title=YTitle)

open System.Drawing
open Accord.Statistics.Models.Regression.Linear

let x = Array.ofSeq(seq { for r in data.Rows -> float r.Population })
let y = Array.ofSeq(seq { for r in data.Rows -> float r.Profit })

let slr = SimpleLinearRegression()
let sse = slr.Regress(x, y)
let mse = sse/float x.Length
let rmse = sqrt mse
let r2 = slr.CoefficientOfDetermination(x, y)

Chart.Combine([
                Chart.Point(seq { for r in data.Rows -> (r.Population, r.Profit) })
                Chart.Line([for x in Array.min x - 1.0 .. Array.max x + 1.0 -> (x, slr.Compute(x)) ], Color=Color.Red)
              ])
              .WithXAxis(Title=XTitle)
              .WithYAxis(Title=YTitle)
        

