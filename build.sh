#!/usr/bin/env bash

#

dotnet restore src/Core_SK/ && \
    dotnet build src/Core_SK/ && \
    echo "Now, run the following to start the project: dotnet run -p src/Core_SK/Core_SK.csproj --launch-profile web"
