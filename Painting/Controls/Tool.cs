using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Painting.Controls
{
	public abstract class Tool
	{ 
		public PictureBox Picture { get; private set; }

		public Action<Tool> ClickedAction { get; private set; }

		protected Values val;

		//

		public Tool(Values val, Action<Tool> clickedAction)
		{
			this.val = val;

			Picture = new PictureBox
			{
				//BorderStyle = BorderStyle.FixedSingle,
				Width = val.ImageSize,
				Height = val.ImageSize,
				SizeMode = PictureBoxSizeMode.Zoom,
			};
			Picture.Click += Picture_Click;

			ClickedAction = clickedAction;
		}

		protected virtual void Picture_Click(object sender, EventArgs e)
		{
			Picture.BorderStyle = BorderStyle.FixedSingle;

			ClickedAction(this);
		}

		//

		public abstract void Action(Graphics g, Point end);

		public virtual void EndAction()
		{

		}

	}
}
