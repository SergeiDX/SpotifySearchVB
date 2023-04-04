Imports SpotifySearchVB.SpotifySearch
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports RestSharp
Imports SpotifySearch.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports SpotifySearch.Models.SpotifySearch

Public Class SearchHelper
    Public Shared Property token As Token

    Public Shared Async Function GetTokenAsync() As Task
        Dim clientID As String = "41bb3e95853047699c0bad73a41fe977"
        Dim clientSecret As String = "c6a26ff8c34c4125bb0cf9290440edd4"
        Dim auth As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientID & ":" & clientSecret))
        Dim args As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String)) From {
            New KeyValuePair(Of String, String)("grant_type", "client_credentials")
        }
        Dim client As HttpClient = New HttpClient()
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}")
        Dim content As HttpContent = New FormUrlEncodedContent(args)
        Dim resp As HttpResponseMessage = Await client.PostAsync("https://accounts.spotify.com/api/token", content)
        Dim msg As String = Await resp.Content.ReadAsStringAsync()
        token = JsonConvert.DeserializeObject(Of Token)(msg)
    End Function

    Public Shared Function SearchArtistOrSong(ByVal searchWord As String) As SpotifyResult
        Dim client = New RestClient("https://api.spotify.com/v1/search")
        client.AddDefaultHeader("Authorization", $"Bearer {token.access_token}")
        Dim request = New RestRequest($"?q={searchWord}&type=artist", Method.[Get])
        Dim response = client.Execute(request)

        If response.IsSuccessful Then
            Dim result = JsonConvert.DeserializeObject(Of SpotifyResult)(response.Content)
            Return result
        Else
            Return Nothing
        End If
    End Function
End Class
