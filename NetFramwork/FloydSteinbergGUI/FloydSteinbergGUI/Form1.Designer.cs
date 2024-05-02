
namespace FloydSteinbergGUI
{
    partial class Frm_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Gbx_Func = new System.Windows.Forms.GroupBox();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Btn_SaveImg = new System.Windows.Forms.Button();
            this.Btn_OpenImg = new System.Windows.Forms.Button();
            this.Gbx_View = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pbx_Result = new System.Windows.Forms.PictureBox();
            this.Gbx_Type = new System.Windows.Forms.GroupBox();
            this.Rdb_Color = new System.Windows.Forms.RadioButton();
            this.Rdb_BW = new System.Windows.Forms.RadioButton();
            this.Gbx_bit = new System.Windows.Forms.GroupBox();
            this.Rdb_10bit = new System.Windows.Forms.RadioButton();
            this.Rdb_Bit8 = new System.Windows.Forms.RadioButton();
            this.Gbx_Level = new System.Windows.Forms.GroupBox();
            this.Nud_level = new System.Windows.Forms.NumericUpDown();
            this.Tbr_Level = new System.Windows.Forms.TrackBar();
            this.Gbx_Brghtness = new System.Windows.Forms.GroupBox();
            this.Nud_Bright = new System.Windows.Forms.NumericUpDown();
            this.Tbr_Bright = new System.Windows.Forms.TrackBar();
            this.Gbx_Func.SuspendLayout();
            this.Gbx_View.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Result)).BeginInit();
            this.Gbx_Type.SuspendLayout();
            this.Gbx_bit.SuspendLayout();
            this.Gbx_Level.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbr_Level)).BeginInit();
            this.Gbx_Brghtness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Bright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbr_Bright)).BeginInit();
            this.SuspendLayout();
            // 
            // Gbx_Func
            // 
            this.Gbx_Func.Controls.Add(this.Btn_Apply);
            this.Gbx_Func.Controls.Add(this.Btn_SaveImg);
            this.Gbx_Func.Controls.Add(this.Btn_OpenImg);
            this.Gbx_Func.Location = new System.Drawing.Point(7, 6);
            this.Gbx_Func.Name = "Gbx_Func";
            this.Gbx_Func.Size = new System.Drawing.Size(120, 148);
            this.Gbx_Func.TabIndex = 0;
            this.Gbx_Func.TabStop = false;
            this.Gbx_Func.Text = "Function";
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Location = new System.Drawing.Point(6, 77);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(95, 22);
            this.Btn_Apply.TabIndex = 0;
            this.Btn_Apply.Text = "Apply";
            this.Btn_Apply.UseVisualStyleBackColor = true;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Btn_SaveImg
            // 
            this.Btn_SaveImg.Location = new System.Drawing.Point(6, 49);
            this.Btn_SaveImg.Name = "Btn_SaveImg";
            this.Btn_SaveImg.Size = new System.Drawing.Size(95, 22);
            this.Btn_SaveImg.TabIndex = 0;
            this.Btn_SaveImg.Text = "Save Image";
            this.Btn_SaveImg.UseVisualStyleBackColor = true;
            this.Btn_SaveImg.Click += new System.EventHandler(this.Btn_SaveImg_Click);
            // 
            // Btn_OpenImg
            // 
            this.Btn_OpenImg.Location = new System.Drawing.Point(6, 21);
            this.Btn_OpenImg.Name = "Btn_OpenImg";
            this.Btn_OpenImg.Size = new System.Drawing.Size(95, 22);
            this.Btn_OpenImg.TabIndex = 0;
            this.Btn_OpenImg.Text = "Open Image";
            this.Btn_OpenImg.UseVisualStyleBackColor = true;
            this.Btn_OpenImg.Click += new System.EventHandler(this.Btn_OpenImg_Click);
            // 
            // Gbx_View
            // 
            this.Gbx_View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gbx_View.AutoSize = true;
            this.Gbx_View.Controls.Add(this.panel1);
            this.Gbx_View.Location = new System.Drawing.Point(2, 160);
            this.Gbx_View.Name = "Gbx_View";
            this.Gbx_View.Size = new System.Drawing.Size(782, 407);
            this.Gbx_View.TabIndex = 1;
            this.Gbx_View.TabStop = false;
            this.Gbx_View.Text = "Preview";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.Pbx_Result);
            this.panel1.Location = new System.Drawing.Point(8, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 368);
            this.panel1.TabIndex = 1;
            // 
            // Pbx_Result
            // 
            this.Pbx_Result.Location = new System.Drawing.Point(0, 0);
            this.Pbx_Result.Name = "Pbx_Result";
            this.Pbx_Result.Size = new System.Drawing.Size(1024, 460);
            this.Pbx_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pbx_Result.TabIndex = 0;
            this.Pbx_Result.TabStop = false;
            // 
            // Gbx_Type
            // 
            this.Gbx_Type.Controls.Add(this.Rdb_Color);
            this.Gbx_Type.Controls.Add(this.Rdb_BW);
            this.Gbx_Type.Location = new System.Drawing.Point(133, 6);
            this.Gbx_Type.Name = "Gbx_Type";
            this.Gbx_Type.Size = new System.Drawing.Size(99, 148);
            this.Gbx_Type.TabIndex = 2;
            this.Gbx_Type.TabStop = false;
            this.Gbx_Type.Text = "Type";
            // 
            // Rdb_Color
            // 
            this.Rdb_Color.AutoSize = true;
            this.Rdb_Color.Location = new System.Drawing.Point(6, 77);
            this.Rdb_Color.Name = "Rdb_Color";
            this.Rdb_Color.Size = new System.Drawing.Size(63, 16);
            this.Rdb_Color.TabIndex = 0;
            this.Rdb_Color.TabStop = true;
            this.Rdb_Color.Text = "Colorful";
            this.Rdb_Color.UseVisualStyleBackColor = true;
            // 
            // Rdb_BW
            // 
            this.Rdb_BW.AutoSize = true;
            this.Rdb_BW.Checked = true;
            this.Rdb_BW.Location = new System.Drawing.Point(6, 39);
            this.Rdb_BW.Name = "Rdb_BW";
            this.Rdb_BW.Size = new System.Drawing.Size(55, 16);
            this.Rdb_BW.TabIndex = 0;
            this.Rdb_BW.TabStop = true;
            this.Rdb_BW.Text = "Binary";
            this.Rdb_BW.UseVisualStyleBackColor = true;
            this.Rdb_BW.CheckedChanged += new System.EventHandler(this.Rdb_BW_CheckedChanged);
            // 
            // Gbx_bit
            // 
            this.Gbx_bit.Controls.Add(this.Rdb_10bit);
            this.Gbx_bit.Controls.Add(this.Rdb_Bit8);
            this.Gbx_bit.Location = new System.Drawing.Point(238, 6);
            this.Gbx_bit.Name = "Gbx_bit";
            this.Gbx_bit.Size = new System.Drawing.Size(99, 148);
            this.Gbx_bit.TabIndex = 2;
            this.Gbx_bit.TabStop = false;
            this.Gbx_bit.Text = "Bit";
            // 
            // Rdb_10bit
            // 
            this.Rdb_10bit.AutoSize = true;
            this.Rdb_10bit.Location = new System.Drawing.Point(8, 77);
            this.Rdb_10bit.Name = "Rdb_10bit";
            this.Rdb_10bit.Size = new System.Drawing.Size(35, 16);
            this.Rdb_10bit.TabIndex = 0;
            this.Rdb_10bit.TabStop = true;
            this.Rdb_10bit.Text = "10";
            this.Rdb_10bit.UseVisualStyleBackColor = true;
            // 
            // Rdb_Bit8
            // 
            this.Rdb_Bit8.AutoSize = true;
            this.Rdb_Bit8.Checked = true;
            this.Rdb_Bit8.Location = new System.Drawing.Point(8, 39);
            this.Rdb_Bit8.Name = "Rdb_Bit8";
            this.Rdb_Bit8.Size = new System.Drawing.Size(29, 16);
            this.Rdb_Bit8.TabIndex = 0;
            this.Rdb_Bit8.TabStop = true;
            this.Rdb_Bit8.Text = "8";
            this.Rdb_Bit8.UseVisualStyleBackColor = true;
            this.Rdb_Bit8.CheckedChanged += new System.EventHandler(this.Rdb_Bit8_CheckedChanged);
            // 
            // Gbx_Level
            // 
            this.Gbx_Level.Controls.Add(this.Nud_level);
            this.Gbx_Level.Controls.Add(this.Tbr_Level);
            this.Gbx_Level.Location = new System.Drawing.Point(343, 6);
            this.Gbx_Level.Name = "Gbx_Level";
            this.Gbx_Level.Size = new System.Drawing.Size(446, 71);
            this.Gbx_Level.TabIndex = 2;
            this.Gbx_Level.TabStop = false;
            this.Gbx_Level.Text = "Gate Level";
            // 
            // Nud_level
            // 
            this.Nud_level.Location = new System.Drawing.Point(381, 25);
            this.Nud_level.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Nud_level.Name = "Nud_level";
            this.Nud_level.Size = new System.Drawing.Size(60, 22);
            this.Nud_level.TabIndex = 0;
            this.Nud_level.ValueChanged += new System.EventHandler(this.Nud_level_ValueChanged);
            // 
            // Tbr_Level
            // 
            this.Tbr_Level.Location = new System.Drawing.Point(6, 17);
            this.Tbr_Level.Maximum = 256;
            this.Tbr_Level.Minimum = 2;
            this.Tbr_Level.Name = "Tbr_Level";
            this.Tbr_Level.Size = new System.Drawing.Size(369, 45);
            this.Tbr_Level.TabIndex = 0;
            this.Tbr_Level.Value = 2;
            this.Tbr_Level.Scroll += new System.EventHandler(this.Tbr_Level_Scroll);
            // 
            // Gbx_Brghtness
            // 
            this.Gbx_Brghtness.Controls.Add(this.Nud_Bright);
            this.Gbx_Brghtness.Controls.Add(this.Tbr_Bright);
            this.Gbx_Brghtness.Location = new System.Drawing.Point(343, 83);
            this.Gbx_Brghtness.Name = "Gbx_Brghtness";
            this.Gbx_Brghtness.Size = new System.Drawing.Size(446, 71);
            this.Gbx_Brghtness.TabIndex = 2;
            this.Gbx_Brghtness.TabStop = false;
            this.Gbx_Brghtness.Text = "Brightness";
            // 
            // Nud_Bright
            // 
            this.Nud_Bright.Location = new System.Drawing.Point(381, 25);
            this.Nud_Bright.Name = "Nud_Bright";
            this.Nud_Bright.Size = new System.Drawing.Size(60, 22);
            this.Nud_Bright.TabIndex = 0;
            this.Nud_Bright.ValueChanged += new System.EventHandler(this.Nud_Bright_ValueChanged);
            // 
            // Tbr_Bright
            // 
            this.Tbr_Bright.Location = new System.Drawing.Point(6, 17);
            this.Tbr_Bright.Maximum = 100;
            this.Tbr_Bright.Name = "Tbr_Bright";
            this.Tbr_Bright.Size = new System.Drawing.Size(369, 45);
            this.Tbr_Bright.TabIndex = 0;
            this.Tbr_Bright.Scroll += new System.EventHandler(this.Tbr_Bright_Scroll);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 569);
            this.Controls.Add(this.Gbx_Brghtness);
            this.Controls.Add(this.Gbx_Level);
            this.Controls.Add(this.Gbx_bit);
            this.Controls.Add(this.Gbx_Type);
            this.Controls.Add(this.Gbx_View);
            this.Controls.Add(this.Gbx_Func);
            this.Name = "Frm_Main";
            this.Text = "FloydSteinbergGUI";
            this.Gbx_Func.ResumeLayout(false);
            this.Gbx_View.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Result)).EndInit();
            this.Gbx_Type.ResumeLayout(false);
            this.Gbx_Type.PerformLayout();
            this.Gbx_bit.ResumeLayout(false);
            this.Gbx_bit.PerformLayout();
            this.Gbx_Level.ResumeLayout(false);
            this.Gbx_Level.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbr_Level)).EndInit();
            this.Gbx_Brghtness.ResumeLayout(false);
            this.Gbx_Brghtness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Bright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbr_Bright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Gbx_Func;
        private System.Windows.Forms.GroupBox Gbx_View;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Button Btn_SaveImg;
        private System.Windows.Forms.Button Btn_OpenImg;
        private System.Windows.Forms.GroupBox Gbx_Type;
        private System.Windows.Forms.RadioButton Rdb_Color;
        private System.Windows.Forms.RadioButton Rdb_BW;
        private System.Windows.Forms.GroupBox Gbx_bit;
        private System.Windows.Forms.RadioButton Rdb_10bit;
        private System.Windows.Forms.RadioButton Rdb_Bit8;
        private System.Windows.Forms.GroupBox Gbx_Level;
        private System.Windows.Forms.TrackBar Tbr_Level;
        private System.Windows.Forms.NumericUpDown Nud_level;
        private System.Windows.Forms.GroupBox Gbx_Brghtness;
        private System.Windows.Forms.NumericUpDown Nud_Bright;
        private System.Windows.Forms.TrackBar Tbr_Bright;
        private System.Windows.Forms.PictureBox Pbx_Result;
        private System.Windows.Forms.Panel panel1;
    }
}

