/// <reference path="jquery-1.4.4-vsdoc.js" />
var addDetailLoad = function () {
	$('a.details-link').each(function () {
		var url = $(this).attr('href');
		$(this).attr('href', '#'); // surpress reload
		$(this).click(function () {
			$('#detail-inner').html('');
			alert(url);
			$('#detail-inner').load(url);
		});
	});
};

$(document).ready(function () {
	addDetailLoad();
});