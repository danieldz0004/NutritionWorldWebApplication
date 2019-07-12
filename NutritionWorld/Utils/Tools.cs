using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutritionWorld.Utils
{

    //transfer date format
    public static class Tools
    {
        public static string ConvertToShortDate(object dateTime)
        {
            string result = "";
            try
            {
                result = ((DateTime)dateTime).ToShortDateString();
            }
            catch (Exception)
            {
                result = "TimeError";//time is wrong
            }
            return result;
        }


        //there are 6 states of a reservation, using number 1-6 to store the reservation state
        public static string GetReservationState(object state)
        {
            string result = "";
            switch (state.ToString())
            {
                case "1":
                    result = "Untreated";
                    break;
                case "2":
                    result = "Have a meal";
                    break;
                case "3":
                    result = "Confirmed";
                    break;
                case "4":
                    result = "User cancellation";
                    break;
                case "5":
                    result = "Admin cancelled";
                    break;
                default:
                    result = "State error";
                    break;
            }
            return result;
        }
    }
}