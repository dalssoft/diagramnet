using System;
using System.Drawing;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// If a class controller implements this interface, then it can control
	/// the label inside the element.
	/// Without this interface, the label will be controled be default controller.
	/// </summary>
	public interface ILabelController
	{
		void SetLabelPosition();
	}
}
