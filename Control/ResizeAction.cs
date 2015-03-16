using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class control the size of elements
	/// </summary>
	internal class ResizeAction
	{
		public delegate void OnElementResizingDelegate(ElementEventArgs e);
		private OnElementResizingDelegate onElementResizingDelegate;

		private bool isResizing = false;
		private IResizeController resizeCtrl = null;
		private Document document = null;

		public ResizeAction()
		{
		}

		public bool IsResizing
		{
			get
			{
				return isResizing;
			}
		}

		public bool IsResizingLink
		{
			get
			{
				return ((resizeCtrl != null) && (resizeCtrl.OwnerElement is BaseLinkElement));
			}
		}

		public void Select(Document document)
		{
			this.document = document;

			// Get Resize Controller
			if ((document.SelectedElements.Count == 1) && (document.SelectedElements[0] is IControllable))
			{	
				IController ctrl = ((IControllable) document.SelectedElements[0]).GetController();
				if (ctrl is IResizeController)
				{
					ctrl.OwnerElement.Invalidate();

					resizeCtrl = (IResizeController) ctrl;
					ShowResizeCorner(true);
				}
			}
			else
				resizeCtrl = null;
		}

		public void Start(Point mousePoint, OnElementResizingDelegate onElementResizingDelegate)
		{
			isResizing = false;

			if (resizeCtrl == null) return;

			this.onElementResizingDelegate = onElementResizingDelegate;

			resizeCtrl.OwnerElement.Invalidate();

			CornerPosition corPos = resizeCtrl.HitTestCorner(mousePoint);

			if (corPos != CornerPosition.Nothing)
			{
				//Events
				ElementEventArgs eventResizeArg = new ElementEventArgs(resizeCtrl.OwnerElement);
				onElementResizingDelegate(eventResizeArg);

				resizeCtrl.Start(mousePoint, corPos);

				UpdateResizeCorner();

				isResizing = true;
			}

		}

		public void Resize(Point dragPoint)
		{
			if ((resizeCtrl != null) && (resizeCtrl.CanResize))
			{				
				//Events
				ElementEventArgs eventResizeArg = new ElementEventArgs(resizeCtrl.OwnerElement);
				onElementResizingDelegate(eventResizeArg);

				resizeCtrl.OwnerElement.Invalidate();

				resizeCtrl.Resize(dragPoint);

				ILabelController lblCtrl = ControllerHelper.GetLabelController(resizeCtrl.OwnerElement);
				if (lblCtrl != null)
					lblCtrl.SetLabelPosition();
				else
				{
					if (resizeCtrl.OwnerElement is ILabelElement)
					{
						LabelElement label = ((ILabelElement) resizeCtrl.OwnerElement).Label;
						label.PositionBySite(resizeCtrl.OwnerElement);
					}
				}

				UpdateResizeCorner();
			}
		}

		public void End(Point posEnd)
		{
			if (resizeCtrl != null)
			{
				resizeCtrl.OwnerElement.Invalidate();

				resizeCtrl.End(posEnd);

				//Events
				ElementEventArgs eventResizeArg = new ElementEventArgs(resizeCtrl.OwnerElement);
				onElementResizingDelegate(eventResizeArg);

				isResizing = false;
			}
		}

		public void DrawResizeCorner(Graphics g)
		{
			if (resizeCtrl != null)
			{
				foreach(RectangleElement r in resizeCtrl.Corners)
				{
					if (document.Action == DesignerAction.Select)
					{
						if (r.Visible) r.Draw(g);
					}
					else if (document.Action == DesignerAction.Connect)
					{
						// if is Connect Mode, then resize only Links.
						if (resizeCtrl.OwnerElement is BaseLinkElement)
							if (r.Visible) r.Draw(g);
					}
				}
			}
		}

		public void UpdateResizeCorner()
		{
			if (resizeCtrl != null)
				resizeCtrl.UpdateCornersPos();
		}

		public Cursor UpdateResizeCornerCursor(Point mousePoint)
		{
			if ((resizeCtrl == null) || (!resizeCtrl.CanResize)) return Cursors.Default;

			CornerPosition corPos = resizeCtrl.HitTestCorner(mousePoint);

			switch(corPos)
			{
				case CornerPosition.TopLeft:
					return Cursors.SizeNWSE;
				
				case CornerPosition.TopCenter:
					return Cursors.SizeNS;								

				case CornerPosition.TopRight:
					return Cursors.SizeNESW;								
					
				case CornerPosition.MiddleLeft:
				case CornerPosition.MiddleRight:
					return Cursors.SizeWE;

				case CornerPosition.BottomLeft:
					return Cursors.SizeNESW;
				
				case CornerPosition.BottomCenter:
					return Cursors.SizeNS;								

				case CornerPosition.BottomRight:
					return Cursors.SizeNWSE;
				default:
					return Cursors.Default;
			}			
			
		}

		public void ShowResizeCorner(bool show)
		{
			if (resizeCtrl != null)
			{
				bool canResize = resizeCtrl.CanResize;
				for(int i = 0; i < resizeCtrl.Corners.Length; i++)
				{
					if (canResize)
						resizeCtrl.Corners[i].Visible = show;
					else
						resizeCtrl.Corners[i].Visible = false;
				}

				if (resizeCtrl.Corners.Length >= (int) CornerPosition.MiddleCenter)
					resizeCtrl.Corners[(int) CornerPosition.MiddleCenter].Visible = false;
			}
		}
	}
}
