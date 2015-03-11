Imports SBO.SboAddOnBase

Public Class SBOSalScaleView
    Inherits SBOBaseObject

    Private ComboBox0 As SAPbouiCOM.ComboBox
    Private Matrix0 As SAPbouiCOM.Matrix

    Sub New(pAddon As SboAddon, pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddon, pForm)
    End Sub



    Public Overrides Sub OnChooseFromListAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnChooseFromListAfter(sboObject, pVal)

        Dim Val As String = HandleChooseFromListEvent(pVal.FormUID, pVal, False)

        If String.IsNullOrEmpty(Val) Then Return

        Select Case pVal.ItemUID
            Case "txtScale"
                m_DBDataSource0.SetValue("Code", m_DBDataSource0.Offset, Val)

                OnFormNavigate()
        End Select
    End Sub

    Public Overrides Sub OnCustomInit()
        MyBase.OnCustomInit()
    End Sub

    Protected Overrides Sub InitFormComponents()
        MyBase.InitFormComponents()

        Me.ComboBox0 = m_Form.Items.Item("cboStep").Specific
        Matrix0 = m_Form.Items.Item("Matrix1").Specific

        Me.ComboBox0.Item.DisplayDesc = True
        Me.ComboBox0.ExpandType = SAPbouiCOM.BoExpandType.et_DescriptionOnly


    End Sub


    Public Overrides Sub OnItemClickBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnItemClickBefore(sboObject, pVal, BubbleEvent)

    End Sub

    Protected Overrides Sub OnFormNavigate()
        MyBase.OnFormNavigate()
        Dim strWhere As String

        If String.IsNullOrEmpty(m_DBDataSource0.GetValue("Code", 0).Trim) Then
            clearCombo(ComboBox0, False)
        Else
            strWhere = " Code = '" + m_DBDataSource0.GetValue("Code", 0).Trim + "'"
            fillCombo("U_StepCode", "U_StepDesc", "@OWA_STEP", ComboBox0.ValidValues, strWhere)
            'ComboBox0.Select(0, SAPbouiCOM.BoSearchKey.psk_Index)
            Me.QueryDBInit()
        End If

    End Sub

    Protected Overrides Sub QueryDBInit()
        MyBase.QueryDBInit()
        m_Conditions = New SAPbouiCOM.Conditions
        m_Condition = m_Conditions.Add

        With m_Condition
            .Alias = "U_ScCode"
            .Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL
            .CondVal = m_DBDataSource0.GetValue("Code", 0).Trim
            .Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND
        End With

        m_Condition = m_Conditions.Add
        With m_Condition
            .Alias = "U_StCode"
            .Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL
            .CondVal = ComboBox0.Selected.Value
        End With

        m_DBDataSource1.Query(m_Conditions)
        Matrix0.LoadFromDataSource()
    End Sub
    
    Protected Overrides Sub OnMatrixAddRow()
        MyBase.OnMatrixAddRow()
       
    End Sub

    Public Overrides Sub OnComboSelectAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnComboSelectAfter(sboObject, pVal)

        Select Case pVal.ItemUID
            Case "cboStep"
                Me.QueryDBInit()

        End Select
    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()

        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_SCALE")
        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_SCALEHIST")


    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()

        m_Form.EnableMenu("1293", True)
        m_Form.EnableMenu("1292", True)
    End Sub



    Public Overrides Sub OnItemPressedAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnItemPressedAfter(sboObject, pVal)
    End Sub

End Class
