// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using cowinNotification;
//
//    var masterData = MasterData.FromJson(jsonString);

namespace cowinNotification
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections;

    public partial class MasterData
    {
        [JsonProperty("centers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Center> Centers { get; set; }
    }

    public partial class Center
    {
        [JsonProperty("center_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CenterId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("state_name", NullValueHandling = NullValueHandling.Ignore)]
        public string StateName { get; set; }

        [JsonProperty("district_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DistrictName { get; set; }

        [JsonProperty("block_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockName { get; set; }

        [JsonProperty("pincode", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pincode { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public long? Lat { get; set; }

        [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
        public long? Long { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? From { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? To { get; set; }

        [JsonProperty("fee_type", NullValueHandling = NullValueHandling.Ignore)]
        public string FeeType { get; set; }

        [JsonProperty("sessions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Session> Sessions { get; set; }
    }

    public partial class Session
    {
        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? SessionId { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }

        [JsonProperty("available_capacity", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailableCapacity { get; set; }

        [JsonProperty("min_age_limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinAgeLimit { get; set; }

        [JsonProperty("vaccine", NullValueHandling = NullValueHandling.Ignore)]
        public string Vaccine { get; set; }

        [JsonProperty("slots", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Slots { get; set; }

        [JsonProperty("available_capacity_dose1", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailableCapacityDose1 { get; set; }

        [JsonProperty("available_capacity_dose2", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailableCapacityDose2 { get; set; }
    }

    public partial class MasterData
    {
        public static MasterData FromJson(string json) => JsonConvert.DeserializeObject<MasterData>(json, cowinNotification.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MasterData self) => JsonConvert.SerializeObject(self, cowinNotification.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
