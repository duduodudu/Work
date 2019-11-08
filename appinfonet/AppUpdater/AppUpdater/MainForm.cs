using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUpdater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void Deocde_ios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_filePath) || !Path.GetExtension(_filePath).Contains("ipa"))
            {
                Choose_file_Click(null, null);
                return;
            }
            if (AppDeocder.ExtractZip(_filePath))
            {
                IpaAppInfo ipa = AppDeocder.ReadAndParsePlist(_filePath);
                if (ipa != null)
                {
                    ios_CFBundleName.Text = ipa.CFBundleName;
                    ios_CFBundleShortVersionString.Text = ipa.CFBundleShortVersionString;
                    ios_CFBundleVersion.Text = ipa.CFBundleVersion;
                    if (!string.IsNullOrWhiteSpace(ipa.CFBundleIconFullPath))
                    {
                        ios_CFBundleIconFiles.Image = Image.FromFile(ipa.CFBundleIconFullPath);
                    }
                }
            }
        }

        private void Decode_android_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(_filePath) || !Path.GetExtension(_filePath).Contains("apk"))
            {
                Choose_file_Click(null, null);
                return;
            }
            ApkDecoder apkDecoder = new ApkDecoder(_filePath);
            apkDecoder.InfoParsedEvent += new Action<ApkDecoder>(apkDecoder_InfoParsed);
            apkDecoder.AaptNotFoundEvent += new MethodInvoker(apkDecoder_AaptNotFound);
        }
        private void apkDecoder_InfoParsed(ApkDecoder apkDecoder)
        {
            this.BeginInvoke((Action)(() =>
            {
                ios_CFBundleName.Text = apkDecoder.AppName;
                ios_CFBundleShortVersionString.Text = apkDecoder.AppVersion;
                ios_CFBundleVersion.Text = apkDecoder.AppVersionCode;
                ios_CFBundleIconFiles.Image = apkDecoder.AppIcon;
            }));
            
        }

        private void apkDecoder_AaptNotFound()
        {
            MessageBox.Show("Fail!Aapt.exe Not Found");
        }


        private string _filePath;
        private void Choose_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择软件安装包";
            //设置要选择的文件的类型
            fileDialog.Filter = "所有文件(*apk,*ipa)|*.apk;*.ipa;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = fileDialog.FileName;//返回文件的完整路径                
            }
        }
    }
}
