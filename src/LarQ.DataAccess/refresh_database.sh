#!/bin/sh

dotnet-ef --startup-project "../LarQ.Presentation/LarQ.Presentation.csproj" database drop --force && 
dotnet-ef --startup-project "../LarQ.Presentation/LarQ.Presentation.csproj" migrations remove && 
dotnet-ef --startup-project "../LarQ.Presentation/LarQ.Presentation.csproj" migrations add "init" && 
dotnet-ef --startup-project "../LarQ.Presentation/LarQ.Presentation.csproj" database update 

