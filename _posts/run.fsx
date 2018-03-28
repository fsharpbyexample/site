
open System.IO
open System.Linq

let files = Directory.GetFiles("./", "2018*")

for file in files do
    let contents = File.ReadAllLines(file)
    let category = contents.Single(fun l -> l.StartsWith("category:")).Replace("category:", "").Trim()
    printfn "%s" category
    let newName = file.Replace("2018-03-29", category).Replace("2018-03-28", category)
    Directory.Move(file, newName)
    ()