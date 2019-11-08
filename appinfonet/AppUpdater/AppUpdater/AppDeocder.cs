using Claunia.PropertyList;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUpdater
{
    public class AppDeocder
    {
        public static FastZip fz = new FastZip();
        /// <summary>
        /// 自定义的解压路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDecodePath(string path)
        {
            var targetPath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "Temp");
            var ext = Path.GetExtension(path);
            if (ext.Contains("ipa"))
            {
                targetPath = targetPath + "IOS";
            }
            else if (ext.Contains("apk"))
            {
                targetPath = targetPath + "Android";
            }
            return targetPath;
        }
        /// <summary>
        /// Payload的下一级文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDecodePayloadAppPath(string path)
        {
            string result = "";
            var payload = Path.Combine(GetDecodePath(path), "Payload");
            var payloadDir = new DirectoryInfo(payload);
            DirectoryInfo[] subdir = payloadDir.GetDirectories();
            if (subdir != null && subdir.Length >= 1)
            {
                DirectoryInfo app = subdir.First();
                result = Path.Combine(payload, app.Name);

            }
            return result;
        }
        /// <summary>
        /// Plist文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDecodePlistPath(string path)
        {
            return Path.Combine(GetDecodePayloadAppPath(path), "Info.plist");
        }
        /// <summary>
        /// App Icon 所在文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDecodeIconPath(string path, List<string> icons)
        {
            icons.Reverse();
            foreach (var item in icons)
            {
                var iconPath = Path.Combine(GetDecodePayloadAppPath(path), item) + "@2x.png";
                if (File.Exists(iconPath))
                {
                    return iconPath;
                }
                iconPath = Path.Combine(GetDecodePayloadAppPath(path), item) + "@3x.png";
                if (File.Exists(iconPath))
                {
                    return iconPath;
                }
            }
            return "";
        }

        /// <summary>
        /// 解压Zip
        /// </summary>
        /// <param name="zipFile">解压后存放路径</param>
        /// <param name="targetPath">Zip的存放路径</param>
        /// <returns></returns>
        public static bool ExtractZip(string zipFile, string targetPath = null)

        {
            if (string.IsNullOrWhiteSpace(targetPath))
            {
                targetPath = GetDecodePath(zipFile);
            }
            bool result = true;
            try
            {
                fz.ExtractZip(zipFile, targetPath, null);
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 读取并解析plist 文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IpaAppInfo ReadAndParsePlist(string path)
        {
            if (!Path.GetExtension(path).Contains("ipa"))
            {
                return null;
            }
            var plistPath = GetDecodePlistPath(path);
            try
            {
                FileInfo plist = new FileInfo(plistPath);
                NSDictionary rootDict = (NSDictionary)PropertyListParser.Parse(plist);

                IpaAppInfo ipa = new IpaAppInfo();
                ipa.Path = path;
                ipa.Size = GetApkIpaSize(path);
                ipa.CFBundleName = rootDict.ObjectForKey("CFBundleName").ToString();
                ipa.CFBundleShortVersionString = rootDict.ObjectForKey("CFBundleShortVersionString").ToString();
                ipa.CFBundleVersion = rootDict.ObjectForKey("CFBundleVersion").ToString();
                ipa.CFBundleIdentifier = rootDict.ObjectForKey("CFBundleIdentifier").ToString();
                // 图标信息
                var icons = (NSDictionary)rootDict.ObjectForKey("CFBundleIcons");
                if (icons != null)
                {
                    NSDictionary iconsDict = (NSDictionary)icons.ObjectForKey("CFBundlePrimaryIcon");
                    if (iconsDict != null)
                    {
                        NSArray iconsFiels = (NSArray)iconsDict.ObjectForKey("CFBundleIconFiles");
                        ipa.CFBundleIconFiles = new List<string>();
                        foreach (var item in iconsFiels)
                        {
                            ipa.CFBundleIconFiles.Add(item.ToString());
                        }
                        ipa.CFBundleIconName = iconsDict.ObjectForKey("CFBundleIconName").ToString();
                        ipa.CFBundleIconFullPath = GetDecodeIconPath(path, ipa.CFBundleIconFiles);
                    }
                }
                return ipa;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetApkIpaSize(string path)
        {
            string apkSize = "0 M";
            if (!File.Exists(path))
                return apkSize;

            FileInfo fi = new FileInfo(path);
            if (fi.Length >= 1024 * 1024)
            {
                apkSize = string.Format("{0:N2} M", fi.Length / (1024 * 1024f));
            }
            else
            {
                apkSize = string.Format("{0:N2} K", fi.Length / 1024f);
            }
            return apkSize;
        }


    }

    public class AppBaseInfo
    {
        /// <summary>
        /// 文件所在路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string Size { get; set; }
    }

    /// <summary>
    /// IPA 解析出来的对象
    /// </summary>
    public class IpaAppInfo : AppBaseInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string CFBundleName { get; set; }
        /// <summary>
        /// 版本号:1.0.0
        /// </summary>
        public string CFBundleShortVersionString { get; set; }
        /// <summary>
        /// build:1
        /// </summary>
        public string CFBundleVersion { get; set; }
        /// <summary>
        /// App Id
        /// </summary>
        public string CFBundleIdentifier { get; set; }
        /// <summary>
        /// 图标
        /// CFBundleIcons.CFBundlePrimaryIcon.CFBundleIconFiles
        /// </summary>
        public List<string> CFBundleIconFiles { get; set; }
        /// <summary>
        /// CFBundleIcons.CFBundlePrimaryIcon.CFBundleIconName
        /// </summary>
        public string CFBundleIconName { get; set; }
        /// <summary>
        /// App Icon 的完整路径
        /// </summary>
        public string CFBundleIconFullPath { get; set; }
    }
}
