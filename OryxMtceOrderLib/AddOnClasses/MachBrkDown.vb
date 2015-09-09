Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderSQL


Public Class MachBrkDown
    Inherits SBOBaseObject

    Dim lblOprName As SAPbouiCOM.StaticText
    Dim txtPOdr As SAPbouiCOM.EditText
    Dim txtPrd As SAPbouiCOM.EditText
    Dim txtOpr As SAPbouiCOM.EditText


    Sub New(ByVal pAddon As SboAddon, ByVal pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddon, pForm)
        InitSBOServerSQL(New BusObjectInfoSQL(pAddon))
    End Sub


    Public Overrides Sub OnChooseFromListBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)

    End Sub

    Public Overrides Sub OnChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnChooseFromListAfter(sboObject, pVal)

        Dim Val As String = HandleChooseFromListEvent(pVal.FormUID, pVal, False)
        Dim dbPOrd As SAPbouiCOM.DBDataSource
        Dim dbOpr As SAPbouiCOM.DBDataSource

        dbPOrd = m_Form.DataSources.DBDataSources.Item("OWOR")
        dbOpr = m_Form.DataSources.DBDataSources.Item("OHEM")

        If String.IsNullOrEmpty(Val) Then Return

        Select Case pVal.ItemUID

            Case "txtPOdr"
                m_DBDataSource0.SetValue("U_PdOrder", 0, Val)
                getOffset(Val, "DocNum", dbOpr)
                txtPrd.Value = dbPOrd.GetValue("ItemCode", dbPOrd.Offset).Trim
            Case "txtOpr"
                m_DBDataSource0.SetValue("U_Operator", 0, Val)

                getOffset(Val, "empID", dbOpr)
                Dim strName As String = dbOpr.GetValue("lastName", dbOpr.Offset).Trim + ", " + dbOpr.GetValue("firstName", dbOpr.Offset).Trim
                lblOprName.Caption = strName

           
        End Select

    End Sub

    Protected Overrides Sub OnFormInit()
        MyBase.OnFormInit()

        'txtPOdr = CType(Me.m_Form.Items.Item("txtPOdr").Specific, SAPbouiCOM.EditText)
        lblOprName = CType(Me.m_Form.Items.Item("lblOprNam").Specific, SAPbouiCOM.StaticText)
        txtOpr = CType(Me.m_Form.Items.Item("txtOpr").Specific, SAPbouiCOM.EditText)
        cbodept = CType(Me.m_Form.Items.Item("cbodept").Specific, SAPbouiCOM.ComboBox)
        cboMach = CType(Me.m_Form.Items.Item("cboMach").Specific, SAPbouiCOM.ComboBox)
    End Sub
    Public Overrides Sub OnComponentInit()
        MyBase.OnComponentInit()

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()
        m_Form.EnableMenu("1292", True)
        m_Form.EnableMenu("1293", True)
    End Sub


    Private matOrdDet As SAPbouiCOM.Matrix
    Private txtMach As SAPbouiCOM.EditText
    Private txtMachGrp As SAPbouiCOM.EditText
    Private txtOprName As SAPbouiCOM.EditText
    Private cboMach As SAPbouiCOM.ComboBox
    Private cbodept As SAPbouiCOM.ComboBox
    Private colPrice As SAPbouiCOM.Column
    Private colQty As SAPbouiCOM.Column
    Private colAmt As SAPbouiCOM.Column

    Protected Overrides Sub OnFormLoad()
        MyBase.OnFormLoad()

        fillCombo("Code", "Name", "OUDP", cbodept.ValidValues, "UserSign='1'")
        fillCombo("VisResCode", "ResName", "ORSC", cboMach.ValidValues, "ResType='M'")
    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()
        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("@OWA_MORBREAKDOWN")

    End Sub

    Public Overrides Sub OnItemPressedAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnItemPressedAfter(sboObject, pVal)
        m_CurrentLineNo = pVal.Row
    End Sub

    



End Class
