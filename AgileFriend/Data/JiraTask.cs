using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace AgileFriend.Data
{
    /// <summary>
    /// The jira task.
    /// </summary>
    public class JiraTask
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("key")]
        public JiraProperty Key { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        [JsonProperty("parent")]
        public JiraProperty Parent { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}