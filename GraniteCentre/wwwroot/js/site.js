growShrinkLogo();
window.onscroll = function () {
    growShrinkLogo();
};

$(document).ready(function () {
    selectActive();
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

function growShrinkLogo() {
    if (window.matchMedia("(min-width: 992px)").matches) {
        var logoContainer = $(".logoContainer");
        if (document.body.scrollTop > 5 || document.documentElement.scrollTop > 5) {
            logoContainer.addClass("smallLogo").removeClass("bigLogo");
        } else {
            logoContainer.removeClass("smallLogo").addClass("bigLogo");
        }
        logoContainer.delay(1000).addClass("transition");
    }
}

function selectActive() {
    var pathname = window.location.pathname;
    var page = pathname.substring(pathname.lastIndexOf('/') + 1);

    if (page === "") page = "Home";

    $("#mainNav li").each(function (x) {
        var val = this.children[0].text.replace(" ", "-");
        if (val === page) {
            $(this).addClass("active");
        }
    });

}

$("#ContactBtn").click(function (e) {
    e.preventDefault();

    $(".contact-form-div").addClass("loading");
    $(".is-invalid").removeClass("is-invalid");
    $(".invalid-feedback").remove();
    $(".contact-form .alert").remove();

    var pathname = window.location.pathname;
    var url = "/En/ContactForm";
    var isFrench = pathname.substr("/Fr/") > 0

    if (isFrench) {
        url = "/Fr/ContactForm";
    }

    var data = {
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        Company: $("#Company").val(),
        Phone: $("#Phone").val(),
        Comments: $("#Comments").val(),
        Captcha: grecaptcha.getResponse()
    };

    $.post(url, data)
        .done(function (e) {
            if (e.success) {
                PopupAlert("success", e.message, ".contact-form");
                $(".contact-form input, .contact-form textarea, .contact-form select").attr('readonly', 'readonly');
                $(".contact-form #ContactBtn").addClass("disabled");
                $(".contact-form .g-recaptcha").remove();
            } else {
                PopupAlert("danger", e.message, ".contact-form");
            }

            if (e.data !== null) {
                var errors = JSON.parse(e.data);

                $.each(errors, function (key, value) {
                    $("#" + key).addClass("is-invalid").after('<div class="invalid-feedback">' + value + '</div>');
                });
            }
        })
        .fail(function (e) {
            if (isFrench) {
                PopupAlert("danger", "Un erreur est survenue, veuillez réessayer plus tard.", ".contact-form");
            } else {
                PopupAlert("danger", "An Error has occurred, please try again later.", ".contact-form");
            }
        })
        .always(function (e) {
            $(".contact-form-div").removeClass("loading");
        });
});

$("#RightFitBtn").click(function (e) {
    e.preventDefault();

    $(".right-fit-form").addClass("loading");
    $(".is-invalid").removeClass("is-invalid");
    $(".invalid-feedback").remove();
    $(".right-fit-form .alert").remove();

    var pathname = window.location.pathname;
    var url = "/En/RightFitForm";
    var isFrench = pathname.substr("/Fr/") > 0

    if (isFrench) {
        url = "/Fr/RightFitForm";
    }

    var data = {
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        Company: $("#Company").val(),
        Phone: $("#Phone").val(),
        RightFit1: $("#RightFit1").val(),
        RightFit2: $("#RightFit2").val(),
        RightFit3: $("#RightFit3").val(),
        RightFit4: $("#RightFit4").val(),
        RightFit5: $("#RightFit5").val(),
        RightFit6: $("#RightFit6").val(),
        RightFit7: $("#RightFit7").val(),
        RightFit8: $("#RightFit8").val(),
        Captcha: grecaptcha.getResponse()
    };

    $.post(url, data)
        .done(function (e) {
            if (e.success) {
                PopupAlert("success", e.message, ".alert-div");
                $(".right-fit-form input, .right-fit-form textarea, .right-fit-form select").attr('readonly', 'readonly');
                $(".right-fit-form #RightFitBtn").addClass("disabled");
                $(".right-fit-form .g-recaptcha").remove();
            } else {
                PopupAlert("danger", e.message, ".alert-div");
            }

            if (e.data !== null) {
                var errors = JSON.parse(e.data);

                $.each(errors, function (key, value) {
                    $("#" + key).addClass("is-invalid").after('<div class="invalid-feedback">' + value + '</div>');
                });
            }
        })
        .fail(function (e) {
            if (isFrench) {
                PopupAlert("danger", "Un erreur est survenue, veuillez réessayer plus tard.", ".alert-div");
            } else {
                PopupAlert("danger", "An Error has occurred, please try again later.", ".alert-div");
            }
        })
        .always(function (e) {
            $(".right-fit-form").removeClass("loading");
        });
});

function PopupAlert(type, message, location) {
    $(".alert").remove();

    var index = message.lastIndexOf(':') + 1;

    var template = $($("#templateAlert").html()).clone(true);

    template.addClass("alert-" + type).children(".alert-content").html("<b>" + message.substr(0, index) + "</b>" + message.substr(index));
    $(location).prepend(template);
}