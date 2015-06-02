// This file of course does not fully process the data submitted from the form.
// However it does intervene with the default behaviour and loads the data from the
//		form into a JavaScript object, demonstrating the use of JavaScript objects

var JSON_SPACING = 4;

// Accept a JS object, print as JSON to a new window
function displayAsJson(formData)
{
	// make a JSON string from the formData object
	var jsonPretty = JSON.stringify(formData, null, JSON_SPACING);

	var win = window.open("", "win", "width=300,height=200"); // a window object
	win.document.open("text/html", "replace");
	win.document.write("<HTML><HEAD><TITLE>Form Data</TITLE></HEAD><BODY>" + jsonPretty + "</BODY></HTML>");
	win.document.close();
}

// when the dom has been constructed:
$(document).ready(function() 
{
  $("#submit").click(function(e) 
  {
	e.preventDefault();		// prevent the form from being posted to a server

	// get the contents of our form inputs
	var email = $("#txtEmail").val();
	var phone = $("#txtPhone").val();
	var msg = $("#txtMessage").val();	

	// load parameters into an Object
	var formData = new Object();
	formData.phone = phone;
	formData.email = email;
	formData.message = msg;

	// show the JSON
	displayAsJson(formData);
	
  });
});