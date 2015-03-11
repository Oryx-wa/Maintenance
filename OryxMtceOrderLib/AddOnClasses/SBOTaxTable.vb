Imports SBO.SboAddOnBase

Public Class SBOTaxTable
    Inherits SBOBaseObject

    Sub New(pAddon As SboAddon, pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddon, pForm)
    End Sub


    Protected Overrides Sub EnableToolBarButtons()
        MyBase.EnableToolBarButtons()
        m_Form.EnableMenu("1292", True)
        m_Form.EnableMenu("1293", True)
    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()

        m_DBDataSource0 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_TAX")
        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("@OWA_NP_TAXTABLE")

    End Sub

    Private Matrix0 As SAPbouiCOM.Matrix

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

    Protected Overrides Function IsReady(ByRef pErrNo As Integer, ByRef pErrMsg As String) As Boolean
        If Not MyBase.IsReady(pErrNo, pErrMsg) Then Return False

        Matrix0.FlushToDataSource()

        Dim i As Integer, x As Decimal = 0, y As Decimal = 0, z As Decimal = 0
        For i = 0 To m_DBDataSource1.Size - 1
            If CType(m_DBDataSource1.GetValue("U_nRate", i), Decimal) <= 0 Then
                Matrix0.Columns.Item("V_3").Cells.Item(i + 1).Click()
                pErrMsg = "Invalid Data"
                Return False
            End If

            x = CType(m_DBDataSource1.GetValue("U_nLower", i), Decimal)
            If Not i = 0 Then
                If x <= z Then
                    Matrix0.Columns.Item("V_1").Cells.Item(i + 1).Click()
                    pErrMsg = "Invalid Data"
                    Return False
                End If
            End If

            y = CType(m_DBDataSource1.GetValue("U_nUpper", i), Decimal)
            If x >= y Then
                Matrix0.Columns.Item("V_2").Cells.Item(i + 1).Click()
                pErrMsg = "Invalid Data"
                Return False
            End If
            z = y
        Next

        If m_DBDataSource0.GetValue("U_lFormula", 0).Trim = "Y" Then
            If Not IsFormulaOK() Then
                If Me.SBOServerSQL.ErrorNo <> 0 Then
                    pErrNo = SBOServerSQL.ErrorNo
                    pErrMsg = SBOServerSQL.ErrorMsg
                End If
                Return False
            End If
        End If

        Return True
    End Function


    Private Function IsFormulaOK() As Boolean
        Dim SBO_RecSet As SAPbobsCOM.Recordset

        If String.IsNullOrEmpty(m_DBDataSource0.GetValue("U_mFormula", 0).Trim) Then
            Return True
        End If


        Try

            SBO_RecSet = Me.ExecuteServerSP("OWA_CHECKTAXRELIEF", m_DBDataSource0.GetValue("U_mFormula", 0).Trim)
            If Me.SBOServerSQL.ErrorNo <> 0 Then
                Return False
            End If

            While Not SBO_RecSet.EoF
                If SBO_RecSet.Fields.Item(0).Value = "N" Then
                    m_ParentAddon.SboApplication.StatusBar.SetText("Invalid Formula", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error)

                    Return False
                Else
                    Return True
                End If
            End While
        Catch ex As Exception
            m_ParentAddon.SboApplication.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error)
            Return False
        End Try

        Return True
    End Function

End Class
