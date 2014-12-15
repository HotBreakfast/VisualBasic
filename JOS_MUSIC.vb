Imports HundredMilesSoftware.UltraID3Lib
Imports System.Drawing.Drawing2D
Public Class Form1
    Dim ultraid3 As HundredMilesSoftware.UltraID3Lib.UltraID3
    Dim A, B, ktu As Integer
    Dim arksiz As Size


    Private Property pics As ID3FrameCollection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        arksiz.Height = 20
        For Each a As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.SpecialDirectories.MyMusic)
            For Each b As String In My.Computer.FileSystem.GetDirectories(a)
                For Each c As String In My.Computer.FileSystem.GetDirectories(b)
                    For Each d As String In My.Computer.FileSystem.GetFiles(c)
                        If d.Contains(".mp3") = True Then
                            ListBox1.Items.Add(d)
                        End If
                    Next
                Next
                For Each c As String In My.Computer.FileSystem.GetFiles(b)
                    If c.Contains(".mp3") = True Then
                        ListBox1.Items.Add(c)
                    End If
                Next
            Next
            For Each b As String In My.Computer.FileSystem.GetFiles(a)
                If b.Contains(".mp3") = True Then
                    ListBox1.Items.Add(b)
                End If
            Next

        Next
        For Each b As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.MyMusic)
            If b.Contains(".mp3") = True Then
                ListBox1.Items.Add(b)
            End If
        Next
        Timer1.Start()

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        AxWindowsMediaPlayer2.URL = ListBox1.SelectedItem.ToString
        AxWindowsMediaPlayer2.Ctlcontrols.play()
        Try
            UltraID3.Read(ListBox1.SelectedItem.ToString)
            pics = UltraID3.ID3v2Tag.Frames.GetFrames(CommonMultipleInstanceID3v2FrameTypes.Picture)
            Panel1.BackgroundImage = CType(pics.Item(0), ID3v22PictureFrame).Picture

        Catch ex As Exception

                Panel1.BackgroundImage = My.Resources(IMAGE IN RESOURCES)

        End Try
        Label1.Text = UltraID3.Title
        Label2.Text = UltraID3.Album
        Label3.Text = UltraID3.Artist

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AxWindowsMediaPlayer2.Ctlcontrols.pause()

    End Sub
    Private Sub Buttonk_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxWindowsMediaPlayer2.Ctlcontrols.play()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim a As Double = Math.Floor(AxWindowsMediaPlayer2.currentMedia.duration)
            Dim t As Double = Math.Floor(AxWindowsMediaPlayer2.Ctlcontrols.currentPosition)

            ProgressBar1.Maximum = CInt(a)
            ProgressBar1.Value = CInt(t)
            If CInt(a) = CInt(t) Then
                Try
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                Catch
                    ListBox1.SelectedIndex = 0
                End Try
            End If
        Catch ex As Exception

        End Try
        Try
            ListBox1.Width = Me.Width / 2


        Catch
        End Try

    End Sub




    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1
        Catch
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
        Catch
            ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1
        End Try
    End Sub


End Class
