module Gen

open System
open System.IO
open Page

let (|PageInfo|) (fileName: string) = 
    match fileName.Split('-') with
    | [|category; position; name|] -> (category, int(position), name.Split('.').[0]) |> Some
    | _ -> None

let getMetaData filePath = 
    let info = new FileInfo(filePath)
    let contents = File.ReadAllLines(filePath)
    match info.Name with
    | PageInfo(category, position, name) -> 
    {
        Category = category
        Order = position
        Creator = ""
        UpdatedAt = DateTime.UtcNow
        Snippets: Snippet list 
    }



let makePages (pagesDir: string) (outputDir: string) = 
    let inputFiles = 
        Directory.GetFiles(pagesDir, "*.fsx")
        
