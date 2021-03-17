$(document).ready(function () {
    $(".code-link").click(async function (ev) {
        ev.preventDefault();
        let codeviewUrl = $(this).data("codeview-url");
        let highlight = $(this).data("highlight");
        let githubUrl = "/GitHub/Source?url=" + codeviewUrl + "&highlight=" + highlight;
        let result = await fetch(githubUrl, {
            method: "get"
        });
        let content = await result.text();
        $("#code-view").html(content);
        $("#external-link").prop("href", $(this).data("external-url"));
        $("#external-link").html($(this).data("external-url"));
    });
});