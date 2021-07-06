# Badges

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=bugs)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=code_smells)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=coverage)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=ncloc)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=alert_status)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=security_rating)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=sqale_index)](https://sonarcloud.io/dashboard?id=DigitalLibrary)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=DigitalLibrary&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=DigitalLibrary)

[![Build Status](https://dev.azure.com/sayusiando/DigitalLibrary/_apis/build/status/DiLib.GH?branchName=master)](https://dev.azure.com/sayusiando/DigitalLibrary/_build/latest?definitionId=64&branchName=master)

# Digital Library Project

This project is about how to manage huge amount of different documents while you can manage the
content connections between them. The problem space this project tries to find a good solution are
the following:

- ETL documents in from different sources in different format
- managing content and relations between different documents and/or its sections
- user interface for reading, where the document connections are displayed in the way it elevates
  the reading experience
- support for writing a document where including other document references is easy
- support for searching through the stored documents
- support for different searching such as full text, thesaurus, etc.

It will be a long journey and you can find the experience of developing this project in
my [blog](https://sayusiando.com), and further information about the product can be
found [here](src/Doc/index.md).

# Try it out

### There is no installer!

- Install [.Net Core SDK](https://dotnet.microsoft.com/download) on your machine
- clone the repository
- `cd src/Host/WebApp`
- `dotnet run` to have the REST Api running
- open another command line and navigate to `src/Host/WebUI` and
- `dotnet run`
- open a browser and navigate to `http://localhost:5000`

In case of you'd like to see the code I suggest to use [Rider](https://www.jetbrains.com/rider/),
but VS Code or Visual Studio will be fine too.
