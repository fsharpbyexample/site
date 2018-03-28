---
layout: page
title: "Functions"
category: syntax
date: 2018-03-28 11:57:31
---

### Declaration & Calling
Functions are declared using the `let` keyword followed by the function name and arguements seperated by spaces.
```
let squareOf x = x * x
```

If no type annotations are provided, the compiler attempts to infer the types of the arguements and the function. You can manually add type annotations using the `:` symbol:
```
let squareOf (x: float) : float = x * x
```

Functions are called by stating the function name followed by the arguments.
```
let squareOfThree = squareOf 3
```

### Partial Application
A function can be [partially applied](https://en.wikipedia.org/Partial_Application) by calling it with only some of the required arguments. The result is a new function.
```
let areaOfCircle radius = radius * radius * 3.14f
```

### Infix functions
Declare an infix function by wrapping the function name in brakets:
```
let (??) value default = if value = null then default else value 
```

This function can then either by called in infix form:
```
let stringOrNull = ...
let valueOrDefault = nullValue ?? "Was null"
```

Or in regular prefix form:
```
let stringOrNull = ...
let valueOrdefault = (??) nullValue "Was null"
```

Ordinary F# operators can be used in infix form:
```
let multiplyByThreeInfix i = i * 3
let multiplyByThreePrefix = (*) 3
```

### Composition
Two functions can be composed using the `>>` operator to create a new function. The return type of the first function must match the argument type of the second function:
```
let calulateAreaOfCircle radius = 3.14f * radius * radius
let printAreaOfCircle area = printfn "The area of this circle is %f" area
let calculateAndPrint = calculateAreaOfCircle >> printAreaOfCircle
```

### Lambda Functions
Anonomous functions are declared using the `fun` key word followed by the arguments:
```
let numbers = [1; 2; 3; 4]
let evenNumbers = List.filter (fun i -> i % 2 = 0) numbers
```