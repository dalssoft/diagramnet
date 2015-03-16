using System;
using System.Collections;
using System.Drawing;

namespace Dalssoft.DiagramNet
{
	[Serializable]
	public class ElementCollection : ReadOnlyCollectionBase
	{
		private Point location = new Point(maxIntSize, maxIntSize);
		private Size size = new Size(0, 0);
		private bool enabledCalc = true;	
		
		private bool needCalc = true;

		public const int maxIntSize = 100;

		#region Collection Members
		
		internal ElementCollection(): base() { }

		public BaseElement this[int item]
		{
			get
			{
				return (BaseElement) InnerList[item];
			}
		}

		internal virtual int Add(BaseElement element)
		{
			needCalc = true;

			return InnerList.Add(element);
		}

		public bool Contains(BaseElement element)
		{
			return InnerList.Contains(element);
		}

		public int IndexOf(BaseElement element)
		{
			return InnerList.IndexOf(element);
		}

		internal void Insert(int index, BaseElement element)
		{
			needCalc = true;
						
			InnerList.Insert(index, element);
		}
		
		internal void Remove(BaseElement element)
		{
			InnerList.Remove(element);

			needCalc = true;

		}

		internal void Clear()
		{
			InnerList.Clear();
			needCalc = true;
		}

		internal void ChangeIndex(int i, int y)
		{
			object tmp = InnerList[y];
			InnerList[y] = InnerList[i];
			InnerList[i] = tmp;
		}

		#region Implementation of IEnumerator
		public class BaseElementEnumarator : IEnumerator 
		{

			private IEnumerator baseEnumarator;
			private IEnumerable tmp;

			BaseElementEnumarator(ElementCollection mapping): base()
			{
				tmp = (IEnumerable) mapping;
				baseEnumarator = tmp.GetEnumerator();
			}

			

			void IEnumerator.Reset()
			{
				baseEnumarator.Reset();
			}
			bool IEnumerator.MoveNext()
			{
				return baseEnumarator.MoveNext();
			}
			
			object IEnumerator.Current
			{
				get
				{
					return baseEnumarator.Current;
				}
			}

			public void Reset()
			{
				baseEnumarator.Reset();
			}
			public bool MoveNext()
			{
				return baseEnumarator.MoveNext();
			}
			
			public BaseElement Current
			{
				get
				{
					return (BaseElement) baseEnumarator.Current;
				}
			}
		}
		#endregion

		#endregion
	
		public BaseElement[] GetArray()
		{
			BaseElement[] els = new BaseElement[InnerList.Count];
			for (int i = 0; i <= InnerList.Count - 1; i++)
			{
				els[i] = (BaseElement) InnerList[i];
			}
			return els;
		}

		#region Window Methods and Properties

		internal bool EnabledCalc
		{
			get
			{
				return enabledCalc;
			}
			set
			{
				enabledCalc = value;

				if (enabledCalc)
				{
					needCalc = true;
				}
			}
		}

		internal Point WindowLocation
		{
			get
			{	
				CalcWindow();
				return location;
			}
		}

		internal Size WindowSize
		{
			get
			{
				CalcWindow();
				return size;
			}
		}

		internal void CalcWindow(bool forceCalc)
		{
			if (forceCalc)
				needCalc = forceCalc;
			CalcWindow();
		}

		internal void CalcWindow()
		{
			if (!enabledCalc) return;

			if (!needCalc) return;

			location.X = maxIntSize;
			location.Y = maxIntSize;
			size.Width = 0;
			size.Height = 0;
			foreach (BaseElement element in this)
			{
				CalcWindowLocation(element);
			}
			
			foreach (BaseElement element in this)
			{
				CalcWindowSize(element);
			}

			needCalc = false;
		}

		internal void CalcWindowLocation(BaseElement element)
		{
			if (!enabledCalc) return;

			Point elementLocation = element.Location;

			if (elementLocation.X < location.X)
				location.X = elementLocation.X;
		
			if (elementLocation.Y < location.Y)
				location.Y = elementLocation.Y;
		}

		internal void CalcWindowSize(BaseElement element)
		{
			if (!enabledCalc) return;

			int val;

			Point elementLocation = element.Location;
			Size elementSize = element.Size;

			val = (elementLocation.X + elementSize.Width) - location.X;
			if (val > size.Width)
				size.Width = val;

			val = (elementLocation.Y + elementSize.Height) - location.Y;
			if (val > size.Height)
				size.Height = val;

		}
		#endregion
	}
}
