import * as k8s from "@pulumi/kubernetes";
import { DeploymentConsts } from '../common/consts';
import * as pulumi from "@pulumi/pulumi";

export class BackendNginxIngressDeployment {
    config = new pulumi.Config();
    name = "nginx-ingress-api";
    NewNginxIngress() {

        // Deploy the NGINX ingress controller using the Helm chart.
        const nginx = new k8s.helm.v2.Chart(this.name,
            {
                chart: "nginx-ingress",
                version: "1.27.1",
                fetchOpts: { repo: "https://kubernetes-charts.storage.googleapis.com/" },
                values: {
                    controller: {
                        publishService: { enabled: true },
                        scope: { enabled: true }
                    },
                }

            }
        );
        return nginx;
    }
}

export class BackendIngressService {
    config = new pulumi.Config();
    name = 'ingress-service-api';
    New() {
        // Create the kuard Ingress
        const ingress = new k8s.networking.v1beta1.Ingress(this.name,
            {
                metadata: {
                    name: this.name,
                    annotations: {
                        "kubernetes.io/ingress.class": "nginx",
                        "nginx.ingress.kubernetes.io/ssl-redirect": "false",
                        "nginx.ingress.kubernetes.io/force-ssl-redirect": "false",
                        "nginx.ingress.kubernetes.io/rewrite-target": "/$2",
                        "nginx.ingress.kubernetes.io/cors-allow-methods": "PUT, GET, POST, OPTIONS"
                    },
                },
                spec: {
                    rules: [
                        {
                            http: {
                                paths: [
                                    {
                                        backend: {
                                            serviceName: DeploymentConsts.TMDB_API,
                                            servicePort: 80,
                                        }
                                    },

                                ],
                            },
                        }
                    ]
                }
            }
        );

        return ingress;
    }
}