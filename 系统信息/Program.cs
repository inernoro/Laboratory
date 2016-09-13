using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 系统信息
{
    class Program
    {
        static void Main(string[] args)
        {

            //获取操作系统版本(PC,PDA均支持) 
            var os = Environment.OSVersion;
            //获取应用程序当前目录(PC支持) 
            var currentDirectory = Environment.CurrentDirectory;
            //列举本地硬盘驱动器(PC支持) 
            var strDrives = Environment.GetLogicalDrives();
            var version = Environment.Version;
            //获取机器名(PC支持) 
            var name = Environment.MachineName;
            ////获取当前环境换行符(PC支持) 
            var line = Environment.NewLine;
            ////获取处理器个数(PC支持) 
            var cpu = Environment.SystemDirectory;
            ////获取当前登录用户(PC支持) 
            var username = Environment.UserName;
            //.获取系统环境变量(PC支持) 
            var dict = Environment.GetEnvironmentVariables();
            //.设置环境变量(PC支持) 
            Environment.SetEnvironmentVariable("Path", "Test");
            //.获取域名(PC支持) 
            var strUser = Environment.UserDomainName;
            //.获取截至到当前时间，操作系统启动的毫秒数(PDA,PC均支持) 
            var tick = Environment.TickCount.ToString();
            //.映射到当前进程的物理内存数 
            var monry = Environment.WorkingSet.ToString();

            var CommandLine = Environment.CommandLine;
            var CurrentDirectory = Environment.CurrentDirectory;
            var CurrentManagedThreadId = Environment.CurrentManagedThreadId;
            var ExitCode = Environment.ExitCode;
            var HasShutdownStarted = Environment.HasShutdownStarted;
            var Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
            var Is64BitProcess = Environment.Is64BitProcess;
            var MachineName = Environment.MachineName;
            var NewLine = Environment.NewLine;
            var OSVersion = Environment.OSVersion;
            var WorkingSet = Environment.WorkingSet;
            var UserName = Environment.UserName;
            var UserInteractive = Environment.UserInteractive;
            var UserDomainName = Environment.UserDomainName;
            var StackTrace = Environment.StackTrace;
            var TickCount = Environment.TickCount;
            var ProcessorCount = Environment.ProcessorCount;
            var SystemPageSize = Environment.SystemPageSize;
            var SystemDirectory = Environment.SystemDirectory;

        }
    }
}
