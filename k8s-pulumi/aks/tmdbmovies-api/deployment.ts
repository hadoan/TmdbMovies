import * as k8s from "@pulumi/kubernetes";
import { DeploymentConsts } from "../../common/consts";
import * as pulumi from "@pulumi/pulumi";

export class ApiDeployment {
    config = new pulumi.Config();
    configMap = DeploymentConsts.TMDB_API;
    New() {

        return new k8s.apps.v1.Deployment(DeploymentConsts.TMDB_API + "-deployment", {
            metadata: { name: DeploymentConsts.TMDB_API },
            spec: {
                selector: { matchLabels: { app: DeploymentConsts.TMDB_API } },
                replicas: 1,
                template: {
                    metadata: { labels: { app: DeploymentConsts.TMDB_API } },
                    spec: {
                        containers: [
                            {
                                name: DeploymentConsts.TMDB_API,
                                image: `${DeploymentConsts.DOCKER_HUB_BASE_URL}${DeploymentConsts.TMDB_API}:latest`,
                                args: [
                                    "dotnet",
                                    "TmdbMovies.HttpApi.Host.dll"
                                ],
                                volumeMounts: [
                                    {
                                        name: this.configMap + "-volume",
                                        mountPath: "/etc/config"
                                    }
                                ],
                                imagePullPolicy: "Always"
                            }
                        ],
                        volumes: [
                            {
                                name: this.configMap + "-volume",
                                configMap: { name: this.configMap }
                            }
                        ]
                    }
                }
            }
        });
    }
}



