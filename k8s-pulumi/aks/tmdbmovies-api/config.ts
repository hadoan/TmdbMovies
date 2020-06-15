import * as pulumi from "@pulumi/pulumi";
import * as k8s from "@pulumi/kubernetes";
import { DeploymentConsts } from "../../common/consts";

export class ApiConfig {

    New() {
        const config = new pulumi.Config();
        const configMap = new k8s.core.v1.ConfigMap(DeploymentConsts.TMDB_API,
            {
                metadata: { name: DeploymentConsts.TMDB_API},
                data: {
                    "appsettings.Production.json": `
                    {
                      "App": {
                        "SelfUrl": "https://localhost:44334",
                        "CorsOrigins": "https://*.TmdbMovies.com,http://localhost:4200"
                      },
                      "ConnectionStrings": {
                        "Default": "Server=.\\sqlexpress;Database=TmdbMovies;Trusted_Connection=True;MultipleActiveResultSets=true"
                      },
                      "AuthServer": {
                        "Authority": "https://localhost:44334"
                      },
                      "Settings": {
                        "Abp.Mailing.Smtp.Host": "127.0.0.1",
                        "Abp.Mailing.Smtp.Port": "25",
                        "Abp.Mailing.Smtp.UserName": "",
                        "Abp.Mailing.Smtp.Password": "",
                        "Abp.Mailing.Smtp.Domain": "",
                        "Abp.Mailing.Smtp.EnableSsl": "false",
                        "Abp.Mailing.Smtp.UseDefaultCredentials": "true",
                        "Abp.Mailing.DefaultFromAddress": "noreply@abp.io",
                        "Abp.Mailing.DefaultFromDisplayName": "ABP application"
                      }
                    }
                    
                      
                `
                }
            });
        return configMap;
    }
}