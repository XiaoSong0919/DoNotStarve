using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoNotStarve
{
    public partial class Form6 : Form
    {
        //string
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (Form1.SavePath == "")
            {
                MessageBox.Show("您还没有设置存档路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //else if (Form1.ClusterName == "")
            //{
            //    MessageBox.Show("您还没有选择要启用的存档！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (!Directory.Exists(Form1.SavePath + textBox1.Text))
                {
                    Directory.CreateDirectory(Form1.SavePath + textBox1.Text);
                    Directory.CreateDirectory(Form1.SavePath + textBox1.Text + "/Master");
                    Form1.ClusterName = textBox1.Text;
                    Form1.ClusterPath = Form1.SavePath + Form1.ClusterName + "/";
                    Form1.newtxt("Master/leveldataoverride.lua", Form1.levelcode_Master);
                    Form1.newtxt("Master/modoverrides.lua", "return {  }");
                    Form1.newtxt("cluster.ini", "[GAMEPLAY] game_mode = endless \n max_players = 6 \n pvp = false \n pause_when_empty = true  \n [NETWORK] lan_only_cluster = false \n cluster_intention = cooperative \n cluster_password = \n cluster_description = \n cluster_name =  \n offline_cluster = false \n cluster_language = zh  \n [MISC] console_enabled = true \n  [SHARD] shard_enabled = true \n bind_ip = 127.0.0.1 \n master_ip = 127.0.0.1 \n master_port = 10888 \n cluster_key = defaultPass");
                    Form1.newtxt("cluster_token.txt", "");
                    Form1.newtxt("Master/Server.ini", "[NETWORK] \r\n server_port = 10999 \r\n [SHARD] \r\n is_master = true \r\n [ACCOUNT] \r\n encode_user_path = true");
                    if (Directory.Exists(Form1.SavePath + textBox1.Text))
                    {
                        Form1.checkfile();
                        Form1.fixfile();
                        Form1 f1 = new Form1();
                        f1.ChangecomboBox2("Add",textBox1.Text);
                        f1.ChangecomboBox2("Text", textBox1.Text);
                        Form1.ClusterName = textBox1.Text;
                        Form1.ClusterPath = Form1.SavePath + Form1.ClusterName + "/";
                        MessageBox.Show("存档新建成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form4 f4 = new Form4();
                        f4.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("此存档已经存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("存档名不能为空！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
