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

    End Sub
