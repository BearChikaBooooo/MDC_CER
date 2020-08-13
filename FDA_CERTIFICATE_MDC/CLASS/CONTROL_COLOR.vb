Public Class CONTROL_COLOR
    Private _COLOR As String
    Public Property COLOR() As String
        Get
            Return _COLOR
        End Get
        Set(ByVal value As String)
            _COLOR = value
        End Set
    End Property
    Public Function color_head(ByVal p As String)
        Dim pp As String = ""
        If p = "1" Then
            pp = "<header class=header style=background:#dd99be;>"
        Else
            pp = "<header class=header style=background:#8CB343;>"
        End If
        Return pp
    End Function
    Public Function color_span(ByVal p As String)
        Dim pp As String = ""
        If p = "1" Then
            pp = "<span class=circle  style=background:#dd99be></span>"
        Else
            pp = "<span class=circle  style=background:#8CB343></span>"
        End If
        Return pp
    End Function
    Public Function color_div(ByVal p As String)
        Dim pp As String = ""
        If p = "1" Then
            pp = "<div class=nav-catagory  style=background:#dd99be>"
        Else
            pp = "<div class=nav-catagory  style=background:#8CB343>"
        End If
        Return pp
    End Function
    Public Function color_footer(ByVal p As String)
        Dim pp As String = ""
        If p = "1" Then
            pp = "<footer class=footer style=background:#dd99be;>"
        Else
            pp = "<footer class=footer >"
        End If
        Return pp
    End Function
End Class
