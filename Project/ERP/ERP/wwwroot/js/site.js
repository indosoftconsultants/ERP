// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function ()
{
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="modal"]').click(function (event)
    {
        var Url = $(this).data('url');
        $.get(url).done(function (data)
        {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})



$('#btn').click(function () {
    $('#addState').modal('show');
});