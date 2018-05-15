Public Class DocumentoMedioPago

    Private _codigo As String
    Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property

End Class
