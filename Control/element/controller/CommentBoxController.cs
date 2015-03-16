using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class is the controller for CommentBoxElement
	/// </summary>
	
	internal class CommentBoxController: RectangleController, ILabelController
	{
		public CommentBoxController(BaseElement element): base(element) {}

		public void SetLabelPosition()
		{
			LabelElement label = ((ILabelElement) el).Label;
			label.Location = el.Location;
			label.Size = el.Size;
		}
	}
}
