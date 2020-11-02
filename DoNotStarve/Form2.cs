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
    public partial class Form2 : Form
    {
        
        string ModPath2 = "";
        static int r = 0,line_m =0;
        string answer = "";
        bool pipei = false;
        public static string SelectedMod = "";
        int i = 0,e =0;
        public Form2()
        {
            InitializeComponent();
        }
        public void Serchtxt(string filename, string keyword)//搜索指定行
        {

            string line;
                System.IO.StreamReader file = new System.IO.StreamReader(Form1.ModPath2 + filename + "/modinfo.lua");
                while ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);
                    if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        answer = line;
                        pipei = true;
                    line_m = line_m + 1;
                    }
                  if(pipei != true)
                {
                    line_m++;
                    
                }


                }
                file.Close();
            
        }
        public static void newtxt(string filename, string code)//新建文件函数
        {
            
            
            
            if (Form2.r == 0)
            {
                FileStream fs1 = new FileStream(Form1.ClusterPath + filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);//创建写入文件
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(code);//开始写入值
                sw.Close();
                fs1.Close();
                //Form1.ClusterPath + filename, false
            }
            else
            {
                FileStream fs1 = new FileStream(Form1.ClusterPath + filename, FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(code);//开始写入值
                sw.Close();
                fs1.Close();
            }
            r++;
            
        }
        public void GetModEnable(string keyword)//获取Mod启用状态
        {
            
            string line,f = "";
            System.IO.StreamReader file = new System.IO.StreamReader(Form1.ClusterPath + "/Master/modoverrides.lua");
            int m = 0;
            bool wait = true;
                wait = true;
            //MessageBox.Show(i.ToString());
            while ((line = file.ReadLine()) != null)
            {
                m = i;
                f = checkedListBox1.Items[m].ToString();

                if (line.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //line_m = m;
                    //pipei = true;
                    //answer = line;
                    checkedListBox1.SetItemChecked(m, true);
                    //checkedListBox1.SetItemChecked(1, true);
                    wait = false;
                }

            }
            file.Close();
            //checkedListBox1.Items

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            ModPath2 =  Form1.ModPath;
            MessageBox.Show(ModPath2);
            if (ModPath2 == "")
            {
                MessageBox.Show("您还没有设置Mod文件夹路径！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //Form2 f2 = new Form2();
                this.Close();
            }
            else
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ModPath2);
                int result2 = GetModCount(dirInfo);
                label1.Text = "一共扫描到" + result2 + "个Mod";
                GetModPath(ModPath2);
                i = 0;
                //GetModEnable("1");

            }
            //checkedListBox1.SetSelected(1, true);
        }
        public void GetModPath(string Path3)//判断文件夹是否为MOD
        {
            string[] dirs = Directory.GetDirectories(Path3);
            List<string> list = new List<string>();
            foreach (string item in dirs)
            {
                list.Add(Path.GetFileNameWithoutExtension(item));
            }
            foreach (var item in list)
            {
                if (File.Exists(Path3 + "/" + item.ToString() + "/modinfo.lua"))
                {

                    //MessageBox.Show(item.ToString());
                    checkedListBox1.Items.Add(item.ToString());
                }

            }
        }
        public static int GetModCount(DirectoryInfo dirInfo)//统计Mod数
        {

            int totalFile = 0;
            string s = "" + dirInfo + "/";
            if (s == Form1.ModPath2)
            {

            }
            else if (File.Exists(Form1.ModPath2 + s + "modinfo.lua"))
            {
                totalFile += dirInfo.GetFiles("modinfo.lua").Length;
            }
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetModCount(subdir);

            }
            return totalFile;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            else
            {
                r = 0;
                int i,h = 0,h1 = 0;
                for (i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        h++;
                    }
                }
                    for (i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                    {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        
                        if(h1 == 0)
                        {
                            newtxt("Master/modoverrides.lua", "return { \n  [\"" + checkedListBox1.Items[i].ToString() + "\"]={\n    configuration_options={ }\n    enabled=true\n  },");
                            h1++;

                        }
                        else if (h1 > 0 && h1 < (h - 1 ))
                        {
                            newtxt("Master/modoverrides.lua", "\n  [\"" + checkedListBox1.Items[i].ToString() + "\"]={\n    configuration_options={ }\n    enabled=true\n  },");
                            h1++;
                        }
                        else
                        {
                            newtxt("Master/modoverrides.lua", "\n  [\"" + checkedListBox1.Items[i].ToString() + "\"]={\n    configuration_options={ }\n    enabled=true\n  }\n}");

                        }
                        
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.SetSelected(1, true);
            MessageBox.Show(checkedListBox1.SelectedItem.ToString());
            line_m = 0;
            pipei = false;
            SelectedMod = checkedListBox1.SelectedItem.ToString();
            Serchtxt(checkedListBox1.SelectedItem.ToString(), "configuration_options");
            Form f7 = new Form7();
            f7.Show();
            //MessageBox.Show(line_m.ToString());
        }
    }
}
