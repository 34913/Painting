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
	public class Bucket : Tool
	{
		private Bitmap bitmap;
		private Color search;
		private bool runnning = false;

		private List<Point> list;

		public Bucket(Values val, Action<Tool> clickedAction)
			: base(val, clickedAction)
		{
			Picture.Image = Properties.Resources.bucket;
			list = new List<Point>();
		}

		public override void Action(Graphics g, Point end)
		{
			if (runnning)
				return;
			runnning = true;

			bitmap = val.Save.Export();
			list.Add(new Point(end.X, end.Y));

			search = bitmap.GetPixel(end.X, end.Y);

			while (list.Count != 0)
				BFS(list[0]);

			val.Save.Set(bitmap);

			runnning = false;
		}

		private void BFS(Point p)
		{
			list.RemoveAt(0);

			if (p.X < 0 || p.Y < 0 || p.X >= bitmap.Width || p.Y >= bitmap.Height)
				return;
			if (!bitmap.GetPixel(p.X, p.Y).Equals(search))
				return;
			
			bitmap.SetPixel(p.X, p.Y, val.Color);
			
			list.Add(new Point(p.X + 1, p.Y));
			list.Add(new Point(p.X, p.Y + 1));
			list.Add(new Point(p.X - 1, p.Y));
			list.Add(new Point(p.X, p.Y - 1));
		}


		public override void EndAction()
		{

		}
	}
}
