Public Class Token

    Private _access_token As String

    Public Property access_token() As String
        Get
            Return _access_token
        End Get
        Set(value As String)
            _access_token = value
        End Set
    End Property

    Private _expires_in As Integer

    Public Property expires_in() As Integer
        Get
            Return _expires_in
        End Get
        Set(value As Integer)
            _expires_in = value
        End Set
    End Property

    Private _refresh_expires_in As Integer

    Public Property refresh_expires_in() As Integer
        Get
            Return _refresh_expires_in
        End Get
        Set(value As Integer)
            _refresh_expires_in = value
        End Set
    End Property

    Private _refresh_token As String

    Public Property refresh_token() As String
        Get
            Return _refresh_token
        End Get
        Set(value As String)
            _refresh_token = value
        End Set
    End Property

    Private _token_type As String

    Public Property token_type() As String
        Get
            Return _token_type
        End Get
        Set(value As String)
            _token_type = value
        End Set
    End Property

    Private _id_token As String

    Public Property id_token() As String
        Get
            Return _id_token
        End Get
        Set(value As String)
            _id_token = value
        End Set
    End Property

End Class
