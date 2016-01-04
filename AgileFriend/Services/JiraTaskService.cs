using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

using AgileFriend.Data;
using AgileFriend.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgileFriend.Services
{
    /// <summary>
    /// The jira task service.
    /// </summary>
    public class JiraTaskService
    {
        /// <summary>
        /// The create jira task models.
        /// </summary>
        /// <param name="jiraTasksXml">
        /// The jira tasks xml.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public static IList<JiraTaskModel> CreateJiraTaskModels(string jiraTasksXml, string taskType)
        {
            // jiraTasksXml = CleanXml(jiraTasksXml);

            // File.WriteAllText("C:\\temp\\bbb.txt", jiraTasksXml);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(jiraTasksXml);

            var jiraTasksJson = JObject.Parse(JsonConvert.SerializeXmlNode(xmlDoc));

            var items = jiraTasksJson["rss"]["channel"]["item"].Children().ToList();

            var jiraTaskModels = new List<JiraTaskModel>();

            foreach (var jiraItem in items)
            {
                var jiraTask = JsonConvert.DeserializeObject<JiraTask>(jiraItem.ToString());

                if (jiraTask.Parent == null)
                {
                    continue;
                }

                var jiraTaskModel = new JiraTaskModel { Id = jiraTask.Key.Text, ParentId = jiraTask.Parent.Text, Summary = jiraTask.Summary, TaskType = taskType };
                jiraTaskModels.Add(jiraTaskModel);
            }

            return jiraTaskModels;
        }

        /// <summary>
        /// The clean xml.
        /// </summary>
        /// <param name="xmlString">
        /// The xml string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string CleanXml(string xmlString)
        {
            var byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

            if (xmlString.StartsWith(byteOrderMarkUtf8))
            {
                xmlString = xmlString.Remove(0, byteOrderMarkUtf8.Length);
            }

            xmlString = xmlString.Replace("&", "&amp;");
            xmlString = xmlString.Replace("\"", "&quot;");
            xmlString = xmlString.Replace("'", "&apos;");
            xmlString = xmlString.Replace("<", "&lt;");
            xmlString = xmlString.Replace(">", "&gt;");

            return xmlString;
        }
    }
}