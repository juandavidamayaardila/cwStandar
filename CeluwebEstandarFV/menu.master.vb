Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports System.Xml
Imports co.com.CeluwebEstandarFV.BussinesObject

Partial Class menu
    Inherits System.Web.UI.MasterPage

    Dim cadena As String
    Dim version As String = ""
    Dim ambiente As String = ""
    Dim mHtml As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Session.Timeout = 300
        Server.ScriptTimeout = 300



        cadena = ConfigurationManager.ConnectionStrings("Conexion").ToString()
        crearMenu()
        CargarVersion()

        If Not Page.IsPostBack Then
        End If

        'imagenLang.ImageUrl = Session("lang-img")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-co")
    End Sub
    Private Sub crearMenu()

        Dim dtMenuItems As New DataTable()
        'Se invoca al procedimiento almacenado
        Dim daMenu As New SqlDataAdapter("ObtenerOpcionesMenu", cadena)

        'daMenu.SelectCommand.Parameters.AddWithValue("@LENGUAJE", Session("lang").ToString())
        'Dim sesLang As String = Session("lang").ToString()
        daMenu.SelectCommand.CommandType = CommandType.StoredProcedure
        daMenu.Fill(dtMenuItems)

        Dim urlSolicitada As String = Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower()
        'bandera para la urlSolicitada
        Dim urlSolicitadaExiste As Boolean = False

        urlSolicitada = Replace(urlSolicitada, "~/", "")

        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            'Esta condicion indica q son elementos padre.
            If drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then

                If String.IsNullOrEmpty(drMenuItem("url").ToString()) Then
                    mHtml = mHtml + "<li> <a><img src=" + drMenuItem("icono") + " /></i>&nbsp;" + drMenuItem("descripcion").ToString() + "<span class='fa fa-chevron-down'></span></a> </a> "
                Else
                    If drMenuItem("descripcion").Equals("Salir") Or drMenuItem("descripcion").Equals("Exit") Then
                        mHtml = mHtml + "<li > <a runat='server' href='" + Page.ResolveClientUrl("~/" + drMenuItem("Url").ToString()) + "'> <img src=" + drMenuItem("icono") + " /> &nbsp;" + drMenuItem("descripcion").ToString() + "</a> "
                    Else
                        mHtml = mHtml + "<li> <a runat='server' href='" + Page.ResolveClientUrl("~/" + drMenuItem("url").ToString()) + "'>" + drMenuItem("descripcion").ToString() + "</a>"
                    End If
                End If

                AddMenuItem(drMenuItem("MenuId").ToString(), dtMenuItems)
                mHtml = mHtml + "</li>"
            End If
        Next



        menuHtml.Text = mHtml
    End Sub

    Private Sub AddMenuItem(ByVal MenuId As String, ByVal dtMenuItems As Data.DataTable)
        Dim con As Integer = 0

        For Each drMenuItem As Data.DataRow In dtMenuItems.Rows
            If drMenuItem("PadreId").ToString.Equals(MenuId) AndAlso Not drMenuItem("MenuId").Equals(drMenuItem("PadreId")) Then

                If con = 0 Then
                    mHtml = mHtml + "<ul class='nav child_menu'>"
                End If
                If String.IsNullOrEmpty(drMenuItem("url").ToString()) Then
                    mHtml = mHtml + "<li> <a><i class='" + drMenuItem("icono") + "'></i>&nbsp;" + drMenuItem("descripcion").ToString() + "<span class='fa fa-chevron-down'></span></a> </a> "
                Else
                    mHtml = mHtml + "<li > <a runat='server' href='" + Page.ResolveClientUrl("~/" + drMenuItem("Url").ToString()) + "'>" + drMenuItem("descripcion").ToString() + "</a> "
                End If

                con += 1
                'Llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(drMenuItem("MenuId").ToString(), dtMenuItems)
                mHtml = mHtml + "</li>"
            End If
        Next

        If con > 0 Then
            mHtml = mHtml + "</ul>"
        End If

    End Sub

    Private Sub CargarVersion()
        Try
            Dim xDoc As New XmlDocument()
            xDoc.Load(Server.MapPath("~/App_Data/AppConfig.xml"))

            Dim versionTag As XmlNodeList = xDoc.GetElementsByTagName("version")
            Dim lista As XmlNodeList = DirectCast(versionTag(0), XmlElement).GetElementsByTagName("WebVersion")

            For Each nodo As XmlElement In lista
                version = nodo.GetAttribute("value")
            Next

            lista = DirectCast(versionTag(0), XmlElement).GetElementsByTagName("Enviroment")
            For Each nodo As XmlElement In lista
                ambiente = nodo.GetAttribute("value")
            Next
        Catch ex As Exception
            Dim [error] As String = ex.Message
        End Try
    End Sub

End Class