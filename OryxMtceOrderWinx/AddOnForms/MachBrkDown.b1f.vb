Option Strict Off
Option Explicit On

Imports SAPbouiCOM.Framework
Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderLib


<FormAttribute("OWA.SBO.OryxMtceOrderWinx.MachBrkDown_b1f", "AddOnForms/MachBrkDown.b1f")>
    Friend Class MachBrkDown_b1f
    Inherits UserFormBaseClass

    Private WithEvents txtOpr As SAPbouiCOM.EditText
    Private WithEvents txtPOdr As SAPbouiCOM.EditText
    Private WithEvents txtPrd As SAPbouiCOM.EditText
    Private WithEvents Button0 As SAPbouiCOM.Button
    Private WithEvents Button1 As SAPbouiCOM.Button
    Private WithEvents lblMachName As SAPbouiCOM.StaticText
    Private WithEvents lblOprName As SAPbouiCOM.StaticText
    Private WithEvents lblprdName As SAPbouiCOM.StaticText
    Private WithEvents cboMach As SAPbouiCOM.ComboBox

    Public Sub New()
    End Sub

    Protected Overrides Sub InitBase(ByVal pAddOn As SboAddon)
        MyBase.InitBase(pAddOn)
        Me.CreateObject(New MachBrkDown(pAddOn, Me.UIAPIRawForm))
    End Sub


    Public Overrides Sub OnInitializeComponent()
        Me.txtPOdr = CType(Me.GetItem("txtPOdr").Specific, SAPbouiCOM.EditText)
        Me.txtPrd = CType(Me.GetItem("txtPrd").Specific, SAPbouiCOM.EditText)
        Me.txtOpr = CType(Me.GetItem("txtOpr").Specific, SAPbouiCOM.EditText)
        Me.Button0 = CType(Me.GetItem("1").Specific, SAPbouiCOM.Button)
        Me.Button1 = CType(Me.GetItem("2").Specific, SAPbouiCOM.Button)
        Me.lblMachName = CType(Me.GetItem("MachName").Specific, SAPbouiCOM.StaticText)
        Me.lblOprName = CType(Me.GetItem("OprName").Specific, SAPbouiCOM.StaticText)
        Me.lblprdName = CType(Me.GetItem("prdName").Specific, SAPbouiCOM.StaticText)
        Me.cboMach = CType(Me.GetItem("cboMach").Specific, SAPbouiCOM.ComboBox)
        Me.OnCustomInitialize()

    End Sub

    Private Sub txtPOdr_ChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles txtPOdr.ChooseFromListAfter
        m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Private Sub txtPOdr_ChooseFromListBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles txtPOdr.ChooseFromListBefore
        m_BaseObject.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)
    End Sub

 

    Private Sub OnCustomInitialize()

    End Sub


    Public Overrides Sub OnInitializeFormEvents()

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()
    End Sub
  

   

End Class
