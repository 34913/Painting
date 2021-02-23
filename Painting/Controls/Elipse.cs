using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.Controls
{
	class Elipse : Tool
	{
		public Elipse(Values val, Action<Tool> clickedAction) : 
			base(val, clickedAction)
		{
			//Picture.Image = Properties.Resources.Elipse;
		}

		public override void Action(Graphics g, Point end)
		{
			throw new NotImplementedException();
			
		}
	}
}
