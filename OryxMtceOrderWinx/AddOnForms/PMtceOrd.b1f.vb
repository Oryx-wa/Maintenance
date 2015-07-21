Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework
Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderLib

<FormAttribute("OWA.SBO.OryxMtceOrderWinx.PMtceOrd_b1f", "AddOnForms/PMtceOrd.b1f")>
Friend Class PMtceOrd_b1f
    Inherits UserFormBaseClass
    Private WithEvents txtOprID As SAPbouiCOM.EditText
    Private WithEvents txtOprName As SAPbouiCOM.EditText
    Private WithEvents Button0 As SAPbouiCOM.Button
    Private WithEvents Button1 As SAPbouiCOM.Button
    Private WithEvents colPrice As SAPbouiCOM.Column
    Private WithEvents colQty As SAPbouiCOM.Column
    Private WithEvents colAmt As SAPbouiCOM.Column
    Private WithEvents EditText0 As SAPbouiCOM.EditText
    Private WithEvents ComboBox0 As SAPbouiCOM.ComboBox
    Private WithEvents ComboBox1 As SAPbouiCOM.ComboBox
    Private WithEvents ComboBox2 As SAPbouiCOM.ComboBox
    Private WithEvents ButtonCombo0 As SAPbouiCOM.ButtonCombo
    Private WithEvents Grid0 As SAPbouiCOM.Grid

    Public Sub New()
    End Sub

    Protected Overrides Sub InitBase(ByVal pAddOn As SboAddon)
        MyBase.InitBase(pAddOn)
        Me.CreateObject(New PMtceOrd(pAddOn, Me.UIAPIRawForm))
    End Sub

    Public Overrides Sub OnInitializeComponent()
        Me.txtOprID = CType(Me.GetItem("txtOprID").Specific, SAPbouiCOM.EditText)
        Me.txtOprName = CType(Me.GetItem("txtOprName").Specific, SAPbouiCOM.EditText)
        Me.Button0 = CType(Me.GetItem("1").Specific, SAPbouiCOM.Button)
        Me.Button1 = CType(Me.GetItem("2").Specific, SAPbouiCOM.Button)
        Me.EditText0 = CType(Me.GetItem("Item_103").Specific, SAPbouiCOM.EditText)
        Me.ComboBox0 = CType(Me.GetItem("cboOrg").Specific, SAPbouiCOM.ComboBox)
        Me.ComboBox1 = CType(Me.GetItem("cboProb").Specific, SAPbouiCOM.ComboBox)
        Me.ComboBox2 = CType(Me.GetItem("cboTech").Specific, SAPbouiCOM.ComboBox)
        Me.ButtonCombo0 = CType(Me.GetItem("cboCreate").Specific, SAPbouiCOM.ButtonCombo)
        Me.Grid0 = CType(Me.GetItem("grdTrans").Specific, SAPbouiCOM.Grid)
        Me.StaticText3 = CType(Me.GetItem("Item_11").Specific, SAPbouiCOM.StaticText)
        Me.EditText4 = CType(Me.GetItem("txtPrc").Specific, SAPbouiCOM.EditText)
        Me.ComboBox4 = CType(Me.GetItem("cboStatus").Specific, SAPbouiCOM.ComboBox)
        Me.ComboBox5 = CType(Me.GetItem("cboType").Specific, SAPbouiCOM.ComboBox)
        Me.StaticText0 = CType(Me.GetItem("Item_3").Specific, SAPbouiCOM.StaticText)
        Me.StaticText1 = CType(Me.GetItem("Item_4").Specific, SAPbouiCOM.StaticText)
        Me.StaticText2 = CType(Me.GetItem("Item_1").Specific, SAPbouiCOM.StaticText)
        Me.EditText1 = CType(Me.GetItem("txtDate").Specific, SAPbouiCOM.EditText)
        Me.EditText2 = CType(Me.GetItem("txtTime").Specific, SAPbouiCOM.EditText)
        Me.txtBrk = CType(Me.GetItem("txtBrk").Specific, SAPbouiCOM.EditText)
        Me.EditText3 = CType(Me.GetItem("txtMach").Specific, SAPbouiCOM.EditText)
        Me.LinkedButton0 = CType(Me.GetItem("Item_9").Specific, SAPbouiCOM.LinkedButton)
        Me.LinkedButton1 = CType(Me.GetItem("Item_10").Specific, SAPbouiCOM.LinkedButton)
        Me.OnCustomInitialize()

    End Sub


    Private Sub txtOprID_ChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles txtOprID.ChooseFromListAfter, txtBrk.ChooseFromListAfter, EditText3.ChooseFromListAfter
        m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Private Sub txtOprID_ChooseFromListBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles txtOprID.ChooseFromListBefore
        'm_BaseObject.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)
    End Sub

    Private Sub cboMach_ComboSelectAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg) Handles ButtonCombo0.ComboSelectAfter, ComboBox1.ComboSelectAfter, ComboBox0.ComboSelectAfter, ComboBox2.ComboSelectAfter, ComboBox4.ComboSelectAfter, ComboBox5.ComboSelectAfter

        m_BaseObject.OnComboSelectAfter(sboObject, pVal)
    End Sub



    Private Sub OnCustomInitialize()

    End Sub


    Public Overrides Sub OnInitializeFormEvents()
        AddHandler LoadAfter, AddressOf Me.Form_LoadAfter

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()
    End Sub


    'Private Sub OnValidateAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles colQty.ValidateAfter, colPrice.ValidateAfter
    '    m_BaseObject.OnItemValidateAfter(sboObject, pVal)
    'End Sub

    'Private Sub OnValidateBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles colQty.ValidateBefore, colPrice.ValidateBefore
    '    m_BaseObject.OnItemValidateBefore(sboObject, pVal, BubbleEvent)
    'End Sub



    Private Sub Grid0_LinkPressedBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles Grid0.LinkPressedBefore
        m_BaseObject.OnLinkedPressedBefore(sboObject, pVal, BubbleEvent)
    End Sub
    Private WithEvents StaticText3 As SAPbouiCOM.StaticText
    Private WithEvents EditText4 As SAPbouiCOM.EditText
    Private WithEvents txtBrk As SAPbouiCOM.EditText

    Private Sub Form_LoadAfter(pVal As SAPbouiCOM.SBOItemEventArg)


    End Sub

    Private Sub cboMach_ComboSelectBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles ComboBox0.ComboSelectBefore, ComboBox0.ComboSelectBefore, ComboBox2.ComboSelectBefore, ComboBox1.ComboSelectBefore, ButtonCombo0.ComboSelectBefore, ComboBox4.ComboSelectBefore
        m_BaseObject.OnComboSelectBefore(sboObject, pVal, BubbleEvent)
    End Sub
    Private WithEvents ComboBox4 As SAPbouiCOM.ComboBox
    Private WithEvents ComboBox5 As SAPbouiCOM.ComboBox
    Private WithEvents StaticText0 As SAPbouiCOM.StaticText
    Private WithEvents StaticText1 As SAPbouiCOM.StaticText
    Private WithEvents StaticText2 As SAPbouiCOM.StaticText
    Private WithEvents EditText1 As SAPbouiCOM.EditText
    Private WithEvents EditText2 As SAPbouiCOM.EditText
    Private WithEvents EditText3 As SAPbouiCOM.EditText
    Private WithEvents LinkedButton0 As SAPbouiCOM.LinkedButton
    Private WithEvents LinkedButton1 As SAPbouiCOM.LinkedButton


    'Private Sub cboMach_ComboSelectAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg) Handles cboMach.ComboSelectAfter

    'End Sub
End Class

