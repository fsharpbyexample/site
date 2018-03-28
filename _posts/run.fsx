open System.IO
open System.Linq

        // file * newName * category
type File = string * string

let read path = 
    let contents = File.ReadAllLines(path)
    let category = contents.Single(fun l -> l.StartsWith("category:")).Replace("category:", "").Trim()
    (path, path.Replace("2018-03-29", category + "0-").Replace("2018-03-28", category), category) 

let files = Directory.GetFiles("./", "2018*") |> Seq.map read
    
for (path, newPath, category) in files do
    Directory.Move(path, newPath)
    ()