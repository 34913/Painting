using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Painting.Controls
{
	public class Values
	{
		private float width;
		
		private Color color;

		private Color firstColor;
		private Color secondColor;

		private Point last;

		private int imageSize;

		public event PropertyChangedEventHandler firstColor_PropertyChanged;
		public event PropertyChangedEventHandler secondColor_PropertyChanged;

		private Saving save;

		//

		public float Width { get => width; set => width = value; }
		public Color Color { get => color; set => color = value; }
		public Color FirstColor
		{
			get => firstColor;
			set
			{
				firstColor = value;
				FirstColor_NotifyPropertyChanged();
			}
		}
		public Color SecondColor
		{
			get => secondColor;
			set
			{
				secondColor = value;
				SecondColor_NotifyPropertyChanged();
			}
		}
		public Point Last { get => last; set => last = value; }
		public int ImageSize { get => imageSize; set => imageSize = value; }
		internal Saving Save { get => save; set => save = value; }

		//

		public Values(Saving save)
		{
			this.save = save;
		}

		//

		private void FirstColor_NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (firstColor_PropertyChanged != null)
			{
				firstColor_PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void SecondColor_NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (secondColor_PropertyChanged != null)
			{
				secondColor_PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}
