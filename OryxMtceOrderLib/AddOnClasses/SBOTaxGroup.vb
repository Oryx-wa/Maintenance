Imports SBO.SboAddOnBase

Public Class SBOTaxGroup
    Inherits SBOBaseObject

    Sub New(pAddOn As SboAddon, pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddOn, pForm)
    End Sub

    Protected Overrides Sub OnFormNavigate()
        MyBase.OnFormNavigate()

        CType(Me.m_Form.Items.Item("lblActName").Specific, SAPbouiCOM.StaticText).Caption = ""

        If getOffset(m_DBDataSource0.GetValue("U_AcctCode", 0).Trim, "AcctCode", m_DBDataSource1) Then
            CType(Me.m_Form.Items.Item("lblActName").Specific, SAPbouiCOM.StaticText).Caption = m_DBDataSource1.GetValue("AcctName", 0).Trim
        End If
    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()
        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_TAXGROUP")
        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("OACT")
    End Sub
    Public Overrides Sub OnChooseFromListAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnChooseFromListAfter(sboObject, pVal)
        Dim Val As String = HandleChooseFromListEvent(pVal.FormUID, pVal, False)

        If String.IsNullOrEmpty(Val) Then Return

        Select Case pVal.ItemUID


            Case "txtActCode"
                m_DBDataSource0.SetValue("U_AcctCode", m_DBDataSource0.Offset, Val)

                If getOffset(Val, "AcctCode", m_DBDataSource1) Then
                    CType(Me.m_Form.Items.Item("lblActName").Specific, SAPbouiCOM.StaticText).Caption = m_DBDataSource1.GetValue("AcctName", 0).Trim
                End If
        End Select

    End Sub

    Protected Overrides Sub OnFormLoad()
        MyBase.OnFormLoad()
    End Sub


    Protected Overrides Sub SetConditions()
        MyBase.SetConditions()

        With m_Condition
            .Alias = "LocManTran"
            .Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL
            .CondVal = "Y"
            .Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND
        End With

        m_Condition = m_Conditions.Add

        With m_Condition
            .Alias = "Postable"
            .Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL
            .CondVal = "Y"
        End With

        m_Form.ChooseFromLists.Item("CFL_1").SetConditions(m_Conditions)

    End Sub

    Protected Overrides Function Save(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Return MyBase.Save(pErrNo, pErrMsg)
    End Function

    Protected Overrides Function IsReady(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Dim Ret As Boolean = MyBase.IsReady(pErrNo, pErrMsg)
        Dim SBO_GL As SAPbobsCOM.ChartOfAccounts
        SBO_GL = m_ParentAddon.SboCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oChartOfAccounts)

        If Not SBO_GL.GetByKey(m_DBDataSource0.GetValue("U_AcctCode", 0).Trim) Then
            pErrNo = -10001
            pErrMsg = "Invalid GL Account Code"
            Ret = False
            m_Form.Items.Item("txtActCode").Click()
        End If

        IsReady = Ret
    End Function

    Public Overrides Sub OnItemClickBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnItemClickBefore(sboObject, pVal, BubbleEvent)
    End Sub
End Class
