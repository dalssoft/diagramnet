using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Dalssoft.DiagramNet;

namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class CommentBoxElement: RectangleElement, IControllable, ILabelElement
	{
		[NonSerialized]
		private RectangleController controller;

		protected Size foldSize = new Size(10, 15);

		public CommentBoxElement(): this(0, 0, 100, 100)
		{}

		public CommentBoxElement(Rectangle rec): this(rec.Location, rec.Size)
		{}

		public CommentBoxElement(Point l, Size s): this(l.X, l.Y, s.Width, s.Height) 
		{}

		public CommentBoxElement(int top, int left, int width, int height): base(top, left, width, height)
		{
			fillColor1 = Color.LemonChiffon;
			fillColor2 = Color.FromArgb(255, 255, 128);

			label.Opacity = 100;
		}

		public override Point Location
		{
			get
			{
				return base.Location;
			}
			set
			{
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
				base.Size = value;
			}
		}

		internal override void Draw(Graphics g)
		{
			IsInvalidated = false;

			Rectangle r = BaseElement.GetUnsignedRectangle(new Rectangle(location, size));

			Point[] points = new Point[5];
			points[0] = new Point(r.X + 0, r.Y + 0);
			points[1] = new Point(r.X + 0, r.Y + r.Height);
			points[2] = new Point(r.X + r.Width, r.Y + r.Height);

			//Fold
			points[3] = new Point(r.X + r.Width, r.Y + foldSize.Height);
			points[4] = new Point(r.X + r.Width - foldSize.Width, r.Y + 0);

			//foreach(Point p in points) p.Offset(location.X, location.Y);

			g.FillPolygon(GetBrush(r), points, FillMode.Alternate);
			g.DrawPolygon(new Pen(borderColor, borderWidth), points);

			g.DrawLine(new Pen(borderColor, borderWidth),
			           new Point(r.X + r.Width - foldSize.Width, r.Y + foldSize.Height),
			           new Point(r.X + r.Width, r.Y + foldSize.Height));

			g.DrawLine(new Pen(borderColor, borderWidth),
			           new Point(r.X + r.Width - foldSize.Width, r.Y + 0),
			           new Point(r.X + r.Width - foldSize.Width, r.Y + 0 + foldSize.Height));
		}

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new CommentBoxController(this);
			return controller;
		}

	}
}
