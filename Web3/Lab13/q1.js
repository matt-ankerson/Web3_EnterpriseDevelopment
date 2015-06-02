function match (team1, team2, score1, score2) 
{
	this.team1 = team1;
	this.team2 = team2;
	this.score1 = score1;
	this.score2 = score2;
	console.log(team1 + " vs " + team2);
}

function get_info(match)
{
	var output = document.getElementById("output");

	for(var key in match)
	{
		if(output.innerHTML == null) {
			console.log("it was null");
			output.innerHTML = key + " " + match[key] + "<br />";
		}
		else {
			output.innerHTML = output.innerHTML + key + " " + match[key] + "<br />";
		}
	}
}

// Insert the contents of given object as a table in the DOMs
function display_object_in_table(o)
{
	// get the table div element
	var divTable = document.getElementById("tbl");
	console.log(divTable);
	// create the table element
	var newTableNode = document.createElement("table");

	// apply style to table
	newTableNode.style.border = "1px solid black";

	// build the table rows and columns
	for (var key in o)
	{
		// create a table row node
		var newTrNode = document.createElement("tr");
		// create a td element for the key
		var newTdKey = document.createElement("td");
		// create an element for the value
		var newTdValue = document.createElement("td");

		// assign text to the td elements
		var newTextNodeKey = document.createTextNode(key);
		var newTextNodeValue = document.createTextNode(o[key]);

		// add the text to the td elements
		newTdKey.appendChild(newTextNodeKey);
		newTdValue.appendChild(newTextNodeValue);

		// apply styles to td elements
		newTdKey.style.border = "1px solid black";
		newTdValue.style.border = "1px solid black";

		// add the td elements to the tr element
		newTrNode.appendChild(newTdKey);
		newTrNode.appendChild(newTdValue);

		// add the tr to the table
		newTableNode.appendChild(newTrNode);
	}

	// add the new table to our div element.
	divTable.appendChild(newTableNode);
}

var matchInstance = new match("Sunderland", "New Castle", 3, 0);
get_info(matchInstance);

display_object_in_table(matchInstance);

