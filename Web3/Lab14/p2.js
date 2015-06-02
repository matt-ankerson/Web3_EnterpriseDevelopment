function draw_smiley()
{
	// get the canvas element
	var canvas = document.getElementById("canvas");
	// get the 2d context from the canvas
	var ctx = canvas.getContext("2d");

	// end angle for a whole circle
	var endAngle = 360 * (Math.PI/180);


	// draw the outer circle
	ctx.beginPath();
	ctx.fillStyle = 'yellow';
	ctx.arc(100, 100, 80, 0, endAngle);
	ctx.fill();
	ctx.strokeStyle = 'black';
	ctx.lineWidth = 5;
	ctx.arc(100, 100, 80, 0, endAngle);	// x, y, radius, start_angle, end_angle
	ctx.stroke();

	// draw the eyes
	ctx.beginPath();
	ctx.fillStyle = 'black';
	ctx.arc(65, 75, 5, 0, endAngle);
	ctx.fill();
	ctx.beginPath();
	ctx.fillStyle = 'black';
	ctx.arc(125, 75, 5, 0, endAngle);
	ctx.fill();

	endAngle = 180 * (Math.PI/180);

	console.log("here");

	// draw the mouth

	ctx.beginPath();
	ctx.strokeStyle = 'black';
	ctx.lineWidth = 5;
	ctx.arc(100, 100, 60, 0, endAngle);	// x, y, radius, start_angle, end_angle
	ctx.stroke();

}

window.onload = draw_smiley;