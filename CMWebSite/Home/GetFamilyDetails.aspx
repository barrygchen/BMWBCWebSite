<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetFamilyDetails.aspx.cs" Inherits="CM.GetFamilyDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Styles.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/demo_page.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.13.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.dataTables.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="../Scripts/common.js" type="text/javascript"></script>
    <script src="../Scripts/CMScript.js" type="text/javascript"></script>

    <script type="text/javascript" language="JavaScript">
        var sFamilyID = "<%=szFamilyID%>";

        $(document).ready(function () {

            //debugger;
            var ssFamilyID = sFamilyID;
            GetFamilyMember(ssFamilyID);

        });

        function GetFamilyMember(ssFamilyID) {
            //debugger;
            var InfoURL = "GetFamilyMemberDetails.aspx?FamilyID=" + ssFamilyID;


              $("#reportContainer").html("<img src='../Images/ajax-loader.gif' />")
              $("#reportContainer").load(InfoURL, function () {
                  var isHTML = $("#reportContainer").html()
                  $('#reportTable').dataTable({
                      "bJQueryUI": true,

                      "sPaginationType": "two_button",
                      "aoColumns": [
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            null

                                        ]
                  });
                  $('#reportTable_filter').hide();
              });
          }


          function cancelUpdate() {

              window.opener.focus();
              window.close();
          }

          function addAnMember(a) {
              var homePhone = $("#txtFamilyPhone").val();
              if (a == 1) {
                // Adult
                  AddwMemberDetails(sFamilyID, "A", homePhone);
              }
              else {
                //Child Member
                  AddwMemberDetails(sFamilyID, "C", homePhone);
              }
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div  class="divLayout">
        <h3 class="PageFunction">Family Details</h3>
        <table style="width:100%">
            <tr  >
                 <td >
                    <table>
                        <tr>
                            <td>Family Last Names<asp:TextBox ID="txtLastNames" runat="server"></asp:TextBox> </td>
                            <td>Family Phone <asp:TextBox ID="txtFamilyPhone" runat="server"></asp:TextBox> </td>
                        </tr>
                    </table>
                </td>                                             
            </tr>
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
                                            <td>Street <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td>
                                            <td>City/Town <asp:TextBox ID="txtTown" runat="server"></asp:TextBox></td>
                                            <td>State <asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
                                            <td>Zip <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
                                             <td>Country<asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
                                            
                                        </tr>
                                        <tr>
                                             <td>Active 
                                                 <asp:RadioButton ID="rdoActive" Text="Yes" GroupName="FamilyActive" runat="server" />
                                                 <asp:RadioButton ID="rdoInActive"  GroupName="FamilyActive"  Text="No" runat="server" />
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
                    <asp:Button ID="btnUpdateFamily" runat="server"  CssClass = "buttonASP" 
                        Text="Update Family Info" onclick="btnUpdateFamily_Click" />
                </td>
                <td >
                    <asp:Button ID="Button1" runat="server"  CssClass = "buttonASP" 
                        Text="Add a Family Member" onclick="btnUpdateFamily_Click" />
                </td>
                <td >
                    <input id="btnAddAdultMember" type="button" class="buttonASP" onclick="addAnMember(1)" value="Add an Adult Family Member" />
                </td>
                  <td >
                    <input id="btnAddChildMember" type="button" class="buttonASP" onclick="addAnMember(2)" value="Add a Child Family Member" />
                </td>
                <td >
                    <input id="btnCancel" type="button" class="buttonASP" onclick="cancelUpdate()" value="Cancel" />
                </td>
            </tr>
        </table>
            <table class="sig-datatable display">
                <tr>
                    <td>
                            <div id='content'>
                        <div class='inner'>
                            <div id="reportContainer" >
                            </div> 
                        </div>
                     </div>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td> </td>
                </tr>
            </table>
             
                </div>
    </form>
</body>
</html>
