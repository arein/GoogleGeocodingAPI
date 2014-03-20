Google Geocoding Client for Windows Store Apps
===============

The code is an approved port of https://code.google.com/p/geocodingapi/. Thanks to Jon Sagara for coding the initial version which targets .NET 3.5 and version 2 of Google's Geocoding API.

About
===============
This is a wrapper for Google's Geocoding API V3.

Installation
===============

### [Nuget](https://www.nuget.org/packages/CeserosGoogleGeocodingClient/1.0.0)
Install-Package CeserosGoogleGeocodingClient

### From Source
Just clone the repo and add the project to your solution.

Usage
===============

``` c#
string address = "350 5th Ave, New York, NY 10118, United States";
List<GeographicCoordinate> coords = await GoogleGeocodingClient.GoogleGeocodingClient.Geocode(address, false);
```

Contributing
===============
You're invited to contribute to the repo. There are a few tasks that could be done:
* Add support for Windows Phone
* Add support for Reverse Geocoding

Apps Using this Library
===============
* [Mils] (https://milsapp.com): A client to [send PDFs as real letters](https://milsapp.com)