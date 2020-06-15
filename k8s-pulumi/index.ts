import * as pulumi from "@pulumi/pulumi";
import * as azure from "@pulumi/azure";
import { DeploymentConsts } from './common/consts';
import * as sql from './databases/sql-deployments';
import * as aks from './aks/aks-deployment';
import * as api from './aks/tmdbmovies-api';
import * as web from './aks/tmdbmovies-frontend';
import * as ingress from './aks/nginx-ingress';

//Deploy k8s
new api.ApiConfig().New();
new api.ApiDeployment().New();
new api.ApiService().New();

new web.WebDeployment().New();
new web.WebService().New();


//ingress
new ingress.NginxIngressDeployment().NewNginxIngress();
new ingress.IngressService().New();


// Export the connection string for the storage account 
export const name = 'k8s-pulumi';
