using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNotStarve
{
    public partial class Form7 : Form
    {
        //string ModPath2 = "";
        static int r = 0, line_m = 0;
        string answer = "";
        bool pipei = false;
        List<string> ModConfigList = new List<string>();
        public Form7()
        {
            InitializeComponent();
        }
        public void Serchtxt(string filename, string keyword)//搜索指定行
        {

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Form1.ModPath2 + Form2.SelectedMod + "/modinfo.lua");
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    answer = line;
                    //pipei = true;
                    //line_m = line_m + 1;
                }
                if (pipei != true)
                {
                    //line_m++;

                }


            }
            file.Close();

        }
        public void GetModName(string keyword)//获取Mod名称
        {

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Form1.ModPath2 + Form2.SelectedMod + "/modinfo.lua");
            int m = 0;
            while ((line = file.ReadLine()) != null)
            {
                m++;
                if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 && pipei == false)
                {
                    line_m = m;
                    pipei = true;
                    answer = line;
                }
                
            }
            file.Close();

        }


        public void GetModConfig(string keyword)//获取Mod配置
        {

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Form1.ModPath2 + Form2.SelectedMod + "/modinfo.lua");
            int m = 0;
            while ((line = file.ReadLine()) != null)
            {
                m++;
                if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    
                    if (m != line_m)
                    {
                        answer = line;
                        line = line.Replace("\"", "");
                        line = line.Replace("=", "");
                        line = line.Replace(",", "");
                        line = line.Replace("name", "");
                        line = line.Trim();
                        ModConfigList.Add(m.ToString() + line);
                    }
                }

            }
            file.Close();
            foreach(string temp in ModConfigList)
            {
                MessageBox.Show(temp);
            }

        }
        private void Form7_Load(object sender, EventArgs e)
        {
            GetModName("name");
            answer = answer.Replace("name", "");
           // answer = answer.Replace(" ", "");
            answer = answer.Replace("=", "");
            answer = answer.Replace("\"", "");
            answer = answer.Trim();
            textBox1.Text = answer;
            GetModConfig("name");
        }
    }
}
