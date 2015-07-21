Imports SAPbouiCOM.Framework
Imports SBO.SboAddOnBase

Public Class MtceOrderAddOn
    Inherits SboAddon

    Private WithEvents SBO_Application As SAPbouiCOM.Application

    Sub New()
        'SBO_Application = Application.SBO_Application
    End Sub

    Public Sub New(ByVal StartUpPath As String, ByVal AddonName As String, ByRef pbo_RunApplication As Boolean)

        MyBase.New(StartUpPath, AddonName)
        m_Namespace = "OWA.SBO.OryxMtceOrderWinx"
        m_AssemblyName = "OryxMtceOrderWinx"
        TablePrefix = "OWA"
        PermissionPrefix = "OWA_MOR"
        MenuXMLFileName = "Menus.xml"


        If IsNothing(m_SboApplication) Then
            pbo_RunApplication = False
            Exit Sub
        Else

            If Not initialise() Then
                pbo_RunApplication = False
                Exit Sub
            End If

        End If
        oApp.Run()
        pbo_RunApplication = True
        'Me.setFilters(oFilters)

    End Sub
    <STAThread()>
    Public Sub Main()

    End Sub


    Public Overrides Sub WriteLog(ByVal strLog As String)
        Dim appstartPath As String = Windows.Forms.Application.StartupPath + "\PayrollLog.txt"
        Dim file As New System.IO.StreamWriter(appstartPath, True)
        file.Write(strLog + ",,,,,,,")
        file.Close()
    End Sub

    Public Overrides Sub WriteLog(ByVal strLog As String, ByVal strFileName As String)
        Dim appstartPath As String = Windows.Forms.Application.StartupPath + strFileName
        Dim file As New System.IO.StreamWriter(appstartPath, True)
        file.Write(strLog)
        file.Close()
    End Sub
End Class


