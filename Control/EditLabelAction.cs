using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This class control the label edition of the element.
	/// </summary>
	internal class EditLabelAction
	{
		private BaseElement siteLabelElement;
		private LabelElement labelElement;
		private TextBox labelTextBox;
		private LabelEditDirection direction;
		private Point center;
		private const int textBoxBorder = 3;

		public EditLabelAction()
		{
		}

		public void StartEdit(BaseElement el, TextBox textBox)
		{
			if (!(el is ILabelElement)) return;

			if (((ILabelElement) el).Label.ReadOnly) return;

			this.siteLabelElement = el;
			this.labelElement = ((ILabelElement) siteLabelElement).Label;
			this.labelTextBox = textBox;
			if (siteLabelElement is BaseLinkElement)
				this.direction = LabelEditDirection.Both;
			else
				this.direction = LabelEditDirection.UpDown;
			
			EditLabelAction.SetTextBoxLocation(siteLabelElement, labelTextBox);

			labelTextBox.AutoSize = true;
			labelTextBox.Show();
			labelTextBox.Text = labelElement.Text;
			labelTextBox.Font = labelElement.Font;
			labelTextBox.WordWrap = labelElement.Wrap;
			
			labelElement.Invalidate();
			
			switch(labelElement.Alignment)
			{
				case StringAlignment.Near:
					labelTextBox.TextAlign = HorizontalAlignment.Left;
					break;
				case StringAlignment.Center:
					labelTextBox.TextAlign = HorizontalAlignment.Center;
					break;
				case StringAlignment.Far:
					labelTextBox.TextAlign = HorizontalAlignment.Right;
					break;
			}	

			labelTextBox.KeyPress += new KeyPressEventHandler(labelTextBox_KeyPress);
			labelTextBox.Focus();
			center.X = textBox.Location.X + (textBox.Size.Width / 2);
			center.Y = textBox.Location.Y + (textBox.Size.Height / 2);
		}

		public void EndEdit()
		{
			if (siteLabelElement == null) return;
			
			labelTextBox.KeyPress -= new KeyPressEventHandler(labelTextBox_KeyPress);

			ILabelController lblCtrl = ControllerHelper.GetLabelController(siteLabelElement);
			labelElement.Size = MeasureTextSize();
			labelElement.Text = labelTextBox.Text;
			labelTextBox.Hide();
			if (lblCtrl != null)
			{
				lblCtrl.SetLabelPosition();
			}
			else
			{
				labelElement.PositionBySite(siteLabelElement);
			}
			labelElement.Invalidate();
			siteLabelElement = null;
			labelElement = null;
			labelTextBox= null;
		}

		public static void SetTextBoxLocation(BaseElement el, TextBox tb)
		{
			if (!(el is ILabelElement)) return;

			LabelElement lab = ((ILabelElement) el).Label;

			el.Invalidate();
			lab.Invalidate();

			if (lab.Text.Length > 0)
			{
				tb.Location = lab.Location;
				tb.Size = lab.Size;
			}
			else
			{
				string tmpText = "XXXXXXX";
				Size sizeTmp = DiagramUtil.MeasureString(tmpText, lab.Font, lab.Size.Width, lab.Format);
				
				if (el is BaseLinkElement)
				{
					tb.Size = sizeTmp;
					tb.Location = new Point(el.Location.X + (el.Size.Width / 2) - (sizeTmp.Width / 2),
						el.Location.Y + (el.Size.Height / 2) - (sizeTmp.Height / 2));
				}
				else
				{
					sizeTmp.Width = el.Size.Width;
					tb.Size = sizeTmp;
					tb.Location = new Point(el.Location.X,
						el.Location.Y + (el.Size.Height / 2) - (sizeTmp.Height / 2));
				}
			}

			SetTextBoxBorder(tb);
		}

		private static void SetTextBoxBorder(TextBox tb)
		{
			Rectangle tbBox = new Rectangle(tb.Location, tb.Size);
			tbBox.Inflate(textBoxBorder, textBoxBorder);
			tb.Location = tbBox.Location;
			tb.Size = tbBox.Size;		
		}

		private Size MeasureTextSize()
		{
			string text = labelTextBox.Text;
			Size sizeTmp = Size.Empty;
			if (direction == LabelEditDirection.UpDown)
				sizeTmp = DiagramUtil.MeasureString(text, labelElement.Font, labelTextBox.Size.Width, labelElement.Format);
			else if (direction == LabelEditDirection.Both)
				sizeTmp = DiagramUtil.MeasureString(text, labelElement.Font);

			sizeTmp.Height += 30;

			return sizeTmp;
		}

		void labelTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (labelTextBox.Text.Length == 0) return;

			Size size = labelTextBox.Size;
			Size sizeTmp = MeasureTextSize();

			if (direction == LabelEditDirection.UpDown)
				size.Height = sizeTmp.Height;
			else if (direction == LabelEditDirection.Both)
				size = sizeTmp;

			labelTextBox.Size = size;

			labelTextBox.Location = new Point(center.X - (size.Width / 2), center.Y - (size.Height / 2));

			//SetTextBoxBorder(labelTextBox);
		}
	}
}

