using System;

namespace Dalssoft.DiagramNet
{
	public class ElementMouseEventArgs: ElementEventArgs 
	{
		private int x;
		private int y;

		public ElementMouseEventArgs(BaseElement el, int x, int y): base (el)
		{
			this.x = x;
			this.y = y;
		}

		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public override string ToString()
		{
			return base.ToString() + " X:" + x + " Y:" + y;
		}

	}
}
