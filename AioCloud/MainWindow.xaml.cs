using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AioCloud
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        /// <summary>
        ///     状态信息
        /// </summary>
        public Model.StatusInfo StatusInfo = Model.StatusInfo.Waiting;

        /// <summary>
        ///     总流量
        /// </summary>
        public ulong Bandwidth = 0;

        /// <summary>
        ///     更新状态
        /// </summary>
        public void UpdateStatus()
        {
            var data = "";
            switch (this.StatusInfo)
            {
                case Model.StatusInfo.Waiting:
                    data = "Waiting";
                    break;
                case Model.StatusInfo.Starting:
                    data = "Starting";
                    break;
                case Model.StatusInfo.Stopping:
                    data = "Stopping";
                    break;
                case Model.StatusInfo.Stopped:
                    data = "Stopped";
                    break;
                case Model.StatusInfo.Terminating:
                    data = "Terminating";
                    break;
            }

            this.StatusLabel.Content = String.Format("{0}{1}{2}", Utils.i18N.Get("Status"), Utils.i18N.Get(": "), data);
        }

        /// <summary>
        ///     更新状态
        /// </summary>
        /// <param name="message">自定义状态信息</param>
        public void UpdateStatus(string message)
        {
            this.StatusLabel.Content = String.Format("{0}{1}{2}", Utils.i18N.Get("Status"), Utils.i18N.Get(": "), Utils.i18N.Get(message));
        }

        /// <summary>
        ///     更新状态
        /// </summary>
        /// <param name="message">自定义状态信息</param>
        public void UpdateStatus(params string[] message)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                sb.Append(Utils.i18N.Get(message[i]));
            }

            this.StatusLabel.Content = String.Format("{0}{1}{2}", Utils.i18N.Get("Status"), Utils.i18N.Get(": "), sb.ToString());
        }

        /// <summary>
        ///     更新流量信息
        /// </summary>
        /// <param name="uplink">当前上传速率（Byte）</param>
        /// <param name="downlink">当前下载速率（Byte）</param>
        public void UpdateBandwidth(ulong uplink, ulong downlink)
        {
            this.UPSpeedLabel.Content = String.Format("{0}{1}{2}/s", "↑", Utils.i18N.Get(": "), Utils.Bandwidth.Compute(uplink));
            this.DLSpeedLabel.Content = String.Format("{0}{1}{2}/s", "↓", Utils.i18N.Get(": "), Utils.Bandwidth.Compute(downlink));

            this.Bandwidth += uplink + downlink;
            this.BandwidthLabel.Content = String.Format("{0}{1}{2}", Utils.i18N.Get("Bandwidth"), Utils.i18N.Get(": "), Utils.Bandwidth.Compute(this.Bandwidth));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 加载配置
            Global.Load();

            // 更新状态
            this.UpdateStatus();

            // 更新流量
            this.UpdateBandwidth(114514, 114514);
        }

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            // 保存配置
            // Global.Save();
        }

        private void LaunchWebsite_Click(object sender, RoutedEventArgs e)
        {
            Process.Start((sender as Button).ToolTip as String);
        }
    }
}
