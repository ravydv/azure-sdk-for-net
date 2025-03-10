// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> The properties used to create a new server by restoring from a backup. </summary>
    public partial class PostgreSqlServerPropertiesForRestore : PostgreSqlServerPropertiesForCreate
    {
        /// <summary> Initializes a new instance of PostgreSqlServerPropertiesForRestore. </summary>
        /// <param name="sourceServerId"> The source server id to restore from. </param>
        /// <param name="restorePointInOn"> Restore point creation time (ISO8601 format), specifying the time to restore from. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceServerId"/> is null. </exception>
        public PostgreSqlServerPropertiesForRestore(ResourceIdentifier sourceServerId, DateTimeOffset restorePointInOn)
        {
            if (sourceServerId == null)
            {
                throw new ArgumentNullException(nameof(sourceServerId));
            }

            SourceServerId = sourceServerId;
            RestorePointInOn = restorePointInOn;
            CreateMode = PostgreSqlCreateMode.PointInTimeRestore;
        }

        /// <summary> The source server id to restore from. </summary>
        public ResourceIdentifier SourceServerId { get; }
        /// <summary> Restore point creation time (ISO8601 format), specifying the time to restore from. </summary>
        public DateTimeOffset RestorePointInOn { get; }
    }
}
