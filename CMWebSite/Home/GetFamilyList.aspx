<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetFamilyList.aspx.cs" Inherits="CM.GetFamilyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/CMScript.js" type="text/javascript"></script>
    <script type="text/javascript" language="JavaScript">
        function showFamilyDetails(familyID) {
           //debugger;
           // popuy Family Details
            showFamilyDetailPopUp(familyID);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div id="repeaterContainer" >
            <asp:Repeater ID="reportRepeater" runat="server">
            <HeaderTemplate>
                <table id="reportTable" class="reportTable" style="width: 100%">
                    <thead class="ui-state-default"  >
                        <tr>
                           <th style="text-align:center; width: 35%">Family Last Names</th>
                           <th style="text-align:center; width: 45%">Address</th>
                           <th style="text-align:center; width: 10%">Phone</th>
                           <th style="text-align:center; width: 10%">Active</th>
                            
                        </tr>
                    </thead>
                <tbody>
            </HeaderTemplate>
            
            <ItemTemplate>
                        <tr class="reportTableRow" onclick="showFamilyDetails('<%#Eval("FamilyID").ToString()%>')" >
                        
                        
                            <td class="reportTableCell"><%# Eval("FamilyLastNames").ToString()%></td>
                            <td class="reportTableCell"><%# Eval("Address").ToString()%></td>
                            <td class="reportTableCell"><%# Eval("phone").ToString()%></td>
                            <td class="reportTableCell"><%# GetActiveStatus(Eval("isActive").ToString())%></td>
                            
                           
                        </tr>
            </ItemTemplate  >
            
            <FooterTemplate >
                    </tbody>
                </table>
            </FooterTemplate>                        
        </asp:Repeater>
        </div>
    </form>
</body>
</html>
