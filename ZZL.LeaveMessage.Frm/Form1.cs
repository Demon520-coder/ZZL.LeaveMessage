using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZZL.LeaveMessage.Frm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Width = 200;
            ObosoloteTest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = "我是button1";
            //新增一个按钮;
            Button btn2 = new Button();
            btn2.Text = "button2";
            btn2.Width = 200;
            this.Controls.Add(btn2);
            btn2.Click += new EventHandler(Btn2_Click);
        }

        private void Btn2_Click(object o, EventArgs e)
        {
            Button btn = (Button)o;
            btn.Text = "我是button2";
        }

        [Conditional("DEBUG")]
        private void DebugIf()
        {
            MessageBox.Show("DebugIf");
        }

        [Obsolete("该方法将被弃用,请使用另外的方法")]
        private void ObosoloteTest()
        {
            MessageBox.Show(nameof(this.ObosoloteTest));
        }
    }
}
