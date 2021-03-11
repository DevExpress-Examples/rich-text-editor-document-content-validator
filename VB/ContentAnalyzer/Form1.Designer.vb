Namespace ContentAnalyzer
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.richEditControl = New DevExpress.XtraRichEdit.RichEditControl()
			Me.gridControl = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colFileName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colTag = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colNamespace = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colPrefix = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.dockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
			Me.dockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
			Me.dockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
			CType(Me.gridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.dockPanel1.SuspendLayout()
			Me.dockPanel1_Container.SuspendLayout()
			Me.SuspendLayout()
			' 
			' richEditControl
			' 
			Me.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richEditControl.Location = New System.Drawing.Point(0, 0)
			Me.richEditControl.Name = "richEditControl"
			Me.richEditControl.Size = New System.Drawing.Size(1115, 459)
			Me.richEditControl.TabIndex = 0
			' 
			' gridControl
			' 
			Me.gridControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl.Location = New System.Drawing.Point(0, 0)
			Me.gridControl.MainView = Me.gridView1
			Me.gridControl.Name = "gridControl"
			Me.gridControl.Size = New System.Drawing.Size(1109, 112)
			Me.gridControl.TabIndex = 1
			Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colFileName, Me.colTag, Me.colNamespace, Me.colPrefix, Me.colDescription})
			Me.gridView1.GridControl = Me.gridControl
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsBehavior.Editable = False
			Me.gridView1.OptionsView.ShowAutoFilterRow = True
			Me.gridView1.OptionsView.ShowGroupPanel = False
			' 
			' colFileName
			' 
			Me.colFileName.Caption = "File Name"
			Me.colFileName.FieldName = "FileName"
			Me.colFileName.Name = "colFileName"
			' 
			' colTag
			' 
			Me.colTag.Caption = "Tag"
			Me.colTag.FieldName = "Tag"
			Me.colTag.Name = "colTag"
			Me.colTag.Visible = True
			Me.colTag.VisibleIndex = 0
			' 
			' colNamespace
			' 
			Me.colNamespace.Caption = "Namespace"
			Me.colNamespace.FieldName = "Namespace"
			Me.colNamespace.Name = "colNamespace"
			' 
			' colPrefix
			' 
			Me.colPrefix.Caption = "Prefix"
			Me.colPrefix.FieldName = "Prefix"
			Me.colPrefix.Name = "colPrefix"
			' 
			' colDescription
			' 
			Me.colDescription.Caption = "Description"
			Me.colDescription.FieldName = "Description"
			Me.colDescription.Name = "colDescription"
			Me.colDescription.Visible = True
			Me.colDescription.VisibleIndex = 1
			' 
			' dockManager1
			' 
			Me.dockManager1.Form = Me
			Me.dockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() { Me.dockPanel1})
			Me.dockManager1.TopZIndexControls.AddRange(New String() { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
			' 
			' dockPanel1
			' 
			Me.dockPanel1.Controls.Add(Me.dockPanel1_Container)
			Me.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
			Me.dockPanel1.ID = New System.Guid("b3bea9bb-4a23-471f-b48a-bb85e9729d0d")
			Me.dockPanel1.Location = New System.Drawing.Point(0, 459)
			Me.dockPanel1.Name = "dockPanel1"
			Me.dockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
			Me.dockPanel1.Size = New System.Drawing.Size(1115, 162)
			Me.dockPanel1.Text = "Skipped Content"
			' 
			' dockPanel1_Container
			' 
			Me.dockPanel1_Container.Controls.Add(Me.gridControl)
			Me.dockPanel1_Container.Location = New System.Drawing.Point(3, 47)
			Me.dockPanel1_Container.Name = "dockPanel1_Container"
			Me.dockPanel1_Container.Size = New System.Drawing.Size(1109, 112)
			Me.dockPanel1_Container.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1115, 621)
			Me.Controls.Add(Me.richEditControl)
			Me.Controls.Add(Me.dockPanel1)
			Me.Name = "Form1"
			Me.Text = "Document Content Validator"
			CType(Me.gridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.dockPanel1.ResumeLayout(False)
			Me.dockPanel1_Container.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private richEditControl As DevExpress.XtraRichEdit.RichEditControl
		Private gridControl As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private dockManager1 As DevExpress.XtraBars.Docking.DockManager
		Private dockPanel1 As DevExpress.XtraBars.Docking.DockPanel
		Private dockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
		Private colFileName As DevExpress.XtraGrid.Columns.GridColumn
		Private colTag As DevExpress.XtraGrid.Columns.GridColumn
		Private colNamespace As DevExpress.XtraGrid.Columns.GridColumn
		Private colPrefix As DevExpress.XtraGrid.Columns.GridColumn
		Private colDescription As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace

