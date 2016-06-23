#load "../LinearRegression/Setup.fsx"

open System.Drawing
open FSharp.Data
open FSharp.Charting

[<Literal>]
let DataPath = __SOURCE_DIRECTORY__ + "/../datasets/iris.data"

type DataSet = CsvProvider<DataPath>
let data = DataSet.Load(DataPath)

open Accord.Statistics.Analysis

let x = Array.ofSeq(seq { for r in data.Rows -> [| float r.``Sepal length``; float r.``Sepal width``; float r.``Petal length``; float r.``Petal width`` |] })
let pca = PrincipalComponentAnalysis(x, AnalysisMethod.Center)
pca.Compute()
printfn "%A" pca.ComponentProportions

let xs = Array.ofSeq(seq { for r in data.Rows -> float r.``Sepal length``, float r.``Petal length`` })

Chart.Point(xs)
  .WithStyling(Color=Color.Navy)

open Accord.MachineLearning

let km = new KMeans(3)
let clusters = km.Compute(Array.map (fun x -> [| fst x; snd x |]) xs)
let applied = Array.zip xs clusters

let separate(f, v) = Array.map (fun x -> v(fst x)) (Array.filter (fun a -> f(a)) applied)
let chart(c) = Chart.Point(Array.zip (separate((fun a -> snd a = c), fst)) (separate((fun a -> snd a = c), snd)))

Chart.Combine(seq { for c in clusters -> chart(c) })
