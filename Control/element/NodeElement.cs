using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This is the base for all node element.
	/// </summary>
	[Serializable]
	public abstract class NodeElement: BaseElement
	{
		protected ConnectorElement[] connects = new ConnectorElement[4];
		protected const int connectSize = 3;
		
//		public NodeElement(): base() 
//		{
//			InitConnectors();
//		}

		protected NodeElement(int top, int left, int width, int height): base(top, left, width, height)
		{
			InitConnectors();
		}

		[Browsable(false)]
		public virtual ConnectorElement[] Connectors
		{
			get
			{
				return connects;
			}
		}

		public override Point Location
		{
			get
			{
				return location;
			}
			set
			{
				location = value;
				UpdateConnectorsPosition();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override Size Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
				UpdateConnectorsPosition();
				OnAppearanceChanged(new EventArgs());
			}
		}
    
        public override bool Visible
		{
			get
			{
				return visible;
			}
			set
			{
				visible = value;
				foreach (ConnectorElement c in connects)
				{
					c.Visible = value;
				}
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual bool IsConnected
		{
			get
			{
				foreach (ConnectorElement c in connects)
				{
					if (c.Links.Count > 0)
						return true;
				}
				return false;
			}
		}

		protected void InitConnectors()
		{
			connects[0] = new ConnectorElement(this);
			connects[1] = new ConnectorElement(this);
			connects[2] = new ConnectorElement(this);
			connects[3] = new ConnectorElement(this);
			UpdateConnectorsPosition();

		}

		protected void UpdateConnectorsPosition()
		{
			Point loc;
			ConnectorElement connect;

			//Top
			loc = new Point(this.location.X + this.size.Width / 2,
				this.location.Y);
			connect = (ConnectorElement) connects[0];
			connect.Location = new Point(loc.X - connectSize, loc.Y - connectSize);
			connect.Size = new Size(connectSize * 2, connectSize * 2);

			//Botton
			loc = new Point(this.location.X + this.size.Width / 2,
				this.location.Y + this.size.Height);
			connect = (ConnectorElement) connects[1];
			connect.Location = new Point(loc.X - connectSize, loc.Y - connectSize);
			connect.Size = new Size(connectSize * 2, connectSize * 2);

			//Left
			loc = new Point(this.location.X,
				this.location.Y + this.size.Height / 2);
			connect = (ConnectorElement) connects[2];
			connect.Location = new Point(loc.X - connectSize, loc.Y - connectSize);
			connect.Size = new Size(connectSize * 2, connectSize * 2);

			//Right
			loc = new Point(this.location.X + this.size.Width,
				this.location.Y + this.size.Height / 2);
			connect = (ConnectorElement) connects[3];
			connect.Location = new Point(loc.X - connectSize, loc.Y - connectSize);
			connect.Size = new Size(connectSize * 2, connectSize * 2);
		}

		public override void Invalidate()
		{
			base.Invalidate ();

			for(int i = connects.Length - 1; i >= 0; i--)
			{
				//connects[i].Invalidate();

				for(int ii = connects[i].Links.Count - 1; ii >= 0; ii--)
				{
					connects[i].Links[ii].Invalidate();
				}				
			}
		}


		internal virtual void Draw(Graphics g, bool drawConnector)
		{
			this.Draw(g);
			if (drawConnector)
				DrawConnectors(g);
		}

		protected void DrawConnectors(Graphics g)
		{
			foreach (ConnectorElement ce in connects)
			{
				ce.Draw(g);
			}
		}

		public virtual ElementCollection GetLinkedNodes()
		{
			ElementCollection ec = new ElementCollection();

			foreach(ConnectorElement ce in connects)
			{
				foreach(BaseLinkElement le in ce.Links)
				{
					if (le.Connector1 == ce)
					{
						ec.Add(le.Connector2.ParentElement);
					}
					else
					{
						ec.Add(le.Connector1.ParentElement);
					}
				}
			}
			
			return ec;
		}
	}
}
