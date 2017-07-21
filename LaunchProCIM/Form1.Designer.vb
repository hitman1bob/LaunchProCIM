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
        Me.btnGo = New System.Windows.Forms.Button()
        Me.cmbDivision = New System.Windows.Forms.ComboBox()
        Me.cmbDatabase = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(267, 2)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "Launch"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'cmbDivision
        '
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Items.AddRange(New Object() {"East", "West"})
        Me.cmbDivision.Location = New System.Drawing.Point(12, 4)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(121, 21)
        Me.cmbDivision.TabIndex = 0
        '
        'cmbDatabase
        '
        Me.cmbDatabase.FormattingEnabled = True
        Me.cmbDatabase.Items.AddRange(New Object() {"ProCIM"})
        Me.cmbDatabase.Location = New System.Drawing.Point(140, 4)
        Me.cmbDatabase.Name = "cmbDatabase"
        Me.cmbDatabase.Size = New System.Drawing.Size(121, 21)
        Me.cmbDatabase.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 84)
        Me.Controls.Add(Me.cmbDatabase)
        Me.Controls.Add(Me.cmbDivision)
        Me.Controls.Add(Me.btnGo)
        Me.Name = "Form1"
        Me.Text = "Launch ProCIM"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGo As Button
    Friend WithEvents cmbDivision As ComboBox
    Friend WithEvents cmbDatabase As ComboBox
End Class
