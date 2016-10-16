using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.VideoSurveillance;
using System.IO;
using System.Drawing.Imaging;
using Emgu.CV.Util;

namespace EmguCVDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' || e.KeyChar == 'ы')
            {
                pictureBox1.Image.Save(this.txtBox_fileDirectory.Text + "/" + this.frameNum + ".jpg", ImageFormat.Jpeg);
            }
        }
        private string currentFileName = "";
        private SortedList<String, String> listFiles; 
        private Mat prevFrame;
        private Emgu.CV.Capture cap;
        private BackgroundSubtractor _forgroundDetector;
        private int curImageIndx = 0;

        private int frameNum = 0;
        private void updateFrameNumber(int i = 1) 
        {
            frameNum = frameNum + i;
            this.textBox1.Text = frameNum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            OpenFileDialog openPic = new OpenFileDialog();
            //openPic.Filter = ".avi";
            if (openPic.ShowDialog() == DialogResult.OK)
            {
                currentFileName = openPic.FileName;
                this.frameNum = 0;
              
                if (currentFileName.Length > 4) 
                {
                    cap = new Emgu.CV.Capture(currentFileName);
                    prevFrame = cap.QueryFrame();
                    updateFrameNumber();
                    textBox2.Text = currentFileName;
                    pictureBox1.Image = prevFrame.Bitmap.Clone() as Bitmap;
                }
            }
        }
        //
        /*  VideoWriter captureOutput = new VideoWriter(@"test.avi",15,
        (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS),
        (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH),
        (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT),
        true);*/
        private void button2_Click(object sender, EventArgs e)
        {
            bool b_NeedStop = FindNextFrame();
            if (!b_NeedStop)
            {
                if (nextFrame != null)
                {
                    nextFrame.Bitmap.Save(this.txtBox_fileDirectory.Text + "/" + this.frameNum + ".jpg", ImageFormat.Jpeg);
                }
                else
                {
                    prevFrame.Bitmap.Save(this.txtBox_fileDirectory.Text + "/" + this.frameNum + ".jpg", ImageFormat.Jpeg);
                }

                //prevFrame.Dispose();
                printToFile();
            }
        }

        private bool FindNextFrame()
        {
            bool b_NeedStop = false;
            if (currentFileName.Length > 4 && cap != null)
            {
                using (Mat image = cap.QueryFrame())
                {
                    SetPrevFrame();
                    Mat nextFrame = image;
                    if (image == null)
                        nextFrame = GetNextFile();
                    updateFrameNumber();

                    bool stop = false;
                    while (nextFrame != null && !stop)
                    {
                        SetPrevFrame();
                        SkipNFrames();

                        if (nextFrame != null && testDiff())
                        {
                            if (!b_AutoRun)
                            {
                                pictureBox1.Image = nextFrame.Bitmap.Clone() as Bitmap;
                                pictureBox1.Refresh();
                            }

                            stop = true;
                        }

                        if (b_listFinished) 
                        {
                            break;
                        }
                    }

                    if (nextFrame == null && b_listFinished)
                    {
                        button2.Enabled = false;
                        MessageBox.Show("Обработка окончена");
                        //pictureBox1.Image = prevFrame.Bitmap.Clone() as Bitmap;
                        b_NeedStop = true;
                    }
                    else
                    {
                        SetPrevFrame();
                        if (!b_AutoRun)
                            pictureBox1.Image = nextFrame.Bitmap.Clone() as Bitmap;
                    }

                    if (!b_AutoRun)
                        pictureBox1.Refresh();
                }
            }

            return b_NeedStop;
        }

        private SearchResult curSearchResult = new SearchResult();

        private bool testDiff()
        {
             if (_forgroundDetector == null)
             {
                //Emgu.CV.O
                _forgroundDetector = new BackgroundSubtractorMOG2(20,16f,true);
             }

            bool result = false;
            using (Mat _forgroundMask = new Mat())
            {
                if (nextFrame != null)
                    _forgroundDetector.Apply(nextFrame, _forgroundMask);
                else
                {
                    return
                        false;
                }

                decimal backGroundCounter = 0;
                decimal whiteColorCounter = 0;
                
                //double delta = 0.01;
                decimal deltaCounter = this.numUpDown_Sens.Value;
                decimal whitePixelsSettings = this.numUpDown_WhitePixels.Value;
                int colorLimit = 200;
                using (Bitmap img = _forgroundMask.Bitmap)
                {
                    using (Bitmap origImg = nextFrame.Bitmap)
                    {
                        curSearchResult.RGBprofile = "";
                        curSearchResult.RGBprofileXY = "";

                        foreach (Rectangle Rect in ListRect)
                        {
                            for (int i = 0; i < Rect.Height; ++i)
                                for (int j = 0; j < Rect.Width; ++j)
                                {
                                    //if (_forgroundMask.Bitmap.GetPixel(Rect.X + j, Rect.Y + i).GetBrightness() > delta)
                                    if (img.GetPixel(Rect.X + j, Rect.Y + i).ToArgb() != -16777216)
                                    {
                                        backGroundCounter++;
                                        if (origImg.GetPixel(Rect.X + j, Rect.Y + i).R > colorLimit
                                            && origImg.GetPixel(Rect.X + j, Rect.Y + i).G > colorLimit
                                            && origImg.GetPixel(Rect.X + j, Rect.Y + i).B > colorLimit
                                            )
                                        {
                                            whiteColorCounter++;
                                            curSearchResult.RGBprofile += string.Format("(R={0},G={1},B={2})|",
                                                origImg.GetPixel(Rect.X + j, Rect.Y + i).R,
                                                origImg.GetPixel(Rect.X + j, Rect.Y + i).G,
                                                origImg.GetPixel(Rect.X + j, Rect.Y + i).B);
                                            curSearchResult.RGBprofileXY += string.Format("(X={0},Y={1})|", Rect.X + j, Rect.Y + i);
                                        }
                                    }
                                }
                        }
                    }
                }

                if (backGroundCounter > deltaCounter && whiteColorCounter > whitePixelsSettings)
                {
                    result = true;
                    if (!b_AutoRun)
                    {
                        pictureBox2.Image = _forgroundMask.Bitmap.Clone() as Bitmap;
                        pictureBox2.Refresh();
                    }

                    curSearchResult.backGroundCounter = backGroundCounter;
                    curSearchResult.frameNumber = this.frameNum;
                    curSearchResult.whiteColorCounter = whiteColorCounter;
                }

                _forgroundMask.Dispose();
            }

            return result;
        }

        private void printToFile() 
        {
            string path = this.txtBox_fileDirectory.Text + "/profile.txt";
            string pathPhoto = this.txtBox_fileDirectory.Text + "/profilePict.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("FrameNumber; backGroundCounter; whiteColorCounter; RGBprofile; RGBprofileXY");
                }
            }

            if (!File.Exists(pathPhoto))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathPhoto))
                {
                    sw.WriteLine("FrameNumber; FileNumber");
                }
            }

            
            if (curSearchResult != null)
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(curSearchResult.getStringToSaveInFile());
                }

                using (StreamWriter sw2 = File.AppendText(pathPhoto))
                {
                    sw2.WriteLine(frameNum.ToString() +";"+currentFileName);
                }

            }
        }

        private bool b_AutoRun = false;

        private void btn_skipNFrames_Click(object sender, EventArgs e)
        {
            if (currentFileName.Length > 4 && cap != null)
            {
                SetPrevFrame();
                SkipNFrames();

                if (nextFrame == null)
                {
                    button2.Enabled = false;
                    if (!b_AutoRun)
                        pictureBox1.Image = prevFrame.Bitmap.Clone() as Bitmap;
                }
                else 
                {
                    SetPrevFrame();
                    if (!b_AutoRun)
                        pictureBox1.Image = nextFrame.Bitmap.Clone() as Bitmap;
                }

                if (!b_AutoRun)
                    pictureBox1.Refresh();
            }
        }

        private Mat nextFrame = null;
        private void SkipNFrames()
        {
            decimal stop = numericUpDown1.Value;
            while (nextFrame != null && stop > 0)
            {
                stop--;
                try
                {
                    using(Mat image = cap.QueryFrame())
                    {
                        if (stop == 0 && image != null)
                        {
                            SetPrevFrame();
                            nextFrame = image.Clone();
                        }
                        if (image == null)
                        {
                            nextFrame = null;
                            break;
                        }
                    }
                }
                catch {
                    SetPrevFrame();
                    nextFrame = null; 
                }

                updateFrameNumber();
            }

            if (nextFrame == null)
            {
                SetPrevFrame();
                nextFrame = GetNextFile();
            }
        }

        private void SetPrevFrame()
        {
            if (nextFrame == null)
                return;
            if (prevFrame != null && prevFrame.Ptr != nextFrame.Ptr)
                prevFrame.Dispose();
            if (prevFrame.Ptr != nextFrame.Ptr && nextFrame != null)
                prevFrame = nextFrame;
        }

        private bool b_listFinished = false;
        private Mat GetNextFile()
        {
            curImageIndx++;
            b_listFinished = true;
            if (curImageIndx < listFiles.Count && curImageIndx >= 0)
            {
                b_listFinished = false;
                currentFileName = listFiles.Values[curImageIndx];
                if (currentFileName.Length > 4)
                {
                    if (cap != null)
                    {
                        cap.Dispose();
                        cap = null;
                        GC.Collect(GC.MaxGeneration,GCCollectionMode.Forced);
                        GC.WaitForFullGCComplete();
                    }

                    cap = new Emgu.CV.Capture(currentFileName);
                    //System.Threading.Thread.Sleep(1000);
                    //while(true)
                        try
                        {
                            nextFrame = cap.QueryFrame();
                            //break;
                        }
                        catch(CvException cf) {
                            /// Занятый ресурс - наведена мышка
                            cap.Dispose();
                            cap = null;
                            GC.Collect();
                            //Emgu.CV.Capture.CaptureModuleType.
                            cap = new Emgu.CV.Capture(currentFileName);
                            string str = cf.ErrorMessage;
                        }
                    //updateFrameNumber();
                    textBox2.Text = currentFileName;
                    if (!b_AutoRun)
                        pictureBox1.Image = prevFrame.Bitmap.Clone() as Bitmap;
                }
            }
            return nextFrame;
        }

        private void btn_SaveFrame_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(this.txtBox_fileDirectory.Text + "/" + this.frameNum + ".jpg", ImageFormat.Jpeg);
        }

        private void btn_LoadFileList_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtBox_fileDirectory.Text = fbd.SelectedPath;
                this.frameNum = 0;
                this.curImageIndx = 0;

                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.flv");
                System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

                listFiles = new SortedList<string,string>();
                foreach (string file in files) 
                {
                    listFiles.Add(file, file);
                }

                System.Windows.Forms.MessageBox.Show("First file: " + listFiles.Values[0].ToString(), "Message");
                currentFileName = listFiles.Values[0].ToString();
                if (currentFileName.Length > 4)
                {
                    cap = new Emgu.CV.Capture(currentFileName);
                    prevFrame = cap.QueryFrame();
                    updateFrameNumber();
                    textBox2.Text = currentFileName;
                    pictureBox1.Image = prevFrame.Bitmap.Clone() as Bitmap;
                }
            }
        }

        private void btn_ResetInterestingRegions_Click(object sender, EventArgs e)
        {
            ListRect = new System.Collections.ArrayList();
        }

        private void btn_StartProcess_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            bool b_NeedStop = false;
            b_AutoRun = true;
            nextFrame = cap.QueryFrame();

            while (!b_NeedStop)
            {
                b_NeedStop = FindNextFrame();
                if (!b_NeedStop) 
                {
                    if (nextFrame != null && ((int)nextFrame.Ptr != 0))
                    {
                        nextFrame.Bitmap.Save(this.txtBox_fileDirectory.Text + "/" + this.frameNum + ".jpg", ImageFormat.Jpeg);
                    }
                    else if ((int)prevFrame.Ptr != 0)
                    {
                        prevFrame.Bitmap.Save(this.txtBox_fileDirectory.Text + "/" + this.frameNum + ".jpg", ImageFormat.Jpeg);
                    }
                    
                    prevFrame.Dispose();
                    printToFile();
                }
            }
            b_AutoRun = false;
            button2.Enabled = true;
        }
    }
}
