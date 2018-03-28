---
layout: page
title: "If statements"
category: syntax
date: 2018-03-28 11:57:49
---

#### If / then / else
An if statement uses the keywords `if`, `then` and `else`.
```
let isEven i = if i % 2 = 0 then true else false
```
All branches must return values of the same type.


#### If / do
An if statement that doesn't return a value uses the `do` keyword:
```
let printIfEven i = if i % 2 = 0 then do
    printfn "Is even"
```

