using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Less2
{
    public partial class Form1 : Form
    {
        // 2. Создайте приложение на базе ListView для просмотра каталога файлов в 5-ти вариантах,
        //для вариантов иконки-плитка-список_изображений отображать содержимое графических файлов.
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.BeforeSelect += TreeView1_BeforeSelect;
            treeView1.BeforeExpand += TreeView1_BeforeExpand1;

            FillDriveNodes();

            Images();

            comboBox1.Items.Add("LargeIcon");
            comboBox1.Items.Add("Details");
            comboBox1.Items.Add("Smallicon");
            comboBox1.Items.Add("List");
            comboBox1.Items.Add("Tile");

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void AddImage(int width, int height)
        {
            imageList1.ImageSize = new Size(width,height);
            imageList1.Images.Add(new Bitmap("Folder.png"));
            imageList1.Images.Add(new Bitmap("File.png"));
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }

        private void SetView()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    listView1.View = View.LargeIcon;
                    listView1.LargeImageList = imageList1;
                    AddImage(50,50);
                    break;
                case 1:
                    listView1.View = View.Details;
                    listView1.LargeImageList = imageList1;
                    AddImage(30,30);
                    break;
                case 2:
                    listView1.View = View.SmallIcon;
                    listView1.SmallImageList = imageList1;
                    AddImage(10,10);
                    break;
                case 3:
                    listView1.View = View.List;
                    listView1.LargeImageList = imageList1;
                    AddImage(20, 20);
                    break;
                case 4:
                    listView1.View = View.Tile;
                    listView1.LargeImageList = imageList1;
                    AddImage(20, 20);
                    break;
            }
        }

        private void TreeView1_BeforeExpand1(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            string[] dirs;

            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);

                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNodes(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            string[] dirs;

            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);

                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNodes(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name };
                    FillTreeNodes(driveNode, drive.Name);
                    treeView1.Nodes.Add(driveNode);
                }
            }
            catch (Exception) { }
        }

        private void FillTreeNodes(TreeNode driveNode, string name)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(name);
                foreach (var dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception) { }
        }

        private void ContentWindow()
        {
            PathToTheFile();

            try
            {
                var folders = new DirectoryInfo(treeView1.SelectedNode.FullPath);

                foreach (var folder in folders.GetDirectories())
                {
                    if (listView1.FindItemWithText(folder.FullName) == null)
                    {
                        listView1.Items.Add(folder.FullName, 0);
                        foreach (var file in folder.GetFiles())
                        {
                            listView1.Items.Add(file.Name, 1);
                        }
                    }
                    else
                    {
                        listView1.Items.Clear();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContentWindow();
        }

        private void Images()
        {
            listView1.View = View.SmallIcon;
            listView1.SmallImageList = imageList1;
            AddImage(10, 10);
        }

        private void PathToTheFile()
        {
            textBox1.Text = Path.GetFullPath(treeView1.SelectedNode.FullPath);
        }
        private void OpenFolder()
        {
            listView1.Items.Clear();

            var folders = new DirectoryInfo(textBox1.Text);

            foreach (var folder in folders.GetDirectories())
            {
                if (listView1.FindItemWithText(folder.FullName) == null)
                {
                    listView1.Items.Add(folder.FullName, 0);
                }
            }

            string[] files = Directory.GetFiles(textBox1.Text);

            foreach (var file in files)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = file.Remove(1, file.LastIndexOf('\\') + 1);
                lvi.ImageIndex = 1;
                listView1.Items.Add(lvi);
            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFolder();
        }

        private void backToolStripButton1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            DirectoryInfo folders = new DirectoryInfo(textBox1.Text);
            foreach (var folder in folders.GetDirectories())
            {
                if (listView1.FindItemWithText(folder.FullName) == null)
                {
                    listView1.Items.Add(folder.FullName, 0);
                    foreach (var file in folder.GetFiles())
                    {
                        listView1.Items.Add(file.Name, 1);
                    }
                }
            }
        }
    }
}
