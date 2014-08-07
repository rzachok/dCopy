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

namespace dCopy
{
    public partial class Form1 : Form
    {
        string srcDir = @"c:\inboundftp";
        string dstDir = @"c:\dest";
        public Form1()
        {
            InitializeComponent();
        }
        private void WalkDirectoryTree(string srcPath, string dstPath)
        {
            string srcFile = "";
            string dstFile = "";
            
            if(!System.IO.Directory.Exists(srcPath))
                return;
            if (!System.IO.Directory.Exists(dstPath))
            {
                System.IO.Directory.CreateDirectory(dstPath);
            }

            string[] filenames = System.IO.Directory.GetFiles(srcPath);
            foreach (string file in filenames)
            {
                string fi = Path.GetFileName(file);
                srcFile = Path.Combine(srcPath, fi);
                dstFile = Path.Combine(dstPath, fi);
                if (File.Exists(dstFile))
                    continue;
                File.Copy(srcFile, dstFile);
                textBox1.Text += fi + "\r\n";
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subFolder = "";
            string folder1 = "";
            string folder2 = "";
            int i = 0;
            string[] dirInfoArray = System.IO.Directory.GetDirectories(srcDir);
            for(i=0; i<dirInfoArray.Length; i++)
            {
                subFolder = Path.GetFileName(dirInfoArray[i]);
                folder1 = Path.Combine(srcDir, subFolder);
                folder2 = Path.Combine(dstDir, subFolder);
                WalkDirectoryTree(folder1, folder2);
            }

        }

    }
}
