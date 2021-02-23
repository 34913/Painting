
namespace Painting
{
	partial class Canvas
	{
		/// <summary>
		/// Vyžaduje se proměnná návrháře.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Uvolněte všechny používané prostředky.
		/// </summary>
		/// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kód generovaný Návrhářem Windows Form

		/// <summary>
		/// Metoda vyžadovaná pro podporu Návrháře - neupravovat
		/// obsah této metody v editoru kódu.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.WidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.FirstColorButton = new System.Windows.Forms.Button();
			this.ToolsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SecondColorButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(12, 78);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(836, 491);
			this.panel1.TabIndex = 0;
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
			this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
			// 
			// WidthNumericUpDown
			// 
			this.WidthNumericUpDown.Location = new System.Drawing.Point(12, 42);
			this.WidthNumericUpDown.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
			this.WidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WidthNumericUpDown.Name = "WidthNumericUpDown";
			this.WidthNumericUpDown.Size = new System.Drawing.Size(75, 20);
			this.WidthNumericUpDown.TabIndex = 1;
			this.WidthNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.WidthNumericUpDown.ValueChanged += new System.EventHandler(this.WidthNumericUpDown_ValueChanged);
			// 
			// FirstColorButton
			// 
			this.FirstColorButton.BackColor = System.Drawing.Color.Black;
			this.FirstColorButton.Location = new System.Drawing.Point(12, 12);
			this.FirstColorButton.Name = "FirstColorButton";
			this.FirstColorButton.Size = new System.Drawing.Size(29, 23);
			this.FirstColorButton.TabIndex = 2;
			this.FirstColorButton.UseVisualStyleBackColor = false;
			this.FirstColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// ToolsFlowLayoutPanel
			// 
			this.ToolsFlowLayoutPanel.Location = new System.Drawing.Point(118, 12);
			this.ToolsFlowLayoutPanel.Name = "ToolsFlowLayoutPanel";
			this.ToolsFlowLayoutPanel.Size = new System.Drawing.Size(730, 51);
			this.ToolsFlowLayoutPanel.TabIndex = 3;
			// 
			// SecondColorButton
			// 
			this.SecondColorButton.BackColor = System.Drawing.Color.White;
			this.SecondColorButton.Location = new System.Drawing.Point(58, 13);
			this.SecondColorButton.Name = "SecondColorButton";
			this.SecondColorButton.Size = new System.Drawing.Size(29, 23);
			this.SecondColorButton.TabIndex = 4;
			this.SecondColorButton.UseVisualStyleBackColor = false;
			this.SecondColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// Canvas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(860, 602);
			this.Controls.Add(this.SecondColorButton);
			this.Controls.Add(this.ToolsFlowLayoutPanel);
			this.Controls.Add(this.FirstColorButton);
			this.Controls.Add(this.WidthNumericUpDown);
			this.Controls.Add(this.panel1);
			this.MaximumSize = new System.Drawing.Size(876, 641);
			this.Name = "Canvas";
			this.Text = "Form1";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Canvas_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NumericUpDown WidthNumericUpDown;
		private System.Windows.Forms.Button FirstColorButton;
		private System.Windows.Forms.FlowLayoutPanel ToolsFlowLayoutPanel;
		private System.Windows.Forms.Button SecondColorButton;
	}
}

