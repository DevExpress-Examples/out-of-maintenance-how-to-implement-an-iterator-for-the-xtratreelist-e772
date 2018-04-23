using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Nodes;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        	private void treeList1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar > 31) { // a letter
				TreeListOperationFindNodeByText op;
				op = new TreeListOperationFindNodeByText(treeList1.FocusedColumn, e.KeyChar.ToString());
				treeList1.NodesIterator.DoOperation(op);
				if(op.Node != null)
					treeList1.FocusedNode = op.Node;
			}
		}
	}

	internal class TreeListOperationFindNodeByText : TreeListOperation 
	{
		private TreeListNode foundNode;
		private TreeListColumn column;
		private string substr;
		public TreeListOperationFindNodeByText(TreeListColumn column, string substr) 
		{ 
			this.foundNode = null;	
			this.column = column;
			this.substr = substr;
		}
		public override void Execute(TreeListNode node)
		{
			string s = node[column].ToString();
			if(s.StartsWith(substr))
				this.foundNode = node;
		}
		public override bool NeedsVisitChildren(TreeListNode node) { return foundNode == null; }
		public TreeListNode Node { get { return foundNode; } }
	}

}