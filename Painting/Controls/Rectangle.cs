using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.Controls
{
	class Rectangle : Tool
	{
		public Rectangle(Values val, Action<Tool> clickedAction)
			: base(val, clickedAction)
		{
			//Picture.Image = Properties.Resources.Rectangle;
		}

		public override void Action(Graphics g, Point end)
		{
			throw new NotImplementedException();
		}
	}
}
