using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
//using the Compent Comspac

namespace DownloadFile
{
    public class IcSharpZipCodeTest
    {
        /**//// <summary>
        /// 实现压缩功能
        /// </summary>
        /// <param name="filenameToZip">要压缩文件(绝对文件路径)</param>
        /// <param name="zipedfiledname">压缩(绝对文件路径)</param>
        /// <param name="compressionLevel">压缩比</param>
        /// <param name="password">加密密码</param>
        /// <param name="comment">压缩文件描述</param>
        /// <returns>异常信息</returns>
        public static string MakeZipFile(string[] filenameToZip, string zipedfiledname, int compressionLevel,
            string password, string comment)
        {
            try
            {
                //使用正则表达式-判断压缩文件路径
                var newRegex = new System.Text.
                    RegularExpressions.Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w   ]*.*))");
                if (!newRegex.Match(zipedfiledname).Success)
                {
                    File.Delete(zipedfiledname);
                    return "压缩文件的路径有误!";
                }
                //创建ZipFileOutPutStream
                var newzipstream = new ZipOutputStream(File.Open(zipedfiledname,
                    FileMode.OpenOrCreate));

                //判断Password
                if (!string.IsNullOrEmpty(password))
                {
                    newzipstream.Password = password;
                }
                if (!string.IsNullOrEmpty(comment))
                {
                    newzipstream.SetComment(comment);
                }
                //设置CompressionLevel
                newzipstream.SetLevel(compressionLevel); //-查看0 - means store only to 9 - means best compression 

                //执行压缩
                foreach (var filename in filenameToZip)
                {
                    var newstream = File.OpenRead(filename);//打开预压缩文件
                    //判断路径
                    if (!newRegex.Match(zipedfiledname).Success)
                    {
                        File.Delete(zipedfiledname);
                        return "压缩文件目标路径不存在!";
                    }
                    var setbuffer = new byte[newstream.Length];
                    newstream.Read(setbuffer, 0, setbuffer.Length);//读入文件
                    //新建ZipEntrity
                    var newEntry = new ZipEntry(filename)
                    {
                        DateTime = DateTime.Now,
                        Size = newstream.Length
                    };
                    //设置时间-长度
                    newstream.Close();
                    newzipstream.PutNextEntry(newEntry);//压入
                    newzipstream.Write(setbuffer, 0, setbuffer.Length);

                }
                //重复压入操作
                newzipstream.Finish();
                newzipstream.Close();

            }
            catch (Exception e)
            {
                //出现异常
                File.Delete(zipedfiledname);
                return e.Message.ToString();
            }

            return "";
        }
        /**//// <summary>
        /// 实现解压操作
        /// </summary>
        /// <param name="zipfilename">要解压文件Zip(物理路径)</param>
        /// <param name="unZipDir">解压目的路径(物理路径)</param>
        /// <param name="password">解压密码</param>
        /// <returns>异常信息</returns>
        public static string UnMakeZipFile(string zipfilename, string unZipDir, string password)
        {
            //判断待解压文件路径
            if (!File.Exists(zipfilename))
            {
                File.Delete(unZipDir);
                return "待解压文件路径不存在!";
            }

            //创建ZipInputStream
            var newinStream = new ZipInputStream(File.OpenRead(zipfilename));

            //判断Password
            if (!string.IsNullOrEmpty(password))
            {
                newinStream.Password = password;
            }
            //执行解压操作
            try
            {
                ZipEntry theEntry;
                //获取Zip中单个File
                while ((theEntry = newinStream.GetNextEntry()) != null)
                {
                    //判断目的路径
                    if (Directory.Exists(unZipDir))
                    {
                        Directory.CreateDirectory(unZipDir);//创建目的目录
                    }
                    //获得目的目录信息
                    var driectoryname = Path.GetDirectoryName(unZipDir);
                    var pathname = Path.GetDirectoryName(theEntry.Name);//获得子级目录
                    var filename = Path.GetFileName(theEntry.Name);//获得子集文件名
                    //处理文件盘符问题
                    pathname = pathname.Replace(":", "$");//处理当前压缩出现盘符问题
                    driectoryname = driectoryname + "\\" + pathname;
                    //创建
                    Directory.CreateDirectory(driectoryname);
                    //解压指定子目录
                    if (filename != string.Empty)
                    {
                        var newstream = File.Create(driectoryname + "\\" + pathname);
                        var size = 2048;
                        var newbyte = new byte[size];
                        while (true)
                        {
                            size = newinStream.Read(newbyte, 0, newbyte.Length);
                            if (size > 0)
                            {
                                //写入数据
                                newstream.Write(newbyte, 0, size);
                            }
                            else
                            {
                                break;
                            }
                            newstream.Close();
                        }
                    }
                }
                newinStream.Close();
            }
            catch (Exception se)
            {
                return se.Message.ToString();
            }
            finally
            {
                newinStream.Close();
            }

            return "";
        }


    }
}