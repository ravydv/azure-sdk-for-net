// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppContainers.Models
{
    public partial class OpenIdConnectClientCredential : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Method))
            {
                writer.WritePropertyName("method");
                writer.WriteStringValue(Method.Value.ToString());
            }
            if (Optional.IsDefined(ClientSecretSettingName))
            {
                writer.WritePropertyName("clientSecretSettingName");
                writer.WriteStringValue(ClientSecretSettingName);
            }
            writer.WriteEndObject();
        }

        internal static OpenIdConnectClientCredential DeserializeOpenIdConnectClientCredential(JsonElement element)
        {
            Optional<ClientCredentialMethod> method = default;
            Optional<string> clientSecretSettingName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("method"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    method = new ClientCredentialMethod(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("clientSecretSettingName"))
                {
                    clientSecretSettingName = property.Value.GetString();
                    continue;
                }
            }
            return new OpenIdConnectClientCredential(Optional.ToNullable(method), clientSecretSettingName.Value);
        }
    }
}
