using System;
using System.Collections;
using System.Drawing;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// Summary description for DiagramUtil.
	/// </summary>
	internal class DiagramUtil
	{
		private DiagramUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region Point Calc
		public static Point DisplayToCartesianCoord(Point p, Rectangle referenceRec)
		{
			//int x0 = referenceRec.Location.X + (referenceRec.Width / 2);
			//int y0 = referenceRec.Location.Y + (referenceRec.Height / 2);
			int x0 = (referenceRec.Width / 2);
			int y0 = (referenceRec.Height / 2);
			
			return new Point(p.X - x0, p.Y - y0);		
		}

		public static double PointToAngle(Point cartPoint)
		{
			
			double angle = (Math.Atan2(cartPoint.Y, cartPoint.X) * (180 / Math.PI));

			if ((angle > 0) && (angle < 180))
				angle = 360 - angle;
			angle = Math.Abs(angle);

			return angle;

		}

		public static CardinalDirection GetDirection(Rectangle rec, Point point)
		{
			Point p = DisplayToCartesianCoord(point, rec);
			
			double angle = PointToAngle(p);
			
			//East
			if (((angle >= 0) && (angle < 45)) || (angle >= 315))
				return CardinalDirection.East;
				//North
			else if ((angle >= 45) && (angle < 135))
				return CardinalDirection.North;
				//West
			else if ((angle >= 135) && (angle < 225))
				return CardinalDirection.West;
				//South
			else if ((angle >= 225) && (angle < 315))
				return CardinalDirection.South;
			
			return CardinalDirection.Nothing;
		}

		public static Point GetUpperPoint(Point[] points)
		{
			Point upper = Point.Empty;
			upper.X = Int32.MaxValue;
			upper.Y = Int32.MaxValue;
			foreach(Point p in points)
			{
				if (p.X < upper.X)
					upper.X = p.X;

				if (p.Y < upper.Y)
					upper.Y = p.Y;
			}

			return upper;
		}

		public static Point GetLowerPoint(Point[] points)
		{
			Point lower = Point.Empty;
			lower.X = Int32.MinValue;
			lower.Y = Int32.MinValue;
			foreach(Point p in points)
			{
				if (p.X > lower.X)
					lower.X = p.X;

				if (p.Y > lower.Y)
					lower.Y = p.Y;
			}

			return lower;
		}

		public static Point GetRelativePoint(Point location1, Point location2)
		{
			Point ret = Point.Empty;
			ret.X = location2.X - location1.X;
			ret.Y = location2.Y - location1.Y;
			return ret;
		}
		#endregion

		#region Draw Font
		public static Size MeasureString(string text, Font font)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}

		public static Size MeasureString(string text, Font font, SizeF layoutArea)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, layoutArea);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}

		public static Size MeasureString(string text, Font font, int width)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, width);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}

		public static Size MeasureString(string text, Font font, PointF origin, StringFormat stringFormat)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, origin, stringFormat);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}

		public static Size MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, layoutArea, stringFormat);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}

		public static Size MeasureString(string text, Font font, int width, StringFormat format)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, width, format);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}

		public static Size MeasureString(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled)
		{
			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
			bmp.Dispose();
			g.Dispose();
			return Size.Round(sizeF);
		}
		#endregion

		public static int GetInnerElementsCount(BaseElement el)
		{
			int ret = 0;
			if (el is ILabelElement) ret++;

			if (el is NodeElement)
			{
				NodeElement nel = (NodeElement) el;
				ret += nel.Connectors.Length;
			}

//			if (el is IContainer)
//			{
//				IContainer cel = (IContainer) el;
//				ret += cel.Elements.Count;
//			}

			return ret;
		}

		public static BaseElement[] GetInnerElements(BaseElement el)
		{
			BaseElement[] ret = new BaseElement[GetInnerElementsCount(el)];

			int i = 0;

			if (el is ILabelElement)
			{
				ret[i] = ((ILabelElement) el).Label;
				i++;
			}
			if (el is NodeElement)
			{
				NodeElement nel = (NodeElement) el;
				ConnectorElement[] innerConnectors = nel.Connectors;
				Array.Copy(innerConnectors, 0, ret, i, innerConnectors.Length);
				i += innerConnectors.Length;
			}

//			if (el is IContainer)
//			{
//				IContainer cel = (IContainer) el;
//				BaseElement [] innerElements = cel.Elements.GetArray();
//				Array.Copy(innerElements, 0, ret, i, innerElements.Length);
//				i += innerElements.Length;
//			}

			return ret;

		}

		public class ArrayHelper
		{
			private ArrayHelper(){}

			public static Array Append(Array arr1, Array arr2)
			{
				Type arr1Type = arr1.GetType().GetElementType();
				Type arr2Type = arr1.GetType().GetElementType();
				
				if (arr1Type != arr2Type) throw new Exception("Arrays isn't the same type");
				
				ArrayList arrNew = new ArrayList(arr1.Length + arr2.Length - 1);
				arrNew.AddRange(arr1);
				arrNew.AddRange(arr2);
				return arrNew.ToArray(arr1Type);
			}

			public static Array Shrink(Array arr, object removeValue)
			{
				ArrayList arrNew = new ArrayList(arr.Length - 1);
				foreach(object o in arr)
				{
					if (o != removeValue)
						arrNew.Add(o);
				}
				arrNew.TrimToSize();
				return arrNew.ToArray(arr.GetType().GetElementType());
			}
		}
	}
}


