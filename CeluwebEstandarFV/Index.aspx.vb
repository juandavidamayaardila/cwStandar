Imports co.com.CeluwebEstandarFV
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Partial Class Index
    Inherits System.Web.UI.Page
    Private login As Login
    Dim version As String = ""
    Dim ambiente As String = ""

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarVersion()
        If IsPostBack = False Then
            Response.Redirect("Administracion/ConfiguracionPreguntas.aspx")
        End If
    End Sub

    Protected Sub bIngresar_Click(sender As Object, e As EventArgs) Handles bIngresar.Click

        Response.Redirect("Administracion/ConfiguracionPreguntas.aspx")

    End Sub
End Class
