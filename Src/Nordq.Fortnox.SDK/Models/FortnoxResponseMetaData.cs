using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nordq.Fortnox.SDK.Models
{
    public class FortnoxResponseMetaData
    {
        [ReadOnly(true)]
        [XmlAttribute]
        [JsonProperty(PropertyName = "@TotalResources")]
        public string TotalResources { get; set; }
        [ReadOnly(true)]
        [XmlAttribute]
        [JsonProperty(PropertyName = "@TotalPages")]
        public string TotalPages { get; set; }
        [ReadOnly(true)]
        [XmlAttribute]
        [JsonProperty(PropertyName = "@CurrentPage")]
        public string CurrentPage { get; set; }
    }
}