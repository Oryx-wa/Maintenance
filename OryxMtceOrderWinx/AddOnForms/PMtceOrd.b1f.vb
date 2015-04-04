Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework
Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderLib

<FormAttribute("OWA.SBO.OryxMtceOrderWinx.PMtceOrd_b1f", "AddOnForms/PMtceOrd.b1f")>
Friend Class PMtceOrd_b1f
    Inherits UserFormBaseClass

    Public Sub New()
    End Sub

    Protected Overrides Sub InitBase(ByVal pAddOn As SboAddon)
        MyBase.InitBase(pAddOn)
        Me.CreateObject(New PMtceOrd(pAddOn, Me.UIAPIRawForm))
    End Sub

    Public Overrides Sub OnInitializeComponent()
        Me.txtOprID = CType(Me.GetItem("txtOprID").Specific, SAPbouiCOM.EditText)
        Me.txtOprName = CType(Me.GetItem("txtOprName").Specific, SAPbouiCOM.EditText)
        Me.txtMachGrp = CType(Me.GetItem("txtMachGrp").Specific, SAPbouiCOM.EditText)
        Me.Button0 = CType(Me.GetItem("1").Specific, SAPbouiCOM.Button)
        Me.Button1 = CType(Me.GetItem("2").Specific, SAPbouiCOM.Button)
        Me.matOrdDet = CType(Me.GetItem("matOrdDet").Specific, SAPbouiCOM.Matrix)
        Me.cboMach = CType(Me.GetItem("cboMach").Specific, SAPbouiCOM.ComboBox)
        Me.EditText0 = CType(Me.GetItem("Item_103").Specific, SAPbouiCOM.EditText)
        Me.OnCustomInitialize()

    End Sub


    Private Sub txtOprID_ChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles txtOprID.ChooseFromListAfter
        m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Private Sub txtOprID_ChooseFromListBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles txtOprID.ChooseFromListBefore
        m_BaseObject.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)
    End Sub

    Private Sub cboMach_ComboSelectAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles cboMach.ComboSelectAfter
        m_BaseObject.OnComboSelectAfter(sboObject, pVal)
    End Sub

    Private Sub matOrdDet_ChooseFromListBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles matOrdDet.ChooseFromListBefore
        m_BaseObject.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)
    End Sub

    Private Sub matOrdDet_ComboSelectAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles matOrdDet.ComboSelectAfter
        m_BaseObject.OnComboSelectAfter(sboObject, pVal)
    End Sub

    Private Sub matOrdDet_ComboSelectBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles matOrdDet.ComboSelectBefore
        m_BaseObject.OnComboSelectBefore(sboObject, pVal, BubbleEvent)
    End Sub

    Private Sub matOrdDet_ChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles matOrdDet.ChooseFromListAfter
        m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Private Sub matOrdDet_PressedAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles matOrdDet.PressedAfter
        m_BaseObject.OnItemPressedAfter(sboObject, pVal)
    End Sub

    Private Sub matOrdDet_PressedBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles matOrdDet.PressedBefore
        m_BaseObject.OnItemPressedBefore(sboObject, pVal, BubbleEvent)
    End Sub



    Private Sub OnCustomInitialize()

    End Sub


    Public Overrides Sub OnInitializeFormEvents()

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()
    End Sub

    Private WithEvents txtOprID As SAPbouiCOM.EditText
    Private WithEvents txtOprName As SAPbouiCOM.EditText
    Private WithEvents txtMachGrp As SAPbouiCOM.EditText
    Private WithEvents Button0 As SAPbouiCOM.Button
    Private WithEvents Button1 As SAPbouiCOM.Button
    Private WithEvents matOrdDet As SAPbouiCOM.Matrix
    Private WithEvents cboMach As SAPbouiCOM.ComboBox
    Private WithEvents colPrice As SAPbouiCOM.Column
    Private WithEvents colQty As SAPbouiCOM.Column
    Private WithEvents colAmt As SAPbouiCOM.Column
    Private WithEvents EditText0 As SAPbouiCOM.EditText

    'Private Sub OnValidateAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles colQty.ValidateAfter, colPrice.ValidateAfter
    '    m_BaseObject.OnItemValidateAfter(sboObject, pVal)
    'End Sub

    'Private Sub OnValidateBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles colQty.ValidateBefore, colPrice.ValidateBefore
    '    m_BaseObject.OnItemValidateBefore(sboObject, pVal, BubbleEvent)
    'End Sub
   
 
End Class

