

function showFamilyDetailPopUp(familyID) {
    debugger;
    var windowName = "FamilyDetails";

    var FamilyDetails = "GetFamilyDetails.aspx";


    FamilyDetails += "?FamilyID=" + familyID;

    var winTop = 75;
    var winLeft = 75;

    var pWidth = screen.width - 150;
    var pHeight = screen.height - 150;
    var windowFeatures = "width=" + pWidth + ",height=" + pHeight + ",";
    windowFeatures = windowFeatures + "left=" + winLeft + ",";
    windowFeatures = windowFeatures + "top=" + winTop + ",";

    windowFeatures = windowFeatures + "resizable=yes,toolbar=no, status=no,scrollbars=1";

    window.open(FamilyDetails, windowName, windowFeatures);
}



function showMemberDetails(familyID, PersonID, MemberTable, FamilyListOpen) {

    debugger;
    var windowName = "ProcessMember";

    var updatemember = "ProcessMember.aspx";


    updatemember += "?FamilyID=" + familyID + "&PersonID=" + PersonID + "&MemberTable=" + MemberTable + "&FamilyListOpen=" + FamilyListOpen;

    var winTop = 75;
    var winLeft = 75;

    var pWidth = screen.width - 150;
    var pHeight = screen.height - 150;
    var windowFeatures = "width=" + pWidth + ",height=" + pHeight + ",";
    windowFeatures = windowFeatures + "left=" + winLeft + ",";
    windowFeatures = windowFeatures + "top=" + winTop + ",";

    windowFeatures = windowFeatures + "resizable=yes,toolbar=no, status=no,scrollbars=1";

    window.open(updatemember, windowName, windowFeatures);
}


function AddwMemberDetails(familyID, MemberTable, homePhone) {

    var windowName = "AddAMember";

    var updatemember = "AddAMember.aspx";


    updatemember += "?FamilyID=" + familyID + "&MemberTable=" + MemberTable + "&homePhone=" + homePhone;

    var winTop = 75;
    var winLeft = 75;

    var pWidth = screen.width - 150;
    var pHeight = screen.height - 150;
    var windowFeatures = "width=" + pWidth + ",height=" + pHeight + ",";
    windowFeatures = windowFeatures + "left=" + winLeft + ",";
    windowFeatures = windowFeatures + "top=" + winTop + ",";

    windowFeatures = windowFeatures + "resizable=yes,toolbar=no, status=no,scrollbars=1";

    window.open(updatemember, windowName, windowFeatures);
}

