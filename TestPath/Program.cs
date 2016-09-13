using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPath
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string>();
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Favorites));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Recent));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Templates));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.History));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Windows));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.System));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.AdminTools));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.Resources));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks));
            list.Add(Environment.GetFolderPath(Environment.SpecialFolder.CDBurning));
            

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i] == "C:\\Users\\inernoro")
                {

                }
            }
        }
    }
}
