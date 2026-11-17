<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cuentas.aspx.cs" Inherits="Banco.CapaDatos.capalogica.capapresentacion.Cuentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cuentas</title>
    <link href="~/CSS/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="inicio.aspx">Inicio</a></li>
                <li><a href="Clientes.aspx">Clientes</a></li>
                <li><a class="active" href="Cuentas.aspx">Cuentas</a></li>
                <li><a href="Contact.aspx">Contactos</a></li>
                <li><a href="AcercaDe.aspx">Acerca de</a></li>
            </ul>
        </div>
        <div>
            <h1>Gestion de Cuentas</h1>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay cuentas registradas"></asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblCodigo" runat="server" Text="Codigo"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCodigoCliente" runat="server" Text="Codigo del cliente"></asp:Label>
            <asp:TextBox ID="txtCodigoCliente" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cuenta" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar Cuenta" OnClick="btnBorrar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar Cuenta" OnClick="btnEditar_Click" />
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
