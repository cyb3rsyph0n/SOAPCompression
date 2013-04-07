Public Class Form1

    Private Sub btnWithoutCompression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithoutCompression.Click

        Dim tmp As New DemoService.DemoService()
        Dim beforenocomp As Long = DateTime.Now.Ticks
        Dim tmpDataset As DataSet = tmp.GetABFD(txtCommand.Text)
        DataGridView1.DataSource = tmpDataset.Tables(0)
        Dim afternocomp As Long = DateTime.Now.Ticks

        MsgBox(String.Format("It took {0} seconds without compression to return {1} rows", New TimeSpan(afternocomp - beforenocomp).TotalSeconds, tmpDataset.Tables(0).Rows.Count))

    End Sub

    Private Sub btnWithCompression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithCompression.Click

        Dim tmp2 As New DemoServiceWithComp.DemoService()

        Dim beforecomp As Long = DateTime.Now.Ticks
        Dim tmpDataset As DataSet = tmp2.GetABFD(txtCommand.Text)
        DataGridView1.DataSource = tmpDataset.Tables(0)
        Dim aftercomp As Long = DateTime.Now.Ticks

        MsgBox(String.Format("It took {0} seconds with compression to return {1} rows", New TimeSpan(aftercomp - beforecomp).TotalSeconds, tmpDataset.Tables(0).Rows.Count))

    End Sub

    Private Sub btnClearGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearGrid.Click

        DataGridView1.DataSource = Nothing

    End Sub
End Class
