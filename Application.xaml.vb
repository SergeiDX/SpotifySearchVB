Class Application
    Private txtSearch As Object

    Public Sub New()
        InitializeComponent()
        Task.Run(Async Function() Await SearchHelper.GetTokenAsync())
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim result = SearchHelper.SearchArtistOrSong(txtSearch.Text)

        If result Is Nothing Then
            Return
        End If

        Dim listArtist = New List(Of SpotifyArtist)()

        For Each item In result.artists.items
            listArtist.Add(New SpotifyArtist() With {
                .ID = item.id,
                .Image = If(item.images.Any(), item.images(0).url, "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png"),
                .Name = item.name,
                .Popularity = $"{item.popularity}% popularidad",
                .Followers = $"{item.followers.total.ToString("N")} seguidores"
            })
        Next
        listArtist.ItemSource = listArtist
    End Sub
End Class
