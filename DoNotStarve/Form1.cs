using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Threading.Thread;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace DoNotStarve
{
    
    public partial class Form1 : Form
    {
        //=====================================变量区域开始=====================================================
        public static string ServerPath = "";//服务器路径
        public static string ModPath = "";//Mod路径
        public static string ModPath2 = "";//Mod路径2
        public static string SavePath = "";//存档路径
        public static string SavePath2 = "";//存档路径2
        public static string ServerMod = "";//服务器模式（Steam或WeGame）
        public static string ServerStartCode = "";//服务器额外启动参数
        public static string ClusterName = "";//存档名
        public static string ClusterNewName = "";//新建存档名
        public static string ClusterPath = "";//使用存档路径
        int file_void = 0;//判断文件是否存在使用的INT变量
        public static bool Masteristrue = false;//Master文件夹是否存在
        public static bool Modistrue = false;//存档Mod配置文件是否存在
        public static bool Serveriniistrue = false;//Server.ini是否存在
        public static bool Levelistrue = false;//存档世界配置文件是否存在
        public static string levelcode_Master = "return {\n desc=\"标准《饥荒》体验。\",\n hideminimap=false,\n id=\"SURVIVAL_TOGETHER\",\n location=\"forest\",\n max_playlist_position=999,\n min_playlist_position=0,\n name=\"默认\",\n numrandom_set_pieces=4,\n override_level_string=false,\n overrides={\n\n\nalternatehunt=\"default\",\n\n\nangrybees=\"default\",\n\n\nantliontribute=\"default\",\n\n\nautumn=\"default\",\n\n\nbearger=\"default\",\n\n\nbeefalo=\"default\",\n\n\nbeefaloheat=\"default\",\n\n\nbees=\"default\",\n\n\nberrybush=\"default\",\n\n\nbirds=\"default\",\n\n\nboons=\"default\",\n\n\nbranching=\"default\",\n\n\nbutterfly=\"default\",\n\n\nbuzzard=\"default\",\n\n\ncactus=\"default\",\n\n\ncarrot=\"default\",\n\n\ncatcoon=\"default\",\n\n\nchess=\"default\",\n\n\nday=\"default\",\n\n\ndeciduousmonster=\"default\",\n\n\ndeerclops=\"default\",\n\n\ndisease_delay=\"default\",\n\n\ndragonfly=\"default\",\n\n\nflint=\"default\",\n\n\nflowers=\"default\",\n\n\nfrograin=\"default\",\n\n\ngoosemoose=\"default\",\n\n\ngrass=\"default\",\n\n\nhas_ocean=true,\n\n\nhoundmound=\"default\",\n\n\nhounds=\"default\",\n\n\nhunt=\"default\",\n\n\nkeep_disconnected_tiles=true,\n\n\nkrampus=\"default\",\n\n\nlayout_mode=\"LinkNodesByKeys\",\n\n\nliefs=\"default\",\n\n\nlightning=\"default\",\n\n\nlightninggoat=\"default\",\n\n\nloop=\"default\",\n\n\nlureplants=\"default\",\n\n\nmarshbush=\"default\",\n\n\nmerm=\"default\",\n\n\nmeteorshowers=\"default\",\n\n\nmeteorspawner=\"default\",\n\n\nmoles=\"default\",\n\n\nmushroom=\"default\",\n\n\nno_joining_islands=true,\n\n\nno_wormholes_to_disconnected_tiles=true,\n\n\npenguins=\"default\",\n\n\nperd=\"default\",\n\n\npetrification=\"default\",\n\n\npigs=\"default\",\n\n\nponds=\"default\",\n\n\nprefabswaps_start=\"default\",\n\n\nrabbits=\"default\",\n\n\nreeds=\"default\",\n\n\nregrowth=\"default\",\n\n\nroads=\"default\",\n\n\nrock=\"default\",\n\n\nrock_ice=\"default\",\n\n\nsapling=\"default\",\n\n\nseason_start=\"default\",\n\n\nspecialevent=\"default\",\n\n\nspiders=\"default\",\n\n\nspring=\"default\",\n\n\nstart_location=\"default\",\n\n\nsummer=\"default\",\n\n\ntallbirds=\"default\",\n\n\ntask_set=\"default\",\n\n\ntentacles=\"default\",\n\n\ntouchstone=\"default\",\n\n\ntrees=\"default\",\n\n\ntumbleweed=\"default\",\n\n\nwalrus=\"default\",\n\n\nweather=\"default\",\n\n\nwildfires=\"default\",\n\n\nwinter=\"default\",\n\n\nworld_size=\"default\",\n\n\nwormhole_prefab=\"wormhole\"\n\n},\n random_set_pieces={\n\n\n\"Sculptures_2\",\n\n\n\"Sculptures_3\",\n\n\n\"Sculptures_4\",\n\n\n\"Sculptures_5\",\n\n\n\"Chessy_1\",\n\n\n\"Chessy_2\",\n\n\n\"Chessy_3\",\n\n\n\"Chessy_4\",\n\n\n\"Chessy_5\",\n\n\n\"Chessy_6\",\n\n\n\"Maxwell1\",\n\n\n\"Maxwell2\",\n\n\n\"Maxwell3\",\n\n\n\"Maxwell4\",\n\n\n\"Maxwell6\",\n\n\n\"Maxwell7\",\n\n\n\"Warzone_1\",\n\n\n\"Warzone_2\",\n\n\n\"Warzone_3\"\n\n},\n required_prefabs={ \"multiplayer_portal\" },\n required_setpieces={ \"Sculptures_1\", \"Maxwell5\" },\n substitutes={\n },\n version=4 }"; //地面世界配置参数
        public static string levelcode_Caves = "return { \n background_node_range={0,1}, \n desc=\"探查洞穴…… 一起！\", \n hideminimap=false, \n id=\"DST_CAVE\", \n location=\"cave\", \n max_playlist_position=999, \n min_playlist_position=0, \n name=\"洞穴\", \n numrandom_set_pieces=0, \n override_level_string=false, \n overrides={  \n  banana=\"default\",  \n  bats=\"default\",  \n  berrybush=\"default\",  \n  boons=\"default\",  \n  branching=\"default\",  \n  bunnymen=\"default\",  \n  cave_ponds=\"default\",  \n  cave_spiders=\"default\",  \n  cavelight=\"default\",  \n  chess=\"default\",  \n  disease_delay=\"default\",  \n  earthquakes=\"default\",  \n  fern=\"default\",  \n  fissure=\"default\",  \n  flint=\"default\",  \n  flower_cave=\"default\",  \n  grass=\"default\",  \n  layout_mode=\"RestrictNodesByKey\",  \n  lichen=\"default\",  \n  liefs=\"default\",  \n  loop=\"default\",  \n  marshbush=\"default\",  \n  monkey=\"default\",  \n  mushroom=\"default\",  \n  mushtree=\"default\",  \n  prefabswaps_start=\"default\",  \n  reeds=\"default\",  \n  regrowth=\"default\",  \n  roads=\"never\",  \n  rock=\"default\",  \n  rocky=\"default\",  \n  sapling=\"default\",  \n  season_start=\"default\",  \n  slurper=\"default\",  \n  slurtles=\"default\",  \n  start_location=\"caves\",  \n  task_set=\"cave_default\",  \n  tentacles=\"default\",  \n  touchstone=\"default\",  \n  trees=\"default\",  \n  weather=\"default\",  \n  world_size=\"default\",  \n  wormattacks=\"default\",  \n  wormhole_prefab=\"tentacle_pillar\",  \n  wormlights=\"default\",  \n  worms=\"default\"  \n }, \n required_prefabs={\"multiplayer_portal\"}, \n substitutes={}, \n version=4 \n }"; //洞穴世界配置参数
        int myprocessID;//进程ID
        bool list_change = false;

        //=====================================变量区域结束=====================================================

        public Form1()
        {
            InitializeComponent();
        }
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //----------------------------------------函数区域开始---------------------------------------------------

        public static void checkfile()//检查文件完整性 函数
        {
            if (!Directory.Exists(Form1.ClusterPath + "Master"))
            {
                Masteristrue = false;
            }
            else
            {
                Masteristrue = true;
            }
            if (!File.Exists(Form1.ClusterPath + "Master/server.ini"))
            {
                Serveriniistrue = false;
            }
            else
            {
                Serveriniistrue = true;
            }
            if (!File.Exists(Form1.ClusterPath + "Master/modoverrides.lua"))
            {
                Modistrue = false;
            }
            else
            {
                Modistrue = true;
            }
            if (!File.Exists(Form1.ClusterPath + "Master/leveldataoverride.lua"))
            {
                Levelistrue = false;
            }
            else
            {
                Levelistrue = true;

            }
        }
        public void ChangecomboBox2(string Change,string text)
        {
            if (Change == "Add")
            {
                comboBox2.Items.Add(text);
            }
            else if (Change == "Remove")
            {
                comboBox2.Items.Remove(text);
            }
            else if (Change == "Clear")
            {
                comboBox2.Items.Clear();
            }
            else if (Change == "Text")
            {
                comboBox2.SelectedItem = text;
            }
            
        }
        public static void fixfile()//修复缺漏文件 函数
        {
            if (Masteristrue == false)
            {
                
                Directory.CreateDirectory(Form1.ClusterPath + "Master");
            }
            if (Levelistrue == false)
            {
                newtxt("Master/leveldataoverride.lua", levelcode_Caves);
            }
            if (Modistrue == false)
            {
                newtxt("Master/modoverrides.lua", "return {  }");
            }
            if (Serveriniistrue == false)
            {
                newtxt("Master/Server.ini", "[NETWORK] \r\n server_port = 10999 \r\n [SHARD] \r\n is_master = true \r\n [ACCOUNT] \r\n encode_user_path = true");
            }
        }
        public static int GetFilesCount(DirectoryInfo dirInfo)//统计存档数 函数
        {
            
            int totalFile = 0;
            string s = "" + dirInfo + "/";
            if (s == SavePath2)
            {

            }
            else if(File.Exists(SavePath2 + s + "cluster.ini"))
            {
                totalFile += dirInfo.GetFiles("cluster.ini").Length;
            }
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
                
            }
            return totalFile;

        }
        public static int GetModCount(DirectoryInfo dirInfo2)//统计Mod数 函数
        {

            int totalFile = 0;
            string s = "" + dirInfo2 + "/";
            if (s == ModPath2)
            {

            }
            else if (File.Exists(ModPath2 + s + "modinfo.lua"))
            {
                totalFile += dirInfo2.GetFiles("modinfo.lua").Length;
            }
            foreach (System.IO.DirectoryInfo subdir in dirInfo2.GetDirectories())
            {
                totalFile += GetModCount(subdir);

            }
            return totalFile;
            

        }
        public void GetSavePath(string Path2)//判断文件夹是否为存档 函数
        {
            string[] dirs = Directory.GetDirectories(Path2);
            List<string> list = new List<string>();
            foreach (string item in dirs)
            {
                list.Add(Path.GetFileNameWithoutExtension(item));
            }
            foreach (var item in list)
            {
                if (File.Exists(Path2 + "/" + item.ToString() + "/cluster.ini"))
                {

                    //MessageBox.Show(item.ToString());
                    if (list_change == false)
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("None");
                        list_change = true;
                    }
                    comboBox2.Items.Add(item.ToString());
                }

            }
        }
        public void GetModPath(string Path3)//判断文件夹是否为MOD 函数
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
                    //comboBox2.Items.Add(item.ToString());
                }

            }
        }
        public static int GetFilesCount2(DirectoryInfo dirInfo)//统计存档数 函数
        {
            
            int totalFile = 0;
            string s = "" + dirInfo + "/";
            if (s == SavePath2)
            {

            }
            else if (File.Exists(SavePath2 + s + "cluster.ini"))
            {
                totalFile += dirInfo.GetFiles("cluster.ini").Length;
            }
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);

            }
            return totalFile;

        }
        public void FileExists(string filename, string filepath)//判断文件是否存在函数
        {
            //int file_void = 0;
            if (File.Exists(filepath + filename))
            {
                file_void = 1;
            }
            else
            {
                file_void = 0;
            }
        }
        public static void Serchtxt(string filename, string keyword)//搜索指定行函数
        {
            string line;
            if (SavePath != "" || ClusterName != "")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(ClusterPath + filename);
                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        MessageBox.Show(line);
                    }


                }
                file.Close();
            }
            else if (SavePath == "")
            {
                MessageBox.Show("您还没有设置存档路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ClusterName == "")
            {
                MessageBox.Show("您还没有选择要启用的存档！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void newtxt(string filename, string code)//新建文件函数
        {
            FileStream fs1 = new FileStream(Form1.ClusterPath + filename, FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(code);//开始写入值
            sw.Close();
            fs1.Close();
        }
        //----------------------------------------函数区域结束---------------------------------------------------
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================


        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)//服务器路径选择
        {


            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择一个文件夹（不需要选择BIN文件夹！！！）",
                ShowNewFolderButton = false
            };
            //dialog.SelectedPath = ServerPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileExists("dontstarve_dedicated_server_nullrenderer.exe",dialog.SelectedPath + "/bin/");
                if (file_void == 0)
                {
                    DialogResult = MessageBox.Show("在此文件夹下没有找到服务器程序，继续设置此文件夹为服务器路径吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.OK)
                    {
                        ServerPath = dialog.SelectedPath + "/";
                        textBox1.Text = ServerPath;
                        textBox2.Text = ServerPath + "mod/";
                        ModPath = ServerPath + "mod/";
                    }
                }
                else
                {
                    ServerPath = dialog.SelectedPath + "/";
                    textBox1.Text = ServerPath;
                    textBox2.Text = ServerPath + "mod/";
                    ModPath = ServerPath + "mod/";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//Mod路径选择
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择Mod文件夹路径",
                ShowNewFolderButton = true
                
            };
            //dialog.SelectedPath = ModPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string history = textBox2.Text;
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dialog.SelectedPath);
                ModPath2 = dialog.SelectedPath + "/";
                int result2 = GetModCount(dirInfo);
                DialogResult = MessageBox.Show("扫描到有" + result2 + "个Mod，是否以此文件夹为Mod文件夹？", "扫描完毕", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //ServerPath = dialog.SelectedPath + "/";
                //textBox1.Text = ServerPath;
                if (DialogResult == DialogResult.OK)
                {
                    textBox2.Text = dialog.SelectedPath + "/";
                    ModPath = dialog.SelectedPath + "/";
                    GetModPath(dialog.SelectedPath);
                }
                else
                {
                    ModPath2 = history;
                    textBox2.Text = history;
                }
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)//启动服务器
        {
            if (file_void == 0)
            {
                MessageBox.Show("服务器路径有误，拒绝启动！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(ClusterName == "")
            {

            }
            else
            {
                Process myProcess = Process.Start(ServerPath + "bin/dontstarve_dedicated_server_nullrenderer.exe", "-console -cluster" + ClusterName + "-shard Master" + ServerStartCode); // 启动外部进程
                myprocessID = myProcess.Id; // 获得该外部进程ID
                //System.Diagnostics.Process.Start(ServerPath + "bin/dontstarve_dedicated_server_nullrenderer.exe", "-console -cluster"+ ClusterName +"-shard Master" + ServerStartCode);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//存档路径选择
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择存档文件夹路径",
                ShowNewFolderButton = true

            };
            //dialog.SelectedPath = ModPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //ServerPath = dialog.SelectedPath + "/";
                //textBox1.Text = ServerPath;
                string history = textBox3.Text;
                SavePath2 = dialog.SelectedPath + "/";
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dialog.SelectedPath);
                int result = GetFilesCount(dirInfo);
                DialogResult = MessageBox.Show("扫描到有"+ result + "个存档，是否以此文件夹为存档文件夹？","扫描完毕",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                {
                    list_change = false;
                    textBox3.Text = dialog.SelectedPath + "/";
                    SavePath = dialog.SelectedPath + "/";
                    GetSavePath(dialog.SelectedPath);
                    comboBox2.SelectedItem = "None";
                }
                else
                {
                    list_change = false;
                    SavePath = history;
                    textBox3.Text = history;
                }    
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Steam")
            {
                ServerMod = "Steam";
            }
            else
            {
                MessageBox.Show("此模式暂未支持，请敬请期待！","十分抱歉！",MessageBoxButtons.OK,MessageBoxIcon.Information);
                comboBox1.SelectedItem = "Steam";
                ServerMod = "Steam";
                //comboBox1.Items.Add("23333333");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() != "None")
            {
                checkfile();
                if (Masteristrue == false || Modistrue == false || Levelistrue == false || Serveriniistrue == false)
                {
                    DialogResult = MessageBox.Show("检测到存档缺少相关的配置文件，是否添加？", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.OK)
                    {
                        fixfile();
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("是否继续以此存档运行？", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.OK)
                        {
                            ClusterName = comboBox2.SelectedItem.ToString();//设置指定存档
                            ClusterPath = SavePath + ClusterName + "/";
                        }
                        else
                        {
                            comboBox2.SelectedItem = "None";
                        }
                    }
                }
                else
                {
                    ClusterName = comboBox2.SelectedItem.ToString();//设置指定存档
                    ClusterPath = SavePath + ClusterName + "/";
                    //Serchtxt("Master/server.ini", "");
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox2.SelectedItem.ToString());
            if (comboBox2.SelectedItem.ToString() != "None")
            {



                checkfile();
                if (Masteristrue == false || Modistrue == false || Levelistrue == false || Serveriniistrue == false)
                {
                    DialogResult = MessageBox.Show("检测到存档缺少相关的配置文件，是否添加？", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.OK)
                    {
                        fixfile();
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("是否继续以此存档运行？", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.OK)
                        {
                            ClusterName = comboBox2.SelectedItem.ToString();//设置指定存档
                            ClusterPath = SavePath + ClusterName + "/";
                        }
                        else
                        {
                            comboBox2.SelectedItem = "None";
                        }
                    }
                }
                else
                {
                    DialogResult = MessageBox.Show("暂无发现缺少的文件", "通过", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("您还没有选择存档！","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "None")
            {
                MessageBox.Show("您还没有选择存档！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = MessageBox.Show("您确定要删除此存档吗？","敏感操作",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                {
                    DialogResult = MessageBox.Show("再次确认！你确定要删除名为\""+ ClusterName + "\"的存档吗？", "敏感操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.OK)
                    {
                        if (Directory.Exists(ClusterPath))
                        {
                            Directory.Delete(ClusterPath, true);
                            if (!Directory.Exists(ClusterPath))
                            {
                                MessageBox.Show("已删除名为\"" + ClusterName + "\"的存档", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                comboBox2.Items.Remove(ClusterName);
                                comboBox2.SelectedItem = "None";
                                ClusterPath = "";
                                ClusterName = "";
                            }
                            else
                            {
                                MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("删除失败，目录不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                } 
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}

