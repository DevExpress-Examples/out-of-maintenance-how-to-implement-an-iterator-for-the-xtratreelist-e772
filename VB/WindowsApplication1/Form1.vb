Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes.Operations
Imports DevExpress.XtraTreeList.Nodes

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

			Private Sub treeList1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles treeList1.KeyPress
            If Asc(e.KeyChar) > 31 Then ' a letter
                Dim op As TreeListOperationFindNodeByText
                op = New TreeListOperationFindNodeByText(treeList1.FocusedColumn, e.KeyChar.ToString())
                treeList1.NodesIterator.DoOperation(op)
                If op.Node IsNot Nothing Then
                    treeList1.FocusedNode = op.Node
                End If
            End If
			End Sub
	End Class

	Friend Class TreeListOperationFindNodeByText
		Inherits TreeListOperation
		Private foundNode As TreeListNode
		Private column As TreeListColumn
		Private substr As String
		Public Sub New(ByVal column As TreeListColumn, ByVal substr As String)
			Me.foundNode = Nothing
			Me.column = column
			Me.substr = substr
		End Sub
		Public Overrides Sub Execute(ByVal node As TreeListNode)
			Dim s As String = node(column).ToString()
			If s.StartsWith(substr) Then
				Me.foundNode = node
			End If
		End Sub
		Public Overrides Function NeedsVisitChildren(ByVal node As TreeListNode) As Boolean
			Return foundNode Is Nothing
		End Function
		Public ReadOnly Property Node() As TreeListNode
			Get
				Return foundNode
			End Get
		End Property
	End Class

End Namespace