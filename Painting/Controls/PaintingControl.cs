using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painting.Controls
{
	class PaintingControl
	{
		private Values val;

		private Tool selected;

		//

		public Tool Selected
		{
			get => selected;
			set
			{
				if (!toolList.Contains(value))
					throw new Exception("Dont exist in list");
				Selected = value;
			}
		}

		public List<Tool> toolList { get; private set; }

		//

		public PaintingControl(Values val)
		{
			this.val = val;

			toolList = new List<Tool>();

			toolList.Add(new Brush(val, selectedChanged));
			toolList.Add(new Bucket(val, selectedChanged));
			toolList.Add(new Eraser(val, selectedChanged));
			toolList.Add(new Spray(val, selectedChanged));

			selected = toolList[0];
			selected.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

		}

		//

		private void selectedChanged(Tool obj)
		{
			if(obj != selected)
				selected.Picture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			selected = obj;
			//foreach(Tool t in toolList)
			//{
			//	if (t == selected)
			//		continue;
			//	t.Picture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			//}
		}


	}
}
