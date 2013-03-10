<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAMember.aspx.cs" Inherits="CM.AddAMember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Styles.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/demo_page.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.13.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>

    <script src="../Scripts/CMScript.js" type="text/javascript"></script>
    <script src="../Scripts/MemberDetailsProcess.js" type="text/javascript"></script>
    <script type="text/javascript" language="JavaScript">
        var strFamilyID = "<%=szFamilyID%>";

        function AddOneMember() {
            debugger;
            var lastName = $("#txtLastName").val();
            var firstName = $("#txtFirstName").val();
            var middleInitial = $("#txtMiddleInitial").val();
            var gender = $("#txtGender").val();
            var DOB = $("#txtDOB").val();
            var homePhone = $("#txtHomePhone").val();
            //var phone = $("#txtPhone").val();
            var cellPhone = $("#txtCellPhone").val();
            var businessPhone = $("#txtBusinessPhone").val();
            var Email = $("#TxtEmail").val();
            var Fellowship = $("#txtFellowship").val();
            var bChristain = true;
            if ($('#rdoChristainYes').is(':checked')) {
                bChristain = true;
            }
            else {
                bChristain = false;
            }

            var bCharterMember = true;
            if ($('#rdoCharterMemberYes').is(':checked')) {
                bCharterMember = true;
            }
            else {
                bCharterMember = false;
            }

            var bShowinDirectory = true;
            if ($('#rdoShowinDirectoryYes').is(':checked')) {
                bShowinDirectory = true;
            }
            else {
                bShowinDirectory = false;
            }

            var bActive = true;
            if ($('#rdoActive').is(':checked')) {
                bActive = true;
            }
            else {
                bActive = false;
            }
            debugger;

            AddChurchMember(lastName, firstName, middleInitial, gender, DOB, homePhone, cellPhone, businessPhone, Email, Fellowship, bChristain, bCharterMember, bShowinDirectory, bActive);


        }


        function AddChurchMember(lastName, firstName, middleInitial, gender, DOB, homePhone, cellPhone, businessPhone, Email, Fellowship, bChristain, bCharterMember, bShowinDirectory, bActive) {

            debugger;
            $.ajax({
                type: "POST",
                url: "../JQueryAjaxProcess.aspx/AddChurchMember",

                data: "{'FamilyID':'" + strFamilyID + "','lastName':'" + lastName + "', 'firstName' : '" + firstName + "', 'middleInitial' : '" + middleInitial + "', 'gender' : '" + gender + "', 'DOB' : '" + DOB + "', 'homePhone' : '" + homePhone +
                  "', 'cellPhone' : '" + cellPhone + "', 'businessPhone' : '" + businessPhone + "', 'Email' : '" + Email + "', 'Fellowship' : '" + Fellowship + "', 'bChristain' : '" + bChristain +
                   "', 'bCharterMember' : '" + bCharterMember + "', 'bShowinDirectory' : '" + bShowinDirectory + "', 'bActive' : '" + bActive + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {


                    // refresh the grid;
                    debugger;
                    window.opener.GetFamilyMember(strFamilyID);
                    window.opener.focus();
                    window.close();

                }
            });
        }



        function cancelAdd() {

            window.opener.focus();
            window.close();
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div  class="divLayout">
        <h3 class="PageFunction">Add an Member</h3>
        <table style="width:100%">
            <tr>
                <td>
                    <div class="blockAddress">
                        <table>
                            <tr>
                                <td>
                                    Address
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Last Name <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                                            <td>First Name <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                                            <td>Middle Initial <asp:TextBox ID="txtMiddleInitial" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Sex <asp:TextBox ID="txtGender" runat="server"></asp:TextBox></td>
                                            <td>Date of Birth <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox></td>
                                            <td></td>
                                        </tr>
                                         <tr>
                                            <td runat="server" id="tdHomePhone" >Home Phone <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox></td>
                                            <td runat="server" id="tdPhone" visible="false" >Phone <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                                            <td runat="server" id="tdCellPhone" >Cell Phone <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox></td>
                                            <td runat="server" id="tdBusinessPhone" >Business Phone <asp:TextBox ID="txtBusinessPhone" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Email <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox></td>
                                            <td runat="server" id="tdFellowship">Fellowship <asp:TextBox ID="txtFellowship" runat="server"></asp:TextBox></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                             <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Christain 
                                                            <asp:RadioButton ID="rdoChristainYes" Text="Yes" GroupName="Christain" runat="server" />
                                                            <asp:RadioButton ID="rdoChristainNo"  GroupName="Christain"  Text="No" runat="server" />
                                                        </td>
                                                         <td>
                                                            CharterMember
                                                            <asp:RadioButton ID="rdoCharterMemberYes" Text="Yes" GroupName="CharterMember" runat="server" />
                                                            <asp:RadioButton ID="rdoCharterMemberNo"  GroupName="CharterMember"  Text="No" runat="server" />
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td>
                                                            Show in Directory
                                                            <asp:RadioButton ID="rdoShowinDirectoryYes" Text="Yes" GroupName="ShowinDirectory" runat="server" />
                                                            <asp:RadioButton ID="rdoShowinDirectoryNo"  GroupName="ShowinDirectory"  Text="No" runat="server" />
                                                        </td>
                                                         <td>
                                                            Active
                                                            <asp:RadioButton ID="rdoActive" Text="Yes" GroupName="FamilyActive" runat="server" />
                                                            <asp:RadioButton ID="rdoInActive"  GroupName="FamilyActive"  Text="No" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                             </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td >
                    <input id="btnAddMember" type="button" class="buttonASP" onclick="AddOneMember()" value="Add a Member" />
                </td>
                 <td >
                    <input id="btnCancel" type="button" class="buttonASP" onclick="cancelAdd()" value="Cancel" />
                </td>
            </tr>
        </table>
         
             
                </div>
    </form>
</body>
</html>
