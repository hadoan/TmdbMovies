import * as pulumi from "@pulumi/pulumi";
import * as azure from "@pulumi/azure";
import { DeploymentConsts } from './common/consts';
import * as sql from './databases/sql-deployments';
import * as aks from './aks/aks-deployment';

const resourceGroupName = "resource-group-" + DeploymentConsts.APP_NAME;
const resourceGroup = new azure.core.ResourceGroup(resourceGroupName, {
    name: resourceGroupName,
    location: "SoutheastAsia"
});

// Deploy database
const sqlServer = sql.newSqlServer(resourceGroup);
const identityDb = sql.newDb(resourceGroup, sqlServer);


//Deploy AKS
const aksCluster = aks.newAks(resourceGroup);


// Export the connection string for the storage account 
export const appResourceGroupName = resourceGroupName;
