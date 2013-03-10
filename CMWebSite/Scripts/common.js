function showCurtain_pieces() {

    if ($('#mrnPickContainer').length > 0) {
        var lblWarningText = $('.mrnpickBoldTextBlack')[0].innerText

        if ($('#ctl00_serverType').val() != "PORTAL") {
            if (lblWarningText.indexOf("Enter Full Name") == -1) {
                showCurtain_piecesForTmpMRN()
            }
            else 
            {
                if (document.location.href.indexOf("ROEHome.aspx") == -1 && document.location.href.indexOf("ProcessLilaOrder.aspx") == -1) {
                    if ($.browser.version < 7) {
                        $('select').hide();
                    }
                    var obj = $('#ctl00_MasterPageContentPlaceHolder_uc2PhysicianMRNPick_Table1');
                    var obj2 = $('#ctl00_MasterPageContentPlaceHolder_ucPhysicianMRNPick_tblMRNSearchPtDemoGfx');

                    var demoGrpahicTable = $('ctl00_MasterPageContentPlaceHolder_ucPhysicianMRNPick_tblMRNSearchPtDemoGfx')
                    var nameTable = $('#ctl00_MasterPageContentPlaceHolder_ucPhysicianMRNPick_tblMRNSearch')

                    if (obj.length == 0) {
                        obj = $('.mrnSearchTable')
                        var isUCWidth = $('.mrnSearchTable').width() - 50
                        var isUCHeight = $('.mrnSearchTable').height() - 20
                        $('#redX').css('margin-top', "30px")


                    }
                    else {
                        var isUCWidth = $('#ctl00_MasterPageContentPlaceHolder_uc2PhysicianMRNPick_Table1').width() + 20
                        var isUCHeight = $('#ctl00_MasterPageContentPlaceHolder_uc2PhysicianMRNPick_Table1').height() - 20
                    }
                    //debugger

                    var isUCOffSet = obj.offset()
                    var isUCLeft = isUCOffSet.left
                    var isUCTop = isUCOffSet.top + 0

                    if (isUCTop == 0)
                    {
                        isUCOffSet = obj2.offset()
                        isUCLeft = isUCOffSet.left
                        isUCTop = isUCOffSet.top + 0                    
                    }



                    var screenWidth = document.documentElement.clientWidth;
                    var screenHeight = document.documentElement.clientHeight;
                    var documentHeight = $(document).height();
                    var documentWidth = $(document).width();
                    $('#redX').css('left', (isUCLeft + isUCWidth - 50) + "px")
                    $('#redX').show();
                    $('#curtain_top').css("height", (isUCTop - 50) + "px")
                    $('#curtain_top').css("width", screenWidth + "px")
                    $('#curtain_top').css('opacity', 0.3);
                    $('#curtain_top').show();

                    $('#curtain_left').css("height", (documentHeight - (isUCTop - 17)) + "px")
                    $('#curtain_left').css("width", (isUCLeft - 10) + "px")
                    $('#curtain_left').css("top", (isUCTop - 50) + "px")
                    $('#curtain_left').css('opacity', 0.3);
                    $('#curtain_left').show();

                    $('#curtain_bottom').css("height", (documentHeight - (isUCTop + isUCHeight + 10)) + "px")
                    $('#curtain_bottom').css("width", (documentWidth - (isUCLeft - 10)) + "px")
                    $('#curtain_bottom').css("top", (isUCTop + isUCHeight + 29) + "px")
                    $('#curtain_bottom').css("left", (isUCLeft - 10) + "px")
                    $('#curtain_bottom').css('opacity', 0.3);
                    $('#curtain_bottom').show();

                    $('#curtain_right').css("height", (isUCHeight + 79) + "px")
                    $('#curtain_right').css("width", (documentWidth - (isUCLeft + isUCWidth - 10)) + "px")
                    $('#curtain_right').css("top", (isUCTop - 50) + "px")
                    $('#curtain_right').css("left", (isUCLeft + isUCWidth - 10) + "px")
                    $('#curtain_right').css('opacity', 0.3);
                    $('#curtain_right').show();

                    $('#controlContainer').css('border', 'inset 2px')
                }
            }
        }
    }    
    
    
}

function showCurtain_piecesForTmpMRN() {


        var obj = $('#mrnPickContainer')
        if (obj.length == 0) {
            obj = $('.mrnSearchTable')
            var isUCWidth = $('.mrnSearchTable').width() - 50
            var isUCHeight = $('.mrnSearchTable').height() - 20
            $('#redX').css('margin-top', "30px")

        }
        else {
            var isUCWidth = obj.width() + 20
            var isUCHeight = obj.height() - 40
        }
        var isUCOffSet = obj.offset()
        var isUCLeft = isUCOffSet.left
        var isUCTop = isUCOffSet.top + 25


        var screenWidth = document.documentElement.clientWidth;
        var screenHeight = document.documentElement.clientHeight;
        var documentHeight = $(document).height();
        var documentWidth = $(document).width();
        $('#redX').css('left', (isUCLeft + isUCWidth - 50) + "px")
        $('#redX').show();
        $('#curtain_top').css("height", (isUCTop - 30) + "px")
        $('#curtain_top').css("width", screenWidth + "px")
        $('#curtain_top').css('opacity', 0.3);
        $('#curtain_top').show();

        $('#curtain_left').css("height", (documentHeight - (isUCTop - 17)) + "px")
        $('#curtain_left').css("width", (isUCLeft - 10) + "px")
        $('#curtain_left').css("top", (isUCTop - 30) + "px")
        $('#curtain_left').css('opacity', 0.3);
        $('#curtain_left').show();

        $('#curtain_bottom').css("height", (documentHeight - (isUCTop + isUCHeight + 10)) + "px")
        $('#curtain_bottom').css("width", (documentWidth - (isUCLeft - 10)) + "px")
        $('#curtain_bottom').css("top", (isUCTop + isUCHeight + 29) + "px")
        $('#curtain_bottom').css("left", (isUCLeft - 10) + "px")
        $('#curtain_bottom').css('opacity', 0.3);
        $('#curtain_bottom').show();

        $('#curtain_right').css("height", (isUCHeight + 59) + "px")
        $('#curtain_right').css("width", (documentWidth - (isUCLeft + isUCWidth - 10)) + "px")
        $('#curtain_right').css("top", (isUCTop - 30) + "px")
        $('#curtain_right').css("left", (isUCLeft + isUCWidth - 10) + "px")
        $('#curtain_right').css('opacity', 0.3);
        $('#curtain_right').show();

        $('#controlContainer').css('border', 'inset 2px')
}

function mrnIsValid() {
    var returnBool = false;
    var stng = $('.ppMRN').val();
    if (stng.length == 7) {
        var isInt = parseInt(stng)
        if (!isNaN(isInt)) {
            returnBool = true;
        }

    }

    return returnBool;
}

function showSwirley() {
    if ($.browser.version < 7) {
        $('select').hide();
    }

    $('#curtain').css('background-color', 'White')
    showCurtain()
    $('#curtain').css('opacity', .8);
    $('.swirleyContainer').html("<image style='' alt = '' src='Images/ajax-loader.gif' />");
    $('.swirleyContainer').centerInClient();
    $('.swirleyContainer').show();
    return true;

}

function hideSwirley() {
    if ($.browser.version < 7) {
        $('select').show();
    }
    $('#curtain').hide();
    $('.swirleyContainer').hide();
    return true;
}


function showCurtain() {

    var documentHeight = $(document).height();
    var documentWidth = $(document).width();
    $('#curtain').css("height", documentHeight + "px")
    $('#curtain').css("width", documentWidth + "px")
    $('#curtain').css('opacity', 0.3);
    $('#curtain').show();
    $('#controlContainer').css('border', 'inset 2px')
}
