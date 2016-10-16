using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using System.Drawing.Imaging;

namespace ImageSlideShow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btn_StartSlideShow.Enabled = false;

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress: '" +
                    e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                            e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }

        private string txtBox_fileDirectoryText = "";
        private int frameNum = 0;
        private int curImageIndx = 0;
        private SortedList<int, string> listFiles;
        private String currentFileName = "";

        private void btn_OpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtBox_fileDirectoryText = fbd.SelectedPath;
                this.frameNum = 0;
                this.curImageIndx = 0;

                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.jpg");
                System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

                listFiles = new SortedList<int, string>();
                foreach (string file in files)
                {
                    int len = file.Length;
                    int pos = file.LastIndexOf("\\");
                    int key = int.Parse(file.Substring(pos + 1, len - 5 - pos));
                    listFiles.Add(key, file);
                }

                System.Windows.Forms.MessageBox.Show("First file: " + listFiles.Values[0].ToString(), "Message");
                currentFileName = listFiles.Values[0].ToString();
                if (currentFileName.Length > 4)
                {
                    Image img = Image.FromFile(currentFileName);
                    {
                        pictureBox1.Image = img;
                    }
                }
            }

            this.btn_StartSlideShow.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool isProcessStart = false;
        private bool isSavePicture = false;
        private Thread demoThread;

      
        delegate void SetImageCallback(int i);

        private void SetImage(int i)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pictureBox1.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                this.Invoke(d, new object[] { i });
            }
            else
            {
                currentFileName = listFiles.Values[i];
                this.pictureBox1.Image = Image.FromFile(currentFileName);
            }
        }

        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }

        private void btn_StartSlideShow_Click(object sender, EventArgs e)
        {
            this.btn_StartSlideShow.Text = "Сохранить изображение (нажать пробел)";
            if (!isProcessStart)
            {
                isProcessStart = true;
                //StartSlideShowProcess();	
                this.demoThread =
                new Thread(new ThreadStart(this.StartSlideShowProcess));

                this.demoThread.Start();
            }
            else
            {
                int indx = currentFileName.LastIndexOf("\\")+1;
                string path = this.txtBox_fileDirectoryText + "\\outPic\\";
                this.CreateIfMissing(path);
                this.pictureBox1.Image.Save(path + currentFileName.Substring(indx), ImageFormat.Jpeg);
            }
        }

        private void StartSlideShowProcess()
        {
            int count = this.listFiles.Keys.Count;

            // do some simple processing for 10 seconds
            for (int i = 1; i < count; i++)
            {
                // report the progress in percent
                // b.ReportProgress(i * 100 / count);
                this.SetImage(i);
                Thread.Sleep(200);
            }

            /*bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    label1.Text = "Finished!";
                    this.btn_StartSlideShow.Text = "Обработка закончена";
                    this.btn_StartSlideShow.Enabled = false;
                    this.isProcessStart = false;
                });
            */
        }
    }
}
