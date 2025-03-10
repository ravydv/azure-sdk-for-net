// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class DiagnosticDetectorResponse : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Kind))
            {
                writer.WritePropertyName("kind");
                writer.WriteStringValue(Kind);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startTime");
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (Optional.IsDefined(EndOn))
            {
                writer.WritePropertyName("endTime");
                writer.WriteStringValue(EndOn.Value, "O");
            }
            if (Optional.IsDefined(IsIssueDetected))
            {
                writer.WritePropertyName("issueDetected");
                writer.WriteBooleanValue(IsIssueDetected.Value);
            }
            if (Optional.IsDefined(DetectorDefinition))
            {
                writer.WritePropertyName("detectorDefinition");
                writer.WriteObjectValue(DetectorDefinition);
            }
            if (Optional.IsCollectionDefined(Metrics))
            {
                writer.WritePropertyName("metrics");
                writer.WriteStartArray();
                foreach (var item in Metrics)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AbnormalTimePeriods))
            {
                writer.WritePropertyName("abnormalTimePeriods");
                writer.WriteStartArray();
                foreach (var item in AbnormalTimePeriods)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Data))
            {
                writer.WritePropertyName("data");
                writer.WriteStartArray();
                foreach (var item in Data)
                {
                    writer.WriteStartArray();
                    foreach (var item0 in item)
                    {
                        writer.WriteObjectValue(item0);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ResponseMetaData))
            {
                writer.WritePropertyName("responseMetaData");
                writer.WriteObjectValue(ResponseMetaData);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static DiagnosticDetectorResponse DeserializeDiagnosticDetectorResponse(JsonElement element)
        {
            Optional<string> kind = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            Optional<bool> issueDetected = default;
            Optional<DetectorDefinition> detectorDefinition = default;
            Optional<IList<DiagnosticMetricSet>> metrics = default;
            Optional<IList<DetectorAbnormalTimePeriod>> abnormalTimePeriods = default;
            Optional<IList<IList<NameValuePair>>> data = default;
            Optional<ResponseMetaData> responseMetaData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"))
                {
                    kind = property.Value.GetString();
                    continue;
                }
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
                        if (property0.NameEquals("startTime"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            startTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("endTime"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            endTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("issueDetected"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            issueDetected = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("detectorDefinition"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            detectorDefinition = DetectorDefinition.DeserializeDetectorDefinition(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("metrics"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<DiagnosticMetricSet> array = new List<DiagnosticMetricSet>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DiagnosticMetricSet.DeserializeDiagnosticMetricSet(item));
                            }
                            metrics = array;
                            continue;
                        }
                        if (property0.NameEquals("abnormalTimePeriods"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<DetectorAbnormalTimePeriod> array = new List<DetectorAbnormalTimePeriod>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DetectorAbnormalTimePeriod.DeserializeDetectorAbnormalTimePeriod(item));
                            }
                            abnormalTimePeriods = array;
                            continue;
                        }
                        if (property0.NameEquals("data"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<IList<NameValuePair>> array = new List<IList<NameValuePair>>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                List<NameValuePair> array0 = new List<NameValuePair>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    array0.Add(NameValuePair.DeserializeNameValuePair(item0));
                                }
                                array.Add(array0);
                            }
                            data = array;
                            continue;
                        }
                        if (property0.NameEquals("responseMetaData"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            responseMetaData = ResponseMetaData.DeserializeResponseMetaData(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new DiagnosticDetectorResponse(id, name, type, systemData.Value, Optional.ToNullable(startTime), Optional.ToNullable(endTime), Optional.ToNullable(issueDetected), detectorDefinition.Value, Optional.ToList(metrics), Optional.ToList(abnormalTimePeriods), Optional.ToList(data), responseMetaData.Value, kind.Value);
        }
    }
}
