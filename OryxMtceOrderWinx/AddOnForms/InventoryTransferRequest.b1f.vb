Option Strict Off
Option Explicit On
Imports OWA.SBO.OryxMtceOrderLib

Imports SAPbouiCOM.Framework

Namespace OWA.SBO.OryxMtceOrderWinx
    <FormAttribute("1250000940", "AddOnForms/InventoryTransferRequest.b1f")>
    Friend Class InventoryTransferRequest
        Inherits SystemFormBase
        Private ReleaseForm As Boolean = False
        Public Sub New()
        End Sub

        Public Overrides Sub OnInitializeComponent()
            Me.EditText0 = CType(Me.GetItem("txtOrder").Specific, SAPbouiCOM.EditText)
            Me.StaticText0 = CType(Me.GetItem("Item_1").Specific, SAPbouiCOM.StaticText)
            EditText0.DataBind.SetBound(True, Me.UIAPIRawForm.DataSources.DBDataSources.Item(0).TableName, "U_MtceOrder")
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
            If InvReqFormParam.MaintenanceId <> 0 Then
                EditText0.Value = InvReqFormParam.MaintenanceId
                InvReqFormParam.MaintenanceId = 0
                ReleaseForm = True

            Else
                EditText0.Item.Visible = False
                StaticText0.Item.Visible = False
            End If

        End Sub

        Private Sub InventoryTransferRequest_UnloadAfter(pVal As SAPbouiCOM.SBOItemEventArg) Handles Me.UnloadAfter
            If ReleaseForm Then InvReqFormParam.oPM.FormRelease(False)

        End Sub
    End Class
End Namespace
