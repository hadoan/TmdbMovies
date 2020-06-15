# TmdbMovies


## Libraries and Framework used in this sample
- ABP is a complete architecture and strong infrastructure to create modern web applications http://abp.io/ 
- https://github.com/borisdj/EFCore.BulkExtensions for bulk insert from TheMoviesDb api

## Logic of the sample
- Get data from MoviesDb: `TheMovieDbApiIntegrationService`
- Background job to get data from Movies Db and store in Sql Server: `RetrievingTopRatedMovieBackgroundWorker`, run every 10 minutes
- Rest Api: `MovieAppService`
- Repository: `EfCoreMovieRepository.cs`

## Run Backend API from aspnet-core folder 
- Change connection string in TmdbMovies.DbMigrator and TmdbMovies.HttpApi.Host project
- Run TmdbMovies.DbMigrator.csproj project to generate database schema
- Run TmdbMovies.HttpApi.Host.csproj project to start backend api

## Run Angular app from angular folder
- `yarn start`

## Demo APP: deployed to Azure AKS
- API: http://52.163.221.126/swagger/index.html
- Web: http://52.187.150.193/, to to Movies Menu to see data

## Docker Image
- Backend: https://hub.docker.com/repository/docker/hadoanmanh/tmdbmovies-api
- Frontend: https://hub.docker.com/repository/docker/hadoanmanh/tmdbmovies-frontend

## Infrashstructure as code: 
- https://www.pulumi.com (typescript)
- Source: https://github.com/hadoan/TmdbMovies/tree/master/k8s-pulumi

