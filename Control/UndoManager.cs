using Diagram.NET.binaryformatter;
using System;
using System.Collections;
using System.IO;

namespace Dalssoft.DiagramNet
{
	internal class UndoManager
	{
		protected MemoryStream[] list;
		protected int currPos = -1;
		protected int lastPos = -1;
		protected bool canUndo = false;
		protected bool canRedo = false;
		protected int capacity;
		protected bool enabled = true;


		public UndoManager(int capacity)
		{
			list = new MemoryStream[capacity];
			this.capacity = capacity;
		}

		public bool CanUndo
		{
			get
			{
				return (currPos != -1);
			}
		}

		public bool CanRedo
		{
			get
			{
				return (currPos != lastPos);
			}
		}

		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				enabled = value;
			}
		}

		public void AddUndo(object o)
		{
			if (!enabled) return;

			currPos++;
			if (currPos >= capacity)
				currPos--;

			ClearList(currPos);

			PushList();

			list[currPos] = SerializeObject(o);
			lastPos = currPos;
		}

		public object Undo()
		{
			if (!CanUndo)
				throw new ApplicationException("Can't Undo.");

			object ret = DeserializeObject(list[currPos]);
			
			currPos--;
		
			return ret;
		}

		public object Redo()
		{
			if (!CanRedo)
				throw new ApplicationException("Can't Undo.");

			currPos++;

			return DeserializeObject(list[currPos]);
		}

		private MemoryStream SerializeObject(object o)
		{
			IFormatter formatter = new BinaryFormatter();
			MemoryStream mem = new MemoryStream();
			formatter.Serialize(mem, o);
			mem.Position = 0;
			return mem;
		}

		private object DeserializeObject(MemoryStream mem)
		{
			mem.Position = 0;
			IFormatter formatter = new BinaryFormatter();
			return (object) formatter.Deserialize(mem);
		}

		private void ClearList()
		{
			ClearList(0);
		}

		private void ClearList(int p)
		{
			if (currPos >= capacity - 1)
				return;

			for(int i = p; i < capacity; i++)
			{
				if (list[i] != null) list[i].Close();
				list[i] = null;
			}
		}

		private void PushList()
		{
			if ((currPos >= capacity - 1) && (list[currPos] != null))
			{
				list[0].Close();
				for (int i = 1; i <= currPos; i++)
				{
					list[i - 1] = list[i];
				}
			}		
		}
	}
}
