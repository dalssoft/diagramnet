using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class StraightLinkElement: BaseLinkElement, IControllable, ILabelElement
	{
		protected LineElement line1 = new LineElement(0,0,0,0);
		protected LabelElement label = new LabelElement();

		[NonSerialized]
		private LineController controller;

		internal StraightLinkElement(ConnectorElement conn1, ConnectorElement conn2): base(conn1, conn2)
		{
			label.PositionBySite(line1);
		}

		#region Properties
		[Browsable(false)]
		public override Point Point1
		{
			get
			{
				return line1.Point1;
			}
		}

		[Browsable(false)]
		public override Point Point2
		{
			get
			{
				return line1.Point2;
			}
		}

		public override Color BorderColor
		{
			get
			{
				return line1.BorderColor;
			}
			set
			{
				line1.BorderColor = value;
			}
		}

		public override int BorderWidth
		{
			get
			{
				return line1.BorderWidth;
			}
			set
			{
				line1.BorderWidth = value;
			}
		}

		public override Point Location
		{
			get
			{
				CalcLink();
				return line1.Location;
			}
		}

		public override Size Size
		{
			get
			{
				CalcLink();
				return line1.Size;
			}
		}

		public override int Opacity
		{
			get
			{
				return line1.Opacity;
			}
			set
			{
				line1.Opacity = value;
			}
		}

		public override LineCap StartCap
		{
			get
			{
				return line1.StartCap;
			}
			set
			{
				line1.StartCap = value;
			}
		}

		public override LineCap EndCap
		{
			get
			{
				return line1.EndCap;
			}
			set
			{
				line1.EndCap = value;
			}
		}

		public override LineElement[] Lines
		{
			get
			{
				return new LineElement[] {line1};
			}
		}


		#endregion

		internal override void Draw(Graphics g)
		{
			IsInvalidated = false;

			line1.Draw(g);
		}

		internal override void CalcLink()
		{
			if (needCalcLink == false) return;

			if (line1 != null)
			{
				Point connector1Location = connector1.Location;
				Point connector2Location = connector2.Location;
				Size connector1Size = connector1.Size;
				Size connector2Size = connector2.Size;

				line1.Point1 = new Point(connector1Location.X + connector1Size.Width / 2, connector1Location.Y + connector1Size.Height / 2);
				line1.Point2 = new Point(connector2Location.X + connector2Size.Width / 2, connector2Location.Y + connector2Size.Height / 2);
				line1.CalcLine();
			}

			needCalcLink = false;
		}

		#region IControllable Members

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new LineController(line1);
			return controller;
		}

		#endregion
	
		#region ILabelElement Members

		public virtual LabelElement Label 
		{
			get
			{
				return label;
			}
			set
			{
				label = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		#endregion
	}
}


