# PriceZ

The PriceZ .NET client wrapper.

[![Build status](https://ci.appveyor.com/api/projects/status/qkewynp2qh7t8xf2?svg=true)](https://ci.appveyor.com/project/guibranco/pricez)
[![PriceZ NuGet Version](https://img.shields.io/nuget/v/PriceZ.svg?style=flat)](https://www.nuget.org/packages/PriceZ/)
[![PriceZ NuGet Downloads](https://img.shields.io/nuget/dt/PriceZ.svg?style=flat)](https://www.nuget.org/packages/PriceZ/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/PriceZ/total.svg?style=flat)](https://github.com/guibranco/PriceZ)
![Last release](https://img.shields.io/github/release-date/guibranco/pricez.svg?style=flat)

[![PriceZ Logo](https://raw.githubusercontent.com/guibranco/PriceZ/master/logo.png)](https://ddd.pricez.com.br)

---

## Nuget package

NuGet package: [https://www.nuget.org/packages/PriceZ](https://www.nuget.org/packages/PriceZ)

```ps

Install-Package PriceZ

```

---

## Usage

### Finding cities by DDD

```cs

var priceZ = new PriceZClient();
var ddds = priceZ.GetDDDs();
foreach(var ddd in ddds){
  Console.WriteLine("DDD: {0}", ddd);
  var cities = priceZ.GetCities(ddd);
  foreach(var city in cities)
    Console.WriteLine("DDD: {0} | City: {1}", ddd, city);
}

```

### Finding cities by state

```cs

var priceZ = new PriceZClient();
var states = priceZ.GetStates();
foreach(var state in states){
  Console.WriteLine("State: {0}", state);
  var cities = priceZ.GetCities(state);
  foreach(var city in cities)
    Console.WriteLine("State: {0} | City: {1}", state, city);
}

```

### Finding zip code data

```cs

var priceZ = new PriceZClient();
var zipCode = priceZ.GetZipcode("01001000");
Console.WriteLine("DDD: {0}", zipCode.AreaCode);

```
