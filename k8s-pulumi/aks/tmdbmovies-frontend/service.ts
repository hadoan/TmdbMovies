import * as pulumi from "@pulumi/pulumi";
import * as k8s from "@pulumi/kubernetes";
import { DeploymentConsts } from "../../common/consts";

export class WebService {

    New() {
        const config = new pulumi.Config();
        const service = new k8s.core.v1.Service(DeploymentConsts.TMDB_FRONT_END, {
            metadata: {
                name: DeploymentConsts.TMDB_FRONT_END
            },
            spec: {
                selector: { app: DeploymentConsts.TMDB_FRONT_END },
                ports: [
                    {
                        protocol: "TCP",
                        port: 80,
                        targetPort: 80
                    }
                ],
            }
        });

    }
}