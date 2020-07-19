using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AioCloud.Controller.Tool
{
    public class Guard
    {
        /// <summary>
        ///     进程
        /// </summary>
        public Process instance;

        /// <summary>
        ///     状态
        /// </summary>
        public Model.StatusInfo status;

        /// <summary>
        ///     日志名
        /// </summary>
        public string Name;

        /// <summary>
        ///     日志锁
        /// </summary>
        public Mutex Mutex;

        /// <summary>
        ///     绝对路径
        /// </summary>
        public string Location;

        /// <summary>
        ///     命令参数
        /// </summary>
        public string Arguments;

        /// <summary>
        ///     启动信息
        /// </summary>
        public ProcessStartInfo StartInfo;

        /// <summary>
        ///     判定启动
        /// </summary>
        public List<string> JudgmentStart;

        /// <summary>
        ///     判定停止
        /// </summary>
        public List<string> JudgmentStop = new List<string>()
        {
            "Failed",

            "Unable"
        };

        /// <summary>
        ///     自动重启
        /// </summary>
        public bool AutoRestart;

        /// <summary>
        ///     启用
        /// </summary>
        /// <param name="name">日志名</param>
        /// <param name="a">绝对路径</param>
        /// <param name="b">命令参数</param>
        /// <param name="c">启动信息</param>
        /// <param name="d">判定信息</param>
        /// <param name="autorestart">自动重启</param>
        /// <returns>是否成功</returns>
        public bool Enable(string name, string a, string b, ProcessStartInfo c, List<string> d, bool autorestart = false)
        {
            // 设置状态
            this.status = Model.StatusInfo.Starting;

            // 清理日志
            if (File.Exists($"Logs\\{this.Name}"))
            {
                File.Delete($"Logs\\{this.Name}");
            }

            // 创建日志锁
            this.Mutex = new Mutex();

            // 设置参数
            this.Name = name;
            this.Location = a;
            this.Arguments = b;
            this.StartInfo = c;
            this.JudgmentStart = d;
            this.AutoRestart = autorestart;

            // 执行启动
            return this.Start();
        }

        /// <summary>
        ///     禁用
        /// </summary>
        public void Disable()
        {
            // 设置状态
            this.status = Model.StatusInfo.Stopping;

            // 关闭进程
            if (this.instance != null)
            {
                try
                {
                    this.instance.Kill();
                    this.instance.WaitForExit();
                }
                catch (Exception e)
                {
                    this.Write(e.ToString());
                }
            }

            // 设置状态
            this.status = Model.StatusInfo.Stopped;

            // 释放锁
            this.Mutex.Close();
        }

        /// <summary>
        ///     启动
        /// </summary>
        /// <returns></returns>
        private bool Start()
        {
            // 设置参数
            this.instance = new Process
            {
                StartInfo = this.StartInfo,
                EnableRaisingEvents = true
            };
            this.instance.StartInfo.FileName = this.Location;
            this.instance.StartInfo.Arguments = this.Arguments;

            // 绑定事件
            this.instance.Exited += this.OnExited;
            this.instance.OutputDataReceived += this.OnOutputDataReceived;
            this.instance.ErrorDataReceived += this.OnOutputDataReceived;

            // 启动进程
            this.instance.Start();

            // 开始读取数据
            this.instance.BeginOutputReadLine();
            this.instance.BeginErrorReadLine();

            // 等待状态变更
            for (var i = 0; i < 10; i++)
            {
                // 睡眠 1 秒
                Thread.Sleep(1000);

                // 检查状态
                if (this.status == Model.StatusInfo.Started) return true;
            }

            // 写入超时日志
            this.Write("Start timeout");

            // 停止进程
            this.Disable();

            // 返回失败
            return false;
        }

        /// <summary>
        ///     重启
        /// </summary>
        /// <returns></returns>
        private void Restart()
        {
            this.Start();
        }

        /// <summary>
        ///     写入日志
        /// </summary>
        /// <returns></returns>
        private bool Write(string s)
        {
            // 锁定
            this.Mutex.WaitOne();

            // 检查是否为空
            if (String.IsNullOrWhiteSpace(s))
            {
                // 解锁
                this.Mutex.ReleaseMutex();

                return false;
            }

            try
            {
                // 写入日志
                File.AppendAllText($"Logs\\{this.Name}", s);

                // 解锁
                this.Mutex.ReleaseMutex();

                return true;
            }
            catch (Exception)
            {
                // 跳过
            }

            // 解锁
            this.Mutex.ReleaseMutex();

            return false;
        }

        /// <summary>
        ///     接收进程退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExited(object sender, EventArgs e)
        {
            // 检查状态
            if (this.status == Model.StatusInfo.Started)
            {
                // 检查是否开启自动重启
                if (this.AutoRestart)
                {
                    // 睡眠 200 毫秒
                    Thread.Sleep(200);

                    // 重启进程
                    this.Restart();
                }
            }
        }

        /// <summary>
        ///     接收输出数据
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">数据</param>
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // 写入日志
            if (!this.Write(e.Data)) return;

            // 检查启动
            if (this.status == Model.StatusInfo.Starting)
            {
                if (this.instance.HasExited)
                {
                    this.status = Model.StatusInfo.Stopped;

                    return;
                }

                for (int i = 0; i < this.JudgmentStart.Count; i++)
                {
                    if (e.Data.Contains(this.JudgmentStart[i]))
                    {
                        this.status = Model.StatusInfo.Started;

                        return;
                    }
                }

                for (int i = 0; i < this.JudgmentStop.Count; i++)
                {
                    if (e.Data.Contains(this.JudgmentStop[i]))
                    {
                        this.status = Model.StatusInfo.Stopped;

                        return;
                    }
                }
            }
        }
    }
}
