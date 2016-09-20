using System;
using System.Windows.Forms;
using CodeBuild.Properties;

namespace CodeBuild
{
    public partial class Mains : Form
    {
        public Mains()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 是否加载
        /// </summary>
        private static bool _connectionState;

        //执行生成
        private void BuildCodeBtnClick(object sender, EventArgs e)
        {
            if (TableName.SelectedIndex == -1 || DatabaseText.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.Mains_BuildCodeBtnClick_抱歉您并没有选择表名);
                return;
            }
            var d = new Dal();
            d.BuildCode(TableName.Text);
            MessageBox.Show(Resources.Mains_BuildCodeBtnClick_);
        }

        /// <summary>
        /// 链接时取出所有的表和数据库
        /// </summary>
        public void ConnectionDatabaseAndViewDatabaseAndTable()
        {
            BindData();
        }

        /// <summary>
        /// 绑定数据库并渲染
        /// </summary>
        public void BindData()
        {
            try
            {
                var d = new Dal();
                var result = d.SelectTableAndDatabase();
                DatabaseText.Items.Clear();
                object[] dbs = result[0].ToArray<string>();
                DatabaseText.Items.AddRange(dbs);
                object[] tables = result[1].ToArray<string>();
                TableName.Items.Clear();
                TableName.Items.AddRange(tables);
                _connectionState = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

        }
        /// <summary>
        /// 值变更时变更连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChangeTextRangeValue(object sender, EventArgs e)
        {
            ChangeConnetion();
        }

        private void ChangeConnetion()
        {
            _connectionState = false;
            PublicPath.MasterConnectionString =
                $@"Server={HostText.Text},{PortText.Text};
                    database={(DatabaseText.Text == Resources.Mains_ValueChangeTextRangeValue_选择数据库 ? "master" : DatabaseText.Text)};
                    uid={UserNameText.Text};
                    pwd={PasswordText.Text};";
        }

        private void ConnectionStrLock(object sender, EventArgs e)
        {
            MessageBox.Show(PublicPath.MasterConnectionString);
        }

        private void DatabaseText_Click(object sender, EventArgs e)
        {
            if (!_connectionState)
            {
                //刷新链接数据库
                ConnectionDatabaseAndViewDatabaseAndTable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDatabaseAndViewDatabaseAndTable();
                MessageBox.Show(Resources.Mains_button1_Click_测试成功);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void TableName_Click(object sender, EventArgs e)
        {

        }

        private void DatabaseText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeConnetion();
                this.TableName.Text = "";
                var d = new Dal();
                var result = d.GetTable();
                TableName.Items.Clear();
                TableName.Items.AddRange(result.ToArray<object>());
                _connectionState = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }

        }

        private void DatabaseText_Click_1(object sender, EventArgs e)
        {
            //是否加载
            if (!_connectionState)
            {
                ConnectionDatabaseAndViewDatabaseAndTable();
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
