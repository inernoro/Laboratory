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
using Init.Properties;
using Newtonsoft.Json;

namespace Init
{
    public partial class Form1 : Form
    {
        private static readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.ssh\\id_rsa.pub";

        private readonly string _port;
        private readonly string _host;
        public Form1()
        {
            InitializeComponent();
            _host = HostText.Text;
            _port = PortText.Text;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilePath))
            {
                var reader = new StreamReader(FilePath);
                try
                {
                    Network.DoPost(UrlText.Text, JsonConvert.SerializeObject(new { Id = reader.ReadToEnd() }));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }else
            MessageBox.Show(Resources.NotFileSorry + FilePath);
        }

        private void HostText_TextChanged(object sender, EventArgs e)
        {
            UrlText.Text = HostText.Text + Resources.PortText + PortText.Text + Resources.UrlText;
        }

        private void RestBtn_Click(object sender, EventArgs e)
        {
            HostText.Text = _host;
            PortText.Text = _port;
        }
    }
}
