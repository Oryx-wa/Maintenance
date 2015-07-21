Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework

Namespace OWA.SBO.OryxMtceOrderWinx
    <FormAttribute("142", "AddOnForms/PurchaseOrder1.b1f")>
    Friend Class PurchaseOrder1
        Inherits SystemFormBase

        Public Sub New()
        End Sub

        Public Overrides Sub OnInitializeComponent()
            'Me.EditText0 = CType(Me.GetItem("Item_0").Specific, SAPbouiCOM.EditText)
            'Me.StaticText0 = CType(Me.GetItem("Item_1").Specific, SAPbouiCOM.StaticText)
            Me.OnCustomInitialize()

        End Sub

        Public Overrides Sub OnInitializeFormEvents()
            AddHandler LoadAfter, AddressOf Me.Form_LoadAfter

        End Sub
        Private WithEvents EditText0 As SAPbouiCOM.EditText

        Private Sub OnCustomInitialize()

        End Sub
        Private WithEvents StaticText0 As SAPbouiCOM.StaticText

        Private Sub Form_LoadAfter(pVal As SAPbouiCOM.SBOItemEventArg)
            'Throw New System.NotImplementedException()

        End Sub
    End Class
End Namespace
