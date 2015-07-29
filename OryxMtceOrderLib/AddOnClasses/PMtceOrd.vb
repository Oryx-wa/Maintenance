Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderSQL

Public Class InvReqFormParam
    Public Shared MaintenanceId As Integer = 0
    Public Shared oPM As PMtceOrd = Nothing
End Class

Public Class PMtceOrd
    Inherits SBOBaseObject

    Dim dbItem As SAPbouiCOM.DBDataSource
    Dim dbOrderDet As SAPbouiCOM.DBDataSource

    Private matOrdDet As SAPbouiCOM.Matrix
    Private txtMach As SAPbouiCOM.EditText, txtPrc As SAPbouiCOM.EditText
    Private txtMachGrp As SAPbouiCOM.EditText
    Private txtOprName As SAPbouiCOM.EditText
    Private cboMach As SAPbouiCOM.ComboBox
    Private colPrice As SAPbouiCOM.Column
    Private colQty As SAPbouiCOM.Column
    Private colAmt As SAPbouiCOM.Column
    Private cboOrg As SAPbouiCOM.ComboBox
    Private cboProb As SAPbouiCOM.ComboBox
    Private cboTech, cboType As SAPbouiCOM.ComboBox
    Private cboCreate As SAPbouiCOM.ButtonCombo
    Private DocEntry As Integer = 0
    Private cboStatus As SAPbouiCOM.ComboBox, txtClose As SAPbouiCOM.EditText
    Private grdTrans As SAPbouiCOM.Grid
    Private grdMtnSch As SAPbouiCOM.Grid
    Private grdCountr As SAPbouiCOM.Grid
    Private editCol As SAPbouiCOM.GridColumn
    Public oForm As SAPbouiCOM.Form, strExclude As String
    Private UserDB As SAPbouiCOM.UserDataSource, UserDB1 As SAPbouiCOM.UserDataSource


    Sub New(ByVal pAddon As SboAddon, ByVal pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddon, pForm)
        InitSBOServerSQL(New BusObjectInfoSQL(pAddon))
    End Sub
    Protected Overrides Sub OnFormInit()
        MyBase.OnFormInit()
        oForm = m_Form
        'matOrdDet = CType(Me.m_Form.Items.Item("matOrdDet").Specific, SAPbouiCOM.Matrix)
        'cboMach = CType(Me.m_Form.Items.Item("cboMach").Specific, SAPbouiCOM.ComboBox)
        cboProb = CType(Me.m_Form.Items.Item("cboProb").Specific, SAPbouiCOM.ComboBox)
        cboOrg = CType(Me.m_Form.Items.Item("cboOrg").Specific, SAPbouiCOM.ComboBox)
        cboTech = CType(Me.m_Form.Items.Item("cboTech").Specific, SAPbouiCOM.ComboBox)
        cboCreate = CType(Me.m_Form.Items.Item("cboCreate").Specific, SAPbouiCOM.ButtonCombo)
        cboStatus = CType(Me.m_Form.Items.Item("cboStatus").Specific, SAPbouiCOM.ComboBox)
        grdTrans = CType(Me.m_Form.Items.Item("grdTrans").Specific, SAPbouiCOM.Grid)
        grdMtnSch = CType(Me.m_Form.Items.Item("grdMtnSch").Specific, SAPbouiCOM.Grid)
        grdCountr = CType(Me.m_Form.Items.Item("grdCountr").Specific, SAPbouiCOM.Grid)
        txtPrc = CType(Me.m_Form.Items.Item("txtPrc").Specific, SAPbouiCOM.EditText)
        txtClose = CType(Me.m_Form.Items.Item("txtClose").Specific, SAPbouiCOM.EditText)
        txtOprName = CType(Me.m_Form.Items.Item("txtOprName").Specific, SAPbouiCOM.EditText)
        cboType = CType(Me.m_Form.Items.Item("cboType").Specific, SAPbouiCOM.ComboBox)

        strExclude = "txtOprName,txtTime,txtDate"
        'Set Auto manage attribute to control behaviour
        cboCreate.Item.SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 6, SAPbouiCOM.BoModeVisualBehavior.mvb_False)
        cboStatus.Item.SetAutoManagedAttribute(SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 6, SAPbouiCOM.BoModeVisualBehavior.mvb_False)


        'fillCombo("VisResCode", "ResName", "ORSC", cboMach.ValidValues, "ResType='M'")
        'fillCombo("Code", "Name", "@OWA_MORPROBLEMTYPES", cboMach.ValidValues)
        fillCombo("Code", "Name", "@OWA_MORORGTYPES", cboOrg.ValidValues)
        fillCombo("Code", "Name", "@OWA_MORPROBLEMTYPES", cboProb.ValidValues)
        fillCombo("empID", "LastName", "OHEM", cboTech.ValidValues, " empid in (Select empid from HEM6 WHERE roleID = -2)")

        cboCreate.Item.AffectsFormMode = False
        cboCreate.ValidValues.Add("1", "Stock Transfer Request")
        cboCreate.ValidValues.Add("2", "Purchase Order")
        cboCreate.ValidValues.Add("3", "Goods Issue")
        'cboCreate.ValidValues.Add("4", "Stock Transfer")



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
                'm_DBDataSource2.SetValue("U_operatorID", 0, Val)

                If getOffset(Val, "empID", m_DBDataSource0) Then
                    txtOprName.Value = m_DBDataSource0.GetValue("firstName", m_DBDataSource0.Offset).Trim & _
                          ", " & m_DBDataSource0.GetValue("lastName", m_DBDataSource0.Offset).Trim
                End If
            Case "txtBrk"

                If getOffset(Val, "DocEntry", m_DBDataSource3) Then
                    UserDB.Value = m_DBDataSource3.GetValue("U_StartDate", m_DBDataSource3.Offset).ToString
                    UserDB1.Value = m_DBDataSource3.GetValue("U_Time", m_DBDataSource3.Offset).ToString
                End If
            Case "txtMach"
                If getOffset(Val, "ResCode", m_DBDataSource1) Then
                    txtPrc.Value = m_DBDataSource1.GetValue("U_PrcCode", m_DBDataSource1.Offset)
                End If
                'Case "matOrdDet"
                '    Select Case pVal.ColUID
                '        Case "cItemCode"
                '            matOrdDet.SetCellWithoutValidation(pVal.Row, pVal.ColUID, Val)
                '            If getOffset(Val, "ItemCode", dbItem) Then
                '                matOrdDet.SetCellWithoutValidation(pVal.Row, "cItemDesc", dbItem.GetValue("ItemName", 0).Trim)
                '                matOrdDet.SetCellWithoutValidation(pVal.Row, "cPrice", dbItem.GetValue("LstEvlPric", 0).Trim)
                '            End If
                '    End Select
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

   

    Protected Overrides Sub OnFormLoad()
        MyBase.OnFormLoad()

    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()

        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("OHEM")
        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("ORSC")
        m_DBDataSource2 = m_Form.DataSources.DBDataSources.Item("@OWA_MORHDR")
        m_DBDataSource3 = m_Form.DataSources.DBDataSources.Item("@OWA_MORBREAKDOWN")
        m_DataTable0 = m_Form.DataSources.DataTables.Item("DT_0")

        'User datasource 
        UserDB = m_Form.DataSources.UserDataSources.Item("UD_0")
        UserDB1 = m_Form.DataSources.UserDataSources.Item("UD_1")

    End Sub

    Public Sub FormRelease(ByVal Action As Boolean)
        Try
            m_Form.Freeze(Action)
            If Not Action Then
                OnFormNavigate()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub OnFormNavigate()
        MyBase.OnFormNavigate()

        Try
            Dim Enabled As Boolean
            If m_Form.Mode <> SAPbouiCOM.BoFormMode.fm_ADD_MODE Then
                DocEntry = m_DBDataSource2.GetValue("DocEntry", m_DBDataSource2.Offset)
                Enabled = IIf(m_DBDataSource2.GetValue("Canceled", m_DBDataSource2.Offset) = "Y", False, True)
            Else
                DocEntry = 0
                Enabled = True
            End If
            Dim i As Integer
            m_Form.Freeze(True)
            For i = 0 To m_Form.Items.Count - 1

                Select Case m_Form.Items.Item(i).UniqueID
                    Case "txtOprName", "txtTime", "txtDate", "txtPrc"

                    Case "txtBrk"
                        If m_DBDataSource2.GetValue("U_OrderType", m_DBDataSource2.Offset) = "B" Then
                            m_Form.Items.Item(i).Enabled = Enabled
                        End If
                    Case "txtClose"
                        If Enabled And m_DBDataSource2.GetValue("U_orderStatus", m_DBDataSource2.Offset) = "C" Then
                            m_Form.Items.Item(i).Enabled = Enabled
                        Else
                            m_Form.Items.Item(i).Enabled = False
                        End If
                    Case Else
                        m_Form.Items.Item(i).Enabled = Enabled
                End Select
            Next
            'm_Form.Freeze(True)
            m_DataTable0 = ExecuteSQLDT("MtceTransactions", DocEntry.ToString)
            grdTrans.DataTable = m_DataTable0
            FormatGrid()
            If DocEntry <> 0 Then
                Dim val As String = m_DBDataSource2.GetValue("U_BrkDown", m_DBDataSource2.Offset)
                If getOffset(Val, "DocEntry", m_DBDataSource3) Then
                    UserDB.ValueEx = m_DBDataSource3.GetValue("U_StartDate", m_DBDataSource3.Offset).ToString
                    UserDB1.ValueEx = m_DBDataSource3.GetValue("U_Time", m_DBDataSource3.Offset).ToString
                Else
                    UserDB.ValueEx = ""
                    UserDB1.ValueEx = ""
                End If

            End If
            m_Form.Freeze(False)

            GetMaintenanceScheduleData(DocEntry.ToString.Trim)
            FormatMaintenanceGrid()

            GetCountersData(DocEntry.ToString.Trim)
            FormatCountersGrid()

        Catch ex As Exception
            m_SboApplication.StatusBar.SetText(ex.ToString, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
            m_Form.Freeze(False)
        Finally
            m_Form.Freeze(False)
        End Try
    End Sub

    Protected Overrides Sub FormatGrid()
        MyBase.FormatGrid()
        grdTrans.Columns.Item("Category").TitleObject.Caption = "Trans / Req"
        grdTrans.Columns.Item("nType").TitleObject.Caption = "Trans Type"
        grdTrans.Columns.Item("DocNum").TitleObject.Caption = "Doc. Num"
        grdTrans.Columns.Item("DocDate").TitleObject.Caption = "Doc. Date"
        grdTrans.Columns.Item("ItemCode").TitleObject.Caption = "Item / GL"
        grdTrans.Columns.Item("ItemName").TitleObject.Caption = "Description"
        grdTrans.Columns.Item("Value").TitleObject.Caption = "Value"

        grdTrans.Columns.Item("DocType").Visible = False
        grdTrans.Columns.Item("objType").Visible = False
        grdTrans.Columns.Item("Category").Visible = False
        grdTrans.Columns.Item("mType").Visible = False


        editCol = grdTrans.Columns.Item("DocNum")
        editCol.LinkedObjectType = "1250000001"

        editCol = grdTrans.Columns.Item("ItemCode")
        editCol.LinkedObjectType = "4"



        'grdTrans.CollapseLevel = 1

        Dim i As Integer

        For i = 0 To grdTrans.Columns.Count - 1
            grdTrans.Columns.Item(i).Editable = False
        Next

        grdTrans.AutoResizeColumns()

    End Sub
    Public Overrides Sub OnItemPressedAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnItemPressedAfter(sboObject, pVal)
        m_CurrentLineNo = pVal.Row
    End Sub


    Public Overrides Sub OnLinkedPressedBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnLinkedPressedBefore(sboObject, pVal, BubbleEvent)

        Select Case pVal.ItemUID
            Case "grdTrans"
                Dim DocKey As Integer = m_DataTable0.GetValue("DocNum", pVal.Row)
                Dim objType As String = m_DataTable0.GetValue("objType", pVal.Row)
                Dim mType As String = m_DataTable0.GetValue("mType", pVal.Row)
                Dim Code As String = m_DataTable0.GetValue("ItemCode", pVal.Row)

                Select Case pVal.ColUID
                    Case "DocNum"
                        m_SboApplication.OpenForm(objType, "", DocKey.ToString)
                        BubbleEvent = False
                    Case "ItemCode"
                        m_SboApplication.OpenForm(mType, "", Code)
                        BubbleEvent = False
                End Select
        End Select
       
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
            
            Case "cboCreate"
                InvReqFormParam.MaintenanceId = DocEntry
                InvReqFormParam.oPM = Me

                Select Case cboCreate.Selected.Value
                    Case "1"

                        m_SboApplication.ActivateMenuItem("3088")
                        FormRelease(True)
                        'oSysForm = m_SboApplication.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_StockTransfersRequest, "", "")
                    Case "2" 'Purchase Order
                        m_SboApplication.ActivateMenuItem("2305")
                        FormRelease(True)
                    Case "3" 'Goods Issue
                        m_SboApplication.ActivateMenuItem("3079")
                        FormRelease(True)
                    Case "4" 'Purchase Request
                        m_SboApplication.ActivateMenuItem("39724")
                        FormRelease(True)
                    
                End Select
            Case "cboStatus"
                Select Case cboStatus.Value.Trim
                    Case "I"
                        cboCreate.Item.Enabled = False
                    Case "C"
                        m_DBDataSource2.SetValue("Status", m_DBDataSource2.Offset, "C")
                        txtClose.Item.Enabled = True
                    Case "L"
                       
                        m_DBDataSource2.SetValue("Canceled", m_DBDataSource2.Offset, "Y")
                End Select
            Case "cboType"
                If cboType.Selected.Value = "B" Then
                    m_Form.Items.Item("txtBrk").Enabled = True
                Else
                    m_Form.Items.Item("txtBrk").Enabled = False
                End If
        End Select

    End Sub

    Public Overrides Sub OnComboSelectBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnComboSelectBefore(sboObject, pVal, BubbleEvent)

        Select Case pVal.ItemUID
            Case "cboStatus"
                Select Case cboStatus.Value
                    Case "C"
                        'Validate that appropriate data has been entered
                        If Not validateClose() Then
                            BubbleEvent = False
                        End If
                    Case "L"
                        If grdTrans.Rows.Count <= 0 Then
                            BubbleEvent = False
                        End If
                End Select
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


    Private Function validateClose() As Boolean
        Try
            Return True
        Catch ex As Exception
            m_SboApplication.StatusBar.SetText(ex.ToString, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
            Return False
        End Try
    End Function

    Private Sub FormatMaintenanceGrid()
        'MyBase.FormatGrid()

        grdMtnSch.Columns.Item("Category").TitleObject.Caption = "Trans / Req"
        grdMtnSch.Columns.Item("nType").TitleObject.Caption = "Trans Type"
        grdMtnSch.Columns.Item("DocNum").TitleObject.Caption = "Doc. Num"
        grdMtnSch.Columns.Item("DocDate").TitleObject.Caption = "Doc. Date"
        grdMtnSch.Columns.Item("ItemCode").TitleObject.Caption = "Item / GL"
        grdMtnSch.Columns.Item("ItemName").TitleObject.Caption = "Description"
        grdMtnSch.Columns.Item("Value").TitleObject.Caption = "Value"

        grdMtnSch.Columns.Item("DocType").Visible = False
        grdMtnSch.Columns.Item("objType").Visible = False
        grdMtnSch.Columns.Item("Category").Visible = False
        grdMtnSch.Columns.Item("mType").Visible = False


        ' editCol = grdTrans.Columns.Item("DocNum")
        ' editCol.LinkedObjectType = "1250000001"

        ' editCol = grdTrans.Columns.Item("ItemCode")
        ' editCol.LinkedObjectType = "4"



        'grdTrans.CollapseLevel = 1

        Dim i As Integer

        For i = 0 To grdMtnSch.Columns.Count - 1
            grdMtnSch.Columns.Item(i).Editable = False
        Next

        grdMtnSch.AutoResizeColumns()

    End Sub

    Private Sub GetMaintenanceScheduleData(ByVal machineId As String)
        m_DataTable0 = ExecuteSQLDT("MtceScheduleData", machineId)
        grdMtnSch.DataTable = m_DataTable0
    End Sub

    Private Sub GetCountersData(ByVal machineId As String)
        m_DataTable0 = ExecuteSQLDT("MtceCountersData", machineId)
        grdCountr.DataTable = m_DataTable0
    End Sub

    Private Sub FormatCountersGrid()
        grdCountr.Columns.Item("Category").TitleObject.Caption = "Trans / Req"
        grdCountr.Columns.Item("nType").TitleObject.Caption = "Trans Type"
        grdCountr.Columns.Item("DocNum").TitleObject.Caption = "Doc. Num"
        grdCountr.Columns.Item("DocDate").TitleObject.Caption = "Doc. Date"
        grdCountr.Columns.Item("ItemCode").TitleObject.Caption = "Item / GL"
        grdCountr.Columns.Item("ItemName").TitleObject.Caption = "Description"
        grdCountr.Columns.Item("Value").TitleObject.Caption = "Value"

        grdCountr.Columns.Item("DocType").Visible = False
        grdCountr.Columns.Item("objType").Visible = False
        grdCountr.Columns.Item("Category").Visible = False
        grdCountr.Columns.Item("mType").Visible = False


        ' editCol = grdTrans.Columns.Item("DocNum")
        ' editCol.LinkedObjectType = "1250000001"

        ' editCol = grdTrans.Columns.Item("ItemCode")
        ' editCol.LinkedObjectType = "4"



        'grdTrans.CollapseLevel = 1

        Dim i As Integer

        For i = 0 To grdCountr.Columns.Count - 1
            grdCountr.Columns.Item(i).Editable = False
        Next

        grdCountr.AutoResizeColumns()
    End Sub

End Class
