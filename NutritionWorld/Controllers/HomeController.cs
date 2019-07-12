using Microsoft.AspNet.Identity;
using NutritionWorld.DataLayer.Models;
using NutritionWorld.Models;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NutritionWorld.Controllers
{
    public class HomeController : Controller
    {
        // create database manager for each table
        private DataLayer.DAl.AspNetUsers _dalUser = new DataLayer.DAl.AspNetUsers();
        private DataLayer.DAl.Restaurant _dalRest = new DataLayer.DAl.Restaurant();
        private DataLayer.DAl.UserComment _dalComment = new DataLayer.DAl.UserComment();
        private DataLayer.DAl.UserReservation _dalUserRes = new DataLayer.DAl.UserReservation();
        private DataLayer.DAl.SpecialDishes _dalDishes = new DataLayer.DAl.SpecialDishes();
        public ActionResult Index()
        {
            ViewBag.ModelList = _dalRest.GetModelList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        // show user's name (first name+last name) and username
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var userMod = _dalUser.GetModel(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.FirstName = userMod.FirstName;
            ViewBag.LastName = userMod.LastName;
            return View();
        }

        //only logged in user can entre this page
        [Authorize]
        public ActionResult Detail(int? id)
        {
            if (id != null && id != 0)
            {
                ViewBag.restModel = _dalRest.GetModel((int)id);
                ViewBag.dishesModel = _dalDishes.GetModelList((int)id);
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // show map for each resturant by their name
        [Authorize]
        public ActionResult Map(string name)
        {
            if (name != null && name != "")
            {
                ViewBag.Name = name;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        //user make a conment
        [HttpGet]
        public string Comment(int restId, string comment)
        {
            var userModel = _dalUser.GetModel(User.Identity.GetUserId(), User.Identity.GetUserName());
            string userName = userModel.FirstName + userModel.LastName;
            // if user haven't eaten in this restuant, then he/she cannot make a comment
            if (!_dalUserRes.IsHaveUserRecord(userName))
            {
                return "You haven't eaten in this restaurant yet. So you can't comment.";
            }
            var comModel = new UserComment();
            comModel.UserName = userName;
            comModel.RestaurantID = restId;
            comModel.Comment = comment;
            //return comments results
            if (_dalComment.Add(comModel) > 0)
            {
                return "Comment on success.";
            }
            else
            {
                return "Comment failed. Please try again later.";
            }
        }

        //Get comment by user ID
        [HttpGet]
        public JsonResult GetComments(int restId)
        {
            var commList = _dalComment.GetModelList(string.Format("RestaurantID = {0} order by ID DESC", restId));
            return Json(commList, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult MyReservation()
        {
            return View();
        }

        // show user who have made a reservation (reservation is either 1 or 2)
        public ActionResult Reservation()
        {
            AspNetUsers userModel = _dalUser.GetModel(User.Identity.GetUserId(), User.Identity.GetUserName());
            ViewBag.Events = _dalUserRes.GetModelList(string.Format("UserName = '{0}' and ReserveStatus in('1','2','3')", userModel.FirstName + userModel.LastName));
            return PartialView("Reservation");
        }

        // if the user cancle his/her reservation, change reservation state to 4
        [HttpGet]
        public ActionResult CancelReservation(int id)
        {
            var mod = _dalUserRes.GetModel(id);
            mod.ReserveStatus = "4";
            _dalUserRes.Update(mod);
            return Reservation();
        }


        // only admin can change reservation
        [Authorize]
        public ActionResult ManageReservation()
        {
            // see if user is admin or not
            if (User.Identity.GetUserId() == "1")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        //return patial view of manage reservation
        public ActionResult _ManageRes_Partial()
        {
            ViewBag.EventsList = _dalUserRes.GetModelList("");
            // only show the reservation which is 'untreated', 'confirmed' and 'already had a meal'
            ViewBag.Events = _dalUserRes.GetModelList("ReserveStatus in('1','2','3')");
            return PartialView("_ManageRes_Partial");
        }

        // if the reservation is cancled by admin, change its state to '5'(canceled by admin)
        [HttpGet]
        public ActionResult ManagerCancelReservation(int id)
        {
            var mod = _dalUserRes.GetModel(id);
            mod.ReserveStatus = "5";
            _dalUserRes.Update(mod);
            return _ManageRes_Partial();
        }


        // chenge date for a reservation
        [HttpGet]
        public ActionResult ManagerRescheduling(int id, DateTime date)
        {
            var mod = _dalUserRes.GetModel(id);
            mod.ReserveDate = date;
            _dalUserRes.Update(mod);
            return _ManageRes_Partial();
        }

        // admin can confirm a user's reservation
        [HttpGet]
        public ActionResult Ham(int id)
        {
            var mod = _dalUserRes.GetModel(id);
            //change his or her state to 3 (confirmed)
            mod.ReserveStatus = "3";
            _dalUserRes.Update(mod);
            return _ManageRes_Partial();
        }

    }
}