// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppContainers
{
    /// <summary>
    /// A Class representing a ManagedEnvironment along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ManagedEnvironmentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetManagedEnvironmentResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetManagedEnvironment method.
    /// </summary>
    public partial class ManagedEnvironmentResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ManagedEnvironmentResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string environmentName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _managedEnvironmentClientDiagnostics;
        private readonly ManagedEnvironmentsRestOperations _managedEnvironmentRestClient;
        private readonly ClientDiagnostics _namespacesClientDiagnostics;
        private readonly NamespacesRestOperations _namespacesRestClient;
        private readonly ManagedEnvironmentData _data;

        /// <summary> Initializes a new instance of the <see cref="ManagedEnvironmentResource"/> class for mocking. </summary>
        protected ManagedEnvironmentResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ManagedEnvironmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ManagedEnvironmentResource(ArmClient client, ManagedEnvironmentData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedEnvironmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagedEnvironmentResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedEnvironmentClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppContainers", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string managedEnvironmentApiVersion);
            _managedEnvironmentRestClient = new ManagedEnvironmentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, managedEnvironmentApiVersion);
            _namespacesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppContainers", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _namespacesRestClient = new NamespacesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.App/managedEnvironments";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ManagedEnvironmentData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of DaprComponentResources in the ManagedEnvironment. </summary>
        /// <returns> An object representing collection of DaprComponentResources and their operations over a DaprComponentResource. </returns>
        public virtual DaprComponentCollection GetDaprComponents()
        {
            return GetCachedClient(Client => new DaprComponentCollection(Client, Id));
        }

        /// <summary>
        /// Get a dapr component.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/daprComponents/{componentName}
        /// Operation Id: DaprComponents_Get
        /// </summary>
        /// <param name="componentName"> Name of the Dapr Component. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="componentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="componentName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DaprComponentResource>> GetDaprComponentAsync(string componentName, CancellationToken cancellationToken = default)
        {
            return await GetDaprComponents().GetAsync(componentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a dapr component.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/daprComponents/{componentName}
        /// Operation Id: DaprComponents_Get
        /// </summary>
        /// <param name="componentName"> Name of the Dapr Component. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="componentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="componentName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DaprComponentResource> GetDaprComponent(string componentName, CancellationToken cancellationToken = default)
        {
            return GetDaprComponents().Get(componentName, cancellationToken);
        }

        /// <summary> Gets a collection of ContainerAppCertificateResources in the ManagedEnvironment. </summary>
        /// <returns> An object representing collection of ContainerAppCertificateResources and their operations over a ContainerAppCertificateResource. </returns>
        public virtual ContainerAppCertificateCollection GetContainerAppCertificates()
        {
            return GetCachedClient(Client => new ContainerAppCertificateCollection(Client, Id));
        }

        /// <summary>
        /// Get the specified Certificate.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/certificates/{certificateName}
        /// Operation Id: Certificates_Get
        /// </summary>
        /// <param name="certificateName"> Name of the Certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerAppCertificateResource>> GetContainerAppCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            return await GetContainerAppCertificates().GetAsync(certificateName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the specified Certificate.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/certificates/{certificateName}
        /// Operation Id: Certificates_Get
        /// </summary>
        /// <param name="certificateName"> Name of the Certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ContainerAppCertificateResource> GetContainerAppCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            return GetContainerAppCertificates().Get(certificateName, cancellationToken);
        }

        /// <summary> Gets a collection of ManagedEnvironmentStorageResources in the ManagedEnvironment. </summary>
        /// <returns> An object representing collection of ManagedEnvironmentStorageResources and their operations over a ManagedEnvironmentStorageResource. </returns>
        public virtual ManagedEnvironmentStorageCollection GetManagedEnvironmentStorages()
        {
            return GetCachedClient(Client => new ManagedEnvironmentStorageCollection(Client, Id));
        }

        /// <summary>
        /// Get storage for a managedEnvironment.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/storages/{storageName}
        /// Operation Id: ManagedEnvironmentsStorages_Get
        /// </summary>
        /// <param name="storageName"> Name of the storage. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storageName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ManagedEnvironmentStorageResource>> GetManagedEnvironmentStorageAsync(string storageName, CancellationToken cancellationToken = default)
        {
            return await GetManagedEnvironmentStorages().GetAsync(storageName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get storage for a managedEnvironment.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/storages/{storageName}
        /// Operation Id: ManagedEnvironmentsStorages_Get
        /// </summary>
        /// <param name="storageName"> Name of the storage. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="storageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="storageName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ManagedEnvironmentStorageResource> GetManagedEnvironmentStorage(string storageName, CancellationToken cancellationToken = default)
        {
            return GetManagedEnvironmentStorages().Get(storageName, cancellationToken);
        }

        /// <summary>
        /// Get the properties of a Managed Environment used to host container apps.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManagedEnvironmentResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.Get");
            scope.Start();
            try
            {
                var response = await _managedEnvironmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedEnvironmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the properties of a Managed Environment used to host container apps.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedEnvironmentResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.Get");
            scope.Start();
            try
            {
                var response = _managedEnvironmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedEnvironmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a Managed Environment if it does not have any container apps.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.Delete");
            scope.Start();
            try
            {
                var response = await _managedEnvironmentRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new AppContainersArmOperation(_managedEnvironmentClientDiagnostics, Pipeline, _managedEnvironmentRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a Managed Environment if it does not have any container apps.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.Delete");
            scope.Start();
            try
            {
                var response = _managedEnvironmentRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new AppContainersArmOperation(_managedEnvironmentClientDiagnostics, Pipeline, _managedEnvironmentRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Patches a Managed Environment using JSON Merge Patch
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Update
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Configuration details of the Environment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation> UpdateAsync(WaitUntil waitUntil, ManagedEnvironmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.Update");
            scope.Start();
            try
            {
                var response = await _managedEnvironmentRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new AppContainersArmOperation(_managedEnvironmentClientDiagnostics, Pipeline, _managedEnvironmentRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Patches a Managed Environment using JSON Merge Patch
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Update
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Configuration details of the Environment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation Update(WaitUntil waitUntil, ManagedEnvironmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.Update");
            scope.Start();
            try
            {
                var response = _managedEnvironmentRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new AppContainersArmOperation(_managedEnvironmentClientDiagnostics, Pipeline, _managedEnvironmentRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks if resource name is available.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/checkNameAvailability
        /// Operation Id: Namespaces_CheckNameAvailability
        /// </summary>
        /// <param name="content"> The check name availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<CheckNameAvailabilityResponse>> CheckContainerAppNameAvailabilityAsync(CheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _namespacesClientDiagnostics.CreateScope("ManagedEnvironmentResource.CheckContainerAppNameAvailability");
            scope.Start();
            try
            {
                var response = await _namespacesRestClient.CheckNameAvailabilityAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks if resource name is available.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/checkNameAvailability
        /// Operation Id: Namespaces_CheckNameAvailability
        /// </summary>
        /// <param name="content"> The check name availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<CheckNameAvailabilityResponse> CheckContainerAppNameAvailability(CheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _namespacesClientDiagnostics.CreateScope("ManagedEnvironmentResource.CheckContainerAppNameAvailability");
            scope.Start();
            try
            {
                var response = _namespacesRestClient.CheckNameAvailability(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<ManagedEnvironmentResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _managedEnvironmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagedEnvironmentResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<ManagedEnvironmentResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _managedEnvironmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new ManagedEnvironmentResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<ManagedEnvironmentResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.SetTags");
            scope.Start();
            try
            {
                await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _managedEnvironmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagedEnvironmentResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<ManagedEnvironmentResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.SetTags");
            scope.Start();
            try
            {
                GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                var originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _managedEnvironmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new ManagedEnvironmentResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<ManagedEnvironmentResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _managedEnvironmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagedEnvironmentResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}
        /// Operation Id: ManagedEnvironments_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<ManagedEnvironmentResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _managedEnvironmentClientDiagnostics.CreateScope("ManagedEnvironmentResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _managedEnvironmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new ManagedEnvironmentResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
