using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Reflection;

namespace Dalssoft.DiagramNet
{
	[
	Serializable,
	TypeConverter(typeof(ExpandableObjectConverter))
	]
	public class LabelElement: BaseElement, ISerializable, IControllable
	{
		protected Color foreColor1 = Color.Black;
		protected Color foreColor2 = Color.Empty;

		protected Color backColor1 = Color.Empty;
		protected Color backColor2 = Color.Empty;

		[NonSerialized]
		private RectangleController controller;

		protected string text = "";

		protected bool autoSize = false;
		
		[NonSerialized]
		protected Font font = new Font(FontFamily.GenericSansSerif, 10);
		
		[NonSerialized]
		private StringFormat format = new StringFormat(StringFormatFlags.NoWrap);

		private StringAlignment alignment;
		private StringAlignment lineAlignment;
		private StringTrimming trimming;
		private bool wrap;
		private bool vertical;
		protected bool readOnly = false;

		public LabelElement(): this(0, 0, 100, 100)
		{}

		public LabelElement(Rectangle rec): this(rec.Location, rec.Size)
		{}

		public LabelElement(Point l, Size s): this(l.X, l.Y, s.Width, s.Height) 
		{}

		public LabelElement(int top, int left, int width, int height): base(top, left, width, height)
		{
			this.Alignment = StringAlignment.Center;
			this.LineAlignment = StringAlignment.Center;
			this.Trimming = StringTrimming.Character;
			this.Vertical = false;
			this.Wrap = true;
			borderColor = Color.Transparent;
		}

		#region Properties
		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				text = value;
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public Font Font
		{
			get
			{
				return font;
			}
			set
			{
				font = value;
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public StringAlignment Alignment
		{
			get
			{
				return alignment;
			}
			set
			{
				alignment = value;
				format.Alignment = alignment;
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public StringAlignment LineAlignment
		{
			get
			{
				return lineAlignment;
			}
			set
			{
				lineAlignment = value;
				format.LineAlignment = lineAlignment;
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public StringTrimming Trimming
		{
			get
			{
				return trimming;
			}
			set
			{
				trimming = value;
				format.Trimming = trimming;
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public bool Wrap
		{
			get
			{
				return wrap;
			}
			set
			{
				wrap = value;
				if (wrap)
					format.FormatFlags &= ~StringFormatFlags.NoWrap;
				else
					format.FormatFlags |= StringFormatFlags.NoWrap;
				
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}
		}

		public bool Vertical
		{
			get
			{
				return vertical;
			}
			set
			{
				vertical = value;
				if (vertical)
					format.FormatFlags |= StringFormatFlags.DirectionVertical;
				else
					format.FormatFlags &= ~StringFormatFlags.DirectionVertical;
				
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
			}

		}

		public bool ReadOnly
		{
			get
			{
				return readOnly;
			}
			set
			{
				readOnly = value;

				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Color ForeColor1
		{
			get
			{
				return foreColor1;
			}
			set
			{
				foreColor1 = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Color ForeColor2 
		{
			get
			{
				return foreColor2;
			}
			set
			{
				foreColor2 = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Color BackColor1
		{
			get
			{
				return backColor1;
			}
			set
			{
				backColor1 = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual Color BackColor2 
		{
			get
			{
				return backColor2;
			}
			set
			{
				backColor2 = value;
				OnAppearanceChanged(new EventArgs());
			}
		}

		public virtual bool AutoSize
		{
			get
			{
				return autoSize;
			}
			set
			{
				autoSize = value;
				if (autoSize) DoAutoSize();
				OnAppearanceChanged(new EventArgs());
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
				size = value;
				if (autoSize) DoAutoSize();
				base.Size = size;			
			}
		}

		internal StringFormat Format
		{
			get
			{
				return format;
			}
		}

		#endregion

		public void DoAutoSize()
		{
			if (text.Length == 0) return;

			Bitmap bmp = new Bitmap(1,1);
			Graphics g = Graphics.FromImage(bmp);
			SizeF sizeF = g.MeasureString(text, font, size.Width, format);
			Size sizeTmp = Size.Round(sizeF);

			if (size.Height < sizeTmp.Height)
				size.Height = sizeTmp.Height;
		}

		protected virtual Brush GetBrushBackColor(Rectangle r)
		{
			//Fill rectangle
			Color fill1;
			Color fill2;
			Brush b;
			if (opacity == 100)
			{
				fill1 = backColor1;
				fill2 = backColor2;
			}
			else
			{
				fill1 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), backColor1);
				fill2 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), backColor2);
			}
			
			if (backColor2 == Color.Empty)
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

		protected virtual Brush GetBrushForeColor(Rectangle r)
		{
			//Fill rectangle
			Color fill1;
			Color fill2;
			Brush b;
			if (opacity == 100)
			{
				fill1 = foreColor1;
				fill2 = foreColor2;
			}
			else
			{
				fill1 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), foreColor1);
				fill2 = Color.FromArgb((int) (255.0f * (opacity / 100.0f)), foreColor2);
			}
			
			if (foreColor2 == Color.Empty)
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

		internal override void Draw(System.Drawing.Graphics g)
		{
			Rectangle r = GetUnsignedRectangle();
			
			g.FillRectangle(GetBrushBackColor(r), r);
			Brush b = GetBrushForeColor(r);
			g.DrawString(text, font, b, (RectangleF) r, format);
			DrawBorder(g, r);
			b.Dispose();
		}

		protected virtual void DrawBorder(Graphics g, Rectangle r)
		{
			//Border
			Pen p = new Pen(borderColor, borderWidth);
			g.DrawRectangle(p, r);
			p.Dispose();
		}

		#region ISerializable Members
		protected LabelElement(SerializationInfo info, StreamingContext context)
		{

			// Get the set of serializable members for our class and base classes
			Type thisType = typeof(LabelElement);
			MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

			// Deserialize the base class's fields from the info object
			for (Int32 i = 0 ; i < mi.Length; i++) 
			{
				// Don't deserialize fields for this class
				if (mi[i].DeclaringType == thisType) continue;

				// To ease coding, treat the member as a FieldInfo object
				FieldInfo fi = (FieldInfo) mi[i];

				// Set the field to the deserialized value
				fi.SetValue(this, info.GetValue(fi.Name, fi.FieldType));
			}

			// Deserialize the values that were serialized for this class
			this.ForeColor1 = (Color) info.GetValue("foreColor1", typeof(Color));
			this.ForeColor2 = (Color) info.GetValue("foreColor2", typeof(Color));
			this.BackColor1 = (Color) info.GetValue("backColor1", typeof(Color));
			this.BackColor2 = (Color) info.GetValue("backColor2", typeof(Color));
			this.Text = info.GetString("text");
			this.Alignment = (StringAlignment) info.GetValue("alignment", typeof(StringAlignment));
			this.LineAlignment = (StringAlignment) info.GetValue("lineAlignment", typeof(StringAlignment));
			this.Trimming = (StringTrimming) info.GetValue("trimming", typeof(StringTrimming));
			this.Wrap = info.GetBoolean("wrap");
			this.Vertical = info.GetBoolean("vertical");
			this.ReadOnly = info.GetBoolean("readOnly");
			this.AutoSize = info.GetBoolean("autoSize");
			
			FontConverter fc = new FontConverter();
			this.Font = (Font) fc.ConvertFromString(info.GetString("font"));
			
		}

		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Serialize the desired values for this class
			info.AddValue("foreColor1", foreColor1);
			info.AddValue("foreColor2", foreColor2);
			info.AddValue("backColor1", backColor1);
			info.AddValue("backColor2", backColor2);
			info.AddValue("text", text);
			info.AddValue("alignment", alignment);
			info.AddValue("lineAlignment", lineAlignment);
			info.AddValue("trimming", trimming);
			info.AddValue("wrap", wrap);
			info.AddValue("vertical", vertical);
			info.AddValue("readOnly", readOnly);
			info.AddValue("autoSize", autoSize);

			FontConverter fc = new FontConverter();
			info.AddValue("font", fc.ConvertToString(font));

			// Get the set of serializable members for our class and base classes
			Type thisType = typeof(LabelElement);
			MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

			// Serialize the base class's fields to the info object
			for (int i = 0 ; i < mi.Length; i++)
			{
				// Don't serialize fields for this class
				if (mi[i].DeclaringType == thisType) continue;
				info.AddValue(mi[i].Name, ((FieldInfo) mi[i]).GetValue(this));
			}
		}
		#endregion

		IController IControllable.GetController()
		{
			if (controller == null)
				controller = new RectangleController(this);
			return controller;
		}

		internal void PositionBySite(BaseElement site)
		{
			Point newLocation = Point.Empty;

			Point siteLocation = site.Location;
			Size siteSize = site.Size;
			Size thisSize = this.Size;
			
			newLocation.X = (siteLocation.X + (siteSize.Width / 2)) - (thisSize.Width / 2);
			newLocation.Y = (siteLocation.Y + (siteSize.Height / 2)) - (thisSize.Height / 2);

			this.Location = newLocation;
		}
	}
//
//	>>>DEBUG: INHERITANCE LABEL TEST
//
//	[Serializable]
//	public class LabelElementT: LabelElement
//	{
//		
//		public LabelElementT(): this(0, 0, 100, 100)
//		{}
//
//		public LabelElementT(Rectangle rec): this(rec.Location, rec.Size)
//		{}
//
//		public LabelElementT(Point l, Size s): this(l.X, l.Y, s.Width, s.Height) 
//		{}
//
//		protected LabelElementT(SerializationInfo info, StreamingContext context): base(info, context)
//		{
//		}
//
//		public LabelElementT(int top, int left, int width, int height): base(top, left, width, height)
//		{
//			text = "David 1 2 3";
//		}
//	}
}




