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

namespace App
{
    public partial class Form1 : Form
    {
        DirectoryWatch CurrentDirWatch;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("settings.inf"))
            {
                CurrentDirWatch = (DirectoryWatch)DirectoryWatch.ReadFromFile("settings.inf");
            }
            else
            {
                CurrentDirWatch = new DirectoryWatch();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CurrentDirWatch.Data.Name = textBox1.Text;
        }
    }

    public struct DirectoryInfo
    {
        public string Name;
        public string[] Files;
    }

    public class DirectoryWatch : SerializableTree<DirectoryInfo>
    {

    }
}
