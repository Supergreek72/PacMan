'Dimitri Papadedes
'May, 19, 2018
'make a game of pacman
Public Class Form1
    Dim start As Boolean = False
    Dim pacmanImage As New Label
    Dim direction As New Label
    Dim score As Integer = 0
    Dim dots As Integer = 0
    Dim cherry_time As Boolean = False
    Dim BigDots As Integer = 0
    Dim music As Boolean = False
    Dim start1 As Boolean = True
    Dim lives As Integer = 3
    Dim sound As Boolean = True
    Dim close_Game As Boolean = False
    Dim Reddirection As New Label
    Dim startRedGhost As Boolean = True
    Dim pinkdirection As New Label
    Dim startPinkGhost As Boolean = True
    Dim bluedirection As New Label
    Dim startBlueGhost As Boolean = True
    Dim Orangedirection As New Label
    Dim startorangeGhost As Boolean = True
    Dim Ghost_Eatable(3) As Boolean
    Dim printhighscore As Boolean = True




#Region "Move Pacman"
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        'move ghost 
        RedGhost_Timer.Enabled = True

        'move ghost 
        PinkGhost_Timer.Enabled = True

        'move ghost 
        BlueGhost_Timer.Enabled = True

        'move ghost 
        OrangeGhost_Timer.Enabled = True

        'clear label
        lblReady.Text = Nothing

        'set image to nothing                                                 
        Pacman.Image = Nothing

        'push ready to the back 
        lblReady.SendToBack()

        'start cherry timer 
        Cherry_timer.Enabled = True

        If e.KeyCode = Keys.Right Then
            direction.Text = "right"
            'start timer 
            Pacman_time.Enabled = True

            If sound = True Then
                'play sound 
                My.Computer.Audio.Play("pacman_chomp.wav", AudioPlayMode.BackgroundLoop)
                sound = False
            End If
        End If

        If e.KeyCode = Keys.Left Then
            direction.Text = "left"
            'start timer 
            Pacman_time.Enabled = True

            If sound = True Then
                'play sound 
                My.Computer.Audio.Play("pacman_chomp.wav", AudioPlayMode.BackgroundLoop)
                sound = False
            End If
        End If

        If e.KeyCode = Keys.Down Then
            direction.Text = "down"
            'start timer 
            Pacman_time.Enabled = True

            If sound = True Then
                'play sound 
                My.Computer.Audio.Play("pacman_chomp.wav", AudioPlayMode.BackgroundLoop)
                sound = False
            End If
        End If

        If e.KeyCode = Keys.Up Then
            direction.Text = "up"
            'start timer 
            Pacman_time.Enabled = True

            If sound = True Then
                'play sound 
                My.Computer.Audio.Play("pacman_chomp.wav", AudioPlayMode.BackgroundLoop)
                sound = False
            End If
        End If



    End Sub
#End Region
#Region "Timer"
    Private Sub Pacman_time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pacman_time.Tick

        'change high score 
        If score > Form2.startHighScore Then
            Form2.startHighScore = score
            lblHighScore.Text = Form2.startHighScore
        End If

        'close game after done 
        If close_Game = True Then
            System.Threading.Thread.Sleep(3450)
            Me.Close()
            Form2.Show()
            lives = 3
            score = 0
            Pacman_time.Enabled = False
        End If

        'start game 
        If start = False Then
            System.Threading.Thread.Sleep(4450)
            start = True
        End If

        'start after death
        If start1 = False Then
            System.Threading.Thread.Sleep(4450)
            start1 = True
        End If


        'change directions 

        'move right 
        If direction.Text = "right" Then

            Pacman.Location = New Point(Pacman.Location.X + 2.5, Pacman.Location.Y)

            'Make pacmans mouth move
            If pacmanImage.Text = "1" Then
                Pacman.BackgroundImage = My.Resources.Right_PacMan

                pacmanImage.Text = "0"
            Else
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'pause 
                System.Threading.Thread.Sleep(11)

                pacmanImage.Text = "1"
            End If

        End If

        'move left
        If direction.Text = "left" Then
            Pacman.Location = New Point(Pacman.Location.X - 2.5, Pacman.Location.Y)

            'Make pacmans mouth move
            If pacmanImage.Text = "1" Then
                Pacman.BackgroundImage = My.Resources.Left_PacMan
                pacmanImage.Text = "0"
            Else
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'pause 
                System.Threading.Thread.Sleep(11)

                pacmanImage.Text = "1"
            End If
        End If

        'move down
        If direction.Text = "down" Then
            Pacman.Location = New Point(Pacman.Location.X, Pacman.Location.Y + 2.5)

            'Make pacmans mouth move
            If pacmanImage.Text = "1" Then
                Pacman.BackgroundImage = My.Resources.Down_PacMan
                pacmanImage.Text = "0"
            Else
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'pause 
                System.Threading.Thread.Sleep(11)


                pacmanImage.Text = "1"
            End If
        End If

        'move up
        If direction.Text = "up" Then
            Pacman.Location = New Point(Pacman.Location.X, Pacman.Location.Y - 2.5)

            'Make pacmans mouth move
            If pacmanImage.Text = "1" Then
                Pacman.BackgroundImage = My.Resources.Up_PacMan
                pacmanImage.Text = "0"
            Else
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'pause 
                System.Threading.Thread.Sleep(11)

                pacmanImage.Text = "1"
            End If
        End If




        collide_with_walls()
        Collide_With_Dots()
        Collide_With_Big_Dots()
        Clear_Dots()



        lblScore.Text = score






    End Sub




#End Region
#Region "Load"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'show high score
        lblHighScore.Text = Form2.startHighScore




        'load full pacman to start 
        Pacman.Image = Image.FromFile("Full_PacMan.png")


        'ready?
        lblReady.Text = "Ready!"

        'play start up sound
        My.Computer.Audio.Play("Intro.wav")


    End Sub
#End Region
#Region "Collide"
#Region "Walls"
    Private Sub collide_with_walls()

        If Pacman.Bounds.IntersectsWith(TopRightBox1.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Topleftbox1.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopRod.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(MiddleHorizontalRod.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(middleunderRod.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopRightbox2.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Topleftbox2.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Topleftbox3.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Toprightbox3.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopRightwall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopLeftWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopLeftConnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(UnderPacmanSpawnBar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopRightInnerWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopRightConnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopRightinnerConnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(UnderPacmanSpawnConnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Topleftinnerconnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopLeftInnerWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomLeftConnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomRightConnector.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(AbovePacmanSpawnbar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(LeftMiddlebar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(RightMiddleBar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(RightGhostSpawn.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(LeftGhostSpawn.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(TopGhostspawn.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomRightBar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Bottomleftbar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BelowPacmanSpawn.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(LastBar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomLeftLastBar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomRightLastBar.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(SecondLastBarLeft.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(SecondLastBarRight.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(LeftNub.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(Rightnub.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomRightWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(BottomLeftWall.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(RightLTop.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(LeftLTop.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(RightLBottom.Bounds) Then
            Pacman_time.Enabled = False
        End If

        If Pacman.Bounds.IntersectsWith(LeftLBottom.Bounds) Then
            Pacman_time.Enabled = False
        End If




        'teleport to other side 
        If Pacman.Bounds.IntersectsWith(leftTele.Bounds) Then
            Pacman.Location = New Point(850, 352)
        End If

        'teleport to other side 
        If Pacman.Bounds.IntersectsWith(RighTele.Bounds) Then
            Pacman.Location = New Point(0, 352)
        End If

    End Sub
#End Region
#Region "Dots"

    Private Sub Collide_With_Dots()




        If Not Dot1.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot1.Bounds) Then
                'make dot go away 
                Dot1.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot2.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot2.Bounds) Then
                'make dot go away 
                Dot2.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot3.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot3.Bounds) Then
                'make dot go away 
                Dot3.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot4.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot4.Bounds) Then
                'make dot go away 
                Dot4.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot5.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot5.Bounds) Then
                'make dot go away 
                Dot5.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot6.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot6.Bounds) Then
                'make dot go away 
                Dot6.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot7.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot7.Bounds) Then
                'make dot go away 
                Dot7.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot8.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot8.Bounds) Then
                'make dot go away 
                Dot8.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot9.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot9.Bounds) Then
                'make dot go away 
                Dot9.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot10.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot10.Bounds) Then
                'make dot go away 
                Dot10.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot11.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot11.Bounds) Then
                'make dot go away 
                Dot11.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If



        If Not Dot12.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot12.Bounds) Then
                'make dot go away 
                Dot12.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If



        If Not Dot13.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot13.Bounds) Then
                'make dot go away 
                Dot13.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If



        If Not Dot14.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot14.Bounds) Then
                'make dot go away 
                Dot14.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If



        If Not Dot15.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot15.Bounds) Then
                'make dot go away 
                Dot15.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot16.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot16.Bounds) Then
                'make dot go away 
                Dot16.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If



        If Not Dot17.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot17.Bounds) Then
                'make dot go away 
                Dot17.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot18.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot18.Bounds) Then
                'make dot go away 
                Dot18.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot19.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot19.Bounds) Then
                'make dot go away 
                Dot19.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot20.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot20.Bounds) Then
                'make dot go away 
                Dot20.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot21.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot21.Bounds) Then
                'make dot go away 
                Dot21.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot22.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot22.Bounds) Then
                'make dot go away 
                Dot22.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot23.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot23.Bounds) Then
                'make dot go away 
                Dot23.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot24.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot24.Bounds) Then
                'make dot go away 
                Dot24.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If



        If Not Dot25.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot25.Bounds) Then
                'make dot go away 
                Dot25.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot26.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot26.Bounds) Then
                'make dot go away 
                Dot26.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot27.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot27.Bounds) Then
                'make dot go away 
                Dot27.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot28.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot28.Bounds) Then
                'make dot go away 
                Dot28.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot29.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot29.Bounds) Then
                'make dot go away 
                Dot29.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot30.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot30.Bounds) Then
                'make dot go away 
                Dot30.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot31.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot31.Bounds) Then
                'make dot go away 
                Dot31.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot32.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot32.Bounds) Then
                'make dot go away 
                Dot32.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot33.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot33.Bounds) Then
                'make dot go away 
                Dot33.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot34.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot34.Bounds) Then
                'make dot go away 
                Dot34.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot35.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot35.Bounds) Then
                'make dot go away 
                Dot35.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot36.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot36.Bounds) Then
                'make dot go away 
                Dot36.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot37.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot37.Bounds) Then
                'make dot go away 
                Dot37.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot38.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot38.Bounds) Then
                'make dot go away 
                Dot38.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot39.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot39.Bounds) Then
                'make dot go away 
                Dot39.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot40.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot40.Bounds) Then
                'make dot go away 
                Dot40.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot41.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot41.Bounds) Then
                'make dot go away 
                Dot41.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot42.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot42.Bounds) Then
                'make dot go away 
                Dot42.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot43.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot43.Bounds) Then
                'make dot go away 
                Dot43.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot44.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot44.Bounds) Then
                'make dot go away 
                Dot44.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot45.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot45.Bounds) Then
                'make dot go away 
                Dot45.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot46.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot46.Bounds) Then
                'make dot go away 
                Dot46.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot47.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot47.Bounds) Then
                'make dot go away 
                Dot47.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot48.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot48.Bounds) Then
                'make dot go away 
                Dot48.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot49.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot49.Bounds) Then
                'make dot go away 
                Dot49.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot50.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot50.Bounds) Then
                'make dot go away 
                Dot50.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot51.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot51.Bounds) Then
                'make dot go away 
                Dot51.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot52.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot52.Bounds) Then
                'make dot go away 
                Dot52.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot53.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot53.Bounds) Then
                'make dot go away 
                Dot53.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot54.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot54.Bounds) Then
                'make dot go away 
                Dot54.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot55.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot55.Bounds) Then
                'make dot go away 
                Dot55.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot56.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot56.Bounds) Then
                'make dot go away 
                Dot56.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot57.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot57.Bounds) Then
                'make dot go away 
                Dot57.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot58.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot58.Bounds) Then
                'make dot go away 
                Dot58.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot59.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot59.Bounds) Then
                'make dot go away 
                Dot59.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot60.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot60.Bounds) Then
                'make dot go away 
                Dot60.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot61.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot61.Bounds) Then
                'make dot go away 
                Dot61.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot62.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot62.Bounds) Then
                'make dot go away 
                Dot62.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot63.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot63.Bounds) Then
                'make dot go away 
                Dot63.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot64.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot64.Bounds) Then
                'make dot go away 
                Dot64.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot65.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot65.Bounds) Then
                'make dot go away 
                Dot65.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot66.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot66.Bounds) Then
                'make dot go away 
                Dot66.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot67.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot67.Bounds) Then
                'make dot go away 
                Dot67.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot68.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot68.Bounds) Then
                'make dot go away 
                Dot68.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot69.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot69.Bounds) Then
                'make dot go away 
                Dot69.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot70.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot70.Bounds) Then
                'make dot go away 
                Dot70.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot71.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot71.Bounds) Then
                'make dot go away 
                Dot71.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot72.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot72.Bounds) Then
                'make dot go away 
                Dot72.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot73.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot73.Bounds) Then
                'make dot go away 
                Dot73.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot74.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot74.Bounds) Then
                'make dot go away 
                Dot74.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot75.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot75.Bounds) Then
                'make dot go away 
                Dot75.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot76.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot76.Bounds) Then
                'make dot go away 
                Dot76.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot77.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot77.Bounds) Then
                'make dot go away 
                Dot77.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot78.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot78.Bounds) Then
                'make dot go away 
                Dot78.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot79.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot79.Bounds) Then
                'make dot go away 
                Dot79.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot80.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot80.Bounds) Then
                'make dot go away 
                Dot80.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot81.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot81.Bounds) Then
                'make dot go away 
                Dot81.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot82.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot82.Bounds) Then
                'make dot go away 
                Dot82.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot83.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot83.Bounds) Then
                'make dot go away 
                Dot83.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot84.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot84.Bounds) Then
                'make dot go away 
                Dot84.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot85.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot85.Bounds) Then
                'make dot go away 
                Dot85.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot86.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot86.Bounds) Then
                'make dot go away 
                Dot86.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot87.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot87.Bounds) Then
                'make dot go away 
                Dot87.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot88.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot88.Bounds) Then
                'make dot go away 
                Dot88.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot89.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot89.Bounds) Then
                'make dot go away 
                Dot89.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot90.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot90.Bounds) Then
                'make dot go away 
                Dot90.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot91.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot91.Bounds) Then
                'make dot go away 
                Dot91.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot92.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot92.Bounds) Then
                'make dot go away 
                Dot92.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot93.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot93.Bounds) Then
                'make dot go away 
                Dot93.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot94.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot94.Bounds) Then
                'make dot go away 
                Dot94.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot95.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot95.Bounds) Then
                'make dot go away 
                Dot95.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot96.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot96.Bounds) Then
                'make dot go away 
                Dot96.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot97.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot97.Bounds) Then
                'make dot go away 
                Dot97.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot98.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot98.Bounds) Then
                'make dot go away 
                Dot98.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot99.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot99.Bounds) Then
                'make dot go away 
                Dot99.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot100.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot100.Bounds) Then
                'make dot go away 
                Dot100.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot101.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot101.Bounds) Then
                'make dot go away 
                Dot101.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot102.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot102.Bounds) Then
                'make dot go away 
                Dot102.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot103.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot103.Bounds) Then
                'make dot go away 
                Dot103.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot104.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot104.Bounds) Then
                'make dot go away 
                Dot104.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot105.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot105.Bounds) Then
                'make dot go away 
                Dot105.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot106.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot106.Bounds) Then
                'make dot go away 
                Dot106.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot107.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot107.Bounds) Then
                'make dot go away 
                Dot107.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot108.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot108.Bounds) Then
                'make dot go away 
                Dot108.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot109.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot109.Bounds) Then
                'make dot go away 
                Dot109.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot110.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot110.Bounds) Then
                'make dot go away 
                Dot110.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot111.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot111.Bounds) Then
                'make dot go away 
                Dot111.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot112.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot112.Bounds) Then
                'make dot go away 
                Dot112.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot113.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot113.Bounds) Then
                'make dot go away 
                Dot113.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot114.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot114.Bounds) Then
                'make dot go away 
                Dot114.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot115.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot115.Bounds) Then
                'make dot go away 
                Dot115.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot116.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot116.Bounds) Then
                'make dot go away 
                Dot116.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot117.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot117.Bounds) Then
                'make dot go away 
                Dot117.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot118.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot118.Bounds) Then
                'make dot go away 
                Dot118.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot119.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot119.Bounds) Then
                'make dot go away 
                Dot119.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot120.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot120.Bounds) Then
                'make dot go away 
                Dot120.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot121.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot121.Bounds) Then
                'make dot go away 
                Dot121.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot122.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot122.Bounds) Then
                'make dot go away 
                Dot122.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot123.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot123.Bounds) Then
                'make dot go away 
                Dot123.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot124.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot124.Bounds) Then
                'make dot go away 
                Dot124.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot125.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot125.Bounds) Then
                'make dot go away 
                Dot125.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot126.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot126.Bounds) Then
                'make dot go away 
                Dot126.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot127.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot127.Bounds) Then
                'make dot go away 
                Dot127.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot128.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot128.Bounds) Then
                'make dot go away 
                Dot128.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot129.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot129.Bounds) Then
                'make dot go away 
                Dot129.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot130.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot130.Bounds) Then
                'make dot go away 
                Dot130.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot131.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot131.Bounds) Then
                'make dot go away 
                Dot131.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot132.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot132.Bounds) Then
                'make dot go away 
                Dot132.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot133.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot133.Bounds) Then
                'make dot go away 
                Dot133.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot134.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot134.Bounds) Then
                'make dot go away 
                Dot134.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot135.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot135.Bounds) Then
                'make dot go away 
                Dot135.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot136.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot136.Bounds) Then
                'make dot go away 
                Dot136.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot137.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot137.Bounds) Then
                'make dot go away 
                Dot137.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot138.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot138.Bounds) Then
                'make dot go away 
                Dot138.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot139.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot139.Bounds) Then
                'make dot go away 
                Dot139.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot140.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot140.Bounds) Then
                'make dot go away 
                Dot140.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot141.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot141.Bounds) Then
                'make dot go away 
                Dot141.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot142.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot142.Bounds) Then
                'make dot go away 
                Dot142.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot143.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot143.Bounds) Then
                'make dot go away 
                Dot143.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot144.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot144.Bounds) Then
                'make dot go away 
                Dot144.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot145.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot145.Bounds) Then
                'make dot go away 
                Dot145.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot146.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot146.Bounds) Then
                'make dot go away 
                Dot146.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot147.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot147.Bounds) Then
                'make dot go away 
                Dot147.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot148.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot148.Bounds) Then
                'make dot go away 
                Dot148.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot149.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot149.Bounds) Then
                'make dot go away 
                Dot149.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If


        If Not Dot150.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot150.Bounds) Then
                'make dot go away 
                Dot150.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot151.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot151.Bounds) Then
                'make dot go away 
                Dot151.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot152.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot152.Bounds) Then
                'make dot go away 
                Dot152.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot153.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot153.Bounds) Then
                'make dot go away 
                Dot153.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot154.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot154.Bounds) Then
                'make dot go away 
                Dot154.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot155.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot155.Bounds) Then
                'make dot go away 
                Dot155.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot156.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot156.Bounds) Then
                'make dot go away 
                Dot156.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot157.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot157.Bounds) Then
                'make dot go away 
                Dot157.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot158.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot158.Bounds) Then
                'make dot go away 
                Dot158.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If

        If Not Dot159.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Dot159.Bounds) Then
                'make dot go away 
                Dot159.Image = Nothing
                'give points 
                score = score + 10
                'add dot score 
                dots = dots + 1
            End If
        End If








    End Sub
#End Region
#Region "Big Dots"

    Private Sub Collide_With_Big_Dots()
        If Not BigDot1.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(BigDot1.Bounds) Then
                'make dot go away 
                BigDot1.Image = Nothing
                'give points 
                score = score + 50
                'add dot score 
                BigDots = BigDots + 1
                'change ghost colour
                Blue_Ghost.Image = My.Resources.Power_Ghost
                Red_Ghost.Image = My.Resources.Power_Ghost
                Orange_Ghost.Image = My.Resources.Power_Ghost
                Pink_Ghost.Image = My.Resources.Power_Ghost
                'make ghost eatable 
                For i = 0 To 3
                    Ghost_Eatable(i) = True
                Next
                'start timer
                Power_Ghost_Timer.Enabled = True
                'play sound 
                My.Computer.Audio.Play("Power_Pellet_Sound.wav", AudioPlayMode.BackgroundLoop)
            End If
        End If


        If Not BigDot2.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(BigDot2.Bounds) Then
                'make dot go away 
                BigDot2.Image = Nothing
                'give points 
                score = score + 50
                'add dot score 
                BigDots = BigDots + 1
                'change ghost colour
                Blue_Ghost.Image = My.Resources.Power_Ghost
                Red_Ghost.Image = My.Resources.Power_Ghost
                Orange_Ghost.Image = My.Resources.Power_Ghost
                Pink_Ghost.Image = My.Resources.Power_Ghost
                'make ghost eatable 
                For i = 0 To 3
                    Ghost_Eatable(i) = True
                    'start timer
                    Power_Ghost_Timer.Enabled = True
                    'play sound 
                    My.Computer.Audio.Play("Power_Pellet_Sound.wav", AudioPlayMode.BackgroundLoop)
                Next
            End If
        End If

        If Not BigDot3.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(BigDot3.Bounds) Then
                'make dot go away 
                BigDot3.Image = Nothing
                'give points 
                score = score + 50
                'add dot score 
                BigDots = BigDots + 1
                'change ghost colour
                Blue_Ghost.Image = My.Resources.Power_Ghost
                Red_Ghost.Image = My.Resources.Power_Ghost
                Orange_Ghost.Image = My.Resources.Power_Ghost
                Pink_Ghost.Image = My.Resources.Power_Ghost
                'make ghost eatable 
                For i = 0 To 3
                    Ghost_Eatable(i) = True
                Next
                'start timer
                Power_Ghost_Timer.Enabled = True
                'play sound 
                My.Computer.Audio.Play("Power_Pellet_Sound.wav", AudioPlayMode.BackgroundLoop)
            End If
        End If

        If Not BigDot4.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(BigDot4.Bounds) Then
                'make dot go away 
                BigDot4.Image = Nothing
                'give points 
                score = score + 50
                'add dot score 
                BigDots = BigDots + 1
                'change ghost colour
                Blue_Ghost.Image = My.Resources.Power_Ghost
                Red_Ghost.Image = My.Resources.Power_Ghost
                Orange_Ghost.Image = My.Resources.Power_Ghost
                Pink_Ghost.Image = My.Resources.Power_Ghost
                'make ghost eatable 
                For i = 0 To 3
                    Ghost_Eatable(i) = True
                    'start timer
                    Power_Ghost_Timer.Enabled = True
                    'play sound 
                    My.Computer.Audio.Play("Power_Pellet_Sound.wav", AudioPlayMode.BackgroundLoop)
                Next
            End If
        End If





    End Sub

#End Region
#Region "Ghosts"

    Private Sub Ghost_Red()


        If Ghost_Eatable(0) Then
            If Pacman.Bounds.IntersectsWith(Red_Ghost.Bounds) Then
                'add score
                score = score + 200
                'send ghost back
                Red_Ghost.Location = New Point(429, 277)
                'set direction
                Reddirection.Text = "right"
                'set image back 
                Red_Ghost.Image = My.Resources.Ghost_Red
                'set varible back 
                Ghost_Eatable(0) = False
            End If

        Else

            If Pacman.Bounds.IntersectsWith(Red_Ghost.Bounds) Then

                'put ghosts back
                Blue_Ghost.Image = My.Resources.Ghost_Blue
                Red_Ghost.Image = My.Resources.Ghost_Red
                Orange_Ghost.Image = My.Resources.Ghost_Orange
                Pink_Ghost.Image = My.Resources.Ghost_Pink

                'make ghosts uneatable
                Ghost_Eatable(0) = False
                Ghost_Eatable(1) = False
                Ghost_Eatable(2) = False
                Ghost_Eatable(3) = False

                'stop game 
                Pacman_time.Enabled = False

                'death music 
                My.Computer.Audio.Play("Pacman_Death.wav", AudioPlayMode.WaitToComplete)

                lblReady.Text = "Ready!"
                lblReady.BringToFront()


                'send ghost back
                Red_Ghost.Location = New Point(429, 277)

                'send ghost back
                Pink_Ghost.Location = New Point(429, 349)

                'send ghost back
                Blue_Ghost.Location = New Point(369, 349)

                'send ghost back
                Orange_Ghost.Location = New Point(490, 349)

                'play chomp sound 
                sound = True

                'play music 
                music = True

                'put ghost direction back
                Reddirection.Text = "right"

                'put direction back
                bluedirection.Text = "right"

                'put direction back
                pinkdirection.Text = "up"

                'put direction back
                Orangedirection.Text = "left"

                'make pacman full
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'stop pacman 
                Pacman_time.Enabled = False

                'put pink ghost back on its way 
                pinkdirection.Text = "up"

                'take a life away 
                lives = lives - 1

                'send pacman back to its spawn 
                Pacman.Location = New Point(429, 579)


                'start tick back up 
                Pacman_time.Enabled = True

                'show 2 lives 
                If lives = 2 Then
                    life3.Image = Nothing
                End If

                'show 1 life 
                If lives = 1 Then
                    Life2.Image = Nothing
                End If

                If lives <= 0 Then
                    'show game over 
                    lblReady.Text = "Game Over"
                    lblReady.BringToFront()

                    'show no lives 
                    Life1.Image = Nothing

                    'change colour 
                    lblReady.ForeColor = Color.Red

                    'stop game 
                    Pacman_time.Enabled = False

                    'close game 
                    close_Game = True

                    'do not play chomp sound 
                    sound = False

                    'do not play music 
                    music = False

                    'start timer 
                    Pacman_time.Enabled = True
                End If

            End If
        End If

    End Sub

    Private Sub Ghost_Pink()

        If Ghost_Eatable(1) Then
            If Pacman.Bounds.IntersectsWith(Pink_Ghost.Bounds) Then
                'add score
                score = score + 200
                'send ghost back
                Pink_Ghost.Location = New Point(429, 349)
                'set direction
                pinkdirection.Text = "up"
                'set image back 
                Pink_Ghost.Image = My.Resources.Ghost_Pink
                'set varible back 
                Ghost_Eatable(1) = False
            End If
        Else

            If Pacman.Bounds.IntersectsWith(Pink_Ghost.Bounds) Then

                'put ghosts back
                Blue_Ghost.Image = My.Resources.Ghost_Blue
                Red_Ghost.Image = My.Resources.Ghost_Red
                Orange_Ghost.Image = My.Resources.Ghost_Orange
                Pink_Ghost.Image = My.Resources.Ghost_Pink

                'make ghosts uneatable
                Ghost_Eatable(0) = False
                Ghost_Eatable(1) = False
                Ghost_Eatable(2) = False
                Ghost_Eatable(3) = False

                'stop game 
                Pacman_time.Enabled = False

                'death music 
                My.Computer.Audio.Play("Pacman_Death.wav", AudioPlayMode.WaitToComplete)

                lblReady.Text = "Ready!"
                lblReady.BringToFront()

                'put direction back
                Reddirection.Text = "right"

                'put direction back
                bluedirection.Text = "right"

                'put direction back
                pinkdirection.Text = "up"

                'put direction back
                Orangedirection.Text = "left"

                'send ghost back
                Blue_Ghost.Location = New Point(369, 349)

                'send ghost back
                Pink_Ghost.Location = New Point(429, 349)

                'send ghost back
                Red_Ghost.Location = New Point(429, 277)

                'send ghost back
                Orange_Ghost.Location = New Point(490, 349)

                'play chomp sound 
                sound = True

                'play music 
                music = True

                'make pacman full
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'stop pacman 
                Pacman_time.Enabled = False

                'make ghost go right 
                startPinkGhost = True

                'take a life away 
                lives = lives - 1

                'send pacman back to its spawn 
                Pacman.Location = New Point(429, 579)

                'set ghost back 
                Pink_Ghost.BackgroundImage = My.Resources.Ghost_Pink

                'start tick back up 
                Pacman_time.Enabled = True

                'show 2 lives 
                If lives = 2 Then
                    life3.Image = Nothing
                End If

                'show 1 life 
                If lives = 1 Then
                    Life2.Image = Nothing
                End If
            End If

            If lives <= 0 Then
                'show game over 
                lblReady.Text = "Game Over"
                lblReady.BringToFront()

                'show no lives 
                Life1.Image = Nothing

                'change colour 
                lblReady.ForeColor = Color.Red

                'stop game 
                Pacman_time.Enabled = False

                'close game 
                close_Game = True

                'do not play chomp sound 
                sound = False

                'do not play music 
                music = False

                'start timer 
                Pacman_time.Enabled = True
            End If
        End If


    End Sub

    Private Sub Ghost_Blue()


        If Ghost_Eatable(2) Then
            If Pacman.Bounds.IntersectsWith(Blue_Ghost.Bounds) Then
                'add score
                score = score + 200
                'send ghost back
                Blue_Ghost.Location = New Point(369, 349)
                'set direction
                bluedirection.Text = "right"
                'set image back 
                Blue_Ghost.Image = My.Resources.Ghost_Blue
                'set varible back 
                Ghost_Eatable(2) = False
            End If

        Else

            If Pacman.Bounds.IntersectsWith(Blue_Ghost.Bounds) Then

                'put ghosts back
                Blue_Ghost.Image = My.Resources.Ghost_Blue
                Red_Ghost.Image = My.Resources.Ghost_Red
                Orange_Ghost.Image = My.Resources.Ghost_Orange
                Pink_Ghost.Image = My.Resources.Ghost_Pink

                'make ghosts uneatable
                Ghost_Eatable(0) = False
                Ghost_Eatable(1) = False
                Ghost_Eatable(2) = False
                Ghost_Eatable(3) = False

                'stop game 
                Pacman_time.Enabled = False

                'death music 
                My.Computer.Audio.Play("Pacman_Death.wav", AudioPlayMode.WaitToComplete)

                lblReady.Text = "Ready!"
                lblReady.BringToFront()

                'put direction back
                Reddirection.Text = "right"

                'put direction back 
                pinkdirection.Text = "up"

                'put direction back
                bluedirection.Text = "right"

                'put direction back
                Orangedirection.Text = "left"

                'send ghost back
                Blue_Ghost.Location = New Point(369, 349)

                'send ghost back
                Pink_Ghost.Location = New Point(429, 349)

                'send ghost back
                Red_Ghost.Location = New Point(429, 277)

                'send ghost back
                Orange_Ghost.Location = New Point(490, 349)

                'play chomp sound 
                sound = True

                'play music 
                music = True

                'make pacman full
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'stop pacman 
                Pacman_time.Enabled = False

                'make ghost go right 
                startPinkGhost = True

                'take a life away 
                lives = lives - 1

                'send pacman back to its spawn 
                Pacman.Location = New Point(429, 579)

                'start tick back up 
                Pacman_time.Enabled = True

                'show 2 lives 
                If lives = 2 Then
                    life3.Image = Nothing
                End If

                'show 1 life 
                If lives = 1 Then
                    Life2.Image = Nothing
                End If
            End If

            If lives <= 0 Then
                'show game over 
                lblReady.Text = "Game Over"
                lblReady.BringToFront()

                'show no lives 
                Life1.Image = Nothing

                'change colour 
                lblReady.ForeColor = Color.Red

                'stop game 
                Pacman_time.Enabled = False

                'close game 
                close_Game = True

                'do not play chomp sound 
                sound = False

                'do not play music 
                music = False

                'start timer 
                Pacman_time.Enabled = True
            End If
        End If
    End Sub

    Private Sub Ghost_Orange()

        If Ghost_Eatable(3) Then
            If Pacman.Bounds.IntersectsWith(Orange_Ghost.Bounds) Then
                'add score
                score = score + 200
                'send ghost back
                Orange_Ghost.Location = New Point(490, 349)
                'set direction
                Orangedirection.Text = "left"
                'set image back 
                Orange_Ghost.Image = My.Resources.Ghost_Orange
                'set varible back 
                Ghost_Eatable(3) = False
            End If

        Else

            If Pacman.Bounds.IntersectsWith(Orange_Ghost.Bounds) Then

                'put ghosts back
                Blue_Ghost.Image = My.Resources.Ghost_Blue
                Red_Ghost.Image = My.Resources.Ghost_Red
                Orange_Ghost.Image = My.Resources.Ghost_Orange
                Pink_Ghost.Image = My.Resources.Ghost_Pink

                'make ghosts uneatable
                Ghost_Eatable(0) = False
                Ghost_Eatable(1) = False
                Ghost_Eatable(2) = False
                Ghost_Eatable(3) = False


                'stop game 
                Pacman_time.Enabled = False

                'death music 
                My.Computer.Audio.Play("Pacman_Death.wav", AudioPlayMode.WaitToComplete)

                lblReady.Text = "Ready!"
                lblReady.BringToFront()

                'put direction back
                Reddirection.Text = "right"

                'put direction back 
                pinkdirection.Text = "up"

                'put direction back
                bluedirection.Text = "right"

                'put direction back
                Orangedirection.Text = "left"

                'send ghost back
                Blue_Ghost.Location = New Point(369, 349)

                'send ghost back
                Pink_Ghost.Location = New Point(429, 349)

                'send ghost back
                Red_Ghost.Location = New Point(429, 277)

                'send ghost back
                Orange_Ghost.Location = New Point(490, 349)

                'play chomp sound 
                sound = True

                'play music 
                music = True

                'make pacman full
                Pacman.BackgroundImage = My.Resources.Full_PacMan

                'stop pacman 
                Pacman_time.Enabled = False

                'make ghost go right 
                startPinkGhost = True

                'take a life away 
                lives = lives - 1

                'send pacman back to its spawn 
                Pacman.Location = New Point(429, 579)

                'start tick back up 
                Pacman_time.Enabled = True

                'show 2 lives 
                If lives = 2 Then
                    life3.Image = Nothing
                End If

                'show 1 life 
                If lives = 1 Then
                    Life2.Image = Nothing
                End If
            End If

            If lives <= 0 Then
                'show game over 
                lblReady.Text = "Game Over"
                lblReady.BringToFront()

                'show no lives 
                Life1.Image = Nothing

                'change colour 
                lblReady.ForeColor = Color.Red

                'stop game 
                Pacman_time.Enabled = False

                'close game 
                close_Game = True

                'start timer 
                Pacman_time.Enabled = True

                'do not play chomp sound 
                sound = False

                'do not play music 
                music = False

                'set high score 
                If printhighscore = True Then
                    Dim outfile As System.IO.StreamWriter = New System.IO.StreamWriter("HighScore.txt")
                    outfile.WriteLine(Form2.startHighScore)
                    outfile.Close()
                    printhighscore = False
                End If
            End If

        End If

    End Sub


#End Region
#End Region
#Region "Cherry Timer"

    Private Sub Cherry_timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cherry_timer.Tick


        If cherry_time = False Then
            'put cherry in
            Cherry.Image = Image.FromFile("Cherry.png")
            'start timer
            cherry_time = True
            'set interval to 1 
            Cherry_timer.Interval = 1
        End If

        If Not Cherry.Image Is Nothing Then
            'check if it hit 
            If Pacman.Bounds.IntersectsWith(Cherry.Bounds) Then
                'make dot go away 
                Cherry.Image = Nothing
                'give points 
                score = score + 100
                'stop timer 
                Cherry_timer.Enabled = False
            End If
        End If


    End Sub
#End Region
#Region "Clear Dots"
    Private Sub Clear_Dots()

        If dots = 159 And BigDots = 4 Then

            'play chomp sound again 
            sound = True

            'play music 
            music = True

            'make pacman full
            Pacman.BackgroundImage = My.Resources.Full_PacMan

            'stop pacman 
            Pacman_time.Enabled = False

            'send ghost back 
            Red_Ghost.Location = New Point(429, 277)

            'send ghost back
            Pink_Ghost.Location = New Point(429, 349)

            'send ghost back
            Blue_Ghost.Location = New Point(369, 349)

            'send ghost back
            Orange_Ghost.Location = New Point(490, 349)

            'send pacman back to its spawn 
            Pacman.Location = New Point(429, 579)

            'sets the direction back 
            startPinkGhost = True
            startRedGhost = True

            'set dots back to 0 
            dots = 0
            BigDots = 0

            lblReady.BringToFront()
            lblReady.Text = "Ready!"



            'get cherry to start again
            Cherry_timer.Interval = 15000
            Cherry_timer.Enabled = True
            cherry_time = False

            Dot1.Image = My.Resources.Small_Dot
            Dot2.Image = My.Resources.Small_Dot
            Dot3.Image = My.Resources.Small_Dot
            Dot4.Image = My.Resources.Small_Dot
            Dot5.Image = My.Resources.Small_Dot
            Dot6.Image = My.Resources.Small_Dot
            Dot7.Image = My.Resources.Small_Dot
            Dot8.Image = My.Resources.Small_Dot
            Dot9.Image = My.Resources.Small_Dot
            Dot10.Image = My.Resources.Small_Dot
            Dot11.Image = My.Resources.Small_Dot
            Dot12.Image = My.Resources.Small_Dot
            Dot13.Image = My.Resources.Small_Dot
            Dot14.Image = My.Resources.Small_Dot
            Dot15.Image = My.Resources.Small_Dot
            Dot16.Image = My.Resources.Small_Dot
            Dot17.Image = My.Resources.Small_Dot
            Dot18.Image = My.Resources.Small_Dot
            Dot19.Image = My.Resources.Small_Dot
            Dot20.Image = My.Resources.Small_Dot
            Dot21.Image = My.Resources.Small_Dot
            Dot22.Image = My.Resources.Small_Dot
            Dot23.Image = My.Resources.Small_Dot
            Dot24.Image = My.Resources.Small_Dot
            Dot25.Image = My.Resources.Small_Dot
            Dot26.Image = My.Resources.Small_Dot
            Dot27.Image = My.Resources.Small_Dot
            Dot28.Image = My.Resources.Small_Dot
            Dot29.Image = My.Resources.Small_Dot
            Dot30.Image = My.Resources.Small_Dot
            Dot31.Image = My.Resources.Small_Dot
            Dot32.Image = My.Resources.Small_Dot
            Dot33.Image = My.Resources.Small_Dot
            Dot34.Image = My.Resources.Small_Dot
            Dot35.Image = My.Resources.Small_Dot
            Dot36.Image = My.Resources.Small_Dot
            Dot37.Image = My.Resources.Small_Dot
            Dot38.Image = My.Resources.Small_Dot
            Dot39.Image = My.Resources.Small_Dot
            Dot40.Image = My.Resources.Small_Dot
            Dot41.Image = My.Resources.Small_Dot
            Dot42.Image = My.Resources.Small_Dot
            Dot43.Image = My.Resources.Small_Dot
            Dot44.Image = My.Resources.Small_Dot
            Dot45.Image = My.Resources.Small_Dot
            Dot46.Image = My.Resources.Small_Dot
            Dot47.Image = My.Resources.Small_Dot
            Dot48.Image = My.Resources.Small_Dot
            Dot49.Image = My.Resources.Small_Dot
            Dot50.Image = My.Resources.Small_Dot
            Dot51.Image = My.Resources.Small_Dot
            Dot52.Image = My.Resources.Small_Dot
            Dot53.Image = My.Resources.Small_Dot
            Dot54.Image = My.Resources.Small_Dot
            Dot55.Image = My.Resources.Small_Dot
            Dot56.Image = My.Resources.Small_Dot
            Dot57.Image = My.Resources.Small_Dot
            Dot58.Image = My.Resources.Small_Dot
            Dot59.Image = My.Resources.Small_Dot
            Dot60.Image = My.Resources.Small_Dot
            Dot61.Image = My.Resources.Small_Dot
            Dot62.Image = My.Resources.Small_Dot
            Dot63.Image = My.Resources.Small_Dot
            Dot64.Image = My.Resources.Small_Dot
            Dot65.Image = My.Resources.Small_Dot
            Dot66.Image = My.Resources.Small_Dot
            Dot67.Image = My.Resources.Small_Dot
            Dot68.Image = My.Resources.Small_Dot
            Dot69.Image = My.Resources.Small_Dot
            Dot70.Image = My.Resources.Small_Dot
            Dot71.Image = My.Resources.Small_Dot
            Dot72.Image = My.Resources.Small_Dot
            Dot73.Image = My.Resources.Small_Dot
            Dot74.Image = My.Resources.Small_Dot
            Dot75.Image = My.Resources.Small_Dot
            Dot76.Image = My.Resources.Small_Dot
            Dot77.Image = My.Resources.Small_Dot
            Dot78.Image = My.Resources.Small_Dot
            Dot79.Image = My.Resources.Small_Dot
            Dot80.Image = My.Resources.Small_Dot
            Dot81.Image = My.Resources.Small_Dot
            Dot82.Image = My.Resources.Small_Dot
            Dot83.Image = My.Resources.Small_Dot
            Dot84.Image = My.Resources.Small_Dot
            Dot85.Image = My.Resources.Small_Dot
            Dot86.Image = My.Resources.Small_Dot
            Dot87.Image = My.Resources.Small_Dot
            Dot88.Image = My.Resources.Small_Dot
            Dot89.Image = My.Resources.Small_Dot
            Dot90.Image = My.Resources.Small_Dot
            Dot91.Image = My.Resources.Small_Dot
            Dot92.Image = My.Resources.Small_Dot
            Dot93.Image = My.Resources.Small_Dot
            Dot94.Image = My.Resources.Small_Dot
            Dot95.Image = My.Resources.Small_Dot
            Dot96.Image = My.Resources.Small_Dot
            Dot97.Image = My.Resources.Small_Dot
            Dot98.Image = My.Resources.Small_Dot
            Dot99.Image = My.Resources.Small_Dot
            Dot100.Image = My.Resources.Small_Dot
            Dot101.Image = My.Resources.Small_Dot
            Dot102.Image = My.Resources.Small_Dot
            Dot103.Image = My.Resources.Small_Dot
            Dot104.Image = My.Resources.Small_Dot
            Dot105.Image = My.Resources.Small_Dot
            Dot106.Image = My.Resources.Small_Dot
            Dot107.Image = My.Resources.Small_Dot
            Dot108.Image = My.Resources.Small_Dot
            Dot109.Image = My.Resources.Small_Dot
            Dot110.Image = My.Resources.Small_Dot
            Dot111.Image = My.Resources.Small_Dot
            Dot112.Image = My.Resources.Small_Dot
            Dot113.Image = My.Resources.Small_Dot
            Dot114.Image = My.Resources.Small_Dot
            Dot115.Image = My.Resources.Small_Dot
            Dot116.Image = My.Resources.Small_Dot
            Dot117.Image = My.Resources.Small_Dot
            Dot118.Image = My.Resources.Small_Dot
            Dot119.Image = My.Resources.Small_Dot
            Dot120.Image = My.Resources.Small_Dot
            Dot121.Image = My.Resources.Small_Dot
            Dot122.Image = My.Resources.Small_Dot
            Dot123.Image = My.Resources.Small_Dot
            Dot124.Image = My.Resources.Small_Dot
            Dot125.Image = My.Resources.Small_Dot
            Dot126.Image = My.Resources.Small_Dot
            Dot127.Image = My.Resources.Small_Dot
            Dot128.Image = My.Resources.Small_Dot
            Dot129.Image = My.Resources.Small_Dot
            Dot130.Image = My.Resources.Small_Dot
            Dot131.Image = My.Resources.Small_Dot
            Dot132.Image = My.Resources.Small_Dot
            Dot133.Image = My.Resources.Small_Dot
            Dot134.Image = My.Resources.Small_Dot
            Dot135.Image = My.Resources.Small_Dot
            Dot136.Image = My.Resources.Small_Dot
            Dot137.Image = My.Resources.Small_Dot
            Dot138.Image = My.Resources.Small_Dot
            Dot139.Image = My.Resources.Small_Dot
            Dot140.Image = My.Resources.Small_Dot
            Dot141.Image = My.Resources.Small_Dot
            Dot142.Image = My.Resources.Small_Dot
            Dot143.Image = My.Resources.Small_Dot
            Dot144.Image = My.Resources.Small_Dot
            Dot145.Image = My.Resources.Small_Dot
            Dot146.Image = My.Resources.Small_Dot
            Dot147.Image = My.Resources.Small_Dot
            Dot148.Image = My.Resources.Small_Dot
            Dot149.Image = My.Resources.Small_Dot
            Dot150.Image = My.Resources.Small_Dot
            Dot151.Image = My.Resources.Small_Dot
            Dot152.Image = My.Resources.Small_Dot
            Dot153.Image = My.Resources.Small_Dot
            Dot154.Image = My.Resources.Small_Dot
            Dot155.Image = My.Resources.Small_Dot
            Dot156.Image = My.Resources.Small_Dot
            Dot157.Image = My.Resources.Small_Dot
            Dot158.Image = My.Resources.Small_Dot
            Dot159.Image = My.Resources.Small_Dot















            'put back big dots
            BigDot1.Image = My.Resources.Big_Dot
            BigDot2.Image = My.Resources.Big_Dot
            BigDot3.Image = My.Resources.Big_Dot
            BigDot4.Image = My.Resources.Big_Dot

            'set directions
            startRedGhost = True
            startBlueGhost = True
            startPinkGhost = True
            startorangeGhost = True

            'put ghosts back
            Blue_Ghost.Image = My.Resources.Ghost_Blue
            Red_Ghost.Image = My.Resources.Ghost_Red
            Orange_Ghost.Image = My.Resources.Ghost_Orange
            Pink_Ghost.Image = My.Resources.Ghost_Pink

            'make ghosts uneatable
            Ghost_Eatable(0) = False
            Ghost_Eatable(1) = False
            Ghost_Eatable(2) = False
            Ghost_Eatable(3) = False

            'shorten timer 
            If Not Power_Ghost_Timer.Interval = 4000 Then
                Power_Ghost_Timer.Interval = Power_Ghost_Timer.Interval - 1000
            End If

        End If

        If music = True Then
            My.Computer.Audio.Play("Intro.wav")
            music = False
            start1 = False
            Pacman_time.Enabled = True
        End If




    End Sub

#End Region
#Region "Red Ghost Timer"

    Private Sub Ghost_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedGhost_Timer.Tick

        Ghost_Red()
        Ghost_Pink()
        Ghost_Blue()
        Ghost_Orange()


        If startRedGhost = True Then
            Reddirection.Text = "right"
            startRedGhost = False
        End If

        'move down
        If Reddirection.Text = "down" Then
            Red_Ghost.Location = New Point(Red_Ghost.Location.X, Red_Ghost.Location.Y + 3)
        End If

        'move right
        If Reddirection.Text = "right" Then
            Red_Ghost.Location = New Point(Red_Ghost.Location.X + 3, Red_Ghost.Location.Y)
        End If

        'move up
        If Reddirection.Text = "up" Then
            Red_Ghost.Location = New Point(Red_Ghost.Location.X, Red_Ghost.Location.Y - 3)
        End If

        'move left 
        If Reddirection.Text = "left" Then
            Red_Ghost.Location = New Point(Red_Ghost.Location.X - 3, Red_Ghost.Location.Y)
        End If




        If Red_Ghost.Bounds.IntersectsWith(ghostmove.Bounds) Then
            Reddirection.Text = "down"
        End If

        If Red_Ghost.Bounds.IntersectsWith(GhostMove1.Bounds) Then
            Reddirection.Text = "left"
        End If

        If Red_Ghost.Bounds.IntersectsWith(Ghostmove2.Bounds) Then
            Reddirection.Text = "down"
        End If

        If Red_Ghost.Bounds.IntersectsWith(Ghostmove3.Bounds) Then
            Reddirection.Text = "left"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove4.Bounds) Then
            Reddirection.Text = "up"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove5.Bounds) Then
            Reddirection.Text = "left"
        End If

        If Red_Ghost.Bounds.IntersectsWith(Ghostmove6.Bounds) Then
            Reddirection.Text = "up"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove7.Bounds) Then
            Reddirection.Text = "left"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove8.Bounds) Then
            Reddirection.Text = "down"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove9.Bounds) Then
            Reddirection.Text = "right"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove10.Bounds) Then
            Reddirection.Text = "up"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove11.Bounds) Then
            Reddirection.Text = "right"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove12.Bounds) Then
            Reddirection.Text = "down"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove13.Bounds) Then
            Reddirection.Text = "right"
        End If

        If Red_Ghost.Bounds.IntersectsWith(RighTele.Bounds) Then
            Red_Ghost.Location = New Point(0, 352)
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove14.Bounds) Then
            Reddirection.Text = "up"
        End If

        If Red_Ghost.Bounds.IntersectsWith(Ghostmove15.Bounds) Then
            Reddirection.Text = "right"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove16.Bounds) Then
            Reddirection.Text = "right"
        End If


        If Red_Ghost.Bounds.IntersectsWith(ghostmove17.Bounds) Then
            Reddirection.Text = "down"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove18.Bounds) Then
            Reddirection.Text = "left"
        End If

        If Red_Ghost.Bounds.IntersectsWith(ghostmove19.Bounds) Then
            Reddirection.Text = "down"
        End If






    End Sub







#End Region
#Region "Pink Ghost Timer"


    Private Sub PinkGhost_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PinkGhost_Timer.Tick

        Ghost_Red()
        Ghost_Pink()
        Ghost_Blue()
        Ghost_Orange()

        If startPinkGhost = True Then
            pinkdirection.Text = "up"
            startPinkGhost = False
        End If

        'move down
        If pinkdirection.Text = "down" Then
            Pink_Ghost.Location = New Point(Pink_Ghost.Location.X, Pink_Ghost.Location.Y + 3)
        End If

        'move right
        If pinkdirection.Text = "right" Then
            Pink_Ghost.Location = New Point(Pink_Ghost.Location.X + 3, Pink_Ghost.Location.Y)
        End If


        'move up
        If pinkdirection.Text = "up" Then
            Pink_Ghost.Location = New Point(Pink_Ghost.Location.X, Pink_Ghost.Location.Y - 3)
        End If

        'move left 
        If pinkdirection.Text = "left" Then
            Pink_Ghost.Location = New Point(Pink_Ghost.Location.X - 3, Pink_Ghost.Location.Y)
        End If


        If Pink_Ghost.Bounds.IntersectsWith(ghostmove20.Bounds) Then
            pinkdirection.Text = "left"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove21.Bounds) Then
            pinkdirection.Text = "down"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(Ghostmove22.Bounds) Then
            pinkdirection.Text = "right"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(Ghostmove23.Bounds) Then
            pinkdirection.Text = "down"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(GhostMove1.Bounds) Then
            pinkdirection.Text = "right"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove24.Bounds) Then
            pinkdirection.Text = "down"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove25.Bounds) Then
            pinkdirection.Text = "left"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove26.Bounds) Then
            pinkdirection.Text = "down"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove27.Bounds) Then
            pinkdirection.Text = "right"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove28.Bounds) Then
            pinkdirection.Text = "down"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove29.Bounds) Then
            pinkdirection.Text = "left"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove30.Bounds) Then
            pinkdirection.Text = "up"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove31.Bounds) Then
            pinkdirection.Text = "right"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove32.Bounds) Then
            pinkdirection.Text = "up"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove33.Bounds) Then
            pinkdirection.Text = "left"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove34.Bounds) Then
            pinkdirection.Text = "up"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove36.Bounds) Then
            pinkdirection.Text = "right"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove17.Bounds) Then
            pinkdirection.Text = "up"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove35.Bounds) Then
            pinkdirection.Text = "left"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove37.Bounds) Then
            pinkdirection.Text = "down"
        End If


        If Pink_Ghost.Bounds.IntersectsWith(ghostmove13.Bounds) Then
            pinkdirection.Text = "left"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove38.Bounds) Then
            pinkdirection.Text = "up"
        End If

        If Pink_Ghost.Bounds.IntersectsWith(ghostmove39.Bounds) Then
            pinkdirection.Text = "left"
        End If










    End Sub

#End Region
#Region "Blue Ghost Timer"

    Private Sub BlueGhost_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueGhost_Timer.Tick

        Ghost_Red()
        Ghost_Pink()
        Ghost_Blue()
        Ghost_Orange()

        If startBlueGhost = True Then
            bluedirection.Text = "right"
            startBlueGhost = False
        End If

        If score > 3000 Then

            'move down
            If bluedirection.Text = "down" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X, Blue_Ghost.Location.Y + 3)
            End If

            'move right
            If bluedirection.Text = "right" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X + 3, Blue_Ghost.Location.Y)
            End If

            'move up
            If bluedirection.Text = "up" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X, Blue_Ghost.Location.Y - 3)
            End If

            'move left 
            If bluedirection.Text = "left" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X - 3, Blue_Ghost.Location.Y)
            End If


        Else
            'move down
            If bluedirection.Text = "down" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X, Blue_Ghost.Location.Y + 2)
            End If

            'move right
            If bluedirection.Text = "right" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X + 2, Blue_Ghost.Location.Y)
            End If

            'move up
            If bluedirection.Text = "up" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X, Blue_Ghost.Location.Y - 2)
            End If

            'move left 
            If bluedirection.Text = "left" Then
                Blue_Ghost.Location = New Point(Blue_Ghost.Location.X - 2, Blue_Ghost.Location.Y)
            End If
        End If


        If Blue_Ghost.Bounds.IntersectsWith(Ghostmove40.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove20.Bounds) Then
            bluedirection.Text = "left"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove41.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove42.Bounds) Then
            bluedirection.Text = "left"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove43.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(Ghostmove44.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove45.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove46.Bounds) Then
            bluedirection.Text = "left"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove8.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove9.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove47.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove48.Bounds) Then
            bluedirection.Text = "left"
        End If


        If Blue_Ghost.Bounds.IntersectsWith(ghostmove49.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove50.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove51.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove52.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove32.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove53.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove54.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove55.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove56.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove57.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove58.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove59.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove60.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove61.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove62.Bounds) Then
            bluedirection.Text = "up"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove12.Bounds) Then
            bluedirection.Text = "left"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove63.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove64.Bounds) Then
            bluedirection.Text = "right"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove65.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove66.Bounds) Then
            bluedirection.Text = "left"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove67.Bounds) Then
            bluedirection.Text = "down"
        End If

        If Blue_Ghost.Bounds.IntersectsWith(ghostmove68.Bounds) Then
            bluedirection.Text = "left"
        End If






    End Sub

#End Region
#Region "Orange Ghost Timer"
    Private Sub OrangeGhost_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrangeGhost_Timer.Tick

        Ghost_Red()
        Ghost_Pink()
        Ghost_Blue()
        Ghost_Orange()

        If startorangeGhost = True Then
            Orangedirection.Text = "left"
            startorangeGhost = False
        End If

        If score > 5000 Then

            'move down
            If Orangedirection.Text = "down" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X, Orange_Ghost.Location.Y + 3)
            End If

            'move right
            If Orangedirection.Text = "right" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X + 3, Orange_Ghost.Location.Y)
            End If

            'move up
            If Orangedirection.Text = "up" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X, Orange_Ghost.Location.Y - 3)
            End If

            'move left 
            If Orangedirection.Text = "left" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X - 3, Orange_Ghost.Location.Y)
            End If

        Else
            'move down
            If Orangedirection.Text = "down" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X, Orange_Ghost.Location.Y + 2)
            End If

            'move right
            If Orangedirection.Text = "right" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X + 2, Orange_Ghost.Location.Y)
            End If

            'move up
            If Orangedirection.Text = "up" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X, Orange_Ghost.Location.Y - 2)
            End If

            'move left 
            If Orangedirection.Text = "left" Then
                Orange_Ghost.Location = New Point(Orange_Ghost.Location.X - 2, Orange_Ghost.Location.Y)
            End If


        End If
        'change directions
        If Orange_Ghost.Bounds.IntersectsWith(ghostmove69.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove20.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove70.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove71.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove72.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove73.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove74.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove11.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove75.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove18.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove19.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove76.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove77.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove78.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove79.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove80.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(Ghostmove2.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(Ghostmove3.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove81.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove82.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove83.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove84.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove85.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove86.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove87.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove88.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove89.Bounds) Then
            Orangedirection.Text = "up"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove7.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove90.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove91.Bounds) Then
            Orangedirection.Text = "left"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove92.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove93.Bounds) Then
            Orangedirection.Text = "right"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove94.Bounds) Then
            Orangedirection.Text = "down"
        End If

        If Orange_Ghost.Bounds.IntersectsWith(ghostmove95.Bounds) Then
            Orangedirection.Text = "right"
        End If









    End Sub
#End Region
#Region "Power Ghosts timer"
    Private Sub Power_Ghost_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Power_Ghost_Timer.Tick

        'put ghosts back
        Blue_Ghost.Image = My.Resources.Ghost_Blue
        Red_Ghost.Image = My.Resources.Ghost_Red
        Orange_Ghost.Image = My.Resources.Ghost_Orange
        Pink_Ghost.Image = My.Resources.Ghost_Pink

        'make ghosts uneatable
        Ghost_Eatable(0) = False
        Ghost_Eatable(1) = False
        Ghost_Eatable(2) = False
        Ghost_Eatable(3) = False

        'stop timer
        Power_Ghost_Timer.Enabled = False


        'play chomp 
        My.Computer.Audio.Play("pacman_chomp.wav", AudioPlayMode.BackgroundLoop)
    End Sub
#End Region



  
End Class
