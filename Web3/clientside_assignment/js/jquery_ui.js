// This Jquery UI snippet demonstrates the usage of Jquery UI for cool UI effects.

// wait until the dom is constructed
$(document).ready(function() 
{
  // hide our terget div to begin with
  var div = $('#effect');
  $(div).hide();

  $(function() 
  {
      // this is the effect
      function runEffect() 
      {
        // effect type
        var selectedEffect = "blind"; // many other effects available
   
        // blind effect requires no options
        var options = {};
   
        // run the effect
        $( "#effect" ).toggle( selectedEffect, options, 500 );
      };
   
      // run the effect when the button is clicked
      $( "#button" ).click(function() 
      {
        runEffect();
      });

    });

});