# PriceZ

The [PriceZ](https://ddd.pricez.com.br) .NET client wrapper.

## CI/CD

[![Build status](https://ci.appveyor.com/api/projects/status/qkewynp2qh7t8xf2?svg=true)](https://ci.appveyor.com/project/guibranco/priceZ)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/priceZ)](https://github.com/guibranco/priceZ)
[![GitHub last release](https://img.shields.io/github/release-date/guibranco/priceZ.svg?style=flat)](https://github.com/guibranco/priceZ)
[![GitHub license](https://img.shields.io/github/license/guibranco/priceZ)](https://github.com/guibranco/priceZ)

## Code Quality

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/34f017f7b2714ae481f3d27b8c38e236)](https://www.codacy.com/manual/changeme/34f017f7b2714ae481f3d27b8c38e236)
[![Codacy Badge](https://api.codacy.com/project/badge/Coverage/34f017f7b2714ae481f3d27b8c38e236)](https://www.codacy.com/manual/changeme/34f017f7b2714ae481f3d27b8c38e236)
[![Codecov](https://codecov.io/gh/guibranco/PriceZ/branch/master/graph/badge.svg)](https://codecov.io/gh/guibranco/PriceZ)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=coverage)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)

[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=code_smells)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_PriceZ&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_PriceZ)

---

## Installation

[![PacakgeName NuGet Version](https://img.shields.io/nuget/v/PriceZ.svg?style=flat)](https://www.nuget.org/packages/PriceZ/)
[![PacakgeName NuGet Downloads](https://img.shields.io/nuget/dt/PriceZ.svg?style=flat)](https://www.nuget.org/packages/PriceZ/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/PriceZ/total.svg?style=flat)](https://github.com/guibranco/PriceZ)

Download the latest zip file from the [Release pages](https://github.com/guibranco/PriceZ/releases) or simple install from [NuGet](https://www.nuget.org/packages/PriceZ) package manager.

NuGet URL: [https://www.nuget.org/packages/PriceZ](https://www.nuget.org/packages/PriceZ)

NuGet installation via *Package Manager Console*:

```ps

Install-Package PriceZ

```

---

## Features

Implements all features of PriceZ API available at [PriceZ](https://ddd.pricez.com.br/)

- Get area codes
- Get states
- Get cities from a state or area code
- Get zipcode data

---

## Usage

### PriceZClient instance

```cs

var client = new HttpClient { BaseAddress = new Uri("https://ddd.pricez.com.br/") };
client.DefaultRequestHeaders.ExpectContinue = false;
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
var priceZClient = new PriceZClient(client);

```

### Get area code

```cs

var myCancellationToken = new CancellationTokenSource().Token;

//use the client created previous
var areaCodes = await priceZClient.GetAreaCodesAsync(myCancellationToken);
foreach(var areaCode in areaCodes){
    Console.WriteLine("Area code: {0}", areaCode);  
    var cities = await priceZClient.GetCitiesAssync(areaCode, myCancellationToken);
    foreach(var city in cities)
        Console.WriteLine("Area code: {0} | City: {1}", areaCode, city);
}

```

### Get states


```cs

var myCancellationToken = new CancellationTokenSource().Token;

//use the client created previous
var states = await priceZClient.GetStatesAsync(myCancellationToken);
foreach(var state in states){
    Console.WriteLine("State: {0}", state);  
    var cities = await priceZClient.GetCitiesAssync(state, myCancellationToken);
    foreach(var city in cities)
        Console.WriteLine("State: {0} | City: {1}", state, city);
}

```

### Get zip code data

```cs

var myCancellationToken = new CancellationTokenSource().Token;

//use the client created previous
var zipCode = await priceZClient.GetZipCodeAsync("01001000",myCancellationToken);
var neighborhood = zipCode.Neighborhood;
var ibgeCode = zipCode.CityInfo.IBGECode;
var cityName = zipCode.City;
//zipCode.CityInfo.Name should be null in the zip code search! User zipcode.City instead.

```
