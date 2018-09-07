# CIS CMSSample



## Content Management System (CMS)

Content is controlled in the CMS on our main website. 

Click the CMS button drop-down for BENEFITS


## SQL Create Script

### One time installation script.

Run the following SQL script in [CMSSample/Database](Database) to create the db and load the data.

* Create DB and Load Data.sql

* Set the path at the top of the file to an applicable location.

``` sql
CREATE DATABASE [CMSSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CISOregon', FILENAME = N'{local\file\path\here.mdf}' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'CISOregon_log', FILENAME = N'{local\file\path\here.mdf}' , SIZE = 5512KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
```

## Tested on Visual Studio 2017 15.8.1

## Requires .Net Core 2.1 
 
* [Download .Net Core](https://www.microsoft.com/net/download)

## Troubleshooting 
These items should happen automatically on build within Visual Studio

* If project won't build, run dotnet build from a cmd prompt
* If the UI is missing css or js files
    * Run npm install
    * Right-click on [gulpfile.js](src/Benefits.Web/gulpfile.js) 
    * Select Task Runner Explorer 
        * Double-click the default event to run it.





