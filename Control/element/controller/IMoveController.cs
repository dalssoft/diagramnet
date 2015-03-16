using System;
using System.Drawing;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// If a class controller implements this interface, it can move the element.
	/// </summary>
	internal interface IMoveController : IController
	{
		bool IsMoving {get;}

		void Start(Point posStart);
		void Move(Point posCurrent);
		void End();

		bool CanMove {get;}
	}
}
