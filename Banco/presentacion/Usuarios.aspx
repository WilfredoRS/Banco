<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Banco.CapaDatos.capalogica.capapresentacion.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
    <link href="~/CSS/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="inicio.aspx">Inicio</a></li>
                <li><a href="Clientes.aspx">Clientes</a></li>
                <li><a class="active" href="Usuarios.aspx">Usuarios</a></li>
                <li><a href="Equipos.aspx">Equipos</a></li>
            </ul>
        </div>
        <div>
            <h1>Gestion de Usuarios</h1>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay usuarios registrados"></asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblUsuarioID" runat="server" Text="Codigo del usuario"></asp:Label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo electronico"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar Usuario" OnClick="btnBorrar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar Usuario" OnClick="btnEditar_Click" />
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>