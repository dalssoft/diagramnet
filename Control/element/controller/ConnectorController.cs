using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class is the controller for ConnectorElement
	/// </summary>
	internal class ConnectorController: RectangleController
	{
		public ConnectorController(ConnectorElement element): base(element)
		{}

		public override void DrawSelection(Graphics g)
		{
			int distance = 1;
			int border = 2;

			Rectangle r = BaseElement.GetUnsignedRectangle(
				new Rectangle(
				el.Location.X - distance, el.Location.Y - distance,
				el.Size.Width + (distance * 2), el.Size.Height + (distance * 2)));

			//HatchBrush brush = new HatchBrush(HatchStyle.SmallCheckerBoard, Color.Red, Color.Transparent);
			SolidBrush brush = new SolidBrush(Color.FromArgb(150, Color.Green));
			Pen p = new Pen(brush, border);
			g.DrawRectangle(p, r);
			
			p.Dispose();
			brush.Dispose();
		}
	}
}
