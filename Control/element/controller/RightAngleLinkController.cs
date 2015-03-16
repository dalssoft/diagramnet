using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class is the controller for RightAngleLinkElement
	/// </summary>
	internal class RightAngleLinkController: IController, IMoveController, IResizeController, ILabelController
	{
		//parent element
		protected RightAngleLinkElement el;

		//Move vars.
		protected Point dragOffset = new Point(0);
		protected bool isDragging = false;
		protected bool canMove = true;

		//Resize vars.
		protected const int selCornerSize = 3;
		protected RectangleElement[] selectionCorner;
		protected CornerPosition selCorner = CornerPosition.Nothing;
		protected bool canResize = true;

		public RightAngleLinkController(RightAngleLinkElement element)
		{
			el = element;
			
			//Create corners
			if (el.lines.Length == 3)
			{
				selectionCorner = new RectangleElement[1];
				selectionCorner[0] = new RectangleElement(0, 0, selCornerSize * 2, selCornerSize * 2);
				selectionCorner[0].BorderColor = Color.Black;
				selectionCorner[0].FillColor1 = Color.White;
				selectionCorner[0].FillColor2 = Color.Empty;
			}
			else
			{
				selectionCorner = new RectangleElement[0];
			}
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
			foreach(LineElement l in el.lines)
			{
				IController ctrl = ((IControllable) l).GetController();
				if (ctrl.HitTest(p))
					return true;
			}
			return false;
		}

		bool Dalssoft.DiagramNet.IController.HitTest(Rectangle r)
		{
			GraphicsPath gp = new GraphicsPath();
			Matrix mtx = new Matrix();

			Point elLocation = el.Location;
			Size elSize = el.Size;
			gp.AddRectangle(new Rectangle(elLocation.X,
				elLocation.Y,
				elSize.Width,
				elSize.Height));
			gp.Transform(mtx);
			Rectangle retGp = Rectangle.Round(gp.GetBounds());
			return r.Contains (retGp);
		}

		public void DrawSelection(Graphics g)
		{
			foreach(LineElement l in el.lines)
			{
				IController ctrl = ((IControllable) l).GetController();
				ctrl.DrawSelection(g);
			}
		}

		#endregion
	
		#region IResizeController Members

		public RectangleElement[] Corners
		{
			get
			{
				return selectionCorner;
			}	
		}

		void IResizeController.UpdateCornersPos()
		{
			if (selectionCorner.Length == 1)
			{
				Point elLinePoint1 = el.lines[1].Point1;
				Point elLinePoint2 = el.lines[1].Point2;
				selectionCorner[0].Location = new Point(elLinePoint1.X + ((elLinePoint2.X - elLinePoint1.X) / 2) - selCornerSize,
														elLinePoint1.Y + ((elLinePoint2.Y - elLinePoint1.Y) / 2) - selCornerSize);
			}
		}

		CornerPosition IResizeController.HitTestCorner(Point p)
		{
			if (selectionCorner.Length == 1)
			{
				IController ctrl = ((IControllable) selectionCorner[0]).GetController();
				if (ctrl.HitTest(p))
				{
					if (el.orientation == Orientation.Horizontal)
						return CornerPosition.MiddleLeft;
					else if (el.orientation == Orientation.Vertical)
						return CornerPosition.TopCenter;
					else
						return CornerPosition.Undefined;
				}
			}
			return CornerPosition.Nothing;
		}

		void IResizeController.Start(Point posStart, CornerPosition corner)
		{
			selCorner = corner;
			dragOffset.X = selectionCorner[0].Location.X - posStart.X;
			dragOffset.Y = selectionCorner[0].Location.Y - posStart.Y;
		}

		void IResizeController.Resize(Point posCurrent)
		{
			RectangleElement corner = selectionCorner[0];
			Point loc;

			Point dragPointEl = posCurrent;
			dragPointEl.Offset(dragOffset.X, dragOffset.Y);
			if (dragPointEl.X < 0) dragPointEl.X = 0;
			if (dragPointEl.Y < 0) dragPointEl.Y = 0;

			if (el.orientation == Orientation.Horizontal)
			{
				corner.Location = new Point(dragPointEl.X, corner.Location.Y);
				loc = new Point(corner.Location.X + corner.Size.Width / 2, corner.Location.Y + corner.Size.Height / 2);
				el.lines[1].Point1 = new Point(loc.X, el.lines[1].Point1.Y);
				el.lines[1].Point2 = new Point(loc.X, el.lines[1].Point2.Y);
			}
			else
			{
				corner.Location = new Point(corner.Location.X, dragPointEl.Y);
				loc = new Point(corner.Location.X + corner.Size.Width / 2, corner.Location.Y + corner.Size.Height / 2);
				el.lines[1].Point1 = new Point(el.lines[1].Point1.X, loc.Y);
				el.lines[1].Point2 = new Point(el.lines[1].Point2.X, loc.Y);
			}

			el.lines[0].Point2 = el.lines[1].Point1;
			el.lines[2].Point1 = el.lines[1].Point2;

			el.NeedCalcLink = true;
		}

		void IResizeController.End(Point posEnd)
		{
			selCorner = CornerPosition.Nothing;
			dragOffset = Point.Empty;
		}

		bool IResizeController.IsResizing
		{
			get
			{
				return (selCorner != CornerPosition.Nothing);
			}
		}

		bool IResizeController.CanResize
		{
			get
			{
				return canResize;
			}
		}

		#endregion

		#region IMoveController Members

		void IMoveController.Start(Point posStart)
		{
			dragOffset.X = el.Location.X - posStart.X;
			dragOffset.Y = el.Location.Y - posStart.Y;
			isDragging = true;
		}

		void IMoveController.Move(Point posCurrent)
		{
			if (isDragging)
			{
				Point dragPointEl = posCurrent;
				dragPointEl.Offset(dragOffset.X, dragOffset.Y) ;
				if (dragPointEl.X < 0) dragPointEl.X = 0;
				if (dragPointEl.Y < 0) dragPointEl.Y = 0;
						
				el.Location = dragPointEl;
			}
		}

		void IMoveController.End()
		{
			isDragging = false;
		}
		
		bool IMoveController.IsMoving
		{
			get
			{
				return isDragging;
			}
		}

		bool IMoveController.CanMove
		{
			get
			{
				return canMove;
			}
		}

		#endregion
	
		#region ILabelController Members

		public void SetLabelPosition()
		{
			LabelElement label = ((ILabelElement) el).Label;

			if (el.Lines.Length == 2)
			{
				label.Location = el.Lines[0].Point2;
			}
			else
				label.PositionBySite(el.Lines[1]);
		}

		#endregion
	}
}
