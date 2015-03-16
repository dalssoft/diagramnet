using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class LineElement: BaseElement, IControllable 
	{
		protected Point point1;
		protected Point point2;
		protected LineCap startCap = LineCap.Round;
		protected LineCap endCap = LineCap.Round;
		protected bool needCalcLine = false;

		[NonSerialized]
		private LineController controller;

		internal LineElement(int x1, int y1, int x2, int y2)
			: this(new Point(x1, y1), new Point(x2, y2)) {}

		internal LineElement(Point p1, Point p2)
		{
			point1 = p1;			
			point2 = p2;
			
			borderWidth = 1;
			borderColor = Color.Black;
		}

		public virtual Point Point1
		{
			get
			{
				CalcLine();
				return point1;
			}
			set
			{
				point1 = value;
				needCalcLine = true;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Point Point2
		{
			get
			{
				CalcLine();
				return point2;
			}
			set
			{
				point2 = value;
				needCalcLine = true;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual LineCap StartCap
		{
			get
			{
				return startCap;
			}
			set
			{
				startCap = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual LineCap EndCap
		{
			get
			{
				return endCap;
			}
			set
			{
				endCap = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		internal override void Draw(Graphics g)
		{
			IsInvalidated = false;

			Rectangle r = RectangleElement.GetUnsignedRectangle(
				new Rectangle(
				location.X, location.Y, 
				size.Width, size.Height));

			//Fill rectangle
			Color borderColor1;
			if (opacity == 100)
				borderColor1 = borderColor;
			else
				borderColor1 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), borderColor);
			
			Pen p;
			p = new Pen(borderColor1, borderWidth);
			
			p.StartCap = startCap;
			p.EndCap = endCap;
			g.DrawLine(p, point1, point2);
			p.Dispose();
		}

		internal void CalcLine()
		{
			if (needCalcLine == false) return;

			//Find Location and Size
			if (point1.X < point2.X)
			{
				location.X = point1.X;
				size.Width = point2.X - point1.X;
			}
			else
			{
				location.X = point2.X;
				size.Width = point1.X - point2.X;
			}

			if (point1.Y < point2.Y)
			{
				location.Y = point1.Y;
				size.Height = point2.Y - point1.Y;
			}
			else
			{
				location.Y = point2.Y;
				size.Height = point1.Y - point2.Y;
			}

			needCalcLine = false;
		}
		
		#region IControllable Members

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new LineController(this);
			return controller;
		}

		#endregion
	}
}