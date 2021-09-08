// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
	var PlaceHolderElement = $('#PlaceHolderHere');
	$('button[data-toggle="ajax-modal"]').click(function (event) {
		var url = $(this).data('controller') + '/' + $(this).data('action');
		var decodedUrl = decodeURIComponent(url);
		$.get(decodedUrl).done(function (data) {
			PlaceHolderElement.html(data);
			PlaceHolderElement.find('.modal').modal('show');
		})
	})

	PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
		event.preventDefault();
		var form = $(this).parents('.modal').find('form');
		var actionUrl = form.attr('action');
		var sendData = form.serialize();
		$.post(actionUrl, sendData).done(function (data) {
			PlaceHolderElement.find('.modal').modal('hide');
			setTimeout(() => location.reload(), 100);
		})
	})
})

$(function () {
	$('button[data-toggle="ajax-edit"]').click(function (event) {
		var url = $(this).data('route');
		var decodedUrl = decodeURIComponent(url);
		var element = $('#' + $(this).data('id'));
		$.get(decodedUrl).done(function (data) {
			element.html(data);
		})
		element.on('click', '[data-save="edit"]', function (event) {
			event.preventDefault();
			var form = element.find('form');
			var actionUrl = form.attr('action');
			var sendData = form.serialize();
			$.post(actionUrl, sendData).done(function (data) {
				element.html(data);
			})
		})
	})
})