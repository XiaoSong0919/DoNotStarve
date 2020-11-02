using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNotStarve
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Form1.SavePath == "")
            {
                MessageBox.Show("您还没有设置存档路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (Form1.ClusterName == "")
            {
                MessageBox.Show("您还没有选择要启用的存档！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (!File.Exists(Form1.ClusterPath + "cluster_token.txt"))
            {
                DialogResult = MessageBox.Show("没有检测到令牌文件！是否新建？","错误",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                if(DialogResult == DialogResult.OK)
                {
                    FileStream fs1 = new FileStream(Form1.ClusterPath + "cluster_token.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine("");//开始写入值
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                StreamReader sr = new StreamReader(Form1.ClusterPath + "cluster_token.txt", Encoding.UTF8);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    textBox1.Text = line;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Form1.ClusterPath + "cluster_token.txt", false))
            {
                file.WriteLine(textBox1.Text);
            }
            this.Close();
        }
    }
}
