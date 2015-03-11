Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderSQL


Public Class PMtceOrd
    Inherits SBOBaseObject

    Dim dbItem As SAPbouiCOM.DBDataSource
    Dim dbOrderDet As SAPbouiCOM.DBDataSource

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

        dbItem = m_Form.DataSources.DBDataSources.Item("OITM")

        If String.IsNullOrEmpty(Val) Then Return

        Select Case pVal.ItemUID

            Case "txtOprID"
                m_DBDataSource2.SetValue("U_operatorID", 0, Val)

                If getOffset(Val, "empID", m_DBDataSource0) Then
                    CType(Me.m_Form.Items.Item("txtOprName").Specific, SAPbouiCOM.EditText).Value = m_DBDataSource0.GetValue("firstName", 0).Trim & _
                          ", " & m_DBDataSource0.GetValue("lastName", 0).Trim
                End If

            Case "matOrdDet"
                Select Case pVal.ColUID
                    Case "cItemCode"
                        matOrdDet.SetCellWithoutValidation(pVal.Row, pVal.ColUID, Val)
                        If getOffset(Val, "ItemCode", dbItem) Then
                            matOrdDet.SetCellWithoutValidation(pVal.Row, "cItemDesc", dbItem.GetValue("ItemName", 0).Trim)
                            matOrdDet.SetCellWithoutValidation(pVal.Row, "cPrice", dbItem.GetValue("LstEvlPric", 0).Trim)
                        End If
                End Select
        End Select

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
    Private colPrice As SAPbouiCOM.Column
    Private colQty As SAPbouiCOM.Column
    Private colAmt As SAPbouiCOM.Column

    Protected Overrides Sub OnFormLoad()
        MyBase.OnFormLoad()

        fillCombo("VisResCode", "ResName", "ORSC", cboMach.ValidValues, "ResType='M'")

    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()

        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("OHEM")
        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("ORSC")
        m_DBDataSource2 = m_Form.DataSources.DBDataSources.Item("@OWA_MORHDR")

    End Sub

    Public Overrides Sub OnItemPressedAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnItemPressedAfter(sboObject, pVal)
        m_CurrentLineNo = pVal.Row
    End Sub

    'Public Sub OnValidateBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
    '    MyBase.OnItemValidateBefore(sboObject, pVal, BubbleEvent)

    '    Dim a, b, c As SAPbouiCOM.EditText

    '    Select Case pVal.ItemUID
    '        Case "cQty", "cPrice"
    '            Try
    '                a = colQty.Cells.Item(pVal.Row).Specific()
    '                b = colPrice.Cells.Item(pVal.Row).Specific()
    '                c = colAmt.Cells.Item(pVal.Row).Specific()

    '                dbOrderDet = m_Form.DataSources.DBDataSources.Item("@OWA_MORDET")
    '                matOrdDet.FlushToDataSource()
    '                dbOrderDet.SetValue("U_amount", pVal.Row - 1, a.Value * b.Value)
    '                matOrdDet.LoadFromDataSource()
    '            Catch ex As Exception
    '                m_ParentAddon.SboApplication.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
    '            End Try

    '    End Select

    'End Sub

    Public Overrides Sub OnComboSelectAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnComboSelectAfter(sboObject, pVal)

        Dim m_DBDataSource3 As SAPbouiCOM.DBDataSource
        m_DBDataSource3 = m_Form.DataSources.DBDataSources.Item("ORSB")

        Select Case pVal.ItemUID
            Case "cboMach"
                If getOffset(m_DBDataSource2.GetValue("U_machineID", 0).Trim, "VisResCode", m_DBDataSource1) Then
                    txtMach.Value = m_DBDataSource1.GetValue("ResName", 0).Trim
                End If

                If getOffset(m_DBDataSource1.GetValue("ResGrpCod", 0).Trim, "ResGrpCod", m_DBDataSource3) Then
                    txtMachGrp.Value = m_DBDataSource3.GetValue("ResGrpNam", 0).Trim
                End If

        End Select

    End Sub

    Protected Overrides Sub SetConditions()
        MyBase.SetConditions()

        With m_Condition
            .Alias = "ItemType"
            .Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL
            .CondVal = "I"
        End With

        m_Form.ChooseFromLists.Item("CFLItem").SetConditions(m_Conditions)

    End Sub

    Public Overrides Sub OnCustomInit()
        MyBase.OnCustomInit()
    End Sub

    Protected Overrides Sub InitFormComponents()
        MyBase.InitFormComponents()

        matOrdDet = CType(Me.m_Form.Items.Item("matOrdDet").Specific, SAPbouiCOM.Matrix)
        cboMach = m_Form.Items.Item("cboMach").Specific
        txtMach = m_Form.Items.Item("txtMach").Specific
        txtMachGrp = m_Form.Items.Item("txtMachGrp").Specific
        'colQty = CType(m_Form.Items.Item("txtMachGrp").Specific, SAPbouiCOM.Matrix).Columns.Item("cQty")
        'colPrice = CType(m_Form.Items.Item("txtMachGrp").Specific, SAPbouiCOM.Matrix).Columns.Item("cPrice")
        'colAmt = CType(m_Form.Items.Item("txtMachGrp").Specific, SAPbouiCOM.Matrix).Columns.Item("cAmt")


    End Sub
    Protected Overrides Sub OnMatrixAddRow()
        MyBase.OnMatrixAddRow()
        AddRowToMatrix(matOrdDet)
    End Sub

    Protected Overrides Function Save(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Return MyBase.Save(pErrNo, pErrMsg)
    End Function

    Protected Overrides Sub OnMatrixDeleteRow()
        MyBase.OnMatrixDeleteRow()
        DeleteMatrixRow(matOrdDet)

    End Sub


    Protected Overrides Sub OnMatrixDeleteAllRows()
        MyBase.OnMatrixDeleteAllRows()
        DeleteAllMatrixRows(matOrdDet)
    End Sub

    Public Overrides Sub OnItemClickBefore(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnItemClickBefore(sboObject, pVal, BubbleEvent)
    End Sub



End Class
