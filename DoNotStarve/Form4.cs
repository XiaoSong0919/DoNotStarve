﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace DoNotStarve
{
    public partial class Form4 : Form
    {
        public static string game_mode;
        public static string max_players;
        public static string pvp;
        public static string pause_when_empty;
        public static string lan_only_cluster;
        public static string cluster_intention;
        public static string cluster_password;
        public static string cluster_description;
        public static string cluster_name;
        public static string offline_cluster;
        public static string cluster_language;
        public static string console_enabled;
        public static string shard_enabled;
        public static string bind_ip;
        public static string master_ip;
        public static string master_port;
        public static string cluster_key;
        public static string answer;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
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
                
                //string answer;
                Serchtxt("cluster.ini", "game_mode");
                answer = answer.Replace("game_mode", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                game_mode = answer;
                if (game_mode == "endless")
                {
                    comboBox1.Text = "无尽";
                }
                else if (game_mode == "survival")
                {
                    comboBox1.Text = "生存";
                }
                else if (game_mode == "wilderness")
                {
                    comboBox1.Text = "荒野";
                }
                //-----------------------------------------game mode
                Serchtxt("cluster.ini", "max_players");
                answer = answer.Replace("max_players", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                max_players = answer;
                textBox1.Text = max_players;
                //-----------------------------------------max players
                Serchtxt("cluster.ini", "pvp");
                answer = answer.Replace("pvp", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                pvp = answer;
                if (pvp == "true")
                {
                    comboBox3.Text = "开启";
                }
                else
                {
                    comboBox3.Text = "关闭";
                }
                //-----------------------------------------pvp
                Serchtxt("cluster.ini", "pause_when_empty");
                answer = answer.Replace("pause_when_empty", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                pause_when_empty = answer;
                if (pause_when_empty == "true")
                {
                    comboBox2.Text = "开启";
                }
                else
                {
                    comboBox2.Text = "关闭";
                }
                //-----------------------------------------pause_when_empty
                Serchtxt("cluster.ini", "lan_only_cluster");
                answer = answer.Replace("lan_only_cluster", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                lan_only_cluster = answer;
                if (lan_only_cluster == "true")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                //-----------------------------------------lan_only_cluster
                Serchtxt("cluster.ini", "cluster_intention");
                answer = answer.Replace("cluster_intention", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                cluster_intention = answer;
                if (cluster_intention == "cooperative")
                {
                    comboBox5.Text = "合作";
                }
                else if(cluster_intention == "competitive")
                {
                    comboBox5.Text = "竞争";
                }
                else if (cluster_intention == "social")
                {
                    comboBox5.Text = "交际";
                }
                else if (cluster_intention == "madness")
                {
                    comboBox5.Text = "疯狂";
                }
                //-----------------------------------------cluster_intention
                Serchtxt("cluster.ini", "cluster_password");
                answer = answer.Replace("cluster_password", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                cluster_password = answer;
                textBox16.Text = cluster_password;
                //-----------------------------------------cluster_password
                Serchtxt("cluster.ini", "cluster_description");
                answer = answer.Replace("cluster_description", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                cluster_description = answer;
                textBox15.Text = cluster_description;
                //-----------------------------------------cluster_description
                Serchtxt("cluster.ini", "cluster_name");
                answer = answer.Replace("cluster_name", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                cluster_name = answer;
                textBox14.Text = cluster_name;
                //-----------------------------------------cluster_name
                Serchtxt("cluster.ini", "offline_cluster");
                answer = answer.Replace("offline_cluster", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                offline_cluster = answer;
                if (offline_cluster == "true")
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
                //-----------------------------------------offline_cluster
                Serchtxt("cluster.ini", "cluster_language");
                answer = answer.Replace("cluster_language", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                cluster_language = answer;
                //-----------------------------------------cluster_language
                Serchtxt("cluster.ini", "console_enabled");
                answer = answer.Replace("console_enabled", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                console_enabled = answer;
                //-----------------------------------------console_enabled
                Serchtxt("cluster.ini", "shard_enabled");
                answer = answer.Replace("shard_enabled", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                shard_enabled = answer;
                if (shard_enabled == "true")
                {
                    comboBox4.Text = "开启";
                }
                else
                {
                    comboBox4.Text = "关闭";
                }
                //-----------------------------------------shard_enabled
                Serchtxt("cluster.ini", "bind_ip");
                answer = answer.Replace("bind_ip", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                bind_ip = answer;
                textBox10.Text = bind_ip;
                //-----------------------------------------bind_ip
                Serchtxt("cluster.ini", "master_ip");
                answer = answer.Replace("master_ip", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                master_ip = answer;
                textBox11.Text = master_ip;
                //-----------------------------------------master_ip
                Serchtxt("cluster.ini", "master_port");
                answer = answer.Replace("master_port", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                master_port = answer;
                textBox12.Text = master_port;
                //-----------------------------------------master_port
                Serchtxt("cluster.ini", "cluster_key");
                answer = answer.Replace("cluster_key", "");
                answer = answer.Replace(" ", "");
                answer = answer.Replace("=", "");
                cluster_key = answer;
                textBox13.Text = cluster_key;
                //-----------------------------------------cluster_key
                //Serchtxt("cluster.ini", "game_mode");
                //answer = answer.Replace("max_players", "");
                //answer = answer.Replace(" ", "");
                //answer = answer.Replace("=", "");
                //-----------------------------------------max players
            }
        }
        public void Serchtxt(string filename, string keyword)//搜索指定行
        {
            
            string line;
            if (Form1.SavePath != "" || Form1.ClusterName != "")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Form1.ClusterPath + filename);
                while ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);
                    if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        answer = line;
                    }


                }
                file.Close();
            }
            else if (Form1.SavePath == "")
            {
                MessageBox.Show("您还没有设置存档路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Form1.ClusterName == "")
            {
                MessageBox.Show("您还没有选择要启用的存档！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox16.PasswordChar = '*';
            }
            else
            {
                textBox16.PasswordChar = '0';
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
