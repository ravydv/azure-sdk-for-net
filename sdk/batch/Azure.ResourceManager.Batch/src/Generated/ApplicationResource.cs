// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A Class representing an Application along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApplicationResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApplicationResource method.
    /// Otherwise you can get one from its parent resource <see cref="BatchAccountResource" /> using the GetApplication method.
    /// </summary>
    public partial class ApplicationResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ApplicationResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _applicationClientDiagnostics;
        private readonly ApplicationRestOperations _applicationRestClient;
        private readonly ApplicationData _data;

        /// <summary> Initializes a new instance of the <see cref="ApplicationResource"/> class for mocking. </summary>
        protected ApplicationResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ApplicationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ApplicationResource(ArmClient client, ApplicationData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ApplicationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ApplicationResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _applicationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Batch", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string applicationApiVersion);
            _applicationRestClient = new ApplicationRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, applicationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Batch/batchAccounts/applications";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ApplicationData Data
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

        /// <summary> Gets a collection of ApplicationPackageResources in the Application. </summary>
        /// <returns> An object representing collection of ApplicationPackageResources and their operations over a ApplicationPackageResource. </returns>
        public virtual ApplicationPackageCollection GetApplicationPackages()
        {
            return GetCachedClient(Client => new ApplicationPackageCollection(Client, Id));
        }

        /// <summary>
        /// Gets information about the specified application package.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}/versions/{versionName}
        /// Operation Id: ApplicationPackage_Get
        /// </summary>
        /// <param name="versionName"> The version of the application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="versionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="versionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ApplicationPackageResource>> GetApplicationPackageAsync(string versionName, CancellationToken cancellationToken = default)
        {
            return await GetApplicationPackages().GetAsync(versionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified application package.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}/versions/{versionName}
        /// Operation Id: ApplicationPackage_Get
        /// </summary>
        /// <param name="versionName"> The version of the application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="versionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="versionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ApplicationPackageResource> GetApplicationPackage(string versionName, CancellationToken cancellationToken = default)
        {
            return GetApplicationPackages().Get(versionName, cancellationToken);
        }

        /// <summary>
        /// Gets information about the specified application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}
        /// Operation Id: Application_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ApplicationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationResource.Get");
            scope.Start();
            try
            {
                var response = await _applicationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about the specified application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}
        /// Operation Id: Application_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ApplicationResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationResource.Get");
            scope.Start();
            try
            {
                var response = _applicationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}
        /// Operation Id: Application_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationResource.Delete");
            scope.Start();
            try
            {
                var response = await _applicationRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new BatchArmOperation(response);
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
        /// Deletes an application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}
        /// Operation Id: Application_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationResource.Delete");
            scope.Start();
            try
            {
                var response = _applicationRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new BatchArmOperation(response);
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
        /// Updates settings for the specified application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}
        /// Operation Id: Application_Update
        /// </summary>
        /// <param name="data"> The parameters for the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<ApplicationResource>> UpdateAsync(ApplicationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationResource.Update");
            scope.Start();
            try
            {
                var response = await _applicationRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates settings for the specified application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}
        /// Operation Id: Application_Update
        /// </summary>
        /// <param name="data"> The parameters for the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<ApplicationResource> Update(ApplicationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _applicationClientDiagnostics.CreateScope("ApplicationResource.Update");
            scope.Start();
            try
            {
                var response = _applicationRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                return Response.FromValue(new ApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
