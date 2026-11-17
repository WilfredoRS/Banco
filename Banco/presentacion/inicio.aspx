<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Banco.presentacion.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>inicio</title>
     <link href="~/CSS/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <div>
              <ul>
     <li><a class="active" href="inicio.aspx">Inicio</a></li>
     <li><a href="Clientes.aspx">Clientes</a></li>
     <li><a href="Contact.aspx">Contactos</a></li>
     <li><a href="AcercaDe.aspx">Acerca de</a></li>
     </ul>
        <div>
            <asp:Image ID="Image1" runat="server" Height="602px" ImageUrl="~/imagenes/UH-01-scaled.jpg" Width="629px" />

        </div>
    </form>
</body>
</html>
