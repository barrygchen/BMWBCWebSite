<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FamilyList.aspx.cs" Inherits="CM.FamilyList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
        <script type="text/javascript" src="../Scripts/jquery.dataTables.js"></script>
      <script type="text/javascript" language="JavaScript">

          $(document).ready(function () {

              GetFamilyList("all");

          });

          function GetFamilyList(listType) {

              var InfoURL = "GetFamilyList.aspx?FamilyStatus=" + listType;


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
                                            null

                                        ]
                  });
                  $('#reportTable_filter').hide();
              });
          }

          function GetFamily() {
             
              var selectedIndex = $('#<%= ddlListFamily.ClientID%>').get(0).selectedIndex;

              var listType = "all";
              if (selectedIndex == 1) {
                  listType = "yes";
              }
              else if (selectedIndex == 2) {
                  listType = "no";
              }

              // now rerender the list
              GetFamilyList(listType);

              //var index = $("#ddlListFamily").get(0).selectedIndex;
          }
      </script>

       <div  class="divLayout">
        <h3 class="PageFunction">Church Family List</h3>
        <table style="width:100%">
            <tr  >
                 <td style="text-align:right; width: 200">
                    Show Family: <asp:DropDownList ID="ddlListFamily" runat="server"></asp:DropDownList> <input id="btnshowList" class='buttonASP' type="button" value="Get Family List" onclick="GetFamily()" />   
                </td>                                              
            </tr>
        </table>
        <table>
            <tr>
                <td >
               
                
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
             
                </div>
</asp:Content>
