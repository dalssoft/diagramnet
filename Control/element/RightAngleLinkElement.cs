using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class RightAngleLinkElement: BaseLinkElement, IControllable, ILabelElement
	{
		internal protected LineElement[] lines = {new LineElement(0,0,0,0)};
		internal protected Orientation orientation;
		internal protected CardinalDirection conn1Dir;
		internal protected CardinalDirection conn2Dir;
		protected bool needCalcLinkLocation = true;
		protected bool needCalcLinkSize = true;

		protected LabelElement label = new LabelElement();

		[NonSerialized]
		private RightAngleLinkController controller;

		public RightAngleLinkElement(ConnectorElement conn1, ConnectorElement conn2): base(conn1, conn2)
		{
			needCalcLink = true;
			InitConnectors(conn1, conn2);
			foreach(LineElement l in lines)
			{
				l.StartCap = LineCap.Round;
				l.EndCap = LineCap.Round;
			}
			startCap = LineCap.Round;
			endCap = LineCap.Round;

			label.PositionBySite(lines[1]);

		}

		#region Properties
		[Browsable(false)]
		public override Point Point1
		{
			get
			{
				return lines[0].Point1;
			}
		}

		[Browsable(false)]
		public override Point Point2
		{
			get
			{
				return lines[lines.Length - 1].Point2;
			}
		}

		public override Color BorderColor
		{
			get
			{
				return base.borderColor;
			}
			set
			{
				base.borderColor = value;
				foreach (LineElement l in lines)
					l.BorderColor = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override int BorderWidth
		{
			get
			{
				return base.borderWidth;
			}
			set
			{
				base.borderWidth = value;
				foreach (LineElement l in lines)
					l.BorderWidth = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override Point Location
		{
			get
			{
				CalcLinkLocation();
				return location;
			}
			set
			{
				IMoveController ctrl = (IMoveController) ((IControllable) this).GetController();
				if (!ctrl.IsMoving)
					return;

				Point locBefore = this.Location;
				Point locAfter = value;

				Point locDiff = new Point(locAfter.X - locBefore.X, locAfter.Y - locBefore.Y);

				foreach(LineElement l in lines)
				{
					Point lPoint1 = l.Point1;
					Point lPoint2 = l.Point2;
					l.Point1 = new Point(lPoint1.X + locDiff.X, lPoint1.Y + locDiff.Y);
					l.Point2 = new Point(lPoint2.X + locDiff.X, lPoint2.Y + locDiff.Y);
				}
				needCalcLink = true;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override Size Size
		{
			get
			{
				CalcLinkSize();
				return size;
			}
		}

		public override int Opacity
		{
			get
			{
				return base.opacity;
			}
			set
			{
				base.opacity = value;
				foreach (LineElement l in lines)
					l.Opacity = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override LineCap StartCap
		{
			get
			{
				return base.startCap;
			}
			set
			{
				base.startCap = value;
				lines[0].StartCap = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override LineCap EndCap
		{
			get
			{
				return base.endCap;
			}
			set
			{
				base.endCap = value;
				lines[lines.Length - 1].EndCap = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public override LineElement[] Lines
		{
			get
			{
				return (LineElement[]) lines.Clone();
			}
		}
		#endregion

		internal override void Draw(Graphics g)
		{
			IsInvalidated = false;

			CalcLink();

			for(int i = 0; i < lines.Length; i++)
				lines[i].Draw(g);
		}

		private void InitConnectors(ConnectorElement conn1, ConnectorElement conn2)
		{
			conn1Dir = conn1.GetDirection();
			conn2Dir = conn2.GetDirection();

			if ((conn1Dir == CardinalDirection.North) || (conn1Dir == CardinalDirection.South))
				orientation = Orientation.Vertical;
			else
				orientation = Orientation.Horizontal;

			if (
				(
				((conn1Dir == CardinalDirection.North) || (conn1Dir == CardinalDirection.South))
				&& ((conn2Dir == CardinalDirection.East) || (conn2Dir == CardinalDirection.West)))
				||
				(
				((conn1Dir == CardinalDirection.East) || (conn1Dir == CardinalDirection.West))
				&& ((conn2Dir == CardinalDirection.North) || (conn2Dir == CardinalDirection.South)))
				)
			{
				lines = new LineElement[2];
				lines[0] = new LineElement(0, 0, 0, 0);
				lines[1] = new LineElement(0, 0, 0, 0);
			}
			else	
			{
				lines = new LineElement[3];
				lines[0] = new LineElement(0, 0, 0, 0);
				lines[1] = new LineElement(0, 0, 0, 0);
				lines[2] = new LineElement(0, 0, 0, 0);
			}
			
			CalcLinkFirtTime();
			CalcLink();
			RestartProps();
		}

		private void RestartProps()
		{
			foreach(LineElement line in lines)
			{
				line.BorderColor = base.borderColor;
				line.BorderWidth = base.borderWidth;
				line.Opacity = base.opacity;
				line.StartCap = base.startCap;
				line.EndCap = base.endCap;
			}
		}
		protected override void OnConnectorChanged(EventArgs e)
		{
			InitConnectors(connector1, connector2);
			base.OnConnectorChanged (e);
		}


		internal void CalcLinkFirtTime()
		{
			if (lines == null)
				return;

			LineElement lastLine = lines[lines.Length - 1];

			Point connector1Location = connector1.Location;
			Point connector2Location = connector2.Location;
			Size connector1Size = connector1.Size;
			Size connector2Size = connector2.Size;

			lines[0].Point1 = new Point(connector1Location.X + connector1Size.Width / 2, connector1Location.Y + connector1Size.Height / 2);
			lastLine.Point2 = new Point(connector2Location.X + connector2Size.Width / 2, connector2Location.Y + connector2Size.Height / 2);
			
			if (lines.Length == 3)
			{
				Point lines0Point1 = lines[0].Point1;
				Point lastLinePoint2 = lastLine.Point2;

				if (orientation == Orientation.Horizontal)
				{
					lines[0].Point2 = new Point(lines0Point1.X + ((lastLinePoint2.X - lines0Point1.X) / 2), lines0Point1.Y);
					lastLine.Point1 = new Point(lines0Point1.X + ((lastLinePoint2.X - lines0Point1.X) / 2), lastLinePoint2.Y);
				}
				else if (orientation == Orientation.Vertical)
				{
					lines[0].Point2 = new Point(lines0Point1.X, lines0Point1.Y + ((lastLinePoint2.Y - lines0Point1.Y) / 2));
					lastLine.Point1 = new Point(lastLinePoint2.X, lines0Point1.Y + ((lastLinePoint2.Y - lines0Point1.Y) / 2));
				}
			}
		}

		internal override void CalcLink()
		{
			if (needCalcLink == false) return;

			if (lines == null)
				return;

			LineElement lastLine = lines[lines.Length - 1];

			//Otimization - Get prop. value only one time
			Point connector1Location = connector1.Location;
			Point connector2Location = connector2.Location;
			Size connector1Size = connector1.Size;
			Size connector2Size = connector2.Size;

			lines[0].Point1 = new Point(connector1Location.X + connector1Size.Width / 2, connector1Location.Y + connector1Size.Height / 2);
			lastLine.Point2 = new Point(connector2Location.X + connector2Size.Width / 2, connector2Location.Y + connector2Size.Height / 2);
			
			if (lines.Length == 3)
			{

				if (orientation == Orientation.Horizontal)
				{
					lines[0].Point2 = new Point(lines[0].Point2.X, lines[0].Point1.Y);
					lastLine.Point1 = new Point(lastLine.Point1.X, lastLine.Point2.Y);
					lines[1].Point1 = lines[0].Point2;
					lines[1].Point2 = lines[2].Point1;
				}
				else if (orientation == Orientation.Vertical)
				{
					lines[0].Point2 = new Point(lines[0].Point1.X, lines[0].Point2.Y);
					lastLine.Point1 = new Point(lastLine.Point2.X, lastLine.Point1.Y);
					lines[1].Point1 = lines[0].Point2;
					lines[1].Point2 = lines[2].Point1;
				}
			}
			else if (lines.Length == 2)
			{
				if ((conn1Dir == CardinalDirection.North) || (conn1Dir == CardinalDirection.South))
					lines[0].Point2 = new Point(lines[0].Point1.X, lastLine.Point2.Y);
				else
					lines[0].Point2 = new Point(lastLine.Point2.X, lines[0].Point1.Y);

				lastLine.Point1 = lines[0].Point2;
			}

			needCalcLinkLocation = true;
			needCalcLinkSize = true;

			needCalcLink = false;
           
        }

		private void CalcLinkLocation()
		{
			//CalcLink();

			if (!needCalcLinkLocation)
				return;

			Point[] points = new Point[lines.Length * 2];
			int i = 0;
			foreach(LineElement ln in lines)
			{
				points[i] = ln.Point1;
				points[i + 1] = ln.Point2;
				i+=2;
			}

			location = DiagramUtil.GetUpperPoint(points);
            label.PositionBySite(lines[1]);
            needCalcLinkLocation = false;
		}

		private void CalcLinkSize()
		{
			if (!needCalcLinkSize)
				return;

			Size sizeTmp = Size.Empty;
				
			if (lines.Length > 1)
			{
				Point[] points = new Point[lines.Length * 2];
				int i = 0;
				foreach(LineElement ln in lines)
				{
					points[i] = ln.Point1;
					points[i + 1] = ln.Point2;
					i+=2;
				}
				Point upper = DiagramUtil.GetUpperPoint(points);
				Point lower = DiagramUtil.GetLowerPoint(points);

				sizeTmp = new Size(lower.X - upper.X, lower.Y - upper.Y);
			}
			
			size = sizeTmp;

			needCalcLinkSize = false;
		}

	
		#region IControllable Members

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new RightAngleLinkController(this);
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
