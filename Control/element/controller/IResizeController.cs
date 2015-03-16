using System;
using System.Drawing;
namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// If a class controller implements this interface, it can resize the element.
	/// </summary>
	internal interface IResizeController : IController
	{
		RectangleElement[] Corners {get;}
		void UpdateCornersPos();

		CornerPosition HitTestCorner(Point p);

		void Start(Point posStart, CornerPosition corner);
		void Resize(Point posCurrent);
		void End(Point posEnd);

		bool IsResizing {get;}

		bool CanResize {get;}
	
	}
}
