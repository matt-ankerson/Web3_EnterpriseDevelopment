using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntroToWebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Assign text to the lower text box
            txtControl.Value = "This text stays";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtASPControl.Text = txtControl.Value;
        }
    }
}