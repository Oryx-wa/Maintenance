
Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework


'<FormAttribute("OWAMORPRTYPEs")>
<FormAttribute("OWA.SBO.OryxMtceOrderWinx.prtypes_b1f", "AddOnForms/prtypes.b1f")>
Friend Class prtypes_b1f
    Inherits UDOFormBase

    Public Sub New()
    End Sub

    Public Overrides Sub OnInitializeComponent()
        Me.OnCustomInitialize()

    End Sub

    Public Overrides Sub OnInitializeFormEvents()
        'AddHandler LoadAfter, AddressOf Me.Form_LoadAfter

    End Sub

    Private Sub OnCustomInitialize()

    End Sub
    Private Sub Form_LoadAfter(pVal As SAPbouiCOM.SBOItemEventArg)
        ' Throw New System.NotImplementedException()

    End Sub
End Class

