﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [BlobsClientTestFixture]
    public abstract class BlobBaseClientTransferValidationTests<TBlobClient> : TransferValidationTestBase<
        BlobServiceClient,
        BlobContainerClient,
        TBlobClient,
        BlobClientOptions,
        BlobTestEnvironment>
        where TBlobClient : BlobBaseClient
    {
        private const string _blobResourcePrefix = "test-blob-";

        public BlobBaseClientTransferValidationTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion,
            RecordedTestMode? mode = null)
            : base(async, _blobResourcePrefix, mode)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(
            BlobServiceClient service = null,
            string containerName = null,
            UploadTransferValidationOptions uploadTransferValidationOptions = default,
            DownloadTransferValidationOptions downloadTransferValidationOptions = default)
        {
            var disposingContainer = await ClientBuilder.GetTestContainerAsync(service: service, containerName: containerName);

            disposingContainer.Container.ClientConfiguration.UploadTransferValidationOptions = uploadTransferValidationOptions;
            disposingContainer.Container.ClientConfiguration.DownloadTransferValidationOptions = downloadTransferValidationOptions;

            return disposingContainer;
        }

        protected override async Task<Response> DownloadPartitionAsync(
            TBlobClient client,
            Stream destination,
            DownloadTransferValidationOptions hashingOptions,
            HttpRange range = default)
        {
            var response = await client.DownloadStreamingAsync(new BlobDownloadOptions
            {
                TransferValidationOptions = hashingOptions,
                Range = range
            });

            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelDownloadAsync(
            TBlobClient client,
            Stream destination,
            DownloadTransferValidationOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await client.DownloadToAsync(destination, new BlobDownloadToOptions
            {
                TransferValidationOptions = hashingOptions,
                TransferOptions = transferOptions,
            });

        protected override async Task<Stream> OpenReadAsync(
            TBlobClient client,
            DownloadTransferValidationOptions hashingOptions,
            int internalBufferSize)
            => await client.OpenReadAsync(new BlobOpenReadOptions(false)
            {
                BufferSize = internalBufferSize,
                TransferValidationOptions = hashingOptions
            });

        [Test]
        public override void TestAutoResolve()
        {
            Assert.AreEqual(
                ValidationAlgorithm.StorageCrc64,
                TransferValidationOptionsExtensions.ResolveAuto(ValidationAlgorithm.Auto));
        }

        #region Added Tests
        [TestCaseSource("GetValidationAlgorithms")]
        public async Task ExpectedDownloadStreamingStreamTypeReturned(ValidationAlgorithm algorithm)
        {
            await using var test = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewResourceName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransferValidationOptions hashingOptions = algorithm == ValidationAlgorithm.None
                ? default
                : new DownloadTransferValidationOptions { Algorithm = algorithm };

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                TransferValidationOptions = hashingOptions,
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            // validated stream is buffered
            Assert.AreEqual(typeof(MemoryStream), response.Value.Content.GetType());
        }

        [Test]
        public async Task ExpectedDownloadStreamingStreamTypeReturned_None()
        {
            await using var test = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewResourceName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            // unvalidated stream type is private; just check we didn't get back a buffered stream
            Assert.AreNotEqual(typeof(MemoryStream), response.Value.Content.GetType());
        }
        #endregion
    }
}
