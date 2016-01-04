using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AgileFriend.Models;
using AgileFriend.Services;

namespace AgileFriend.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult JiraBoard(string jiraTasks, string taskType)
        {
            var jiraTaskModels = JiraTaskService.CreateJiraTaskModels(jiraTasks, taskType);

            return View(jiraTaskModels);
        }
    }
}
