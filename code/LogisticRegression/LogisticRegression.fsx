#load "../LinearRegression/Setup.fsx"

open System.Drawing
open FSharp.Data
open FSharp.Charting

[<Literal>]
let DataPath = __SOURCE_DIRECTORY__ + "/../datasets/ex2data1.txt"

type DataSet = CsvProvider<DataPath>
let data = DataSet.Load(DataPath)

[<Literal>]
let XTitle = "Exam 1 Score"
[<Literal>]
let YTitle = "Exam 2 Score"

let separate f v = 
    let filter = Seq.filter f (seq { for r in data.Rows -> (r.Admitted, v(r)) })
    Array.ofSeq(Seq.map (fun t -> snd t) filter)

let fa x = fst x
let ex1a = separate fa (fun r -> float r.Exam1)
let ex2a = separate fa (fun r -> float r.Exam2)

let fna x = not(fst x)
let ex1na = separate fna (fun r -> float r.Exam1)
let ex2na = separate fna (fun r -> float r.Exam2)

let ex1 = Array.ofSeq(seq { for r in data.Rows -> float r.Exam1 })
let ex2 = Array.ofSeq(seq { for r in data.Rows -> float r.Exam2 })

Chart.Combine([
                Chart.Point(Array.zip ex1a ex2a).WithStyling(Name="Admitted",Color=Color.DarkGreen)
                Chart.Point(Array.zip ex1na ex2na).WithStyling(Name="Not admitted",Color=Color.Red)
            ])
            .WithXAxis(Title=XTitle,Min=Array.min ex1-1.0,Max=Array.max ex1+1.0)
            .WithYAxis(Title=YTitle,Min=Array.min ex2-1.0,Max=Array.max ex2+1.0)

open Accord.Statistics.Analysis

let xs = Array.map (fun t -> [| fst t; snd t |]) (Array.zip ex1 ex2)
let adm = Array.ofSeq(seq { for r in data.Rows -> if r.Admitted then 1.0 else 0.0 })
let lra = LogisticRegressionAnalysis(xs, adm)
lra.Compute() |> ignore
let coeff = lra.CoefficientValues

let bx = [| Array.min ex1-2.0; Array.max ex1+2.0 |]

Chart.Combine([
                Chart.Point(Array.zip ex1a ex2a).WithStyling(Name="Admitted",Color=Color.DarkGreen)
                Chart.Point(Array.zip ex1na ex2na).WithStyling(Name="Not admitted",Color=Color.Red)
                Chart.Line([ for x in bx -> (x, (-1.0/coeff.[2]) * (coeff.[1]*x + coeff.[0]))])
                    .WithStyling(Name="Decision boundary",Color=Color.Navy)
            ])
            .WithXAxis(Title=XTitle,Min=Array.min ex1-1.0,Max=Array.max ex1+1.0)
            .WithYAxis(Title=YTitle,Min=Array.min ex2-1.0,Max=Array.max ex2+1.0)

lra.Regression.Compute([| 70.0; 70.0 |])


