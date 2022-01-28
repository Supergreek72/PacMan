'Dimitri Papadedes
'June 13th 2018
'make a game of Pacman 
Public Class Form2
    Public startHighScore As Integer

#Region "Start"
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Me.Hide()
        Form1.Show()



    End Sub
#End Region
#Region "Load"
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim infile As System.IO.StreamReader = New System.IO.StreamReader("HighScore.txt")

        'show high score
        startHighScore = infile.ReadLine
        lblHighScore.Text = startHighScore
        infile.Close()




    End Sub
#End Region
#Region "Close"
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
#End Region
#Region "Move"
    Private Sub Timer_Ghost_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Ghost.Tick
        'move pacman
        Pacman.Location = New Point(Pacman.Location.X + 3, Pacman.Location.Y)

        'move ghosts
        GhostRed.Location = New Point(GhostRed.Location.X + 3, GhostRed.Location.Y)
        ghostBlue.Location = New Point(ghostBlue.Location.X + 3, ghostBlue.Location.Y)
        GhostPink.Location = New Point(GhostPink.Location.X + 3, GhostPink.Location.Y)
        GhostOrange.Location = New Point(GhostOrange.Location.X + 3, GhostOrange.Location.Y)

        'put ghost back
        If GhostRed.Bounds.IntersectsWith(ghostmove2.Bounds) Then
            GhostRed.Location = New Point(-32, 370)
        End If

        If ghostBlue.Bounds.IntersectsWith(ghostmove2.Bounds) Then
            ghostBlue.Location = New Point(-32, 370)
        End If

        If GhostPink.Bounds.IntersectsWith(ghostmove2.Bounds) Then
            GhostPink.Location = New Point(-32, 370)
        End If

        If GhostOrange.Bounds.IntersectsWith(ghostmove2.Bounds) Then
            GhostOrange.Location = New Point(-32, 370)
        End If

        'move pacman back
        If Pacman.Bounds.IntersectsWith(ghostmove2.Bounds) Then
            Pacman.Location = New Point(-25, 370)
        End If

    End Sub
#End Region

End Class