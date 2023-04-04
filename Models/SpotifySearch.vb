Public Class SpotifySearch
    Public Class ExternalUrls
        Public Property spotify As String
    End Class

    Public Class Followers
        Public Property href As Object
        Public Property total As Integer
    End Class

    Public Class ImageSp
        Public Property width As Integer
        Public Property url As String
        Public Property height As Integer
    End Class

    Public Class Item
        Public Property external_urls As ExternalUrls
        Public Property followers As Followers
        Public Property genres As List(Of String)
        Public Property href As String
        Public Property id As String
        Public Property images As List(Of ImageSp)
        Public Property name As String
        Public Property popularity As Integer
        Public Property type As String
        Public Property uri As String
    End Class

    Public Class Artists
        Public Property href As String
        Public Property items As List(Of Item)
        Public Property limit As Integer
        Public Property [next] As String
        Public Property offset As Integer
        Public Property previous As Object
        Public Property total As Integer
    End Class

    Public Class SpotifyResult
        Public Property artists As Artists
    End Class
End Class
