# hm-department-service

Independent microservice repository for Hospital Management.

## Local run

`ash
dotnet restore
dotnet build
dotnet run --project src/DepartmentService.Api/DepartmentService.Api.csproj
`

## Docker

`ash
docker build -t hm-department-service:local .
docker run -p 8086:8080 hm-department-service:local
`

## GitHub setup later

`ash
git branch -M main
git remote add origin <your-github-repo-url>
git add .
git commit -m "Initial scaffold"
git push -u origin main
`
