using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class ElipseNode: NodeElement, IControllable, ILabelElement
	{
		protected ElipseElement elipse;
		protected LabelElement label = new LabelElement();

		[NonSerialized]
		private ElipseController controller;

		public ElipseNode(): this(0, 0, 100, 100)
		{}

		public ElipseNode(Rectangle rec): this(rec.Location, rec.Size)
		{}

		public ElipseNode(Point l, Size s): this(l.X, l.Y, s.Width, s.Height) 
		{}

		public ElipseNode(int top, int left, int width, int height): base(top, left, width, height)
		{
			elipse = new ElipseElement(top, left, width, height);
			SyncContructors();
		}
		
		public override Color BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				elipse.BorderColor = value;
				base.BorderColor = value;
			}
		}

		public Color FillColor1
		{
			get
			{
				return elipse.FillColor1;
			}
			set
			{
				elipse.FillColor1 = value;
			}
		}

		public Color FillColor2
		{
			get
			{
				return elipse.FillColor2;
			}
			set
			{
				elipse.FillColor2 = value;
			}
		}

		public override int Opacity
		{
			get
			{
				return base.Opacity;
			}
			set
			{
				elipse.Opacity = value;
				base.Opacity = value;
			}
		}

		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				elipse.Visible = value;
				base.Visible = value;
			}
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
				elipse.Location = value;
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
				elipse.Size = value;
				base.Size = value;
			}
		}

		public override int BorderWidth
		{
			get
			{
				return base.BorderWidth;
			}
			set
			{
				elipse.BorderWidth = value;
				base.BorderWidth = value;
			}
		}
        Image __Backupgroup = null;
        [DefaultValue(null)]
        public Image Backupgroup
        {
            get { return __Backupgroup; }
            set
            {
                elipse.Backupgroup = value;
                __Backupgroup = value;

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
		
		private void SyncContructors()
		{
			base.location = elipse.Location;
			base.size = elipse.Size;
			base.borderColor = elipse.BorderColor;
			base.borderWidth = elipse.BorderWidth;
			base.opacity = elipse.Opacity;
			base.visible = elipse.Visible;
		}

		internal override void Draw(Graphics g)
		{
			IsInvalidated = false;
			elipse.Draw(g);
		}

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new ElipseController(this);
			return controller;
		}
	}
}
