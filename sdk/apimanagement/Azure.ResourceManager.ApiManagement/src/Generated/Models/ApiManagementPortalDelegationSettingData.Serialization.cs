// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementPortalDelegationSettingData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(Uri))
            {
                writer.WritePropertyName("url");
                writer.WriteStringValue(Uri.AbsoluteUri);
            }
            if (Optional.IsDefined(ValidationKey))
            {
                writer.WritePropertyName("validationKey");
                writer.WriteStringValue(ValidationKey);
            }
            if (Optional.IsDefined(IsSubscriptions))
            {
                writer.WritePropertyName("subscriptions");
                writer.WriteObjectValue(IsSubscriptions);
            }
            if (Optional.IsDefined(IsUserRegistration))
            {
                writer.WritePropertyName("userRegistration");
                writer.WriteObjectValue(IsUserRegistration);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ApiManagementPortalDelegationSettingData DeserializeApiManagementPortalDelegationSettingData(JsonElement element)
        {
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<Uri> uri = default;
            Optional<string> validationKey = default;
            Optional<SubscriptionsDelegationSettingsProperties> subscriptions = default;
            Optional<RegistrationDelegationSettingsProperties> userRegistration = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("url"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                uri = null;
                                continue;
                            }
                            uri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("validationKey"))
                        {
                            validationKey = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("subscriptions"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            subscriptions = SubscriptionsDelegationSettingsProperties.DeserializeSubscriptionsDelegationSettingsProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("userRegistration"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userRegistration = RegistrationDelegationSettingsProperties.DeserializeRegistrationDelegationSettingsProperties(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ApiManagementPortalDelegationSettingData(id, name, type, systemData.Value, uri.Value, validationKey.Value, subscriptions.Value, userRegistration.Value);
        }
    }
}
