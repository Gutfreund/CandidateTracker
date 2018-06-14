using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq;
using May_23.Models;

namespace May_23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandidate(Candidate candidate)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            repo.AddCandidate(candidate);
            return Redirect("/Home/Pending");
        }

        public ActionResult Pending()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetPending());
        }

        public ActionResult Confirmed()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetConfirmed());
        }

        public ActionResult Refused()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetRefused());
        }

        public ActionResult ViewDetails(int candidateId)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            return View(repo.ViewDetails(candidateId));
        }

        [HttpPost]
        public void Confirm(int candidateId)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            repo.Confirm(candidateId);
        }

        [HttpPost]
        public void Refuse(int candidateId)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            repo.Refuse(candidateId);
        }

        public ActionResult UpdateStatus()
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            return Json(new { Pending = repo.GetPendingCount(), Confirmed = repo.GetConfirmedCount(), Refused = repo.GetRefusedCount() }, JsonRequestBehavior.AllowGet);
        }
    }
}