using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 隐写
{
    public partial class Form1 : Form
    {
        public string str;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            label8.Text = "打开文件......";
            if (open.ShowDialog() == DialogResult.OK)
            {
                label4.Text = open.FileName;
            }
            label8.Text = "空闲";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            label8.Text = "打开文件......";
            if (open.ShowDialog() == DialogResult.OK)
            {
                label5.Text = open.FileName;
                label3.Text = System.IO.Path.GetDirectoryName(label5.Text);
            }
            label8.Text = "空闲";
        }



        private void button3_Click(object sender, EventArgs e)
        {


            string Fname = System.IO.Path.GetFileName(label5.Text);
            if (label4.Text == "位置" || label5.Text == "位置")
            {
                MessageBox.Show("请选择正确的文件", "出现毁灭性错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string str = "copy /b " + "\"" + label4.Text + " \" + \"" + label5.Text + "\" \"" + label5.Text + "\"";
                label8.Text = "制作中......";
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine(str);
                p.StandardInput.WriteLine("Yes");
                p.StandardInput.WriteLine("exit");
                p.StandardInput.Close();
                // string output = p.StandardOutput.ReadToEnd();
                // MessageBox.Show(output, "调试信息");
                MessageBox.Show("操作成功", "", MessageBoxButtons.OK,MessageBoxIcon.Information);
                label8.Text = "空闲";
                p.Close();
            }
            if (checkBox1.Checked == true)
            {
                label8.Text = "打开文件夹";
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("start "+label3.Text);
                p.StandardInput.Close();
                p.WaitForExit();
                p.Close();
                label8.Text = "空闲";
            }
            if(checkBox2.Checked == true)
            {
                label8.Text = "删除源文件";
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.Start();
                p.StandardInput.WriteLine("del " + label4.Text);
                p.StandardInput.Close();
                label8.Text = "空闲";
            }
            if (checkBox3.Checked == true)
            {
                label8.Text = "关闭程序......";
                System.Environment.Exit(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Npath = System.AppDomain.CurrentDomain.BaseDirectory;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.StandardInput.WriteLine("cd " + Npath);
            p.StandardInput.WriteLine(Npath[0] + ":");
            p.StandardInput.WriteLine("start ./README.txt");
            p.StandardInput.Close();
            string Out = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
        }


    }
}
