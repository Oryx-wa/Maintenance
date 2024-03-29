﻿Option Strict Off
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
        Me.txtOpr = CType(Me.GetItem("txtOpr").Specific, SAPbouiCOM.EditText)
        Me.Button0 = CType(Me.GetItem("1").Specific, SAPbouiCOM.Button)
        Me.Button1 = CType(Me.GetItem("2").Specific, SAPbouiCOM.Button)
        Me.cboMach = CType(Me.GetItem("cboMach").Specific, SAPbouiCOM.ComboBox)
        Me.EditText0 = CType(Me.GetItem("txtTime").Specific, SAPbouiCOM.EditText)
        Me.EditText1 = CType(Me.GetItem("txtPrd").Specific, SAPbouiCOM.EditText)
        Me.LinkedButton0 = CType(Me.GetItem("Item_3").Specific, SAPbouiCOM.LinkedButton)
        Me.EditText3 = CType(Me.GetItem("txtDate").Specific, SAPbouiCOM.EditText)
        Me.StaticText1 = CType(Me.GetItem("Item_4").Specific, SAPbouiCOM.StaticText)
        Me.StaticText2 = CType(Me.GetItem("Item_5").Specific, SAPbouiCOM.StaticText)
        Me.EditText5 = CType(Me.GetItem("Item_11").Specific, SAPbouiCOM.EditText)
        Me.StaticText3 = CType(Me.GetItem("Item_7").Specific, SAPbouiCOM.StaticText)
        Me.EditText6 = CType(Me.GetItem("Item_13").Specific, SAPbouiCOM.EditText)
        Me.StaticText4 = CType(Me.GetItem("Item_14").Specific, SAPbouiCOM.StaticText)
        Me.EditText7 = CType(Me.GetItem("Item_15").Specific, SAPbouiCOM.EditText)
        Me.ComboBox0 = CType(Me.GetItem("cbodept").Specific, SAPbouiCOM.ComboBox)
        Me.StaticText5 = CType(Me.GetItem("lblOprNam").Specific, SAPbouiCOM.StaticText)
        Me.OnCustomInitialize()

    End Sub

    'Private Sub txtPOdr_ChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles txtPOdr.ChooseFromListAfter
    '    m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    'End Sub

    'Private Sub txtPOdr_ChooseFromListBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean) Handles txtPOdr.ChooseFromListBefore
    '    m_BaseObject.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)
    'End Sub

 

    Private Sub OnCustomInitialize()

    End Sub


    Public Overrides Sub OnInitializeFormEvents()

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()
    End Sub
    Private WithEvents StaticText0 As SAPbouiCOM.StaticText
    Private WithEvents EditText0 As SAPbouiCOM.EditText
    Private WithEvents EditText2 As SAPbouiCOM.EditText
    Private WithEvents EditText1 As SAPbouiCOM.EditText
    Private WithEvents LinkedButton0 As SAPbouiCOM.LinkedButton
    Private WithEvents EditText3 As SAPbouiCOM.EditText
    Private WithEvents StaticText1 As SAPbouiCOM.StaticText
    Private WithEvents StaticText2 As SAPbouiCOM.StaticText
    Private WithEvents EditText5 As SAPbouiCOM.EditText
    Private WithEvents StaticText3 As SAPbouiCOM.StaticText
    Private WithEvents EditText6 As SAPbouiCOM.EditText
    Private WithEvents StaticText4 As SAPbouiCOM.StaticText
    Private WithEvents EditText7 As SAPbouiCOM.EditText
    Private WithEvents ComboBox0 As SAPbouiCOM.ComboBox




    
    Private Sub txtOpr_ChooseFromListAfter(ByVal sboObject As System.Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg) Handles txtOpr.ChooseFromListAfter
        m_BaseObject.OnChooseFromListAfter(sboObject, pVal)
    End Sub
    Private WithEvents StaticText5 As SAPbouiCOM.StaticText
End Class
