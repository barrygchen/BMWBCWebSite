<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CMWebSite.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/menustyle.css" rel="stylesheet" type="text/css" />
    <style>
    .menu,
	.menu ul,
	.menu li,
	.menu a {
	    margin: 0;
	    padding: 0;
	    border: none;
	    outline: none;
	}
	 
	.menu {
	    height: 40px;
	    width: 505px;
	 
	    background: #4c4e5a;
	    background: -webkit-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
	    background: -moz-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
	    background: -o-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
	    background: -ms-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
	    background: linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
	 
	    -webkit-border-radius: 5px;
	    -moz-border-radius: 5px;
	    border-radius: 5px;
	}
	 
	.menu li {
	    position: relative;
	    list-style: none;
	    float: left;
	    display: block;
	    height: 40px;
	}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="menu">
	 
	    <li><a href="#">My dashboard</a></li>
	    <li><a href="#">Likes</a></li>
	    <li><a href="#">Views</a>
	 
	        <ul>
	            <li><a href="#" class="documents">Documents</a></li>
	            <li><a href="#" class="messages">Messages</a></li>
	            <li><a href="#" class="signout">Sign Out</a></li>
	        </ul>
	 
	    </li>
	    <li><a href="#">Uploads</a></li>
	    <li><a href="#">Videos</a></li>
	    <li><a href="#">Documents</a></li>
	 
	</ul>
    </form>
</body>
</html>
