Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework
Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderLib

<FormAttribute("OWA.SBO.OryxMtceOrderWinx.PMtceSchedule", "AddOnForms/PMtceSchedule.b1f")>
Friend Class PMtceSchedule
    Inherits UserFormBaseClass

    Public Sub New()
    End Sub

    Protected Overrides Sub InitBase(ByVal pAddOn As SboAddon)
        MyBase.InitBase(pAddOn)
        Me.CreateObject(New PMtceSched(pAddOn, Me.UIAPIRawForm))
    End Sub

    Public Overrides Sub OnInitializeComponent()
        Me.Folder0 = CType(Me.GetItem("Item_1").Specific, SAPbouiCOM.Folder)
        Me.Folder1 = CType(Me.GetItem("Item_2").Specific, SAPbouiCOM.Folder)
        Me.Button0 = CType(Me.GetItem("1").Specific, SAPbouiCOM.Button)
        Me.Button1 = CType(Me.GetItem("2").Specific, SAPbouiCOM.Button)
        Me.StaticText0 = CType(Me.GetItem("Item_4").Specific, SAPbouiCOM.StaticText)
        Me.EditText0 = CType(Me.GetItem("txMacName").Specific, SAPbouiCOM.EditText)
        Me.StaticText1 = CType(Me.GetItem("Item_6").Specific, SAPbouiCOM.StaticText)
        Me.Matrix0 = CType(Me.GetItem("grdSched").Specific, SAPbouiCOM.Matrix)
        Me.Matrix1 = CType(Me.GetItem("grdcoutr").Specific, SAPbouiCOM.Matrix)
        Me.EditText1 = CType(Me.GetItem("txtMachId").Specific, SAPbouiCOM.EditText)
        Me.OnCustomInitialize()

    End Sub

    Public Overrides Sub OnInitializeFormEvents()
        AddHandler LoadAfter, AddressOf Me.Form_LoadAfter

    End Sub

    Private Sub OnCustomInitialize()

    End Sub

    Private WithEvents Folder0 As SAPbouiCOM.Folder
    Private WithEvents Folder1 As SAPbouiCOM.Folder
    Private WithEvents Button0 As SAPbouiCOM.Button
    Private WithEvents Button1 As SAPbouiCOM.Button
    Private WithEvents StaticText0 As SAPbouiCOM.StaticText
    Private WithEvents EditText0 As SAPbouiCOM.EditText
    Private WithEvents StaticText1 As SAPbouiCOM.StaticText
    Private WithEvents Matrix0 As SAPbouiCOM.Matrix
    Private WithEvents Matrix1 As SAPbouiCOM.Matrix
    Private WithEvents EditText1 As SAPbouiCOM.EditText

    Private Sub Form_LoadAfter(ByVal pVal As SAPbouiCOM.SBOItemEventArg)

    End Sub

    Private Sub EditText1_ChooseFromListAfter(ByVal sboObject As System.Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles EditText1.ChooseFromListAfter, Matrix0.ChooseFromListAfter, Matrix1.ChooseFromListAfter
        m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Private Sub Matrix0_PressedBefore(ByVal sboObject As System.Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As System.Boolean) Handles Matrix0.PressedBefore
        oForm.DataSources.DBDataSources.Item("@OWA_MACACTIVITY").Clear()
        Matrix0 = oForm.Items.Item("grdSched").Specific

        If pVal.Row = Matrix0.RowCount + 1 Then
            If pVal.Row = 1 Then
                Matrix0.AddRow(1)
            Else
                Matrix0.AddRow(1, Matrix0.RowCount)
            End If
            Matrix0.Columns.Item(1).Cells.Item(pVal.Row).Click()
        End If
    End Sub

    Private Sub Matrix1_PressedBefore(ByVal sboObject As System.Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As System.Boolean) Handles Matrix1.PressedBefore
        oForm.DataSources.DBDataSources.Item("@OWA_MACCOUNTERS").Clear()
        Matrix1 = oForm.Items.Item("grdcoutr").Specific

        If pVal.Row = Matrix1.RowCount + 1 Then
            If pVal.Row = 1 Then
                Matrix1.AddRow(1)
            Else
                Matrix1.AddRow(1, Matrix0.RowCount)
            End If
            Matrix1.Columns.Item(1).Cells.Item(pVal.Row).Click()
        End If
    End Sub
End Class