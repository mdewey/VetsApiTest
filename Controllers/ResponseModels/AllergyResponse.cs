using System;
using Newtonsoft.Json;

namespace VetsApiTest.Controllers.Allergy
{
     public  class AllergyResponse
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("link")]
        public Link[] Link { get; set; }

        [JsonProperty("entry")]
        public Entry[] Entry { get; set; }
    }

    public  class Entry
    {
        [JsonProperty("fullUrl")]
        public Uri FullUrl { get; set; }

        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        [JsonProperty("search")]
        public Search Search { get; set; }
    }

    public  class Resource
    {
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("recordedDate")]
        public DateTimeOffset RecordedDate { get; set; }

        [JsonProperty("patient")]
        public Patient Patient { get; set; }

        [JsonProperty("substance")]
        public Substance Substance { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("note")]
        public Note Note { get; set; }

        [JsonProperty("reaction")]
        public Reaction[] Reaction { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }
    }

    public  class Note
    {
        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public  class Patient
    {
        [JsonProperty("reference")]
        public Uri Reference { get; set; }

        [JsonProperty("display")]
        public string Display { get; set; }
    }

    public  class Reaction
    {
        [JsonProperty("certainty", NullValueHandling = NullValueHandling.Ignore)]
        public string Certainty { get; set; }

        [JsonProperty("manifestation")]
        public Manifestation[] Manifestation { get; set; }
    }

    public  class Manifestation
    {
        [JsonProperty("coding")]
        public Coding[] Coding { get; set; }
    }

    public  class Coding
    {
        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("display")]
        public string Display { get; set; }
    }

    public  class Substance
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public  class Search
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

    public  class Link
    {
        [JsonProperty("relation")]
        public string Relation { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

}