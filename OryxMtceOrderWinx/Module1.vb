Imports SAPbouiCOM.Framework

Module Module1

    Public Addon As MtceOrderAddOn

    <STAThread()>
    Public Sub Main()
        Dim dbo_RunApplication As Boolean

        Addon = New MtceOrderAddOn(Windows.Forms.Application.StartupPath, "Oryx Addons", dbo_RunApplication)

        If dbo_RunApplication = True Then
            System.Windows.Forms.Application.Run()
        Else
            System.Windows.Forms.Application.Exit()
        End If
    End Sub

End Module
