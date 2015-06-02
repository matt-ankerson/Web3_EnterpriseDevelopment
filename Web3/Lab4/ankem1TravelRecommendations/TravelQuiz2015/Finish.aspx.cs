using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelQuiz2015
{
    public partial class Finish : System.Web.UI.Page
    {
        // Event handler for Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            // Print out the contents of session for diagnostic purposes

            String sessionContents = "";

            for(int i = 0; i < Session.Count; i++)
            {
                sessionContents += (Session[(i + 1)]);
            }

            testSessionDiv.InnerText = sessionContents;
        }

        /// <summary>
        /// Returns a destination decided upon by the contents of Session.
        /// </summary>
        /// <returns>A KeyValuePair containing the name of the destination and a file path to an appropriate image.</returns>
        public KeyValuePair<string, string> DecideDestination()
        {
            // Create a KeyValuePair to hold our destination.
            KeyValuePair<string, string> finalDestination = new KeyValuePair<string, string>();

            // Create a Dictionary to hold our possible destinations.
            Dictionary<string, int> possibleDests = new Dictionary<string,int>();
            possibleDests.Add("Greece", 0);
            possibleDests.Add("London", 0);
            possibleDests.Add("Munich", 0);
            possibleDests.Add("Paris", 0);
            possibleDests.Add("Queenstown", 0);
            possibleDests.Add("Rarotonga", 0);
            possibleDests.Add("Rome", 0);
            possibleDests.Add("Venice", 0);

            // Loop over the answers that we stored earlier
            for(int i = 0; i < Session.Count; i++)
            {
                string question = Session[(i + 1)].ToString();

                // Switch on i, decide which question we're dealing with
                switch(i)
                {
                    case 0:
                        if (question.Contains("history"))
                            possibleDests["Greece"]++;
                        if (question.Contains("club"))
                            possibleDests["London"]++;
                        if (question.Contains("adventure"))
                            possibleDests["Queenstown"]++;
                        if (question.Contains("romantic"))
                            possibleDests["Venice"]++;
                        if (question.Contains("solitary"))
                            possibleDests["Rarotonga"]++;
                        break;
                    case 1:
                        if (question.Contains("True"))
                            possibleDests["Munich"]++;
                        else
                            possibleDests["Rarotonga"]++;
                        break;
                    case 2:
                        if (question.Contains("Shop"))
                            possibleDests["London"]++;
                        if (question.Contains("historical"))
                            possibleDests["Greece"]++;
                        if (question.Contains("fishing"))
                            possibleDests["Queenstown"]++;
                        if (question.Contains("museums"))
                            possibleDests["Rome"]++;
                        break;
                    case 3:
                        if (question.Contains("Solo"))
                            possibleDests["Queenstown"]++;
                        if (question.Contains("friends"))
                            possibleDests["London"]++;
                        if (question.Contains("family"))
                            possibleDests["Munich"]++;
                        if (question.Contains("partner"))
                            possibleDests["Venice"]++;
                        break;
                    default:
                        break;
                }
            }

            // Loop over each KeyValuePair in our possible destinations
            foreach(var item in possibleDests)
            {
                if(item.Value == possibleDests.Values.Max())
                {
                    //finalDestination.Key = item.Key;
                    //finalDestination.Value = item.
                }
            }


                return finalDestination;
        }
    }
}