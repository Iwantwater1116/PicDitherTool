using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace FloydSteinbergGUI
{
    public partial class Frm_Main : Form
    {

        //Level
        private int _gateLevel = 0;
        public int gateLevel
        {
            get => _gateLevel;
            set
            {
                _gateLevel = value;
                Nud_level.Value = _gateLevel;
                Tbr_Level.Value = _gateLevel;
            }
        }

        //Bright
        //Level
        private int _brightLevel = 0;
        public int brightLevel
        {
            get => _brightLevel;
            set
            {
                _brightLevel = value;
                Nud_Bright.Value = _brightLevel;
                Tbr_Bright.Value = _brightLevel;
            }
        }

        //type
        private int _type = 0; //0: bw, 1:color
        public int type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }

        //type
        private int _bit = 0; //0: 8, 1:10
        public int Bit
        {
            get => _bit;
            set
            {
                _bit = value;
            }
        }
        public Frm_Main()
        {
            InitializeComponent();
            Initinal();
        }

        //picture
        private Bitmap originPic;
        private void Initinal()
        {
            gateLevel = 128;
            brightLevel = 100;
        }

        private void Tbr_Level_Scroll(object sender, EventArgs e)
        {
            gateLevel = Tbr_Level.Value;
        }

        private void Nud_level_ValueChanged(object sender, EventArgs e)
        {
            gateLevel = Convert.ToInt32(Nud_level.Value);
        }

        private void Rdb_BW_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_BW.Checked)
            {
                type = 0;
            }
            else
            {
                type = 1;
            }
        }

        private void Rdb_Bit8_CheckedChanged(object sender, EventArgs e)
        {
            if(Rdb_Bit8.Checked)
            {
                Bit = 0;
            }
            else
            {
                Bit = 1;
            }
        }

        private void Tbr_Bright_Scroll(object sender, EventArgs e)
        {
            brightLevel = Tbr_Bright.Value;
        }

        private void Nud_Bright_ValueChanged(object sender, EventArgs e)
        {
            brightLevel = Convert.ToInt32(Nud_Bright.Value);
        }

        private async void Btn_Apply_Click(object sender, EventArgs e)
        {
            Bitmap result;
            if(originPic != null)
            {
                Btn_Apply.Text = "Wait...";
                Btn_Apply.Enabled = false;
                Btn_OpenImg.Enabled = false;
                Btn_SaveImg.Enabled = false;
                Bitmap inputpic = (Bitmap)originPic.Clone();
                result = await FSDitherLib.TransDither(inputpic, _type, _bit, _gateLevel, (Convert.ToDouble(_brightLevel)/100));
                if(result != null)
                {
                    MessageBox.Show("Finish!");
                    Btn_Apply.Text = "Apply";
                    Btn_Apply.Enabled = true;
                    Btn_OpenImg.Enabled = true;
                    Btn_SaveImg.Enabled = true;
                    //Pbx_Result.Size = new Size(result.Width,result.Height);
                    Pbx_Result.Image = result;

                }
            }
        }

        private void Btn_OpenImg_Click(object sender, EventArgs e)
        {
            // 使用文件對話框選擇圖像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "圖像文件|*.jpg;*.jpeg;*.png|所有文件|*.*";
            openFileDialog.Title = "選擇圖像文件";

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originPic = new Bitmap(openFileDialog.FileName);
                }
                MessageBox.Show("Finish");
                Pbx_Result.Image = originPic;
            }
            catch
            {
                MessageBox.Show("Failed");

            }
            
        }

        private void Btn_SaveImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG文件|*.png|JPEG文件|*.jpg";
            saveFileDialog.Title = "另存圖像";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 獲取要保存的文件類型
                    ImageFormat imageFormat = ImageFormat.Png; // 預設保存為PNG
                    if (saveFileDialog.FilterIndex == 2)
                    {
                        imageFormat = ImageFormat.Jpeg;
                    }

                    // 保存圖像
                    Pbx_Result.Image.Save(saveFileDialog.FileName, imageFormat);
                    MessageBox.Show("圖像已成功保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法保存圖像：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
