<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Banco.CapaDatos.capalogica.capapresentacion.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Equipos</title>
    <link href="~/CSS/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="inicio.aspx">Inicio</a></li>
                <li><a href="Clientes.aspx">Clientes</a></li>
                <li><a href="Usuarios.aspx">Usuarios</a></li>
                <li><a class="active" href="Equipos.aspx">Equipos</a></li>
            </ul>
        </div>
        <div>
            <h1>Gestion de Equipos</h1>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay equipos registrados"></asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblEquipoID" runat="server" Text="Codigo del equipo"></asp:Label>
            <asp:TextBox ID="txtEquipoID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblTipo" runat="server" Text="Tipo de equipo"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblUsuarioID" runat="server" Text="Codigo del usuario"></asp:Label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Equipo" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar Equipo" OnClick="btnBorrar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar Equipo" OnClick="btnEditar_Click" />
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>