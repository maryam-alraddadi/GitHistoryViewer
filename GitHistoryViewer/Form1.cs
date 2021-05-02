using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHistoryViewer
{
    public partial class Form1 : Form
    {
        int x, y;
        public Form1()
        {
            x = 0;
            y = 0;
            //Repository.Clone("https://github.com/maryam-alraddadi/Learn-Git.git", @"C:\Users\maryam\source\repos\gitViewerExample");
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Brushes.Black, 4);
            string date;
            using (var repo = new Repository(@"C:\Users\maryam\source\repos\gitViewerExample"))
            {

                foreach (var commit in repo.Commits)
                {
                    //Debug.WriteLine(
                    //    $"{commit.Id.ToString().Substring(0, 7)} " +
                    //    $"{commit.Author.When.ToLocalTime()} " +
                    //    $"{commit.MessageShort} " +
                    //    $"{commit.Author.Name}");
                    g.DrawEllipse(pen, x + 100, y + 200, 60, 60);
                    // Set format of string.
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    Font drawFont = new Font("Arial", 10);
                    // Draw string to screen.
                    e.Graphics.DrawString(commit.Id.ToString().Substring(0, 7), drawFont, drawBrush, x + 80, y + 280);
                    date = commit.Author.When.ToLocalTime().ToString().Substring(0, 3) + commit.Author.When.ToLocalTime().ToString().Substring(8, 6);
                    e.Graphics.DrawString(date, drawFont, drawBrush, x + 80, y + 20);
                    // 
                    if (commit.Id.Equals(repo.Head.Tip.Id))
                    {
                        e.Graphics.DrawString("HEAD", drawFont, drawBrush, x + 80, y + 120);
                    }
                    x += 280;
                    foreach (var b in repo.Branches)
                    {
                        Debug.WriteLine($"branch: {b.FriendlyName} ");
                    }
                }
                Debug.WriteLine("loooool");
            }
        }
    }
}
