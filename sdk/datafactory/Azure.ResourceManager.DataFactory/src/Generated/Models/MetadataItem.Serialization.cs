// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class MetadataItem : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Name);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Name.ToString()).RootElement);
#endif
            }
            if (Optional.IsDefined(Value))
            {
                writer.WritePropertyName("value");
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Value);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Value.ToString()).RootElement);
#endif
            }
            writer.WriteEndObject();
        }

        internal static MetadataItem DeserializeMetadataItem(JsonElement element)
        {
            Optional<BinaryData> name = default;
            Optional<BinaryData> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    name = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    value = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new MetadataItem(name.Value, value.Value);
        }
    }
}
