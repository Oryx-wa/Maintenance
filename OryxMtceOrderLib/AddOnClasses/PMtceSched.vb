Imports SBO.SboAddOnBase
Imports OWA.SBO.OryxMtceOrderSQL
Imports SAPbouiCOM.Framework

Public Class PMtceSched
    Inherits SBOBaseObject

    'form control
    Private txtMachId As SAPbouiCOM.EditText
    Private txMacName As SAPbouiCOM.EditText
    Private grdSched As SAPbouiCOM.Matrix
    Private grdcoutr As SAPbouiCOM.Matrix


    'necessary things
    Public oForm As SAPbouiCOM.Form, strExclude As String
    Private UserDB As SAPbouiCOM.UserDataSource, UserDB1 As SAPbouiCOM.UserDataSource

    Sub New(ByVal pAddon As SboAddon, ByVal pForm As SAPbouiCOM.IForm)
        MyBase.New(pAddon, pForm)
        InitSBOServerSQL(New BusObjectInfoSQL(pAddon))
    End Sub

    Protected Overrides Sub SetConditions()
        MyBase.SetConditions()

        With m_Condition
            .Alias = "ResType"
            .Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL
            .CondVal = "M"
        End With
        m_Form.ChooseFromLists.Item("cflMach").SetConditions(m_Conditions)

    End Sub

    Protected Overrides Sub AddDataSource()
        MyBase.AddDataSource()

        m_DBDataSource1 = m_Form.DataSources.DBDataSources.Item("ORSC")
        m_DBDataSource2 = m_Form.DataSources.DBDataSources.Item("@OWA_RESOURCE")

    End Sub

    Protected Overrides Sub OnFormInit()
        MyBase.OnFormInit()
        oForm = m_Form

        txtMachId = CType(Me.m_Form.Items.Item("txtMachId").Specific, SAPbouiCOM.EditText)
        txMacName = CType(Me.m_Form.Items.Item("txMacName").Specific, SAPbouiCOM.EditText)
        grdSched = CType(Me.m_Form.Items.Item("grdSched").Specific, SAPbouiCOM.Matrix)
        grdcoutr = CType(Me.m_Form.Items.Item("grdcoutr").Specific, SAPbouiCOM.Matrix)
    End Sub


    Public Overrides Sub OnChooseFromListAfter(ByVal sboObject As Object, ByVal pVal As SAPbouiCOM.SBOItemEventArg)
        MyBase.OnChooseFromListAfter(sboObject, pVal)
        Dim Val As String = HandleChooseFromListEvent(pVal.FormUID, pVal, False)

        If String.IsNullOrEmpty(Val) Then Return

        Select Case pVal.ItemUID
            Case "txtMachId"
                If getOffset(Val, "ResCode", m_DBDataSource1) Then
                    m_DBDataSource2.SetValue("Code", m_DBDataSource2.Offset, Val)
                    m_DBDataSource2.SetValue("Name", m_DBDataSource2.Offset, m_DBDataSource1.GetValue("ResName", 0))
                End If
            Case "grdSched"
                Select Case pVal.ColUID
                    Case "Col_0"
                        m_DBDataSource3 = m_Form.DataSources.DBDataSources.Item("@OWA_ACTIVITYTYPES")
                        m_DBDataSource4 = m_Form.DataSources.DBDataSources.Item("@OWA_MACACTIVITY")

                        grdSched.FlushToDataSource()

                        If getOffset(Val, "Code", m_DBDataSource3) Then
                            Dim a = m_DBDataSource3.GetValue("U_actType", 0)
                            m_DBDataSource4.SetValue("U_actType", pVal.Row - 1, m_DBDataSource3.GetValue("U_actType", 0))
                            m_DBDataSource4.SetValue("U_actdesc", pVal.Row - 1, m_DBDataSource3.GetValue("U_actDesc", 0))
                            m_DBDataSource4.SetValue("U_actfreq", pVal.Row - 1, m_DBDataSource3.GetValue("U_actFreq", 0))
                            m_DBDataSource4.SetValue("U_freqValue", pVal.Row - 1, m_DBDataSource3.GetValue("U_freqUnit", 0))
                        End If
                       
                        grdSched.LoadFromDataSource()

                End Select
            Case "grdcoutr"
                Select Case pVal.ColUID
                    Case "Col_0"

                        m_DBDataSource3 = m_Form.DataSources.DBDataSources.Item("@OWA_COUNTERS")
                        m_DBDataSource4 = m_Form.DataSources.DBDataSources.Item("@OWA_MACCOUNTERS")

                        grdcoutr.FlushToDataSource()

                        If getOffset(Val, "Code", m_DBDataSource3) Then
                            Dim a = m_DBDataSource3.GetValue("U_ctype", 0)
                            m_DBDataSource4.SetValue("U_ctype", pVal.Row - 1, m_DBDataSource3.GetValue("U_ctype", 0).Trim)
                            m_DBDataSource4.SetValue("U_cUnit", pVal.Row - 1, m_DBDataSource3.GetValue("U_cUnit", 0).Trim)
                            m_DBDataSource4.SetValue("U_cValue", pVal.Row - 1, m_DBDataSource3.GetValue("U_cValue", 0).Trim)
                        End If

                        grdcoutr.LoadFromDataSource()

                End Select
        End Select

    End Sub

    Protected Overrides Sub EnableToolBarButtons()
        m_Form.EnableMenu("1282", True)
        m_Form.EnableMenu("1292", True)
        m_Form.EnableMenu("1293", True)
        m_Form.EnableMenu("1287", True)
    End Sub

End Class
