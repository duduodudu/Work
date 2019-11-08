namespace AppUpdater
{
    partial class MainForm
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
            this.deocde_ios = new System.Windows.Forms.Button();
            this.decode_android = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ios_CFBundleIconFiles = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ios_CFBundleVersion = new System.Windows.Forms.Label();
            this.ios_CFBundleShortVersionString = new System.Windows.Forms.Label();
            this.ios_CFBundleName = new System.Windows.Forms.Label();
            this.choose_file = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ios_CFBundleIconFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // deocde_ios
            // 
            this.deocde_ios.Location = new System.Drawing.Point(119, 12);
            this.deocde_ios.Name = "deocde_ios";
            this.deocde_ios.Size = new System.Drawing.Size(75, 23);
            this.deocde_ios.TabIndex = 0;
            this.deocde_ios.Text = "ios解析";
            this.deocde_ios.UseVisualStyleBackColor = true;
            this.deocde_ios.Click += new System.EventHandler(this.Deocde_ios_Click);
            // 
            // decode_android
            // 
            this.decode_android.Location = new System.Drawing.Point(588, 12);
            this.decode_android.Name = "decode_android";
            this.decode_android.Size = new System.Drawing.Size(75, 23);
            this.decode_android.TabIndex = 1;
            this.decode_android.Text = "android";
            this.decode_android.UseVisualStyleBackColor = true;
            this.decode_android.Click += new System.EventHandler(this.Decode_android_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ios_CFBundleIconFiles);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ios_CFBundleVersion);
            this.panel1.Controls.Add(this.ios_CFBundleShortVersionString);
            this.panel1.Controls.Add(this.ios_CFBundleName);
            this.panel1.Location = new System.Drawing.Point(26, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 330);
            this.panel1.TabIndex = 2;
            // 
            // ios_CFBundleIconFiles
            // 
            this.ios_CFBundleIconFiles.Location = new System.Drawing.Point(24, 159);
            this.ios_CFBundleIconFiles.Name = "ios_CFBundleIconFiles";
            this.ios_CFBundleIconFiles.Size = new System.Drawing.Size(144, 138);
            this.ios_CFBundleIconFiles.TabIndex = 6;
            this.ios_CFBundleIconFiles.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "build";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "name";
            // 
            // ios_CFBundleVersion
            // 
            this.ios_CFBundleVersion.AutoSize = true;
            this.ios_CFBundleVersion.Location = new System.Drawing.Point(58, 116);
            this.ios_CFBundleVersion.Name = "ios_CFBundleVersion";
            this.ios_CFBundleVersion.Size = new System.Drawing.Size(95, 12);
            this.ios_CFBundleVersion.TabIndex = 2;
            this.ios_CFBundleVersion.Text = "CFBundleVersion";
            // 
            // ios_CFBundleShortVersionString
            // 
            this.ios_CFBundleShortVersionString.AutoSize = true;
            this.ios_CFBundleShortVersionString.Location = new System.Drawing.Point(54, 78);
            this.ios_CFBundleShortVersionString.Name = "ios_CFBundleShortVersionString";
            this.ios_CFBundleShortVersionString.Size = new System.Drawing.Size(161, 12);
            this.ios_CFBundleShortVersionString.TabIndex = 1;
            this.ios_CFBundleShortVersionString.Text = "CFBundleShortVersionString";
            // 
            // ios_CFBundleName
            // 
            this.ios_CFBundleName.AutoSize = true;
            this.ios_CFBundleName.Location = new System.Drawing.Point(54, 41);
            this.ios_CFBundleName.Name = "ios_CFBundleName";
            this.ios_CFBundleName.Size = new System.Drawing.Size(77, 12);
            this.ios_CFBundleName.TabIndex = 0;
            this.ios_CFBundleName.Text = "CFBundleName";
            // 
            // choose_file
            // 
            this.choose_file.Location = new System.Drawing.Point(26, 12);
            this.choose_file.Name = "choose_file";
            this.choose_file.Size = new System.Drawing.Size(75, 23);
            this.choose_file.TabIndex = 3;
            this.choose_file.Text = "选择文件";
            this.choose_file.UseVisualStyleBackColor = true;
            this.choose_file.Click += new System.EventHandler(this.Choose_file_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.choose_file);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.decode_android);
            this.Controls.Add(this.deocde_ios);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ios_CFBundleIconFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deocde_ios;
        private System.Windows.Forms.Button decode_android;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ios_CFBundleShortVersionString;
        private System.Windows.Forms.Label ios_CFBundleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ios_CFBundleVersion;
        private System.Windows.Forms.PictureBox ios_CFBundleIconFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choose_file;
    }
}