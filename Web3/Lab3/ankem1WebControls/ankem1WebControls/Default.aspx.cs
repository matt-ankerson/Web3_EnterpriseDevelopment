// Practical 2.1 Web Controls
// Author: Matthew Ankerson
// Date: 23 Feb 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ankem1WebControls
{
    public partial class Default : System.Web.UI.Page
    {
        // Private data fields
        Table tblImages;
        List<string> folderNames;
        List<string> filePrefixes;
        List<string> fileSuffixes;
        string fontString;
        string message;

        // Event handler for Page Load
        // Populate the ListBox using the Font folder names
        protected void Page_Load(object sender, EventArgs e)
        {
            populateFontLists();

            // loop over our folder names
            foreach (string name in folderNames)
            {
                // Capatalize the first letter of the Font name
                string tidyName = (char.ToUpper(name[0]) + name.Substring(1));
                // Add to the ListBox
                ddlFonts.Items.Add(tidyName);
            }

        }

        // Event handler for Diplay button
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            // Get the Font name from the list box
            fontString = ddlFonts.SelectedItem.Text;

            // Get the message the user wants to display, cast the whole message to lower case
            message = txtEnterText.Text.ToLower();

            // Get the appropriate images to represent the message:

            // Loop over each character in the message
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i].ToString() != " ")
                {
                    string letter = message[i].ToString();

                    // Create an image
                    Image imageLetter = new Image();

                    // Decapatalize the first letter of the Font/folder name
                    string folderName = (char.ToLower(fontString[0]) + fontString.Substring(1));

                    // Get the appropriate index at which our fileName prefix and suffix reside in the filePrefixes and fileSuffixes Lists respectively
                    int parallelIndex = folderNames.IndexOf(folderName);

                    // Build the URL to the image:
                    imageLetter.ImageUrl = "images/" + folderName + "/" + filePrefixes[parallelIndex] + letter + fileSuffixes[parallelIndex] + ".gif";

                    divImageText.Controls.Add(imageLetter);
                }
                else
                {
                    Image imageSpace = new Image();
                    imageSpace.ImageUrl = "images/space.gif";
                    divImageText.Controls.Add(imageSpace);
                }
            }
        }

        // Hard code the file name information for our Fonts
        private void populateFontLists()
        {
            folderNames = new List<string> {"cartoon", "copperDeco",
                                        "decoTwoTone", "embroidery", "fancy",
                                        "goldDeco", "green", "greenChunky",
                                        "ice", "letsFaceIt", "lights",
                                        "peppermintSnow", "polkadot", "rainbow",
                                        "seaScribe", "shadow", "snowflake",
                                        "teddy", "tiger", "victorian",
                                        "water", "wood", "zebra"};

            filePrefixes = new List<string> {"alphabet_", "copperdeco-",
                                         "", "embroidery-", "art_",
                                         "golddeco-", "", "109",
                                         "ice", "faceoff-", "",
                                         "peppermint-", "polkadot-","",
                                         "", "shad_", "snowflake-",
                                         "alphabear", "", "vic",
                                         "wr_", "wood", "zebra-"};

            fileSuffixes = new List<string> { "s","",
                                          "4", "", "",
                                          "", "", "",
                                          "", "", "1",
                                          "", "", "",
                                          "", "", "",
                                          "smblue", "", "",
                                          "", "", ""};
        }
    }
}