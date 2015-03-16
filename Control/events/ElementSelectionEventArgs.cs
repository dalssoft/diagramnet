using System;

namespace Dalssoft.DiagramNet
{
	public class ElementSelectionEventArgs: EventArgs 
	{
		ElementCollection elements;

		public ElementSelectionEventArgs(ElementCollection elements)
		{
			this.elements = elements;
		}

		public ElementCollection Elements
		{
			get
			{
				return elements;
			}
		}

		public override string ToString()
		{
			return "ElementCollection: " + elements.Count.ToString();
		}

	}
}
