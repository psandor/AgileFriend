using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileFriend.Models
{
    /// <summary>
    /// The jira task model.
    /// </summary>
    public class JiraTaskModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the parent id.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the task type.
        /// </summary>
        public string TaskType { get; set; }
    }
}