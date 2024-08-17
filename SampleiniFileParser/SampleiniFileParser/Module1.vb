' https://github.com/glennsdev/IniFile
' Load TEST.INI file on current EXE directory (The test.ini file must be in the bin\debug folder)
' Download latest release (compiled DLL): https://github.com/glennsdev/IniFile/releases/download/1.2/IniFile.dll.zip
' No need [section] feature and no future plan to supporting it
' Supporting remark ";" sign
'
' After key item, equals and value will come. There will be no white space between key and value.
'   debug = yes(Incorrect sentence)
'   Debug = yes(Correct sentence).
'
'Imports GLib
' Imports GLib.IniFile

Module Module1
    Dim oIniFile As New GLib.IniFile
    Dim lLoad As Boolean
    Dim vIniFile As String = "test.ini"
    Dim filePath As String = Nothing
    Dim fileContents As String = Nothing
    Sub Main(args As String())
        ' Komut satırından geçilen dosya yolunu alın
        If args.Length <> 1 Then
            Console.WriteLine("Dosya yolu parametresi gereklidir!")
            Return
        End If
        Dim filePath As String = args(0)

        ' Procedures 
        LoadIni()
        ReadKey("debug")
        ChangeKey("debug", False)
        SaveIni()
    End Sub
    Sub ReadKey(ByVal vkey As String)
        Dim str As String = oIniFile.Items(vkey) ' or 
        MsgBox("str value : " & str)
    End Sub
    Sub ChangeKey(ByVal vkey As String, vValue As String)
        oIniFile.Items(vkey) = vValue
        'oIniFile(vkey2) = "config:development1.ini"
    End Sub
    Sub LoadIni()
        lLoad = oIniFile.LoadFile(vIniFile) ' test.ini is in the bin\debug director (Debug Mode)
        If (lLoad = False) Then
            MsgBox("ini file not found !")
        End If
    End Sub
    Sub SaveIni()
        Dim lSave As Boolean
        '-- Save using the file name passed on LoadFile()
        lSave = oIniFile.SaveFile()
        If (lSave) Then
            MsgBox("Success")
        Else
            MsgBox("Unsuccess")
        End If
    End Sub
    Sub ReadFile()
        ' Dosyayı okuyup konsola yazdırın
        If System.IO.File.Exists(filePath) Then
            fileContents = System.IO.File.ReadAllText(filePath)
            Console.WriteLine(fileContents)
        Else
            Console.WriteLine("Dosya bulunamadı!")
        End If
    End Sub
End Module

