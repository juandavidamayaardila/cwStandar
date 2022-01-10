
Namespace BussinesObject

    'Esta clase Pregunta contien las propiedades de codigo, 
    '    pregunta, respuestas falsas
    Public Class Pregunta
        Private codigo As Integer
        Public Property _codigo() As Integer
            Get
                Return codigo
            End Get
            Set(ByVal value As Integer)
                codigo = value
            End Set
        End Property


        Private descripcion As String
        Public Property _descripcion() As String
            Get
                Return descripcion
            End Get
            Set(ByVal value As String)
                descripcion = value
            End Set
        End Property

        Private categoria As String
        Public Property _categoria() As String
            Get
                Return categoria
            End Get
            Set(ByVal value As String)
                categoria = value
            End Set
        End Property

        Private respuetaVerdadera As String
        Public Property _respuetaVerdadera() As String
            Get
                Return respuetaVerdadera
            End Get
            Set(ByVal value As String)
                respuetaVerdadera = value
            End Set
        End Property

        Private respuestaFalsa1 As String
        Public Property _respuestaFalsa1() As String
            Get
                Return respuestaFalsa1
            End Get
            Set(ByVal value As String)
                respuestaFalsa1 = value
            End Set
        End Property

        Private respuestaFalsa2 As String
        Public Property _respuestaFalsa2() As String
            Get
                Return respuestaFalsa2
            End Get
            Set(ByVal value As String)
                respuestaFalsa2 = value
            End Set
        End Property

        Private respuestaFalsa3 As String
        Public Property _respuestaFalsa3() As String
            Get
                Return respuestaFalsa3
            End Get
            Set(ByVal value As String)
                respuestaFalsa3 = value
            End Set
        End Property

        'Constructor con los parametros necesario para instanciar la clase
        Sub New(ByVal categoria As String, ByVal descripcion As String, ByVal respuestaVerdadera As String, ByVal respuestaFalsa1 As String, ByVal respuestaFalsa2 As String, ByVal respuestaFalsa3 As String)


            Me.categoria = categoria
            Me.descripcion = descripcion
            Me.respuetaVerdadera = respuestaVerdadera
            Me.respuestaFalsa1 = respuestaFalsa1
            Me.respuestaFalsa2 = respuestaFalsa2
            Me.respuestaFalsa3 = respuestaFalsa3

        End Sub

        Sub New(ByVal codigo As String, ByVal categoria As String, ByVal descripcion As String, ByVal respuestaVerdadera As String, ByVal respuestaFalsa1 As String, ByVal respuestaFalsa2 As String, ByVal respuestaFalsa3 As String)

            Me.codigo = codigo
            Me.categoria = categoria
            Me.descripcion = descripcion
            Me.respuetaVerdadera = respuestaVerdadera
            Me.respuestaFalsa1 = respuestaFalsa1
            Me.respuestaFalsa2 = respuestaFalsa2
            Me.respuestaFalsa3 = respuestaFalsa3

        End Sub


        Sub New(ByVal codigo As String)
            Me.codigo = codigo
        End Sub

        Sub New()

        End Sub

    End Class
End Namespace