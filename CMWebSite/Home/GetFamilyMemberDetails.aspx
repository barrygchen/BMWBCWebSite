<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetFamilyMemberDetails.aspx.cs" Inherits="CM.GetFamilyMemberDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Scripts/CMScript.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
   
          <div id="repeaterContainer" >
            <asp:Repeater ID="reportRepeater" runat="server">
            <HeaderTemplate>
                <table id="reportTable" class="reportTable" style="width: 100%">
                    <thead class="ui-state-default"  >
                        <tr>
                           <th style="text-align:center; width: 20%">Name</th>
                           <th style="text-align:center; width: 10%">Gender</th>
                           <th style="text-align:center; width: 20%">Phone</th>
                           <th style="text-align:center; width: 10%">Email</th>
                           <th style="text-align:center; width: 10%">Adult(A)/Child(C)</th>
                           <th style="text-align:center; width: 10%">IsChristian</th>
                           <th style="text-align:center; width: 10%">Active</th>
                            
                            
                        </tr>
                    </thead>
                <tbody>
            </HeaderTemplate>
            
            <ItemTemplate>
                        <tr class="reportTableRow" onclick="showMemberDetails('<%#Eval("FamilyID").ToString()%>', '<%#Eval("PersonID").ToString()%>', '<%#Eval("MemberTable").ToString()%>', 'yes')" >
                        
                        
                            <td class="reportTableCell"><%# Eval("Name").ToString()%></td>
                            <td class="reportTableCell"><%# Eval("Sex").ToString()%></td>
                            <td class="reportTableCell"><%# Eval("Home_Phone").ToString()%></td>
                            <td class="reportTableCell"><%# Eval("Email").ToString()%></td>
                            <td class="reportTableCell"><%# Eval("MemberTable").ToString()%></td>
                            <td class="reportTableCell"><%# GetChristianStatus(Eval("isChristian").ToString())%></td>
                            <td class="reportTableCell"><%# GetActiveStatus(Eval("isActive").ToString())%></td>
                          
                            
                           
                        </tr>
            </ItemTemplate  >
            
            <FooterTemplate >
                    </tbody>
                </table>
            </FooterTemplate>                        
        </asp:Repeater>
        </div>
   
</body>
</html>
