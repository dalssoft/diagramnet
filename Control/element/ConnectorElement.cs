using System;
using System.Drawing;

namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class ConnectorElement: RectangleElement, IControllable 
	{
		private NodeElement parentElement;
		private ElementCollection links = new ElementCollection();

		[NonSerialized]
		private ConnectorController controller;

		internal ConnectorElement(NodeElement parent): base(new Rectangle(0, 0, 0, 0))
		{
			parentElement = parent;
			borderColor = Color.Black;
			fillColor1 = Color.LightGray;
			fillColor2 = Color.Empty;
		}

		public NodeElement ParentElement
		{
			get
			{
				return parentElement;
			}
		}

		internal void AddLink(BaseLinkElement lnk)
		{
			links.Add(lnk);
		}

		internal void RemoveLink(BaseLinkElement lnk)
		{
			links.Remove(lnk);
		}

		public ElementCollection Links
		{
			get
			{
				return links;
			}
		}

		internal CardinalDirection GetDirection()
		{
			Rectangle rec = new Rectangle(parentElement.Location, parentElement.Size);
			Point refPoint = new Point(this.location.X - parentElement.Location.X + (this.size.Width / 2),
			                           this.location.Y - parentElement.Location.Y + (this.size.Height / 2));

			return DiagramUtil.GetDirection(rec, refPoint);
		}

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new ConnectorController(this);
			return controller;
		}

	
		public override Point Location
		{
			get
			{
				return base.Location;
			}
			set
			{
				if (value == base.Location) return;
				
				foreach(BaseLinkElement lnk in links)
				{
					lnk.NeedCalcLink = true;					
				}
				base.Location = value;
			}
		}
	
		public override Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				if (value == base.Size) return;

				foreach(BaseLinkElement lnk in links)
				{
					lnk.NeedCalcLink = true;
				}
				base.Size = value;
			}
		}
	}
}
