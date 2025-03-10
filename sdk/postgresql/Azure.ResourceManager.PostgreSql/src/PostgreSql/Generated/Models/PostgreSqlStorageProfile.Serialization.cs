// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.Models
{
    public partial class PostgreSqlStorageProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(BackupRetentionDays))
            {
                writer.WritePropertyName("backupRetentionDays");
                writer.WriteNumberValue(BackupRetentionDays.Value);
            }
            if (Optional.IsDefined(GeoRedundantBackup))
            {
                writer.WritePropertyName("geoRedundantBackup");
                writer.WriteStringValue(GeoRedundantBackup.Value.ToString());
            }
            if (Optional.IsDefined(StorageInMB))
            {
                writer.WritePropertyName("storageMB");
                writer.WriteNumberValue(StorageInMB.Value);
            }
            if (Optional.IsDefined(StorageAutogrow))
            {
                writer.WritePropertyName("storageAutogrow");
                writer.WriteStringValue(StorageAutogrow.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static PostgreSqlStorageProfile DeserializePostgreSqlStorageProfile(JsonElement element)
        {
            Optional<int> backupRetentionDays = default;
            Optional<PostgreSqlGeoRedundantBackup> geoRedundantBackup = default;
            Optional<int> storageMB = default;
            Optional<PostgreSqlStorageAutogrow> storageAutogrow = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("backupRetentionDays"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    backupRetentionDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("geoRedundantBackup"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    geoRedundantBackup = new PostgreSqlGeoRedundantBackup(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("storageMB"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    storageMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("storageAutogrow"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    storageAutogrow = new PostgreSqlStorageAutogrow(property.Value.GetString());
                    continue;
                }
            }
            return new PostgreSqlStorageProfile(Optional.ToNullable(backupRetentionDays), Optional.ToNullable(geoRedundantBackup), Optional.ToNullable(storageMB), Optional.ToNullable(storageAutogrow));
        }
    }
}
