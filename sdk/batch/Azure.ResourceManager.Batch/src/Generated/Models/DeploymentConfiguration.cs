// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> Deployment configuration properties. </summary>
    public partial class DeploymentConfiguration
    {
        /// <summary> Initializes a new instance of DeploymentConfiguration. </summary>
        public DeploymentConfiguration()
        {
        }

        /// <summary> Initializes a new instance of DeploymentConfiguration. </summary>
        /// <param name="cloudServiceConfiguration"> This property and virtualMachineConfiguration are mutually exclusive and one of the properties must be specified. This property cannot be specified if the Batch account was created with its poolAllocationMode property set to &apos;UserSubscription&apos;. </param>
        /// <param name="virtualMachineConfiguration"> This property and cloudServiceConfiguration are mutually exclusive and one of the properties must be specified. </param>
        internal DeploymentConfiguration(CloudServiceConfiguration cloudServiceConfiguration, VirtualMachineConfiguration virtualMachineConfiguration)
        {
            CloudServiceConfiguration = cloudServiceConfiguration;
            VirtualMachineConfiguration = virtualMachineConfiguration;
        }

        /// <summary> This property and virtualMachineConfiguration are mutually exclusive and one of the properties must be specified. This property cannot be specified if the Batch account was created with its poolAllocationMode property set to &apos;UserSubscription&apos;. </summary>
        public CloudServiceConfiguration CloudServiceConfiguration { get; set; }
        /// <summary> This property and cloudServiceConfiguration are mutually exclusive and one of the properties must be specified. </summary>
        public VirtualMachineConfiguration VirtualMachineConfiguration { get; set; }
    }
}
