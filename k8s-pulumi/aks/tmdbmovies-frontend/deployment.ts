import * as k8s from "@pulumi/kubernetes";
import { DeploymentConsts } from "../../common/consts";
import * as pulumi from "@pulumi/pulumi";

export class WebDeployment {
    config = new pulumi.Config();
    configMap = DeploymentConsts.TMDB_FRONT_END;
    New() {

        return new k8s.apps.v1.Deployment(DeploymentConsts.TMDB_FRONT_END + "-deployment", {
            metadata: { name: DeploymentConsts.TMDB_FRONT_END },
            spec: {
                selector: { matchLabels: { app: DeploymentConsts.TMDB_FRONT_END } },
                replicas: 1,
                template: {
                    metadata: { labels: { app: DeploymentConsts.TMDB_FRONT_END } },
                    spec: {
                        containers: [
                            {
                                name: DeploymentConsts.TMDB_FRONT_END,
                                image: `${DeploymentConsts.DOCKER_HUB_BASE_URL}${DeploymentConsts.TMDB_FRONT_END}:latest`,
                                args: [
                                    "ng",
                                    "serve",
                                    "--host",
                                    "0.0.0.0"
                                ],
                                imagePullPolicy: "Always"
                            }
                        ]
                    }
                }
            }
        });
    }
}



