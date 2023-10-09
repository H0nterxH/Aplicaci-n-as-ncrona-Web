<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Consulta de Datos</title>
    
    <style>
        body {
            background: linear-gradient(to bottom, red, white);
            text-align: center;
        }

        .custom-button {
            width: 150px; 
            padding: 10px; 
            background-color: black;
            color: white;
            text-align: left; 
            display: block; 
            margin: 5px 0; 
        }
    </style>
</head>
<body>
    <h3>Practica</h3>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Consulta 1" OnClick="Button1_Click" CssClass="custom-button" />
            <asp:Button ID="Button2" runat="server" Text="Consulta 2" OnClick="Button2_Click" CssClass="custom-button" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" BackColor="white"></asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
