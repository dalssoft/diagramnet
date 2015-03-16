using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class is the controller for LineElement
	/// </summary>
	internal class LineController: IController
	{
		//parent element
		protected LineElement el;

		public LineController(LineElement element)
		{
			el = element;
		}

		#region IController Members

		public BaseElement OwnerElement
		{
			get
			{
				return el;
			}
		}

		public bool HitTest(Point p)
		{
			GraphicsPath gp = new GraphicsPath();
			Matrix mtx = new Matrix();
			Pen pen = new Pen(el.BorderColor, el.BorderWidth + 4);
			pen.StartCap = el.StartCap;
			pen.EndCap = el.EndCap;
			gp.AddLine(el.Point1, el.Point2);
			gp.Transform(mtx);
			//Rectangle retGp = Rectangle.Round(gp.GetBounds());
			return gp.IsOutlineVisible (p, pen);
		}

		public bool HitTest(Rectangle r)
		{
			GraphicsPath gp = new GraphicsPath();
			Matrix mtx = new Matrix();

			gp.AddRectangle(new Rectangle(el.Location.X,
				el.Location.Y,
				el.Size.Width,
				el.Size.Height));
			gp.Transform(mtx);
			Rectangle retGp = Rectangle.Round(gp.GetBounds());
			return r.Contains (retGp);
		}

		public void DrawSelection(Graphics g)
		{
			/*
			Pen p = new Pen(Color.FromArgb(80, Color.Yellow), el.BorderWidth + 2);
			p.StartCap = el.StartCap;
			p.EndCap = el.EndCap;
			g.DrawLine(p, el.Point1, el.Point2);
			*/
		}

		#endregion

	}
}
