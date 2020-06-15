import * as pulumi from "@pulumi/pulumi";
import * as k8s from "@pulumi/kubernetes";
import { DeploymentConsts } from "../../common/consts";

export class ApiService {

    New() {
        const config = new pulumi.Config();
        const service = new k8s.core.v1.Service(DeploymentConsts.TMDB_API, {
            metadata: {
                name: DeploymentConsts.TMDB_API
            },
            spec: {
                selector: { app: DeploymentConsts.TMDB_API },
                ports: [
                    {
                        protocol: "TCP",
                        port: 80,
                        targetPort: 80
                    }
                ],
                type: 'LoadBalancer'
            }
        });

    }
}