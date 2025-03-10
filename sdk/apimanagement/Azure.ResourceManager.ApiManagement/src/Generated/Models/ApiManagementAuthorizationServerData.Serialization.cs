// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementAuthorizationServerData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsCollectionDefined(AuthorizationMethods))
            {
                writer.WritePropertyName("authorizationMethods");
                writer.WriteStartArray();
                foreach (var item in AuthorizationMethods)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ClientAuthenticationMethods))
            {
                writer.WritePropertyName("clientAuthenticationMethod");
                writer.WriteStartArray();
                foreach (var item in ClientAuthenticationMethods)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TokenBodyParameters))
            {
                writer.WritePropertyName("tokenBodyParameters");
                writer.WriteStartArray();
                foreach (var item in TokenBodyParameters)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TokenEndpoint))
            {
                writer.WritePropertyName("tokenEndpoint");
                writer.WriteStringValue(TokenEndpoint);
            }
            if (Optional.IsDefined(SupportState))
            {
                writer.WritePropertyName("supportState");
                writer.WriteBooleanValue(SupportState.Value);
            }
            if (Optional.IsDefined(DefaultScope))
            {
                writer.WritePropertyName("defaultScope");
                writer.WriteStringValue(DefaultScope);
            }
            if (Optional.IsCollectionDefined(BearerTokenSendingMethods))
            {
                writer.WritePropertyName("bearerTokenSendingMethods");
                writer.WriteStartArray();
                foreach (var item in BearerTokenSendingMethods)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ResourceOwnerUsername))
            {
                writer.WritePropertyName("resourceOwnerUsername");
                writer.WriteStringValue(ResourceOwnerUsername);
            }
            if (Optional.IsDefined(ResourceOwnerPassword))
            {
                writer.WritePropertyName("resourceOwnerPassword");
                writer.WriteStringValue(ResourceOwnerPassword);
            }
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName");
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsDefined(ClientRegistrationEndpoint))
            {
                writer.WritePropertyName("clientRegistrationEndpoint");
                writer.WriteStringValue(ClientRegistrationEndpoint);
            }
            if (Optional.IsDefined(AuthorizationEndpoint))
            {
                writer.WritePropertyName("authorizationEndpoint");
                writer.WriteStringValue(AuthorizationEndpoint);
            }
            if (Optional.IsCollectionDefined(GrantTypes))
            {
                writer.WritePropertyName("grantTypes");
                writer.WriteStartArray();
                foreach (var item in GrantTypes)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ClientId))
            {
                writer.WritePropertyName("clientId");
                writer.WriteStringValue(ClientId);
            }
            if (Optional.IsDefined(ClientSecret))
            {
                writer.WritePropertyName("clientSecret");
                writer.WriteStringValue(ClientSecret);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ApiManagementAuthorizationServerData DeserializeApiManagementAuthorizationServerData(JsonElement element)
        {
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> description = default;
            Optional<IList<AuthorizationMethod>> authorizationMethods = default;
            Optional<IList<ClientAuthenticationMethod>> clientAuthenticationMethod = default;
            Optional<IList<TokenBodyParameterContract>> tokenBodyParameters = default;
            Optional<string> tokenEndpoint = default;
            Optional<bool> supportState = default;
            Optional<string> defaultScope = default;
            Optional<IList<BearerTokenSendingMethod>> bearerTokenSendingMethods = default;
            Optional<string> resourceOwnerUsername = default;
            Optional<string> resourceOwnerPassword = default;
            Optional<string> displayName = default;
            Optional<string> clientRegistrationEndpoint = default;
            Optional<string> authorizationEndpoint = default;
            Optional<IList<GrantType>> grantTypes = default;
            Optional<string> clientId = default;
            Optional<string> clientSecret = default;
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
                        if (property0.NameEquals("description"))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("authorizationMethods"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<AuthorizationMethod> array = new List<AuthorizationMethod>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString().ToAuthorizationMethod());
                            }
                            authorizationMethods = array;
                            continue;
                        }
                        if (property0.NameEquals("clientAuthenticationMethod"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<ClientAuthenticationMethod> array = new List<ClientAuthenticationMethod>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new ClientAuthenticationMethod(item.GetString()));
                            }
                            clientAuthenticationMethod = array;
                            continue;
                        }
                        if (property0.NameEquals("tokenBodyParameters"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<TokenBodyParameterContract> array = new List<TokenBodyParameterContract>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(TokenBodyParameterContract.DeserializeTokenBodyParameterContract(item));
                            }
                            tokenBodyParameters = array;
                            continue;
                        }
                        if (property0.NameEquals("tokenEndpoint"))
                        {
                            tokenEndpoint = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("supportState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            supportState = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("defaultScope"))
                        {
                            defaultScope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("bearerTokenSendingMethods"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<BearerTokenSendingMethod> array = new List<BearerTokenSendingMethod>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new BearerTokenSendingMethod(item.GetString()));
                            }
                            bearerTokenSendingMethods = array;
                            continue;
                        }
                        if (property0.NameEquals("resourceOwnerUsername"))
                        {
                            resourceOwnerUsername = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("resourceOwnerPassword"))
                        {
                            resourceOwnerPassword = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("displayName"))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("clientRegistrationEndpoint"))
                        {
                            clientRegistrationEndpoint = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("authorizationEndpoint"))
                        {
                            authorizationEndpoint = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("grantTypes"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<GrantType> array = new List<GrantType>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new GrantType(item.GetString()));
                            }
                            grantTypes = array;
                            continue;
                        }
                        if (property0.NameEquals("clientId"))
                        {
                            clientId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("clientSecret"))
                        {
                            clientSecret = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ApiManagementAuthorizationServerData(id, name, type, systemData.Value, description.Value, Optional.ToList(authorizationMethods), Optional.ToList(clientAuthenticationMethod), Optional.ToList(tokenBodyParameters), tokenEndpoint.Value, Optional.ToNullable(supportState), defaultScope.Value, Optional.ToList(bearerTokenSendingMethods), resourceOwnerUsername.Value, resourceOwnerPassword.Value, displayName.Value, clientRegistrationEndpoint.Value, authorizationEndpoint.Value, Optional.ToList(grantTypes), clientId.Value, clientSecret.Value);
        }
    }
}
