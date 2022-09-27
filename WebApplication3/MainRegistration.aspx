<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainRegistration.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 1080px">
    <form id="form1" runat="server">
        <div style="width: 1080px">
            Sample Event Registration Page (but not very pretty)</div>
        <p style="width: 1080px">
            Username*:
            <asp:TextBox ID="UsernameText" runat="server" Width="205px"></asp:TextBox>
        </p>
        <p style="width: 531px">
            Name:&emsp;&emsp;&nbsp;&nbsp;&nbsp; Title:&emsp; First name*:&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp; Middle Initial:&emsp;&emsp;Last Name*:</p>
        <p style="margin-left: 80px; width: 988px;">
&nbsp;
            <asp:TextBox ID="UserTitleText" runat="server" Width="32px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:TextBox ID="UserFirstText" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="UserMiddleText" runat="server" Width="32px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="UserLastText" runat="server" Width="150px"></asp:TextBox>
        </p>
        <p>

            Email Address*:&emsp;
            <asp:TextBox ID="UserEmail" runat="server" Width="250px"></asp:TextBox>

        </p>
        <p>

            Phone Number*:&emsp;
            <asp:TextBox ID="UserPhone" runat="server" Width="250px"></asp:TextBox>

        </p>
        <p>

            Favorite Color:&emsp;&emsp;
            <asp:TextBox ID="UserBlah" runat="server" Width="250px"></asp:TextBox>

        </p>
        <p>

            Which role are you attending as?*&emsp;
            <asp:DropDownList ID="UserRole" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="UserRole_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Attendee</asp:ListItem>
                <asp:ListItem>Employee</asp:ListItem>
                <asp:ListItem>Sponsor</asp:ListItem>
            </asp:DropDownList>

        </p>
        
        <asp:Label ID="RoleQs" runat="server" Text="Extra Questions:" Visible="false"></asp:Label> <br />
        <asp:Label ID="LabelReception" runat="server" Text="Will you be attending the welcome reception?" Visible="false"></asp:Label> <br />
        <asp:DropDownList ID="UserReception" runat="server" Visible="false">
            <asp:ListItem>No</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="LabelShirt" runat="server" Text="What is your T-shirt size?*" Visible="false"></asp:Label> <br />
        <asp:DropDownList ID="UserTShirt" runat="server" Visible="false">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Small</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>Large</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="LabelDiet" runat="server" Text="Do you have any special dietary requirements?" Visible="false"></asp:Label> <br />
        <asp:TextBox ID="UserFood" runat="server" Width="400" Visible="false"></asp:TextBox><br />
        <asp:Label ID="LabelCompany" runat="server" Text="What company is your sponsorship representing?*" Visible="false"></asp:Label> <br />
        <asp:TextBox ID="UserCompany" runat="server" Width="150" Visible="false"></asp:TextBox><br />
        <asp:Label ID="LabelRegion" runat="server" Text="What region do you work in?" Visible="false"></asp:Label> <br />
        <asp:DropDownList ID="UserRegion" runat="server" Visible="false">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>East</asp:ListItem>
            <asp:ListItem>Central</asp:ListItem>
            <asp:ListItem>West</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Visible="false" OnClick="ButtonSubmit_Click" />
        <br />
        <asp:Label ID="LabelUhOh" runat="server" Text=""></asp:Label>
        <br />
    </form>
</body>
</html>
