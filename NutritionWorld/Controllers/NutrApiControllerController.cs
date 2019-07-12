using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NutritionWorld.Utils;
using System.Data;

namespace NutritionWorld.Controllers
{
    public class NutrApiController : ApiController
    {
        private DataLayer.DAl.AspNetUsers _dalUser = new DataLayer.DAl.AspNetUsers();
        private DataLayer.DAl.UserReservation _dalUserRes = new DataLayer.DAl.UserReservation();
        private DataLayer.DAl.Restaurant _dalRest = new DataLayer.DAl.Restaurant();
        // GET: api/Api
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Api/5
        public string Get(int restId, string restName, DateTime reserveDate)
        {
            return "";
        }
        
        // Send Email
        // POST: api/Api
        [HttpPost]
        public string Post([FromBody]DataLayer.Models.UserReservation reseMod)
        {
            var userMod = _dalUser.GetModel(User.Identity.GetUserId(), User.Identity.GetUserName());
            DataLayer.Models.UserReservation model = new DataLayer.Models.UserReservation();
            model.UserName = userMod.FirstName + userMod.LastName;
            model.RestName = reseMod.RestName;
            model.ReserveDate = reseMod.ReserveDate;
            // default reservation state is '1' ('Untreated')
            model.ReserveStatus = "1";

            DataTable dt = _dalUserRes.GetList(string.Format("UserName = '{0}' and ReserveStatus <> '3'", userMod.FirstName + userMod.LastName)).Tables[0];
            bool flag = false;
            // checked if there is alreay a reservation on that day
            foreach (DataRow row in dt.Rows)
            {
                if (((DateTime)reseMod.ReserveDate).ToShortDateString() == ((DateTime)row["ReserveDate"]).ToShortDateString())
                {
                    flag = true;
                }
            }
            if (flag)
            {
                return "You have made a reservation that day.";
            }
            // if reservation success, send a email to user using api
            if (_dalUserRes.Add(model) > 0)
            {
                EmailSender es = new EmailSender();
                try
                {
                    string content = string.Format("Hello!{0}{1},You made a reservation in {2}. Restaurant:{3}. Address:{4}. Welcome!",
                                userMod.FirstName,
                                userMod.LastName,
                                DateTime.Now.ToString("yyyy-MM-dd"),
                                reseMod.RestName,
                                _dalRest.GetModel(reseMod.RestId).Address);
                    es.Send(userMod.Email, "Reservations", content);
                }
                catch (Exception)
                {

                }
                return "Reservations!";
            }
            else
            {
                return "Reservation failed. Please try again later.";
            }
        }

        // PUT: api/Api/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Api/5
        public void Delete(int id)
        {
        }
    }
}
