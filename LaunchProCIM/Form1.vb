Imports System.IO
Imports System.Environment

Public Module GlobalVariables
    Public DevMode As String = "0"
    Public IniFileName As String = ""
    Public Const QUOTE = """"
    Public IniFile As String = "procim.ini"
    Public DBServer As String = ""
    Public PFiles As String = ""
    Public PCLoc As String = "\ProCIM Suite\ProCIM\"
    Public PCFileName As String = ""
    Public OSType As Boolean = Environment.Is64BitOperatingSystem
End Module

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

#Region "Declarations"
        'Set initial values for the comboxbox's
        cmbDivision.SelectedIndex = 1
        cmbDatabase.SelectedIndex = 0
#End Region

        'Check for Dev Mode
        ParseCommandLineArgs(DevMode)
        If GlobalVariables.DevMode = "1" Then
            cmbDatabase.Items.Add("ProCIMTest")
        End If

    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        'Assign values from combobox's and test if not null
        Dim Div As String = cmbDivision.SelectedItem
        Dim Db As String = cmbDatabase.SelectedItem

        If Not (cmbDatabase.SelectedItem Is Nothing) Then
            Db = cmbDatabase.SelectedItem
        End If
        If Not (cmbDivision.SelectedItem Is Nothing) Then
            Div = cmbDivision.SelectedItem
        End If
        If Db Is Nothing Or Div Is Nothing Then
            MessageBox.Show("Please select from both lists")
        End If

        'If OK, create INI file
        If Not Db Is Nothing And Not Div Is Nothing Then
            CreateIni(Div, Db)
        End If

        'Create Launcher string
        Dim ProCIMStart As String = PFiles & PCLoc & "ProCIM Launcher.exe"

        'Start ProCIM and Exit
        Process.Start(ProCIMStart)
        Application.Exit()
    End Sub

    Private Sub CreateIni(ByVal Div As String, ByVal Db As String)

        'Set server name
        If cmbDivision.SelectedItem = "East" Then
            DBServer = "dbsrvr"
        Else
            DBServer = "procim"
        End If

        'Get and Check OS Type - Assign Program Files variable
        If OSType Then
            PFiles = Environment.GetEnvironmentVariable(My.Settings.PFilesEnvx64)
            If PFiles Is Nothing Then
                Environment.SetEnvironmentVariable(My.Settings.PFilesEnvx64, My.Settings.PFilesx64)
                PFiles = Environment.GetEnvironmentVariable(My.Settings.PFilesEnvx64)
            End If
        Else
            PFiles = Environment.GetEnvironmentVariable(My.Settings.PfilesEnvx86)
            If PFiles Is Nothing Then
                Environment.SetEnvironmentVariable(My.Settings.PfilesEnvx86, My.Settings.PFilesx86)
                PFiles = Environment.GetEnvironmentVariable(My.Settings.PfilesEnvx86)
            End If
        End If

        'Set INI file name
        PCFileName = PFiles & PCLoc & IniFile & IniFileName

        'Write the file to temp file
        Dim strFileName As String = WriteToControlFile("")    'The control file
        Dim oFileStream As New FileStream(strFileName, FileMode.Append)
        Dim oWriter As New StreamWriter(oFileStream)
        oWriter.WriteLine("[DBAccess]")
        oWriter.WriteLine("ServerName=" & DBServer)
        oWriter.WriteLine("DatabaseName=" & cmbDatabase.SelectedItem)
        oWriter.WriteLine("Facility=1")
        oWriter.WriteLine("Splash=Yes")
        oWriter.Close()
        oFileStream.Close()

        'Move contents of temp file to INI file
        System.IO.File.Copy(strFileName, PCFileName, True)
        
    End Sub

    Private Function ParseCommandLineArgs(ByRef DevMode As String)
        Dim inputArgument As String = "/dev="
        Dim inputName As String = ""
        'Parse command line to check for dev mode
        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower.StartsWith(inputArgument) Then
                inputName = s.Remove(0, inputArgument.Length)
            End If
        Next

        DevMode = inputName
        Return DevMode

    End Function

    Public Function WriteToControlFile(ByVal Data As String) As String
        ' Writes text to the ProCIM control file and retu
        'Dim strFilename As String = My.Settings.BatchFilerns path
        Dim strFilename As String = Path.GetTempFileName()
        Dim objFS As New System.IO.FileStream(strFilename,
            System.IO.FileMode.Create,
            System.IO.FileAccess.Write)
        ' Opens stream and begins writing
        Dim Writer As New StreamWriter(objFS)
        Writer.BaseStream.Seek(0, SeekOrigin.End)
        Writer.WriteLine(Data)
        Writer.Flush()
        ' Closes and returns temp path
        Writer.Close()
        Return strFilename

    End Function
End Class
