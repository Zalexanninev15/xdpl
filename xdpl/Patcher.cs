using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace xdpl
{
    public partial class Patcher : Form
    {
        public Patcher() {  InitializeComponent(); }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All files|*.*";
			open.FileName = "";
            if (open.ShowDialog() == DialogResult.OK) { textBox1.Text = open.FileName; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
		    open.FileName = "";
            open.Filter = "xdelta Patch Files|*.xdelta|All files|*.*";
            if (open.ShowDialog() == DialogResult.OK) { textBox2.Text = open.FileName; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All files|*.*";
			save.FileName = "";
            if (save.ShowDialog() == DialogResult.OK) { textBox3.Text = save.FileName; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All files|*.*";
			open.FileName = "";
            if (open.ShowDialog() == DialogResult.OK) { textBox4.Text = open.FileName; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
			open.FileName = "";
            open.Filter = "All files|*.*";
            if (open.ShowDialog() == DialogResult.OK) { textBox5.Text = open.FileName; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
			save.FileName = "";
            save.Filter = "xdelta Patch Files|*.xdelta|All files|*.*";
            if (save.ShowDialog() == DialogResult.OK) { textBox6.Text = save.FileName; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = "xdelta3.exe";
                    proc.StartInfo.Arguments = " -d -s " + '"' + textBox1.Text + '"' + " " + '"' + textBox2.Text + '"' + " " + '"' + textBox3.Text + '"';
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.Start();
                    proc.WaitForExit();
                    try
                    {
                        var RP = @textBox3.Text;
                        StreamReader sr = new StreamReader(RP);
                        var IP = sr.ReadToEnd();
                        sr.Close();
                        MessageBox.Show("Apply patch complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) { MessageBox.Show("Apply patch failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                } catch { MessageBox.Show("Problem with the file(s)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("You need to fill in all the fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = "xdelta3.exe";
                    proc.StartInfo.Arguments = " -e -s " + '"' + textBox4.Text + '"' + " " + '"' + textBox5.Text + '"' + " " + '"' + textBox6.Text + '"';
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.Start();
                    proc.WaitForExit();
                    try
                    {
                        var RP = @textBox5.Text;
                        StreamReader sr = new StreamReader(RP);
                        var IP = sr.ReadToEnd();
                        sr.Close();
                        MessageBox.Show("Make patch complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }  catch (Exception ex) { MessageBox.Show("Apply patch failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                } catch { MessageBox.Show("Problem with the file(s)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("You need to fill in all the fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox2_Click(object sender, EventArgs e) { Process.Start("https://github.com/Zalexanninev15/xdpl"); }
    }
}