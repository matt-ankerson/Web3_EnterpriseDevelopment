using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelQuiz2015
{
    public partial class TravelQuizHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStartQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question1.aspx");
        }

    }
}