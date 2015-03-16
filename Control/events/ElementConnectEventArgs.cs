using System;

namespace Dalssoft.DiagramNet
{
	public class ElementConnectEventArgs: EventArgs
	{
		private NodeElement node1;
		private NodeElement node2;
		private BaseLinkElement link;

		public ElementConnectEventArgs(NodeElement node1, NodeElement node2, BaseLinkElement link)
		{
			this.node1 = node1;
			this.node2 = node2;
			this.link = link;
		}

		public NodeElement Node1
		{
			get
			{
				return node1;
			}
		}

		public NodeElement Node2
		{
			get
			{
				return node2;
			}
		}

		public BaseLinkElement Link
		{
			get
			{
				return link;
			}
		}

		public override string ToString()
		{
			string toString = "";

			if (node1 != null)
				toString += "Node1:" + node1.ToString();

			if (node2 != null)
				toString += "Node2:" + node2.ToString();

			if (link != null)
				toString += "Link:" + link.ToString();

			return toString;
		}

	}
}
