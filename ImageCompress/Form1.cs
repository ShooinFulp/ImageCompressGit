using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace ImageCompress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //开始停止开关
        private bool isStop = false;
        //文件夹选择
        private FolderBrowserDialog fbd = new FolderBrowserDialog();
        //上一次结束的索引
        private int lastIndex = 0;

        /// <summary>
        /// 选择图片路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            this.txtPath.Text = SelectFolderPath("选择图片位置");
        }

        /// <summary>
        /// 选择压缩后图片保存位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectNewPath_Click(object sender, EventArgs e)
        {
            this.txtNewPath.Text = SelectFolderPath("选择压缩后图片保存位置");
        }

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompress_Click(object sender, EventArgs e)
        {
            //开关打开
            isStop = false;
            //获取路径下所有图片信息
            var path = txtPath.Text;
            if (path.Equals("")) return;
            //路径转文件信息
            FileInfo[] fileInfoList = Path2FileList(path);

            //获取大于100k的图片
            List<FileInfo> pathList = GetGreater100KImageFile(fileInfoList, this.txtMemory.Text);

            string savePath = this.txtNewPath.Text;//保存路径
            if (savePath.Equals("")) return;

            int level = Convert.ToInt32(this.txtLevel.Text.Equals("") ? "0" : this.txtLevel.Text);//清晰度

            //开始压缩
            Thread thread = new Thread(new ThreadStart(() =>
            ComPress(pathList, savePath, level)
            ));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="pathList">压缩文件列表</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="level">压缩质量   0-100    0为最低画质   100为最高画质</param>
        private void ComPress(List<FileInfo> pathList, string savePath, int level)
        {

            int compressCount = 0;//成功压缩次数
            List<string> newFilePath = new List<string>();//新图片路径
            int onceCount = Convert.ToInt32(this.txtCount.Text);//筛选内存

            foreach (var imagePath in pathList)
            {
                //停止压缩
                if (isStop) break;

                Bitmap bitmap = new Bitmap(imagePath.FullName);
                string newFullName = savePath + "\\" + imagePath.Name;
                newFilePath.Add(newFullName);
                ImageHelper.Compress(bitmap, newFullName, level, imagePath.Extension);
                bitmap.Dispose();
                compressCount++;
                //显示当前操作的记录日志
                ShowActiveState(compressCount, imagePath, newFullName);

                //如果不是第一次   则进入判断是否进行删除移动操作
                if (compressCount == 0) continue;


                //如果实际图片数量小于输入图片数量且压缩完成   则直接移动删除图片
                if (onceCount > pathList.Count && compressCount == pathList.Count)
                {
                    DeleteOldFileAndMoveNewFile(pathList, newFilePath, onceCount);

                    ShowState(pathList, compressCount);

                    return;
                }
                //如果压缩到达了输入的个数则进行删除已经压缩过的原图片    然后移动图片至原图片目录
                if (compressCount % onceCount != 0) continue;
                DeleteOldFileAndMoveNewFile(pathList, newFilePath, onceCount);

                ShowState(pathList, compressCount);

            }
            //删除移动剩余的图片
            DeleteOldFileAndMoveNewFile(pathList, newFilePath, newFilePath.Count);
            ShowState(pathList, compressCount);

        }

        /// <summary>
        /// 显示当前操作的记录日志
        /// </summary>
        /// <param name="compressCount"></param>
        /// <param name="imagePath"></param>
        /// <param name="newFullName"></param>
        private void ShowActiveState(int compressCount, FileInfo imagePath, string newFullName)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
            //显示操作日志
            lbOutText.Items.Add(string.Format(@"{2}：原图片路径{0}        压缩后图片路径{1};", imagePath.FullName, newFullName, compressCount))
                ));
            }
        }

        /// <summary>
        /// 显示状态
        /// </summary>
        /// <param name="pathList"></param>
        /// <param name="compressCount"></param>
        private void ShowState(List<FileInfo> pathList, int compressCount)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
            //显示结果
            lblResult.Text = string.Format(@"
                 总共{0}个图片；
                 成功压缩{1}个图片；
            ", pathList.Count, compressCount)
                ));
            }
            else
            {
                //显示结果
                lblResult.Text = string.Format(@"
                 总共{0}个图片；
                 成功压缩{1}个图片；
            ", pathList.Count, compressCount);
            }
        }

        /// <summary>
        /// 删除旧图片    移动新图片至旧文件中
        /// </summary>
        /// <param name="pathList"></param>
        /// <param name="newFilePath"></param>
        /// <param name="onceCount"></param>
        private void DeleteOldFileAndMoveNewFile(List<FileInfo> pathList, List<string> newFilePath, int onceCount)
        {
            int count = onceCount + lastIndex;//执行到的索引
            for (int i = lastIndex; i < count; i++)
            {
                //如果索引大于本身长度则跳出循环
                if (i >= pathList.Count) break;

                string oldFullName = pathList[i].FullName;
                //删除集合中当前元素
                // pathList.RemoveAt(i);
                //删除文件
                File.Delete(oldFullName);
                //移动文件
                File.Move(newFilePath[i], oldFullName);
            }
            //清空新路径
            // newFilePath.Clear();
            //最后一次执行的数量设置为下一次的开始索引
            lastIndex = count;
        }

        /// <summary>
        /// 筛选大于100k的jpg.png图片
        /// </summary>
        /// <param name="fileInfoList">文件数组</param>
        /// <returns>List<FileInfo> </returns>
        private static List<FileInfo> GetGreater100KImageFile(FileInfo[] fileInfoList, string memory)
        {
            List<FileInfo> pathList = new List<FileInfo>();

            int intMemory = Convert.ToInt32(memory) * 102400;

            foreach (FileInfo fileInfo in fileInfoList)
            {
                //小于100k不压缩
                if (fileInfo.Length < intMemory) continue;

                var extension = fileInfo.Extension;
                if (extension.Equals(ImageTypeEnum.PNG) || extension.Equals(ImageTypeEnum.JPGE) || extension.Equals(ImageTypeEnum.JPG))
                {
                    pathList.Add(fileInfo);
                }
            }

            return pathList;
        }


        /// <summary>
        /// 路径转FileInfo
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>FileInfo[]</returns>
        private FileInfo[] Path2FileList(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfoList = directoryInfo.GetFiles();
            return fileInfoList;
        }

        /// <summary>
        /// 选择目录路径
        /// </summary>
        /// <returns></returns>
        private string SelectFolderPath(string message)
        {
            fbd.Description = message;
            DialogResult dialogResult = fbd.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            return "";
        }

        /// <summary>
        /// 停止压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopCompress_Click(object sender, EventArgs e)
        {
            isStop = true;
            this.lbOutText.Items.Clear();
            this.lblResult.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            this.Dispose();
        }
    }
}
