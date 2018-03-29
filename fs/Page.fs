module Page

open System
open Fue.Data
open Fue.Compiler

type Snippet = string * string

type ViewModel = {
    Category: string
    Order: int
    Creator: string
    UpdatedAt: DateTime
    Snippets: Snippet list }

let genSnippet ((comment, code): Snippet)  = 
    init
    |> add "comment" comment
    |> add "code" code
    |> fromFile "public/snippet.html"

let genPage (vm: ViewModel) = 
    init
    |> add "category" vm.Category
    |> add "order" vm.Order
    |> add "creator" vm.Creator
    |> add "updated_at" vm.UpdatedAt
    |> add "snippets" (Seq.map genSnippet vm.Snippets)
    |> fromFile "public/page.html"
