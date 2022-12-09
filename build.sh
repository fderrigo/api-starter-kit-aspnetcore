#!/usr/bin/env bash

#

dotnet restore src/CoreSK/ && \
    dotnet build src/CoreSK/ && \
    echo "Now, run the following to start the project: dotnet run -p src/CoreSK/CoreSK.csproj --launch-profile web"
