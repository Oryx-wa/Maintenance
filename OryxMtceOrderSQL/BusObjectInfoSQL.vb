Imports SBO.SboAddOnBase

Public Class BusObjectInfoSQL
    Inherits SBOSQLBase

    Sub New(pAddOn As SboAddon)
        MyBase.New(pAddOn)
    End Sub

    Protected Overrides Function GetAppResource(filename As String) As System.IO.Stream
        Dim thisExe As System.Reflection.Assembly
        Dim file As System.IO.Stream = Nothing
        Try
            thisExe = System.Reflection.Assembly.GetExecutingAssembly
            file = thisExe.GetManifestResourceStream("OWA.SBO.OryxMtceOrderSQL." + filename)
        Catch ex As Exception

        End Try

        Return file

    End Function
End Class
