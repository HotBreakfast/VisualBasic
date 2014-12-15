

Imports HundredMilesSoftware.UltraID3Lib
Imports System.Drawing.Drawing2D
Public Class Form1
    Dim ultraid3 As HundredMilesSoftware.UltraID3Lib.UltraID3




 Sub main()
Dim id3tag As New ID3TagLibrary.MP3File(ListBox1.SelectedItem.ToString)
        Try
            ultraid3.Read(ListBox1.SelectedItem.ToString)
            pics = ultraid3.ID3v2Tag.Frames.GetFrames(CommonMultipleInstanceID3v2FrameTypes.Picture)
            Panel1.BackgroundImage = CType(pics.Item(0), ID3v22PictureFrame).Picture

        Catch ex As Exception
            Try

                Panel1.BackgroundImage = id3tag.Tag2.Artwork(1)
            Catch

                Panel1.BackgroundImage = My.Resources.note
            End Try
        End Try
      End Sub
  End Class
