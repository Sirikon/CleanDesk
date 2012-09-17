Public Class Form1
    Dim repeats As Integer
    Dim format As String
    Dim path As String
    Dim serial As Integer
    Dim num2 As Integer
    Dim data As String
    Dim pic As String
    Dim vid As String
    Dim music As String
    Dim doc As String
    Dim pf As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer2.Enabled = True
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists("newformats") Then
            CDConfig.newformats()
            My.Computer.FileSystem.DeleteFile("newformats")
        End If
        If GetSetting("CleanDesk", "data", "configured", "") = "1" Then
            data = GetSetting("CleanDesk", "data", "time", "")
            serial = data + 1
            SaveSetting("CleanDesk", "data", "time", serial)
            pic = My.Computer.FileSystem.SpecialDirectories.MyPictures
            vid = My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments) & "\Videos"
            doc = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            pf = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
            music = My.Computer.FileSystem.SpecialDirectories.MyMusic
            For number As Integer = 1 To 46
                If number = 1 Then
                    format = "jpg"
                ElseIf number = 2 Then
                    format = "jpeg"
                ElseIf number = 3 Then
                    format = "psd"
                ElseIf number = 4 Then
                    format = "png"
                ElseIf number = 5 Then
                    format = "bmp"
                ElseIf number = 6 Then
                    format = "gif"
                ElseIf number = 7 Then
                    format = "tga"
                ElseIf number = 8 Then
                    format = "ico"
                ElseIf number = 9 Then
                    format = "tif"
                ElseIf number = 10 Then
                    format = "tiff"
                ElseIf number = 11 Then
                    format = "svg"
                ElseIf number = 12 Then
                    format = "cdr"
                ElseIf number = 13 Then
                    format = "mp3"
                ElseIf number = 14 Then
                    format = "wma"
                ElseIf number = 15 Then
                    format = "wmv"
                ElseIf number = 16 Then
                    format = "avi"
                ElseIf number = 17 Then
                    format = "mp4"
                ElseIf number = 18 Then
                    format = "ogv"
                ElseIf number = 19 Then
                    format = "webm"
                ElseIf number = 20 Then
                    format = "flv"
                ElseIf number = 21 Then
                    format = "exe"
                ElseIf number = 22 Then
                    format = "msi"
                ElseIf number = 23 Then
                    format = "txt"
                ElseIf number = 24 Then
                    format = "doc"
                ElseIf number = 25 Then
                    format = "odt"
                ElseIf number = 26 Then
                    format = "odp"
                ElseIf number = 27 Then
                    format = "ods"
                ElseIf number = 28 Then
                    format = "pps"
                ElseIf number = 29 Then
                    format = "ppsx"
                ElseIf number = 30 Then
                    format = "docx"
                ElseIf number = 31 Then
                    format = "xls"
                ElseIf number = 32 Then
                    format = "xlsx"
                ElseIf number = 33 Then
                    format = "dlc"
                ElseIf number = 34 Then
                    format = "megamanager"
                ElseIf number = 35 Then
                    format = "pdf"
                ElseIf number = 36 Then
                    format = "wav"
                ElseIf number = 37 Then
                    format = "mkv"
                ElseIf number = 38 Then
                    format = "mts"
                ElseIf number = 39 Then
                    format = "rtf"
                ElseIf number = 40 Then
                    format = "iso"
                ElseIf number = 41 Then
                    format = "m4v"
                ElseIf number = 42 Then
                    format = "fc2map"
                ElseIf number = 43 Then
                    format = "zip"
                ElseIf number = 44 Then
                    format = "rar"
                ElseIf number = 45 Then
                    format = "7z"
                ElseIf number = 46 Then
                    format = "tar.gz"
                End If
                path = CDConfig.sel(format)
                For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
            My.Computer.FileSystem.SpecialDirectories.Desktop, _
            FileIO.SearchOption.SearchTopLevelOnly, "*." & format)
                    Dim foundFileInfo As New System.IO.FileInfo(foundFile)
                    For Each foundfile2 As String In My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly, "*." & format)
                        Dim foundFileInfo2 As New System.IO.FileInfo(foundfile2)
                        If foundFileInfo2.Name = foundFileInfo.Name Then
                            repeats = repeats + 1
                            My.Computer.FileSystem.RenameFile(foundfile2, serial & "OLD" + foundFileInfo2.Name)
                        End If
                    Next
                Next
                For Each foundfile2 As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Desktop, FileIO.SearchOption.SearchTopLevelOnly, "*." & format)
                    Dim foundFileInfo2 As New System.IO.FileInfo(foundfile2)
                    My.Computer.FileSystem.MoveFile(foundfile2, path & "\" & foundFileInfo2.Name)
                Next
            Next
            If repeats <> 0 Then
                Dim habian As String
                Dim archivos As String
                habian = "Habían "
                archivos = " archivos con el nombre repetido, estos an sido renombrados al prefijo OLD"
                MsgBox(habian & repeats & archivos, MsgBoxStyle.Information, "Repeticiones")
            End If
        Else
            CDConfig.config()
            MsgBox("CleanDesk configurado, reinicielo para que empiece a funcionar", MsgBoxStyle.Information)
            Close()
        End If
        Timer1.Enabled = True
        ProgressBar1.Value = 100
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.1
        If Me.Opacity = 1 Then Timer1.Enabled = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Opacity -= 0.1
        If Me.Opacity = 0 Then
            Timer1.Enabled = False
            Me.Close()
        End If
    End Sub
End Class
