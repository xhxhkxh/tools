using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace MemoryTest
{

    public partial class Form1 : Form
    {
        public long t_mem = 0;
        public Form1()
        {
            InitializeComponent();
        }


        public void Redisplay()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            CheckForIllegalCrossThreadCalls = false;
            p.StandardInput.WriteLine("del info.log");
            p.StandardInput.WriteLine("echo =====Memory Test by xhxhkh======= >> info.log");
            p.StandardInput.WriteLine("echo Start time: %time% >> info.log");
            while (true)
            {
                string command = "echo [%time%] CPU used:[" + performanceCounter1.NextValue()+"] >> info.log";
                //刷新CPU计数器
                string s = Convert.ToString(performanceCounter1.NextValue()/10);
                label5.Text = "目前CPU利用率（%）：" + s;
                p.StandardInput.WriteLine(command);
                Thread.Sleep(500);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //新的线程托管CPU计数器
            Thread re = new Thread(new ThreadStart(Redisplay));
            re.Start();
            Form2 form2 = new Form2();
            form2.Show();
        }


        public void Test()
        {
            //内存测试部分
            if (radioButton1.Checked)
            {
                while (t_mem <= 100)
                {
                    if (checkBox1.Checked == false)
                    {
                        this.BackColor = Color.White;
                        checkBox1.Checked = true;
                        
                    }
                    else
                    {
                        this.BackColor = Color.Wheat;
                        checkBox1.Checked = false;
                        
                    }
                    t_mem++;
                    //Console.WriteLine(t_mem);
                }
                t_mem = 0;
            }
            else if (radioButton2.Checked)
            {
                while (t_mem <= 1024)
                {
                    
                    if (checkBox1.Checked == false)
                    {
                        checkBox1.Checked = true;
                        this.BackColor = Color.White;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        this.BackColor = Color.Wheat;
                    }
                    t_mem++;
                    //Console.WriteLine(t_mem);
                }
                t_mem = 0;
            }
            else if (radioButton3.Checked)
            {
                while (t_mem <= 2048)
                {
                    if (checkBox1.Checked == false)
                    {
                        checkBox1.Checked = true;
                        this.BackColor = Color.White;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        this.BackColor = Color.Wheat;
                    }
                    t_mem++;
                    //Console.WriteLine(t_mem);
                }
                t_mem = 0;
            }
            else if (radioButton5.Checked)
            {
                while (true)
                {
                    if (checkBox1.Checked == false)
                    {
                        checkBox1.Checked = true;
                        this.BackColor = Color.Wheat;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        this.BackColor = Color.White;
                    }
                }
            }
            else
            {
                while (t_mem <= 4096)
                {
                    if (checkBox1.Checked == false)
                    {
                        checkBox1.Checked = true;
                        
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        
                    }
                    t_mem++;
                    //Console.WriteLine(t_mem);
                }
                t_mem = 0;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保证前端效果，这里使用一个新的线程来托管内存测试
            Thread t = new Thread(new ThreadStart(Test));
            t.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //这是目前退出的最干净的方式。将会退出所有的线程和本体
            System.Environment.Exit(1145141);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
