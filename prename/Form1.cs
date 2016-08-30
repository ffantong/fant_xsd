using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prename
{
    public partial class Form1 : Form
    {
        Timer Timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString();
            this.Load+=Form1_Load;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.label2.Enabled = true;
                this.textBox2.Enabled = true;
            }
            else
            {
                this.label2.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBox2.Text = "只能输入数字";
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                this.label3.Enabled = true;
                this.textBox3.Enabled = true;
            }
            else
            {
                this.label3.Enabled = false;
                this.textBox3.Enabled = false;
                this.textBox3.Text = "只能输入数字";
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked == true)
            {
                this.textBox4.Enabled = true;

            }
            else
            {
                this.textBox4.Enabled = false;
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (this.checkBox4.Checked == true)
            {
                this.textBox5.Enabled = true;

            }
            else
            {
                this.textBox5.Enabled = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 )
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            this.textBox1.Text = f.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String []fname = Directory.GetFiles(textBox1.Text);
            String newname;
            string qd;
            int number;
            int skip = 0;
            for (int i = 0; i < fname.Length; i++)
            {
                this.toolStripProgressBar1.Value =i*100/(fname.Length-1) ;
                newname = fname[i].Replace(textBox1.Text + '\\', "");
                newname = newname.Substring(0, newname.LastIndexOf('.'));
                if (checkBox6.Checked == true)
                {
                    newname = "";
                }
                try
                {
                    if (checkBox1.Checked == true)
                    {
                        newname = newname.Substring(int.Parse(textBox2.Text));
                    }

                    if (checkBox2.Checked == true)
                    {
                        newname = newname.Substring(0, newname.Length - int.Parse(textBox3.Text));
                    }

                    if (checkBox3.Checked == true)
                    {
                        newname = textBox4.Text + newname;
                    }

                    if (checkBox4.Checked == true)
                    {
                        newname = newname + textBox5.Text;
                    }
                    if (checkBox5.Checked == true)
                    {
                        if (checkBox7.Checked == true)
                        {
                            number = i + Convert.ToInt32(textBox6.Text.Trim());
                            qd = "";
                            for (int j = 0; j < (fname.Length + Convert.ToInt32(textBox6.Text.Trim())).ToString().Length
                                - number.ToString().Length; j++)
                            {
                                qd = qd + '0';
                            }
                            newname = newname + qd + number;
                        }
                        else
                        {
                            newname=newname+(i+Convert.ToInt32(textBox6.Text.Trim()));
                        }
                    }
                 System.IO.File.Move(fname[i], textBox1.Text + '\\' + newname +
                     fname[i].Substring(fname[i].LastIndexOf('.')));
                }catch(Exception)
                {
                    skip++;
                }
            }
            this.label4.Text = "已完成！共处理" + (fname.Length-skip) + "个文件！跳过"+skip+"个文件！";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // 调用本方法开始用计算器            
            Timer1.Interval = 1000;//设置时钟周期为1秒（1000毫秒）  
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Enabled = true;
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            // Set the caption to the current time. 
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
                this.label2.Enabled = false;
                this.textBox2.Enabled = false;
                this.label3.Enabled = false;
                this.textBox3.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox7.Enabled = true;
                label5.Enabled = true;
                textBox6.Enabled = true;
            }
            else
            {
                checkBox7.Enabled = false;
                label5.Enabled = false;
                textBox6.Enabled = false;
                textBox6.Text = "1";
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }
    }


    public partial class Form2 : Form
    {
        Label label1 = new Label();
        Label label2 = new Label();
        Label label3 = new Label();
        Button btok = new Button();
        public Form2()
        {
            this.Height = 150;
            this.Text = "关于";
            this.BackColor = Color.FromArgb( 128, 255, 128);
            label1.Text = "文件批量重命名 1.0";
            label2.Text = "版权所有(ffantong)";
            label3.Text = "2014.3.25";
            btok.Text = "确定";
            label1.SetBounds(20,15,300,20);
            label2.SetBounds(20, 40, 300, 20);
            label3.SetBounds(20, 65, 300, 20);
            btok.SetBounds(110,85,60,22);
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(btok);
            btok.Click += buttonok_Click;
        }

        private void buttonok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
