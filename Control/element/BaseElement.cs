using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Xml;

namespace Dalssoft.DiagramNet
{
	/// <summary>
	/// This is the base for all element the will be draw on the
	/// document.
	/// </summary>
	[Serializable]
	public abstract class BaseElement
	{
		protected Point location;
		protected Size size;
		protected bool visible = true;
		protected Color borderColor = Color.Black;
		protected int borderWidth = 1;
		protected int opacity = 100;
		internal protected Rectangle invalidateRec = Rectangle.Empty;
		internal protected bool IsInvalidated = true;

		protected BaseElement()
		{
		}

		protected BaseElement(int top, int left, int width, int height)
		{
			location  = new Point(top, left);
			size = new Size(width, height);
		}
        public string  Name { get; set; }
        public virtual Point Location
		{
			get
			{
				return location;
			}
			set
			{
				location = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Size Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual bool Visible
		{
			get
			{
				return visible;
			}
			set
			{
				visible = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Color BorderColor
		{
			get
			{
				return borderColor;
			}
			set
			{
				borderColor = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual int BorderWidth
		{
			get
			{
				return borderWidth;
			}
			set
			{
				borderWidth = value;
				OnAppearanceChanged(new EventArgs());
			}
		}
		
		public virtual int Opacity 
		{
			get
			{
				return opacity;
			}
			set
			{
				if ((value >= 0) || (value <=100))
					opacity = value;
				else
					throw new Exception("'" + value + "' is not a valid value for 'Opacity'. 'Opacity' should be between 0 and 100.");

				OnAppearanceChanged(new EventArgs());
			}
		}
		internal virtual void Draw(Graphics g)
		{
			IsInvalidated = false;
		}


		public virtual void Invalidate()
		{
			if (IsInvalidated)
				invalidateRec = Rectangle.Union(invalidateRec, GetUnsignedRectangle());
			else
				invalidateRec = GetUnsignedRectangle();

			IsInvalidated = true;
		}

		public virtual Rectangle GetRectangle()
		{
			return new Rectangle(this.Location, this.Size);
		}

		public virtual Rectangle GetUnsignedRectangle()
		{
			
			return GetUnsignedRectangle(GetRectangle());
		}

		internal static Rectangle GetUnsignedRectangle(Rectangle rec)
		{
			Rectangle retRectangle = rec;
			if (rec.Width < 0)
			{
				retRectangle.X = rec.X + rec.Width;
				retRectangle.Width = - rec.Width;
			}
			
			if (rec.Height < 0)
			{
				retRectangle.Y = rec.Y + rec.Height;
				retRectangle.Height = - rec.Height;
			}

			return retRectangle;
		}

		#region Events
		[field: NonSerialized]
		public event EventHandler AppearanceChanged;

		protected virtual void OnAppearanceChanged(EventArgs e)
		{
			if (AppearanceChanged != null)
				AppearanceChanged(this, e);
		}
		#endregion

	}
}
