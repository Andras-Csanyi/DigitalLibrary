# Badges

[![codecov](https://codecov.io/gh/SayusiAndo/DigitalLibrary/branch/master/graph/badge.svg?token=XQIZ9D1T4W)](https://codecov.io/gh/SayusiAndo/DigitalLibrary)
[![Build Status](https://dev.azure.com/sayusiando/DigitalLibrary/_apis/build/status/DigitalLibrary.Github?branchName=refs%2Fpull%2F150%2Fmerge)](https://dev.azure.com/sayusiando/DigitalLibrary/_build/latest?definitionId=60&branchName=refs%2Fpull%2F150%2Fmerge)

# Digital Library Project 
This project is about how to manage huge amount of different documents while you can manage 
the content connections between them. The problem space this project tries to find a good
solution are the following:

 - ETL documents in from different sources in different format
 - managing content and relations between different documents and/or its sections
 - user interface for reading, where the document connections are displayed in the way it elevates
 the reading experience
 - support for writing a document where including other document references is easy
 - support for searching through the stored documents
 - support for different searching such as full text, thesaurus, etc.
 
 It will be a long journey and you can find the experience of developing this project in 
 my [blog](https://sayusiando.com), and further information about the product can be found [here](src/Doc/index.md).
 
 # Try it out
  ### There is no installer!
  
   - Install [.Net Core SDK](https://dotnet.microsoft.com/download) on your machine
   - clone the repository
   - `cd src/Host/WebApp`
   - `dotnet run` to have the REST Api running
   - open another command line and navigate to `src/Host/WebUI` and
   - `dotnet run`
   - open a browser and navigate to `http://localhost:5000`
   
  In case of you'd like to see the code I suggest to use [Rider](https://www.jetbrains.com/rider/), but
  VS Code or Visual Studio will be fine too.
