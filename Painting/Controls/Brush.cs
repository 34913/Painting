using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace Painting.Controls
{
	public class Brush : Tool
	{
		public Brush(Values val, Action<Tool> clickedAction)
			: base(val, clickedAction)
		{
			Picture.Image = Properties.Resources.brush;
		}

		public override void Action(Graphics g, Point end)
		{
			if (val.Last.Equals(end))
			{
				g.FillEllipse(new SolidBrush(val.Color), end.X - (val.Width / 2), end.Y - (val.Width / 2), val.Width, val.Width);
			}
			else
			{
				Pen pen = new Pen(val.Color, val.Width);
				pen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				g.DrawLine(pen, val.Last, end);
			}
		}

	}
}
