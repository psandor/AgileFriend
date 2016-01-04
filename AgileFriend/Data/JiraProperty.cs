using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace AgileFriend.Data
{
    /// <summary>
    /// The jira property.
    /// </summary>
    public class JiraProperty
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("@id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}