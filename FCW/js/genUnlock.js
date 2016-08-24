
function genSingleUnlockElement(name, expirydate) {
    var todaysDate = new Date();
    var itemPrice = 0;
    var gName = "";

    switch (name) {
        case "U/O":
            gName = "2 GOALS -- / 3 GOALS ++";
            itemPrice = 30;
            break;
        case "TG":
            gName = "TOTAL GOALS";
            itemPrice = 20;
            break;
        case "CS":
            gName = "CORRECT SCORE";
            itemPrice = 20;
            break;
        case "PtS":
            gName = "WHO SCORES";
            itemPrice = 20;
            break;
    }

    var element = cEl("div").attr("class", "plan span4")
        .append(
            cEl("h3").tEl(gName)
        );
    if (expirydate !== todaysDate.format("dd/mm/yyyy")) {
        element.append(
                    cEl("div").attr("class", "features select").tEl("Expires on : " + expirydate)
                    );
    } else {
        element.append(
                    cEl("div").attr("class", "features").tEl("Unlock this option for all the matches for only " + itemPrice + " Golden Balls")
                    )
            .append(
                cEl("div").attr("class", "features select background-img").append(cEl("a").listener("click", purchaseOption).wr({ Slug: name }).attr("class", "btn btn-success").tEl("Unlock"))//.tEl("Expires on : " + expirydate)
                );
    }

    return element;
}