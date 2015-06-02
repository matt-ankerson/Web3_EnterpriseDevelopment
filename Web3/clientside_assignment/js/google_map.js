
// Initialize a google map showing the farm's location
function initialize() 
{
	// The latitude and longitude of the farm
  	var myLatlng = new google.maps.LatLng(-45.956142,169.564126);

  	// Disable scroll wheel functionality to suit the nature of the website.
  	var mapOptions = {
    	zoom: 10,
    	scrollwheel: false,
    	center: myLatlng
  	}

  	// Create the map using the map-canvas div
  	var map = new google.maps.Map(document.getElementById('farm-map-canvas'), mapOptions);

  	// Create a marker to accurately indicate the position of the farm
  	var marker = new google.maps.Marker({
      	position: myLatlng,
      	map: map,
      	title: 'Sunny Braes, Tuapeka West'
  	});
}

// Load the map when the document is ready
google.maps.event.addDomListener(window, 'load', initialize);