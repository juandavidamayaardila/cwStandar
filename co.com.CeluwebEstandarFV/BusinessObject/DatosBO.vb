Imports System.Data.SqlClient
Imports co.com.CeluwebEstandarFV.DataBase

Namespace BussinesObject


    Public Class DatosBO

        Dim _cadenaConexion As String
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        Dim conexion As Conexion


        Sub New(ByVal cadenaConexion As String)
            Me._cadenaConexion = cadenaConexion

        End Sub

        Function CrearPreguntas(ByVal pregunta As Pregunta) As String

            Dim respuesta As String = "error"

            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "PreguntasInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@categoria", pregunta._categoria)
                comando.Parameters.AddWithValue("@pregunta", pregunta._descripcion)
                comando.Parameters.AddWithValue("@respuestaVerdadera", pregunta._respuetaVerdadera)
                comando.Parameters.AddWithValue("@respuestaFalsa1", pregunta._respuestaFalsa1)
                comando.Parameters.AddWithValue("@respuestaFalsa2", pregunta._respuestaFalsa2)
                comando.Parameters.AddWithValue("@respuestaFalsa3", pregunta._respuestaFalsa3)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        respuesta = reader("respuesta")

                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return respuesta
        End Function


        Function ActualizarPreguntas(ByVal pregunta As Pregunta) As String
            Dim respuesta As String = ""

            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "PreguntaUpdateProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", pregunta._codigo)
                comando.Parameters.AddWithValue("@categoria", pregunta._categoria)
                comando.Parameters.AddWithValue("@pregunta", pregunta._descripcion)
                comando.Parameters.AddWithValue("@respuestaVerdadera", pregunta._respuetaVerdadera)
                comando.Parameters.AddWithValue("@respuestaFalsa1", pregunta._respuestaFalsa1)
                comando.Parameters.AddWithValue("@respuestaFalsa2", pregunta._respuestaFalsa2)
                comando.Parameters.AddWithValue("@respuestaFalsa3", pregunta._respuestaFalsa3)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        respuesta = reader("respuesta")

                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return respuesta
        End Function

        Function EliminarPreguntas(ByVal pregunta As Pregunta) As String
            Dim respuesta As String = ""

            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "PreguntaDelPrco"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", pregunta._codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        respuesta = reader("respuesta")

                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return respuesta
        End Function


        Function ObtenerInfoPregunta(ByVal pregunta As Pregunta) As Pregunta
            Dim respuesta As String = ""
            Dim pre As Pregunta = New Pregunta()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "PreguntaSelPrco"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@codigo", pregunta._codigo)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read

                        pre._categoria = reader("categoria").ToString()
                        pre._descripcion = reader("pregunta").ToString()
                        pre._respuetaVerdadera = reader("respuestaVerdadera").ToString()
                        pre._respuestaFalsa1 = reader("respuestaFalsa1").ToString()
                        pre._respuestaFalsa2 = reader("respuestaFalsa2").ToString()
                        pre._respuestaFalsa3 = reader("respuestaFalsa3").ToString()

                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return pre
        End Function


        Function obtenerPreguntas(ByVal categoria As String) As Pregunta
            Dim respuesta As String = ""
            Dim pre As Pregunta = New Pregunta()
            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "SeleccionarPreguntaSelProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@categoria", categoria)


                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        pre._categoria = reader("categoria").ToString()
                        pre._descripcion = reader("pregunta").ToString()
                        pre._respuetaVerdadera = reader("respuestaVerdadera").ToString()
                        pre._respuestaFalsa1 = reader("respuestaFalsa1").ToString()
                        pre._respuestaFalsa2 = reader("respuestaFalsa2").ToString()
                        pre._respuestaFalsa3 = reader("respuestaFalsa3").ToString()

                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return pre
        End Function


        Function registrarResultado(ByVal nombre As String, ByVal puntaje As Int32) As String
            Dim respuesta As String = "error"

            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "PuntajeInsProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD
                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@puntaje", puntaje)

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        respuesta = reader("respuesta").ToString()
                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return respuesta
        End Function


        Function validarPreguntas() As String
            Dim respuesta As String = "error"

            comando = New SqlCommand()
            conexion = New DataBase.Conexion(_cadenaConexion)

            Try
                comando.CommandText = "ValidarNumeroPreguntasSelProc"
                comando.CommandType = CommandType.StoredProcedure
                comando.Connection = conexion.getConexionBD

                conexion.openConexion()
                reader = comando.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read
                        respuesta = reader("respuesta").ToString()
                    End While
                End If
            Catch ex As Exception
                Dim errorT As String = ex.Message
            Finally
                conexion.CloseConexion()
            End Try

            Return respuesta
        End Function
    End Class
End Namespace