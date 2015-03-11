Imports SBO.SboAddOnBase
Public Class SBOScaleSteps
    Inherits SBOBaseObject

    Sub New(pAddon As SboAddon, pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddon, pForm)
    End Sub


    Public Overrides Sub OnChooseFromListAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Public Overrides Sub OnChooseFromListBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnChooseFromListBefore(sboObject, pVal, BubbleEvent)

    End Sub

    Public Overrides Sub OnComponentInit()
        MyBase.OnComponentInit()

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()

        m_Form.EnableMenu("1292", True)
        m_Form.EnableMenu("1293", True)
    End Sub

    Protected Overrides Sub OnFormNavigate()
        MyBase.OnFormNavigate()

    End Sub

    Private Matrix0 As SAPbouiCOM.Matrix

    Protected Overrides Sub OnFormLoad()
        MyBase.OnFormLoad()
    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()

        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_SCALE")
        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_STEP")

    End Sub

    Public Overrides Sub OnItemPressedAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnItemPressedAfter(sboObject, pVal)

    End Sub
    Protected Overrides Sub SetConditions()
        MyBase.SetConditions()
    End Sub

    Public Overrides Sub OnCustomInit()
        MyBase.OnCustomInit()
    End Sub

    Protected Overrides Sub InitFormComponents()
        MyBase.InitFormComponents()

        Matrix0 = CType(Me.m_Form.Items.Item("Matrix1").Specific, SAPbouiCOM.Matrix)

    End Sub
    Protected Overrides Sub OnMatrixAddRow()
        MyBase.OnMatrixAddRow()
        AddRowToMatrix(Matrix0)
      
    End Sub

    Protected Overrides Sub AddRowToMatrix(pMatrix As SAPbouiCOM.Matrix)
        MyBase.AddRowToMatrix(pMatrix)
       
        Matrix0.SetCellWithoutValidation(Matrix0.RowCount, "V_0", "")
        Matrix0.SetCellWithoutValidation(Matrix0.RowCount, "V_1", "")
        Matrix0.FlushToDataSource()
    End Sub
    Protected Overrides Function Save(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Return MyBase.Save(pErrNo, pErrMsg)
    End Function

    Protected Overrides Function IsReady(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Dim Ret As Boolean = MyBase.IsReady(pErrNo, pErrMsg)
        Matrix0.FlushToDataSource()

        For i As Int16 = 1 To Matrix0.RowCount
            Dim EditCol0 As SAPbouiCOM.EditText
            EditCol0 = Matrix0.GetCellSpecific("V_0", i)
            If String.IsNullOrEmpty(EditCol0.Value.Trim) Then
                pErrMsg = "Invalid Data"
                EditCol0.Item.Click()
                Return False
            End If

            EditCol0 = Matrix0.GetCellSpecific("V_1", i)
            If String.IsNullOrEmpty(EditCol0.Value.Trim) Then
                pErrMsg = "Invalid Data"
                EditCol0.Item.Click()
                Return False
            End If
        Next
        
        IsReady = Ret
    End Function

    Public Overrides Sub OnItemClickBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnItemClickBefore(sboObject, pVal, BubbleEvent)
    End Sub
End Class
