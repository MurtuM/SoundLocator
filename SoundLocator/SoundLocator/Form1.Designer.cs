namespace SoundLocator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.settings_box = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scroll_opacity = new System.Windows.Forms.HScrollBar();
            this.button_lock = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.button_center = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button_kill = new System.Windows.Forms.Button();
            this.num_cell_spacing = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_cell_align = new System.Windows.Forms.ComboBox();
            this.scroll_curvature = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_cell_count = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.num_cell_y = new System.Windows.Forms.NumericUpDown();
            this.num_cell_x = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.scroll_decay = new System.Windows.Forms.HScrollBar();
            this.label_max = new System.Windows.Forms.Label();
            this.label_min = new System.Windows.Forms.Label();
            this.scroll_max = new System.Windows.Forms.HScrollBar();
            this.pbar_peak_r = new System.Windows.Forms.ProgressBar();
            this.pbar_peak_l = new System.Windows.Forms.ProgressBar();
            this.scroll_min = new System.Windows.Forms.HScrollBar();
            this.combo_sessions = new System.Windows.Forms.ComboBox();
            this.panel_cells = new System.Windows.Forms.FlowLayoutPanel();
            this.settings_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_spacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_x)).BeginInit();
            this.SuspendLayout();
            // 
            // settings_box
            // 
            this.settings_box.BackColor = System.Drawing.Color.Silver;
            this.settings_box.Controls.Add(this.label7);
            this.settings_box.Controls.Add(this.scroll_opacity);
            this.settings_box.Controls.Add(this.button_lock);
            this.settings_box.Controls.Add(this.splitter1);
            this.settings_box.Controls.Add(this.button_center);
            this.settings_box.Controls.Add(this.label6);
            this.settings_box.Controls.Add(this.button_kill);
            this.settings_box.Controls.Add(this.num_cell_spacing);
            this.settings_box.Controls.Add(this.label5);
            this.settings_box.Controls.Add(this.combo_cell_align);
            this.settings_box.Controls.Add(this.scroll_curvature);
            this.settings_box.Controls.Add(this.label4);
            this.settings_box.Controls.Add(this.label2);
            this.settings_box.Controls.Add(this.num_cell_count);
            this.settings_box.Controls.Add(this.label3);
            this.settings_box.Controls.Add(this.num_cell_y);
            this.settings_box.Controls.Add(this.num_cell_x);
            this.settings_box.Controls.Add(this.label1);
            this.settings_box.Controls.Add(this.scroll_decay);
            this.settings_box.Controls.Add(this.label_max);
            this.settings_box.Controls.Add(this.label_min);
            this.settings_box.Controls.Add(this.scroll_max);
            this.settings_box.Controls.Add(this.pbar_peak_r);
            this.settings_box.Controls.Add(this.pbar_peak_l);
            this.settings_box.Controls.Add(this.scroll_min);
            this.settings_box.Controls.Add(this.combo_sessions);
            this.settings_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_box.Location = new System.Drawing.Point(-1, 61);
            this.settings_box.Margin = new System.Windows.Forms.Padding(0);
            this.settings_box.Name = "settings_box";
            this.settings_box.Padding = new System.Windows.Forms.Padding(0);
            this.settings_box.Size = new System.Drawing.Size(375, 295);
            this.settings_box.TabIndex = 0;
            this.settings_box.TabStop = false;
            this.settings_box.Text = "SoundLocator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 261);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(53, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "Opacity";
            // 
            // scroll_opacity
            // 
            this.scroll_opacity.Location = new System.Drawing.Point(6, 275);
            this.scroll_opacity.Maximum = 109;
            this.scroll_opacity.Minimum = 20;
            this.scroll_opacity.Name = "scroll_opacity";
            this.scroll_opacity.Size = new System.Drawing.Size(179, 17);
            this.scroll_opacity.TabIndex = 25;
            this.scroll_opacity.Value = 20;
            // 
            // button_lock
            // 
            this.button_lock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_lock.Location = new System.Drawing.Point(261, 267);
            this.button_lock.Name = "button_lock";
            this.button_lock.Size = new System.Drawing.Size(56, 25);
            this.button_lock.TabIndex = 24;
            this.button_lock.Text = "Lock";
            this.button_lock.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 13);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 282);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // button_center
            // 
            this.button_center.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_center.Location = new System.Drawing.Point(194, 267);
            this.button_center.Name = "button_center";
            this.button_center.Size = new System.Drawing.Size(61, 25);
            this.button_center.TabIndex = 4;
            this.button_center.Text = "Center";
            this.button_center.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 226);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(53, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "Spacing";
            // 
            // button_kill
            // 
            this.button_kill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_kill.Location = new System.Drawing.Point(323, 267);
            this.button_kill.Name = "button_kill";
            this.button_kill.Size = new System.Drawing.Size(49, 25);
            this.button_kill.TabIndex = 3;
            this.button_kill.Text = "Exit";
            this.button_kill.UseVisualStyleBackColor = true;
            // 
            // num_cell_spacing
            // 
            this.num_cell_spacing.Location = new System.Drawing.Point(10, 224);
            this.num_cell_spacing.Name = "num_cell_spacing";
            this.num_cell_spacing.Size = new System.Drawing.Size(51, 20);
            this.num_cell_spacing.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 201);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Align";
            // 
            // combo_cell_align
            // 
            this.combo_cell_align.FormattingEnabled = true;
            this.combo_cell_align.Location = new System.Drawing.Point(192, 197);
            this.combo_cell_align.Name = "combo_cell_align";
            this.combo_cell_align.Size = new System.Drawing.Size(138, 22);
            this.combo_cell_align.TabIndex = 19;
            // 
            // scroll_curvature
            // 
            this.scroll_curvature.LargeChange = 1;
            this.scroll_curvature.Location = new System.Drawing.Point(192, 173);
            this.scroll_curvature.Maximum = 9;
            this.scroll_curvature.Name = "scroll_curvature";
            this.scroll_curvature.Size = new System.Drawing.Size(138, 17);
            this.scroll_curvature.TabIndex = 18;
            this.scroll_curvature.Value = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 176);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Curve";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 173);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "# Cells";
            // 
            // num_cell_count
            // 
            this.num_cell_count.Location = new System.Drawing.Point(10, 171);
            this.num_cell_count.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_cell_count.Name = "num_cell_count";
            this.num_cell_count.Size = new System.Drawing.Size(111, 20);
            this.num_cell_count.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 201);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cell size";
            // 
            // num_cell_y
            // 
            this.num_cell_y.Location = new System.Drawing.Point(67, 199);
            this.num_cell_y.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.num_cell_y.Name = "num_cell_y";
            this.num_cell_y.Size = new System.Drawing.Size(54, 20);
            this.num_cell_y.TabIndex = 12;
            // 
            // num_cell_x
            // 
            this.num_cell_x.Location = new System.Drawing.Point(10, 199);
            this.num_cell_x.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.num_cell_x.Name = "num_cell_x";
            this.num_cell_x.Size = new System.Drawing.Size(51, 20);
            this.num_cell_x.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 146);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Decay";
            // 
            // scroll_decay
            // 
            this.scroll_decay.Location = new System.Drawing.Point(10, 143);
            this.scroll_decay.Maximum = 109;
            this.scroll_decay.Name = "scroll_decay";
            this.scroll_decay.Size = new System.Drawing.Size(320, 17);
            this.scroll_decay.TabIndex = 7;
            // 
            // label_max
            // 
            this.label_max.AutoSize = true;
            this.label_max.Location = new System.Drawing.Point(331, 120);
            this.label_max.Name = "label_max";
            this.label_max.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_max.Size = new System.Drawing.Size(31, 14);
            this.label_max.TabIndex = 6;
            this.label_max.Text = "Max";
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Location = new System.Drawing.Point(331, 96);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(29, 14);
            this.label_min.TabIndex = 5;
            this.label_min.Text = "Min";
            // 
            // scroll_max
            // 
            this.scroll_max.Location = new System.Drawing.Point(10, 119);
            this.scroll_max.Maximum = 109;
            this.scroll_max.Name = "scroll_max";
            this.scroll_max.Size = new System.Drawing.Size(320, 17);
            this.scroll_max.TabIndex = 4;
            // 
            // pbar_peak_r
            // 
            this.pbar_peak_r.Location = new System.Drawing.Point(10, 70);
            this.pbar_peak_r.Name = "pbar_peak_r";
            this.pbar_peak_r.Size = new System.Drawing.Size(317, 11);
            this.pbar_peak_r.TabIndex = 3;
            // 
            // pbar_peak_l
            // 
            this.pbar_peak_l.Location = new System.Drawing.Point(10, 52);
            this.pbar_peak_l.Name = "pbar_peak_l";
            this.pbar_peak_l.Size = new System.Drawing.Size(317, 11);
            this.pbar_peak_l.TabIndex = 2;
            // 
            // scroll_min
            // 
            this.scroll_min.Location = new System.Drawing.Point(10, 95);
            this.scroll_min.Maximum = 109;
            this.scroll_min.Name = "scroll_min";
            this.scroll_min.Size = new System.Drawing.Size(320, 17);
            this.scroll_min.TabIndex = 1;
            // 
            // combo_sessions
            // 
            this.combo_sessions.FormattingEnabled = true;
            this.combo_sessions.Location = new System.Drawing.Point(8, 21);
            this.combo_sessions.Name = "combo_sessions";
            this.combo_sessions.Size = new System.Drawing.Size(319, 22);
            this.combo_sessions.TabIndex = 0;
            // 
            // panel_cells
            // 
            this.panel_cells.AutoSize = true;
            this.panel_cells.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_cells.Location = new System.Drawing.Point(0, 0);
            this.panel_cells.Margin = new System.Windows.Forms.Padding(1);
            this.panel_cells.Name = "panel_cells";
            this.panel_cells.Size = new System.Drawing.Size(0, 0);
            this.panel_cells.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(385, 371);
            this.Controls.Add(this.panel_cells);
            this.Controls.Add(this.settings_box);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Text = "SoundLocator";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.settings_box.ResumeLayout(false);
            this.settings_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_spacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cell_x)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox settings_box;
        private System.Windows.Forms.HScrollBar scroll_min;
        private System.Windows.Forms.ComboBox combo_sessions;
        private System.Windows.Forms.ProgressBar pbar_peak_r;
        private System.Windows.Forms.ProgressBar pbar_peak_l;
        private System.Windows.Forms.FlowLayoutPanel panel_cells;
        private System.Windows.Forms.Button button_kill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar scroll_decay;
        private System.Windows.Forms.Label label_max;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.HScrollBar scroll_max;
        private System.Windows.Forms.NumericUpDown num_cell_y;
        private System.Windows.Forms.NumericUpDown num_cell_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_cell_count;
        private System.Windows.Forms.Button button_center;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.HScrollBar scroll_curvature;
        private System.Windows.Forms.ComboBox combo_cell_align;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_cell_spacing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button_lock;
        private System.Windows.Forms.HScrollBar scroll_opacity;
        private System.Windows.Forms.Label label7;
    }
}

