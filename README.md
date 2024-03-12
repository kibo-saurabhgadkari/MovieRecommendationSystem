# MovieRecommendationSystem

# Code Coverage
coverlet "C:\Learning\repos\MovieRecommendationSystem\MovieRecommendation.Tests\bin\Debug\net6.0\MovieRecommendation.Tests.dll" --target "dotnet" --targetargs "test C:\Learning\repos\MovieRecommendationSystem\MovieRecommendation.Tests\MovieRecommendation.Tests.csproj --no-build" --format lcov --output "C:\Learning\repos\MovieRecommendationSystem\MovieRecommendation.Tests\coverage/"
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./coverage/