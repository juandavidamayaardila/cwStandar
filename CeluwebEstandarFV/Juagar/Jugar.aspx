<%@ Page Title="" Language="C#" MasterPageFile="~/menu.master" AutoEventWireup="true" CodeFile="Jugar.aspx.cs" Inherits="Juagar_Jugar" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/informes.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" ID="lblTitulo" Text="VAMOR A JUGAR"></asp:Label>
                </small>
            </h1>

            <asp:Panel runat="server" ID="pnJugador" class="panel panel-default">
                <div class="panel-heading" style="text-align: center">
                    <asp:Label runat="server" Text="Registro Jugador"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="col-sm-12 col-xs-12">

                        <div class="table-responsive">
                            <table style="margin: auto;">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text="Ingrese el nombre del jugador"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtJugador"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" Text="Registrar" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="panel panel-default" runat="server" ID="pnPreguntas" Visible="false">
                <div class="panel-heading" style="text-align: center">
                    <asp:Label runat="server" Text="Pregunta"></asp:Label>
                </div>
                <div class="panel-body" style="padding-left: 30%">
                    <div>
                        <asp:Label Font-Size="XX-Large" runat="server" ID="lblPregunta" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-sm-6" id="divA" runat="server">
                            <asp:RadioButton runat="server" ID="rbA" OnCheckedChanged="rbA_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Font-Size="Medium" runat="server" ID="lblRespuesta1" Text=""></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <asp:RadioButton runat="server" ID="rbB" OnCheckedChanged="rbB_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Font-Size="Medium" runat="server" ID="lblRespuesta2" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:RadioButton runat="server" ID="rbC" OnCheckedChanged="rbC_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Font-Size="Medium" runat="server" ID="lblRespuesta3" Text=""></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <asp:RadioButton runat="server" ID="rbD" OnCheckedChanged="rbD_CheckedChanged" AutoPostBack="true" />
                            <asp:Label Font-Size="Medium" runat="server" ID="lblRespuesta4" Text=""></asp:Label>
                        </div>
                    </div>
                   
                </div>
            </asp:Panel>
            <div class="panel panel-default">
                <%--<div class="panel-heading">Lista Instructoress</div>--%>
                <div class="panel-body">

                    <div style="text-align: center">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                        <asp:Button ID="btnRetiro" runat="server" Text="Retirar del Juego" CssClass="btn btn-danger" OnClick="btnRetiro_Click" />
                    </div>
                </div>
            </div>

            <asp:Panel class="panel panel-default" runat="server" ID="pnPuntaje">
                <div class="panel-heading" style="text-align: center">
                    <asp:Label runat="server" Text="Puntaje"></asp:Label>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <asp:Label Font-Size="XX-Large" runat="server" ID="lblPuntajeActual" Text="Su puntaje es: 0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <br />
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Lista de Puntuación"></asp:Label>
                </div>
                <div class="table-responsive filtrar">
                    <asp:GridView ID="gvDatos" runat="server" AllowPaging="False" AutoGenerateColumns="False" CssClass="gvHeader  hide-column"
                        DataSourceID="dsDatos" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="nombre" ItemStyle-HorizontalAlign="left" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" InsertVisible="False" ReadOnly="True" SortExpression="fecha" ItemStyle-HorizontalAlign="left" />
                            <asp:BoundField DataField="puntaje" HeaderText="Puntaje" InsertVisible="False" ReadOnly="True" SortExpression="puntaje" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsDatos" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="HistoricoSelProc"
                        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




