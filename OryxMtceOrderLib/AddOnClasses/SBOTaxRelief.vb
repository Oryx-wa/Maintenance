Imports SBO.SboAddOnBase

Public Class SBOTaxRelief
    Inherits SBOBaseObject

    Sub New(pAddOn As SboAddon, pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddOn, pForm)
    End Sub

    Protected Overrides Sub OnFormNavigate()
        MyBase.OnFormNavigate()
    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()
        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_TAXRELF")
    End Sub

    Public Overrides Sub OnChooseFromListAfter(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnChooseFromListAfter(sboObject, pVal)
    End Sub

    Protected Overrides Sub OnFormLoad()
        MyBase.OnFormLoad()
    End Sub
    Protected Overrides Function Save(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Return MyBase.Save(pErrNo, pErrMsg)
    End Function

    Protected Overrides Function IsReady(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        Return MyBase.IsReady(pErrNo, pErrMsg)
    End Function

    Public Overrides Sub OnItemClickBefore(sboObject As Object, pVal As SAPbouiCOM.SBOItemEventArg, ByRef BubbleEvent As Boolean)
        MyBase.OnItemClickBefore(sboObject, pVal, BubbleEvent)
    End Sub

    Protected Overrides Sub SetConditions()
        MyBase.SetConditions()
    End Sub
End Class
