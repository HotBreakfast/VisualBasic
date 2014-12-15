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
