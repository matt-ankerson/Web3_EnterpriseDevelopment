
function make_fancy()
{
	// select class royal name and add the fancy class
	$('.royalName').addClass('fancy');
}

function make_all_loud()
{
	$('#mainList li').addClass('loudBorder');
}

function make_direct_children_loud()
{
	$('#mainList > li').addClass('loudBorder');
}

function make_first_div_loud()
{
	var all_divs = $('div');
	all_divs.eq(0).addClass('loudBorder');
}

function make_first_li_loud()
{
	var all_lis = $('li');
	all_lis.eq(0).addClass('loudBorder');
}

function make_first_li_children_loud()
{
	$('li:nth-child(1)').addClass('loudBorder');
}

function q8()
{
	var items = $('li >').filter(function() {
		return $(this) == items.get(1);
		
	});
	items.addClass('loudBorder');
}

function q9()
{
	$('li:nth-child(2)').addClass('loudBorder');
}

function q10()
{
	$('span:contains(Count of Habsburg)').addClass('loudBorder');
}

function q11()
{
	$('span:contains(Count of Habsburg)').addClass('loudBorder');
	$('li:contains(Count of Habsburg)').addClass('loudBorder');
}

function q12()
{
	$('.royalName').parent().addClass('loudBorder');
}

function q13()
{
	$('span:contains(Duke of Austria)').parent().parent().prev().addClass('fancy');
}

function make_adjustments()
{
	//make_fancy();
	//make_all_loud();
	//make_direct_children_loud();
	//make_first_div_loud();
	//make_first_li_loud();
	//make_first_li_children_loud();
	//q8();
	//q9();
	//q10();
	//q11();
	//q12();
	q13();
}


window.onload = make_adjustments;