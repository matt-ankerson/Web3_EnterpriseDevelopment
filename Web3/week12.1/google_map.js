var map;

function initialize() 
{
  var mapOptions = {
    zoom: 8,
    center: new google.maps.LatLng(-45.878760, 170.502798),
    mapTypeId: google.maps.MapTypeId.SATELLITE
  };

  map = new google.maps.Map(document.getElementById('map-canvas'),
      mapOptions);
}

/*
// The event object passed into the callback by the system has a field latLng 
// which holds the latitude and longitude of the clicked location on the map.
google.maps.event.addOnClickListener(map, 'click', function(event) 
	{
		// Create the marker options
		var marker_options = {
			position: google.maps.LatLng(-45.878760, 170.502798),
			title: document.getElementById("toolTip").value;
		};

		// Create the marker object
		var marker_object = new google.maps.Marker(marker_options);

		// Binding the marker object to the map object
		marker_object.setMap(map);
	}); 
*/

google.maps.event.addDomListener(window, 'load', initialize);