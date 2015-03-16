using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class control the elements motion.
	/// </summary>
	
	internal class MoveAction
	{
		public delegate void OnElementMovingDelegate(ElementEventArgs e);
		private OnElementMovingDelegate onElementMovingDelegate;

		private bool isMoving = false;
		private IMoveController[] moveCtrl;
		private Point upperSelPoint = Point.Empty;
		private Point upperSelPointDragOffset = Point.Empty;
		private Document document = null;

		public MoveAction()
		{
		}
		
		public bool IsMoving
		{
			get
			{
				return isMoving;
			}
		}

		public void Start(Point mousePoint, Document document, OnElementMovingDelegate onElementMovingDelegate)
		{
			this.document = document;
			this.onElementMovingDelegate = onElementMovingDelegate;

			// Get Controllers
			moveCtrl = new IMoveController[document.SelectedElements.Count];
			IMoveController[] moveLabelCtrl = new IMoveController[document.SelectedElements.Count];
			for(int i = document.SelectedElements.Count - 1; i >= 0; i--)
			{
				moveCtrl[i] = ControllerHelper.GetMoveController(document.SelectedElements[i]);
				
				if ((moveCtrl[i] != null) && (moveCtrl[i].CanMove))
				{
					onElementMovingDelegate(new ElementEventArgs(document.SelectedElements[i]));
					moveCtrl[i].Start(mousePoint);
					
					//ILabelElement - Move Label inside the element
					if ((document.SelectedElements[i] is ILabelElement) &&
						(ControllerHelper.GetLabelController(document.SelectedElements[i]) == null))
					{
						LabelElement label = ((ILabelElement) document.SelectedElements[i]).Label;
						moveLabelCtrl[i] = ControllerHelper.GetMoveController(label);
						if ((moveLabelCtrl[i] != null) && (moveLabelCtrl[i].CanMove))
							moveLabelCtrl[i].Start(mousePoint);
						else
							moveLabelCtrl[i] = null;
					}
				}
				else
					moveCtrl[i] = null;
			}

			moveCtrl = (IMoveController[]) DiagramUtil.ArrayHelper.Append(moveCtrl, moveLabelCtrl);
			moveCtrl = (IMoveController[]) DiagramUtil.ArrayHelper.Shrink(moveCtrl, null);

			// Can't move only links
			bool isOnlyLink = true;
			foreach (IMoveController ctrl in moveCtrl)
			{
				// Verify
				if (ctrl != null)
				{
					ctrl.OwnerElement.Invalidate();

					if (!(ctrl.OwnerElement is BaseLinkElement) && !(ctrl.OwnerElement is LabelElement))
					{
						isOnlyLink = false;
						break;
					}
				}
			}
			if (isOnlyLink)
			{
				//End Move the Links
				foreach (IMoveController ctrl in moveCtrl)
				{
					if (ctrl !=null)
						ctrl.End();
				}
				moveCtrl = new IMoveController[] {null};
			}

			//Upper selecion point controller
			UpdateUpperSelectionPoint();
			upperSelPointDragOffset.X = upperSelPoint.X - mousePoint.X;
			upperSelPointDragOffset.Y = upperSelPoint.Y - mousePoint.Y;

			isMoving = true;
		}

		public void Move(Point dragPoint)
		{
			//Upper selecion point controller
			Point dragPointEl = dragPoint;
			dragPointEl.Offset(upperSelPointDragOffset.X, upperSelPointDragOffset.Y);
					
			upperSelPoint = dragPointEl;
					
			if (dragPointEl.X < 0) dragPointEl.X = 0;
			if (dragPointEl.Y < 0) dragPointEl.Y = 0;

			//Move Controller
			if (dragPointEl.X == 0) dragPoint.X = dragPoint.X - upperSelPoint.X;					
			if (dragPointEl.Y == 0) dragPoint.Y = dragPoint.Y - upperSelPoint.Y;

			foreach(IMoveController ctrl in moveCtrl)
			{
				if (ctrl != null)
				{
					ctrl.OwnerElement.Invalidate();

					onElementMovingDelegate(new ElementEventArgs(ctrl.OwnerElement));
					
					ctrl.Move(dragPoint);

					if (ctrl.OwnerElement is NodeElement)
					{
						UpdateLinkPosition((NodeElement) ctrl.OwnerElement);
					}

					ILabelController lblCtrl = ControllerHelper.GetLabelController(ctrl.OwnerElement);
					if (lblCtrl != null)
						lblCtrl.SetLabelPosition();
				}
			}
		}

		public void End()
		{
			upperSelPoint = Point.Empty;
			upperSelPointDragOffset = Point.Empty;
				
//			ElementEventArgs eventClickArg = new ElementEventArgs(selectedElement);
//			OnElementClick(eventClickArg);

			foreach(IMoveController ctrl in moveCtrl)
			{
				if (ctrl !=null)
				{
					if (ctrl.OwnerElement is NodeElement)
					{
						UpdateLinkPosition((NodeElement) ctrl.OwnerElement);
					}

					ctrl.End();

					onElementMovingDelegate(new ElementEventArgs(ctrl.OwnerElement));
				}
			}

			isMoving = false;

//			ElementMouseEventArgs eventMouseUpArg = new ElementMouseEventArgs(selectedElement, e.X, e.Y);
//			OnElementMouseUp(eventMouseUpArg);
		}

		private void UpdateUpperSelectionPoint()
		{
			//Get upper selecion point
			Point[] points = new Point[document.SelectedElements.Count];
			int p = 0;
			foreach(BaseElement el in document.SelectedElements)
			{
				points[p] = el.Location;
				p++;
			}
			upperSelPoint = DiagramUtil.GetUpperPoint(points);
		}

		private void UpdateLinkPosition(NodeElement node)
		{
			foreach(ConnectorElement conn in node.Connectors)
			{
				foreach (BaseElement el in conn.Links)
				{
					BaseLinkElement lnk = (BaseLinkElement) el;
					IController ctrl = ((IControllable) lnk).GetController();
					if (ctrl is IMoveController)
					{
						IMoveController mctrl = (IMoveController) ctrl;
						if (!mctrl.IsMoving) lnk.NeedCalcLink = true;
					}
					else lnk.NeedCalcLink = true;

					if (lnk is ILabelElement)
					{
						LabelElement label = ((ILabelElement) lnk).Label;

						ILabelController lblCtrl = ControllerHelper.GetLabelController(lnk);
						if (lblCtrl != null)
							lblCtrl.SetLabelPosition();
						else
						{
							label.PositionBySite(lnk);
						}		
						label.Invalidate();
					}
				}
			}
		}
	}
}
