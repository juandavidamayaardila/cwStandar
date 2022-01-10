<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/menu.master" CodeFile="ConfiguracionPreguntas.aspx.cs" Inherits="Administracion_ConfiguracionPreguntas" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="panel-heading-icon">
                <img src="../styles/icons/gestion.png" />
            </div>
            <h1 class="page-header">
                <small>
                    <asp:Label runat="server" Text="Administración de Preguntas"></asp:Label>
                </small>
            </h1>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Preguntas"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class=" table-responsive">
                        <table style="margin: auto;">
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Categoria"></asp:Label>:
                                </td>
                                <td colspan="2">
                                    <asp:HiddenField runat="server" ID="hfIdTabla" />
                                    <asp:DropDownList ID="ddlCategoria" runat="server" DataSourceID="dsCategoria" DataTextField="categoria" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"
                                        DataValueField="id" CssClass='form-control' Width="196px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsCategoria" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>"
                                        SelectCommand="CategoriasSelProc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label runat="server" Text="Pregunta"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPregunta" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="validator" runat="server" ControlToValidate="txtPregunta"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label runat="server" Text="Respuesta Verdadera"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRespuestaVerdadera" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRespuestaVerdadera"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label runat="server" Text="Respuesta Falsa"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRespuestaFalsa1" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRespuestaFalsa1"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label runat="server" Text="Respuesta Falsa"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRespuestaFalsa2" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRespuestaFalsa2"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label runat="server" Text="Respuesta Falsa"></asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRespuestaFalsa3" runat="server" CssClass='form-control'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRespuestaFalsa3"
                                        ErrorMessage=" * "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <div style="text-align: center">
                            <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
                            <asp:Button ID="btnModificar" runat="server" CausesValidation="False" Text="Modificar" OnClick="btnModificar_Click"
                                Visible="False" CssClass="btn btn-success" />
                            <asp:Button ID="btnEliminar" runat="server" CausesValidation="False" Text="Eliminar"
                                Visible="False" CssClass="btn btn-danger" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False"
                                CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Label runat="server" Text="Lista de Preguntas por Categoria"></asp:Label>
                </div>
                <div class="table-responsive filtros" style="overflow: auto; max-height: 300px;">
                    <asp:GridView ID="gvPregutnas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="gvHeader filtrar hide-column"
                        DataSourceID="dsPreguntas" EnableModelValidation="True" DataKeyNames="id" OnRowCommand="gvPregutnas_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:Button ID="btnRegistrar" CommandArgument='<%# Eval("id")%>' CommandName="seleccionar" runat="server" CausesValidation="false" Text='Seleccionar' CssClass="btn btn-link"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="codigo" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="pregunta" HeaderText="Descripcion" SortExpression="descripcion" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="respuestaVerdadera" HeaderText="Respuesta Verdadera" SortExpression="respuestaVerdadera" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="respuestaFalsa1" HeaderText="Respuesta Falsa" SortExpression="respuestaFalsa1" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="respuestaFalsa2" HeaderText="Respuesta Falsa" SortExpression="respuestaFalsa2" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="respuestaFalsa3" HeaderText="Respuesta Falsa" SortExpression="respuestaFalsa3" ItemStyle-HorizontalAlign="Left"></asp:BoundField>


                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsPreguntas" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="PreguntaGVSelProc" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCategoria" Name="categoria" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

