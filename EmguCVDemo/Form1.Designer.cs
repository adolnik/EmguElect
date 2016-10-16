using System;
using System.Drawing;
using System.Collections;
namespace EmguCVDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ResetInterestingRegions = new System.Windows.Forms.Button();
            this.txtBox_fileDirectory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_LoadFileList = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_skipNFrames = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numUpDown_Sens = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_SaveFrame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.numUpDown_WhitePixels = new System.Windows.Forms.NumericUpDown();
            this.btn_StartProcess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Sens)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_WhitePixels)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1372, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть видео файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(4, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1500, 800);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(949, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 67);
            this.button2.TabIndex = 2;
            this.button2.Text = "3. Тест параметров по настройке";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1500, 800);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выделите мышью интересующий участок видео";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(901, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "На рисунке ниже будет показан детектор движения";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBox_fileDirectory);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_LoadFileList);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 204);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Элементы управления";
            // 
            // btn_ResetInterestingRegions
            // 
            this.btn_ResetInterestingRegions.Location = new System.Drawing.Point(949, 37);
            this.btn_ResetInterestingRegions.Name = "btn_ResetInterestingRegions";
            this.btn_ResetInterestingRegions.Size = new System.Drawing.Size(191, 62);
            this.btn_ResetInterestingRegions.TabIndex = 8;
            this.btn_ResetInterestingRegions.Text = "2. Сбросить регионы интереса";
            this.btn_ResetInterestingRegions.UseVisualStyleBackColor = true;
            this.btn_ResetInterestingRegions.Click += new System.EventHandler(this.btn_ResetInterestingRegions_Click);
            // 
            // txtBox_fileDirectory
            // 
            this.txtBox_fileDirectory.Location = new System.Drawing.Point(231, 153);
            this.txtBox_fileDirectory.Name = "txtBox_fileDirectory";
            this.txtBox_fileDirectory.Size = new System.Drawing.Size(546, 26);
            this.txtBox_fileDirectory.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Файлы в директории";
            // 
            // btn_LoadFileList
            // 
            this.btn_LoadFileList.Location = new System.Drawing.Point(10, 25);
            this.btn_LoadFileList.Name = "btn_LoadFileList";
            this.btn_LoadFileList.Size = new System.Drawing.Size(893, 60);
            this.btn_LoadFileList.TabIndex = 5;
            this.btn_LoadFileList.Text = "1. Выбрать директорию с файлами flv";
            this.btn_LoadFileList.UseVisualStyleBackColor = true;
            this.btn_LoadFileList.Click += new System.EventHandler(this.btn_LoadFileList_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(231, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(546, 26);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(231, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(322, 26);
            this.textBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Название текущего файла";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Текущий номер кадра";
            // 
            // btn_skipNFrames
            // 
            this.btn_skipNFrames.Location = new System.Drawing.Point(1372, 301);
            this.btn_skipNFrames.Name = "btn_skipNFrames";
            this.btn_skipNFrames.Size = new System.Drawing.Size(245, 52);
            this.btn_skipNFrames.TabIndex = 7;
            this.btn_skipNFrames.Text = "Просто пропустить N кадров";
            this.btn_skipNFrames.UseVisualStyleBackColor = true;
            this.btn_skipNFrames.Click += new System.EventHandler(this.btn_skipNFrames_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(1163, 81);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numUpDown_Sens
            // 
            this.numUpDown_Sens.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDown_Sens.Location = new System.Drawing.Point(1163, 133);
            this.numUpDown_Sens.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpDown_Sens.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDown_Sens.Name = "numUpDown_Sens";
            this.numUpDown_Sens.Size = new System.Drawing.Size(271, 26);
            this.numUpDown_Sens.TabIndex = 9;
            this.numUpDown_Sens.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1159, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 20);
            this.label5.TabIndex = 200;
            this.label5.Text = "Чувствительность датчика к шуму";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1159, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Смотреть через N кадров";
            // 
            // btn_SaveFrame
            // 
            this.btn_SaveFrame.Location = new System.Drawing.Point(1372, 412);
            this.btn_SaveFrame.Name = "btn_SaveFrame";
            this.btn_SaveFrame.Size = new System.Drawing.Size(245, 54);
            this.btn_SaveFrame.TabIndex = 12;
            this.btn_SaveFrame.Text = "Сохранить кадр";
            this.btn_SaveFrame.UseVisualStyleBackColor = true;
            this.btn_SaveFrame.Visible = false;
            this.btn_SaveFrame.Click += new System.EventHandler(this.btn_SaveFrame_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 470);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(902, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 367);
            this.panel2.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1159, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 20);
            this.label8.TabIndex = 201;
            this.label8.Text = "Количество белых пикселей";
            // 
            // numUpDown_WhitePixels
            // 
            this.numUpDown_WhitePixels.Location = new System.Drawing.Point(1163, 190);
            this.numUpDown_WhitePixels.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDown_WhitePixels.Name = "numUpDown_WhitePixels";
            this.numUpDown_WhitePixels.Size = new System.Drawing.Size(120, 26);
            this.numUpDown_WhitePixels.TabIndex = 202;
            this.numUpDown_WhitePixels.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btn_StartProcess
            // 
            this.btn_StartProcess.Location = new System.Drawing.Point(949, 176);
            this.btn_StartProcess.Name = "btn_StartProcess";
            this.btn_StartProcess.Size = new System.Drawing.Size(191, 62);
            this.btn_StartProcess.TabIndex = 203;
            this.btn_StartProcess.Text = "4. Автопоиск c сохранением";
            this.btn_StartProcess.UseVisualStyleBackColor = true;
            this.btn_StartProcess.Click += new System.EventHandler(this.btn_StartProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1629, 1051);
            this.Controls.Add(this.btn_StartProcess);
            this.Controls.Add(this.numUpDown_WhitePixels);
            this.Controls.Add(this.btn_ResetInterestingRegions);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_SaveFrame);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numUpDown_Sens);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btn_skipNFrames);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_Sens)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_WhitePixels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private Point RectStartPoint;
        private Point tempEndPoint;
        private ArrayList ListRect = new ArrayList();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
               
        void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBox1.Image != null && ListRect.Count > 0)
            {
                foreach (Rectangle Rect in ListRect)
                {
                    if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                    {
                        e.Graphics.FillRectangle(selectionBrush, Rect);
                    }
                }
            }
        }
        void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                tempEndPoint = e.Location;
                Rectangle Rect = new Rectangle();
                Rect.Location = new Point(
                    Math.Min(RectStartPoint.X, tempEndPoint.X),
                    Math.Min(RectStartPoint.Y, tempEndPoint.Y));
                Rect.Size = new Size(
                    Math.Abs(RectStartPoint.X - tempEndPoint.X),
                    Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
                ListRect.Add(Rect);

                pictureBox1.Refresh();
            }
        }

        void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
          
            RectStartPoint = e.Location;
            Invalidate();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_skipNFrames;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numUpDown_Sens;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_SaveFrame;
        private System.Windows.Forms.Button btn_LoadFileList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBox_fileDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_ResetInterestingRegions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numUpDown_WhitePixels;
        private System.Windows.Forms.Button btn_StartProcess;
    }
}

