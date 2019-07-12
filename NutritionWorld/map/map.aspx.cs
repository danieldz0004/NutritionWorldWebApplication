using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NutritionWorld.Views.Home.map
{
    public partial class map : ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetName
        {
            get
            {
                try
                {
                    return Request.QueryString["name"];
                }
                catch (Exception)
                {
                    Response.Redirect("/Home");
                    return "";
                }
            }
        }
    }
}