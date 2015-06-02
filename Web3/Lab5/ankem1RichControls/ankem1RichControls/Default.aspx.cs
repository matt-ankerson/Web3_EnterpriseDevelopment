using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ankem1RichControls
{
    public partial class Default : System.Web.UI.Page
    {
        private const int IMAGESIZE = 30;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Task One - Make the calendar show August 2015

            // Create a new DateTime instance for the first day of August 2015.
            DateTime august = new DateTime(2015, 8, 1);

            // Assign our new DateTime object to the Calendar's TodaysDate property
            calCalendar.TodaysDate = august;
        }

        // Event handler for calCalendar_SelectionChanged.
        // Will fire when the user selects a different date
        protected void calCalendar_SelectionChanged(object sender, EventArgs e)
        {

        }

        // Event handler for calCalendar_DayRender
        // This method will run each time a day is rendered.
        protected void calCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            // Task Two - add images to certain days of the week.

            // Create the image instances we need.
            Image bath = new Image();
            Image raceCar = new Image();

            bath.ImageUrl = "images/bathtub-clip-art.jpg";
            raceCar.ImageUrl = "images/race-car.gif";

            bath.Height = IMAGESIZE;
            bath.Width = IMAGESIZE;
            raceCar.Height = IMAGESIZE;
            raceCar.Width = IMAGESIZE;

            // Style our images
            raceCar.Style.Add("display", "block");
            bath.Style.Add("display", "block");

            // Create a Hyperlink to add to a day. ***(Task 3)***
            HyperLink raceCarLink = new HyperLink();
            raceCarLink.NavigateUrl = "http://www.nzsupertourers.co.nz/";
            raceCarLink.Text = "Race!";          

            // Check the day of the week
            if (e.Day.Date.DayOfWeek == DayOfWeek.Friday)
            {
                e.Cell.BackColor = System.Drawing.Color.PapayaWhip;
                e.Cell.Controls.Add(raceCar);
                e.Cell.Controls.Add(raceCarLink);
            }

            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = System.Drawing.Color.PapayaWhip;
                e.Cell.Controls.Add(bath);
            }
        }
    }
}