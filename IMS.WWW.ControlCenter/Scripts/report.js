/// <reference path="jquery-1.4.4-vsdoc.js" />
/// <reference path="jquery-ui.js" />
var addDetailLoad = function (elements) {
	var detailsContainer = $('#detail-inner');
	var buttons = $('.detail-button');
	buttons.unbind('click');
	buttons.each(function () {
		var url = "/Reports/Details/" + $(this).attr('id');
		$(this).button({
			icons: {
				primary: "ui-icon-document"
			},
			text: false
		});
		$(this).click(function () {
			$('#detail-inner').load(url);
		});
	});
}

var bounce = function (element) {
	var speeds = ['slow', 'normal', 'fast']
	for (var speed in speeds) {
		element.fadeIn(speed).fadeOut(speed).fadeIn(speed);
	}
}

var startTimer = function () {
	window.setTimeout('poll()', 5000);
}

var poll = function () {
	var lastReportID =
		$('#report-rows :first')
		.attr('id')
		.replace('report-row-', '');
	var pushReceivedReports = function (data) {
		var tableBody = $('#report-table tbody');
		var rows = $(data)
		addDetailLoad(data);
		rows.prependTo(tableBody);
		bounce($('td', rows));
		startTimer();
	}
	$.ajax({
		url: '/Reports/Poll?lastReceivedReportID=' + lastReportID,
		accepts: "text/html",
		success: pushReceivedReports
	});
}

$(document).ready(function () {
	addDetailLoad($(this));
	startTimer();
});
