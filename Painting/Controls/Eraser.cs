using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.Controls
{
	public class Eraser : Brush
	{
		public Eraser(Values val, Action<Tool> clickedAction)
			:base(val, clickedAction)
		{
			Picture.Image = Properties.Resources.eraser;
		}

		public override void Action(Graphics g, Point end)
		{
			Color c = val.Color;

			if (val.Color.Equals(val.FirstColor))
				val.Color = val.SecondColor;
			else
				val.Color = val.FirstColor;

			base.Action(g, end);
			val.Color = c;
		}
	}
}
