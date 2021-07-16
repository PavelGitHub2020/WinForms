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

namespace Less1
{
    public partial class Form1 : Form
    {
        //Создайте приложение на базе TreeView для просмотра каталогов файлов с вложенными каталогами.
        public Form1()
        {
            InitializeComponent();

            treeView1.BeforeSelect += TreeView1_BeforeSelect;
            treeView1.BeforeExpand += TreeView1_BeforeExpand1;

            FillDriveNodes();
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

        

       
    }
}
