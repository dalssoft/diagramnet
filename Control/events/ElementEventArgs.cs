using System;

namespace Dalssoft.DiagramNet
{
	public class ElementEventArgs: EventArgs
	{
		private BaseElement element;

		public ElementEventArgs(BaseElement el)
		{
			element = el;
		}

		public BaseElement Element
		{
			get
			{
				return element;
			}
		}

		public override string ToString()
		{
			return "el: " + element.GetHashCode();
		}


	}
}
