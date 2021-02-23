using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Painting.Controls
{
	public class Saving
	{
		Panel panel;

		private string lastSavePath = "../Image.bmp";

		private List<Image> saveList;

		public int Position { get; private set; }

		//

		public Saving(Panel panel)
		{
			this.panel = panel;

			saveList = new List<Image>();
			Position = 0;
			
			Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
			
			saveList.Add(bitmap);
		}

		//

		public Image Back
		{
			get
			{
				if (Position == 0)
					throw new Exception("Cant go back any further");

				Position--;
				return Last;
			}
		}
		public Image Front {
			get
			{
				if (Position == saveList.Count - 1)
					throw new Exception("Cant go in front any further");

				Position++;
				return Last;
			}
		}

		public Image Last
		{
			get => saveList[Position];
		}

		public string LastSavePath { get => lastSavePath; }

		//

		public Bitmap Export()
		{
			Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
			Graphics graphics = Graphics.FromImage(bitmap);

			System.Drawing.Rectangle rectangle = panel.RectangleToScreen(panel.ClientRectangle);
			graphics.CopyFromScreen(rectangle.Location, Point.Empty, panel.Size);

			//panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
			return bitmap;
		}

		public void Save(string location)
		{
			if (File.Exists(location))
				File.Delete(location);
			Last.Save(location, ImageFormat.Bmp);
		}
		public void Save()
		{
			Save(lastSavePath);
		}

		public void Set(Image bitmap)
		{
			Graphics g = panel.CreateGraphics();

			g.Clear(Color.White);

			g.DrawImage(bitmap, new Point());
		}

		//

		public void SaveMove(Image bitmap)
		{
			Position++;
			if (Position != saveList.Count)
				for (int i = Position; i < saveList.Count; i++)
					saveList.RemoveAt(i);

			saveList.Add(bitmap);
		}
		public void SaveMove()
		{
			SaveMove(Export());
		}

	}
}
