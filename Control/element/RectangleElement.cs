using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class RectangleElement : BaseElement, IControllable, ILabelElement
	{
		protected Color fillColor1 = Color.White;
		protected Color fillColor2 = Color.DodgerBlue;
		protected LabelElement label = new LabelElement();
		
		[NonSerialized]
		private RectangleController controller;

		public RectangleElement(): this(0, 0, 100, 100)
		{}

		public RectangleElement(Rectangle rec): this(rec.Location, rec.Size)
		{}
		
		public RectangleElement(Point l, Size s): this(l.X, l.Y, s.Width, s.Height) 
		{}

		public RectangleElement(int top, int left, int width, int height)
		{
			location  = new Point(top, left);
			size = new Size(width, height);
		}

		public override Point Location
		{
			get
			{
				return base.Location;
			}
			set
			{

                label.Location = value;
                base.Location = value;
			}
		}


		public override Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
			}
		}

		public virtual Color FillColor1
		{
			get
			{
				return fillColor1;
			}
			set
			{
				fillColor1 = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Color FillColor2 
		{
			get
			{
				return fillColor2;
			}
			set
			{
				fillColor2 = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual LabelElement Label 
		{
			get
			{
				return label;
			}
			set
			{
				label = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		protected virtual Brush GetBrush(Rectangle r)
		{
			//Fill rectangle
			Color fill1;
			Color fill2;
			Brush b;
			if (opacity == 100)
			{
				fill1 = fillColor1;
				fill2 = fillColor2;
			}
			else
			{
				fill1 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), fillColor1);
				fill2 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), fillColor2);
			}
			
			if (fillColor2 == Color.Empty)
				b = new SolidBrush(fill1);
			else
			{
				Rectangle rb = new Rectangle(r.X, r.Y, r.Width + 1, r.Height + 1);
				b = new LinearGradientBrush(
					rb,
					fill1, 
					fill2, 
					LinearGradientMode.Horizontal);
			}

			return b;
		}

		protected virtual void DrawBorder(Graphics g, Rectangle r)
		{
			//Border
			Pen p = new Pen(borderColor, borderWidth);
			g.DrawRectangle(p, r);
			p.Dispose();
		}
        Image __Backupgroup = null;
        [DefaultValue(null)]
        public Image Backupgroup
        {
            get { return __Backupgroup; }
            set
            {
                __Backupgroup = value;
                OnAppearanceChanged(new EventArgs());
            }
        }
        internal override void Draw(Graphics g)
		{
			IsInvalidated = false;

			Rectangle r = GetUnsignedRectangle();
            Brush b = GetBrush(r);			
			g.FillRectangle(b, r);
            if (Backupgroup != null)
            {
                g.DrawImage(Backupgroup, r.X, r.Y,r.Width ,r.Height);
            }
            DrawBorder(g, r);
			b.Dispose();
		}
		
		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new RectangleController(this);
			return controller;
		}
	
	}
}
