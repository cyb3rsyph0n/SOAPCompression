<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnWithCompression = New System.Windows.Forms.Button
        Me.btnWithoutCompression = New System.Windows.Forms.Button
        Me.btnClearGrid = New System.Windows.Forms.Button
        Me.txtCommand = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(665, 318)
        Me.DataGridView1.TabIndex = 0
        '
        'btnWithCompression
        '
        Me.btnWithCompression.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWithCompression.Location = New System.Drawing.Point(536, 363)
        Me.btnWithCompression.Name = "btnWithCompression"
        Me.btnWithCompression.Size = New System.Drawing.Size(141, 23)
        Me.btnWithCompression.TabIndex = 1
        Me.btnWithCompression.Text = "With Compression"
        Me.btnWithCompression.UseVisualStyleBackColor = True
        '
        'btnWithoutCompression
        '
        Me.btnWithoutCompression.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnWithoutCompression.Location = New System.Drawing.Point(12, 363)
        Me.btnWithoutCompression.Name = "btnWithoutCompression"
        Me.btnWithoutCompression.Size = New System.Drawing.Size(141, 23)
        Me.btnWithoutCompression.TabIndex = 2
        Me.btnWithoutCompression.Text = "Without Compression"
        Me.btnWithoutCompression.UseVisualStyleBackColor = True
        '
        'btnClearGrid
        '
        Me.btnClearGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearGrid.Location = New System.Drawing.Point(306, 363)
        Me.btnClearGrid.Name = "btnClearGrid"
        Me.btnClearGrid.Size = New System.Drawing.Size(75, 23)
        Me.btnClearGrid.TabIndex = 3
        Me.btnClearGrid.Text = "Clear Grid"
        Me.btnClearGrid.UseVisualStyleBackColor = True
        '
        'txtCommand
        '
        Me.txtCommand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommand.Location = New System.Drawing.Point(12, 12)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.Size = New System.Drawing.Size(665, 20)
        Me.txtCommand.TabIndex = 4
        Me.txtCommand.Text = "select top 10000 * from inspections"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 393)
        Me.Controls.Add(Me.txtCommand)
        Me.Controls.Add(Me.btnClearGrid)
        Me.Controls.Add(Me.btnWithoutCompression)
        Me.Controls.Add(Me.btnWithCompression)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Compression Vs. No Compression"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnWithCompression As System.Windows.Forms.Button
    Friend WithEvents btnWithoutCompression As System.Windows.Forms.Button
    Friend WithEvents btnClearGrid As System.Windows.Forms.Button
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox

End Class
