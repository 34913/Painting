using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Timers;

namespace Painting.Controls
{
	public class Spray : Tool
	{
		private Timer timer;
		private Random r;

		private Point p;
		Graphics g;

		public Spray(Values val, Action<Tool> clickedAction) 
			: base(val, clickedAction)
		{
			Picture.Image = Properties.Resources.spray;

			timer = new Timer();
			timer.Interval = 1; //ms
			timer.Enabled = false;

			timer.Elapsed += Timer_Elapsed;
			timer.AutoReset = true;
			
			r = new Random();
		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			ElapsedAction();
		}

		public override void Action(Graphics g, Point end)
		{
			p = end;
			if (!timer.Enabled)
			{
				timer.Start();
				this.g = g;
				ElapsedAction();
			}
		}

		public override void EndAction()
		{
			timer.Stop();
		}

		private void ElapsedAction()
		{
			if(val.Width == 1)
			{
				g.FillEllipse(new SolidBrush(val.Color), p.X - (val.Width / 2), p.Y - (val.Width / 2), val.Width, val.Width);
				return;
			}

			int half = (int)(val.Width / 2);

			Point pos;
			while (true)
			{
				pos = new Point(r.Next(0 - half, half), r.Next(0 - half, half));

				if(Math.Sqrt(Math.Pow(Math.Abs(pos.X), 2) + Math.Pow(Math.Abs(pos.Y), 2)) <= half)
					break;
			}
			pos.X += p.X;
			pos.Y += p.Y;

			float width = 5 + val.Width / 10;
			if (val.Width < width)
				width = (int)val.Width;

			g.FillEllipse(new SolidBrush(val.Color), pos.X, pos.Y, width, width);
		}

		protected override void Picture_Click(object sender, EventArgs e)
		{
			base.Picture_Click(sender, e);
			timer.Enabled = false;
		}


	}
}
