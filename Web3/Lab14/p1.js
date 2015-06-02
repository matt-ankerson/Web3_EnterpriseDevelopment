
function draw_intersecting_rects()
{
	// get the canvas element
	var mainCanvas = document.getElementById("canvas");
	// get the 2d context from the canvas
	var mainContext = mainCanvas.getContext("2d");

	// draw a blue rectangle 
	mainContext.fillStyle='blue';
	mainContext.fillRect(20, 20, 40, 40);

	// turn transparency on
	mainContext.globalAlpha = 0.2;

	// draw a green rectangle
	mainContext.fillStyle='green';
	mainContext.fillRect(30, 30, 40, 40);
}

window.onload = draw_intersecting_rects;