---
layout: page
title: "Dependency inversion"
category: patterns
date: 2018-03-29 01:36:48
---

Depencency inversion can be accomplished by providing your service instances as parameters passed to your domain functions. The service instances can be provided as single functions or implementations of interfaces.
This is analagous to constructor injection in Object Orientated programming.

#### Service as a function
{% capture comments1 %}
We define a `Logger` type alias to act as our interface.
{% endcapture %}
{% capture code1 %}
{% highlight fsharp %}
type Logger = string -> unit
{% endhighlight %}
{% endcapture %}
{% include code.html comments=comments1 code=code1 %}

{% capture comments2 %}
We can then inject an instance of our `Logger` type into domain code. In this example, we are calculating the end of quarter bank balance for a company.
{% endcapture %}
{% capture code2 %}
{% highlight fsharp %}
let calculateBalance (logger: Logger) revenue costs taxRate = 
    let profit = revenue - costs
    logger ("Total profit: " + profit.ToString())
    
    let taxAmount = profit * taxRate
    logger ("Total tax: " + profit.ToString())

    let balance = profit - taxAmount
    logger ("Remaining balance: " + balance.ToString())
    
    balance
{% endhighlight %}
{% endcapture %}
{% include code.html comments=comments2 code=code2 %}


```fsharp
// We can then inject an instance of our `Logger` type into domain code. In this example, we are calculating the end of quarter bank balance for a company.
let calculateBalance (logger: Logger) revenue costs taxRate = 
    let profit = revenue - costs
    logger ("Total profit: " + profit.ToString())
    
    let taxAmount = profit * taxRate
    logger ("Total tax: " + profit.ToString())

    let balance = profit - taxAmount
    logger ("Remaining balance: " + balance.ToString())
    
    balance
```

``` fsharp
// You can then use [Partial Application](/syntax/partial-application) to bind a service instance to the function.
// For testing
let nullLogger str = ()
// For productions
let consoleLogger str = System.Console.WriteLine(str)

let calcBalanceTesting = calculateBalance nullLogger
let calcBalanceProduction = calculateBalance consoleLogger

let balance = calcBalanceTesting 100m 70m 0.2m
```

#### Service as an interface
Instead of using a type alias you can use a regular interface to define your service APIs.
```
type ILogger =
    abstract member this.Info(msg: string): unit
```
And then you can use it in the function as so.
```

```