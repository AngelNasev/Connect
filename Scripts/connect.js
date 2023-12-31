﻿$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-connect-target"));
            $target.replaceWith(data);
        });
        return false;
    };
    
    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-connect-autocomplete"),
            select: submitAutocompleteForm
        };
        $input.autocomplete(options);
    };

    $("form[data-connect-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-connect-autocomplete]").each(createAutocomplete);
});