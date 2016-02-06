window.document.onload = function(e) {
    var s = localStorage.getItem('scrollPos') ? localStorage.getItem('scrollPos') : 0;
    console.log(s);
    $(window).scrollTop(s);
}

window.document.unload = function(e) {
    localStorage.setItem('scrollPos', $(window).scrollTop());
    alert($(window).scrollTop());
}

function OnStart() {
    var d = $find("dtNdeshjet").get_selectedDate();
    console.log(d);
    $get('<%=txtCalendar.ClientID %>').value = d.toUTCString();
    $get('<%=btnFilter.ClientID %>').click();
}

function DateChanged() {
    $get('<%=btnFilter.ClientID %>').click();
}