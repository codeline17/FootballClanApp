function manageClan(e) {
    var leaveClan = document.querySelector('.leave-clanBtn');
    var table = document.querySelector('#clan-table');
    table.classList.toggle('manage-clan');
    leaveClan.classList.toggle('leave-clan');
}