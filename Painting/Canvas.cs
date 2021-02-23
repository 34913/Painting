using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Painting.Controls;

namespace Painting
{
	public partial class Canvas : Form
	{
		private PaintingControl control;

		private Values val;

		public Canvas()
		{
			InitializeComponent();

			MainMenu mainMenu = new MainMenu();

			MenuItem backItem = new MenuItem()
			{
				Text = "Back",
			};
			backItem.Click += (o, e) =>
			{
				try
				{
					val.Save.Set(val.Save.Back);
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
					return;
				}
			};

			MenuItem forwardItem = new MenuItem()
			{
				Text = "Forward",
			};
			forwardItem.Click += (o, e) =>
			{
				try
				{
					val.Save.Set(val.Save.Front);
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
					return;
				}
			};

			MenuItem saveItem = new MenuItem {
				Text = "Save",
			};
			saveItem.Click += (o, e) =>
			{
				val.Save.Save();
			};

			MenuItem clearItem = new MenuItem()
			{
				Text = "Clear",
			};
			clearItem.Click += (o, e) =>
			{
				panel1.CreateGraphics().Clear(Color.White);
				val.Save.SaveMove(new Bitmap(panel1.Width, panel1.Height));
			};

			MenuItem openLastItem = new MenuItem() {
				Text = "Open last"
			};
			openLastItem.Click += (o, e) =>
			{
				if (!File.Exists(val.Save.LastSavePath))
				{
					MessageBox.Show("Any save unavailable");
					return;
				}
				val.Save.Set(Image.FromFile(val.Save.LastSavePath));
				val.Save.SaveMove(Image.FromFile(val.Save.LastSavePath));
			};

			mainMenu.MenuItems.Add(backItem);
			mainMenu.MenuItems.Add(forwardItem);
			mainMenu.MenuItems.Add(saveItem);
			mainMenu.MenuItems.Add(clearItem);
			mainMenu.MenuItems.Add(openLastItem);

			Menu = mainMenu;

			val = new Values(new Saving(panel1))
			{
				Color = FirstColorButton.BackColor,
				FirstColor = FirstColorButton.BackColor,
				SecondColor = SecondColorButton.BackColor,
				
				ImageSize = ToolsFlowLayoutPanel.Height - 6,
				Width = (float)WidthNumericUpDown.Value
			};

			val.firstColor_PropertyChanged += Val_firstColor_PropertyChanged;
			val.secondColor_PropertyChanged += Val_secondColor_PropertyChanged;

			control = new PaintingControl(val);
			foreach (Tool t in control.toolList)
				ToolsFlowLayoutPanel.Controls.Add(t.Picture);

			this.Focus();
		}

		private void Val_firstColor_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			FirstColorButton.BackColor = val.FirstColor;
		}

		private void Val_secondColor_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			SecondColorButton.BackColor = val.SecondColor;
		}

		private void ColorButton_Click(object sender, EventArgs e)
		{
			Button b = sender as Button;

			ColorDialog cd = new ColorDialog
			{
				Color = b.BackColor,
			};

			if (cd.ShowDialog() == DialogResult.OK)
			{
				if (b.Equals(FirstColorButton))
				{
					if (val.SecondColor.Equals(cd.Color))
						val.SecondColor = b.BackColor;

					val.FirstColor = cd.Color;
				}
				else
				{
					if (val.FirstColor.Equals(cd.Color))
						val.FirstColor = b.BackColor;

					val.SecondColor = cd.Color;
				}
			}
			Focus();
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
				return;

			val.Last = e.Location;
			panel1_MouseMove(sender, e);
		}

		private void WidthNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			val.Width = (float)(sender as NumericUpDown).Value;
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
				return;
			val.Color = ((e.Button == MouseButtons.Left) ? (val.FirstColor) : (val.SecondColor));

			control.Selected.Action(panel1.CreateGraphics(), e.Location);

			val.Last = e.Location;

			
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			control.Selected.EndAction();

			val.Save.SaveMove();
		}

		private void Canvas_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Modifiers == Keys.Control)
			{
				try
				{
					if (e.KeyCode == Keys.Z)
						val.Save.Set(val.Save.Back);
					else if (e.KeyCode == Keys.Y)
						val.Save.Set(val.Save.Front);
				}
				catch(Exception exc)
				{
					MessageBox.Show(exc.Message);
					return;
				}

				if (e.KeyCode == Keys.S)
					val.Save.Save();
				else if (e.KeyCode == Keys.O)
				{
					if (!File.Exists(val.Save.LastSavePath))
					{
						MessageBox.Show("Any save unavailable");
						return;
					}
					val.Save.Set(Image.FromFile(val.Save.LastSavePath));
					val.Save.SaveMove();
				}
			}
		}
	
	}
}
