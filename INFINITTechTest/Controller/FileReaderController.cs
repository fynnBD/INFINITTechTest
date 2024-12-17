using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFINITTechTest.Controller.Interfaces;
using INFINITTechTest.Data;
using INFINITTechTest.Models;
using INFINITTechTest.Models.Interfaces;
using INFINITTechTest.Repositories;
using INFINITTechTest.Views.Interfaces;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace INFINITTechTest.Controller
{
    public class FileReaderController : IFileReaderController
    {
        private IFileReaderView View { get; set; }
        private IFileReaderModel Model { get; set; }

        public void SetView(IFileReaderView view)
        {
            this.View = view;
        }

        public async Task InternalWireUpEvents()
        {

            if (ConfigurationManager.AppSettings["gitHubKey"] == "")
            {
                MessageBox.Show("Please enter your API key in App.Config");
                Application.Exit();
            }

            SetButtonValues("Loading...", false);

            await Model.LoadDirectory();

            this.View.TreeView.Invoke((MethodInvoker)(() =>
            {
                BuildTreeView();
            }));

            SetButtonValues("Load Stats", true);
        }

        private void SetButtonValues(string text, bool enabled)
        {
            this.View.LoadStatsButton.Invoke((MethodInvoker)(() =>
            {
                View.LoadStatsButton.Enabled = enabled;
                View.LoadStatsButton.Text = text;
            }));
        }

        public void SetModel(IFileReaderModel model)
        {
            this.Model = model;
        }

        private void BuildTreeView()
        {
            TreeView treeView = View.TreeView;
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            var nodes = TreeBuilderHelper.BuildTreeFromNodes(Model.Nodes);
            foreach (TreeNode node in nodes)
            {
                treeView.Nodes.Add(node);
            }

            treeView.EndUpdate();
        }

        private void SetData()
        {
            View.CharListView.Items.Clear();
            foreach (FileReaderModel.CharCount c in Model.CharList.OrderByDescending(t => t.Count))
            {
                var item = new ListViewItem { Text = c.Character.ToString() };
                item.SubItems.Add(c.Count.ToString());
                View.CharListView.Items.Add(item);
            }
        }

        public void LoadStats()
        {
            View.LoadStatsButton.Enabled = false;

            try
            {
                Model.LoadCharList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not connect to repo");
                throw;
            }
            SetData();

            View.LoadStatsButton.Enabled = true;
        }
    }
}
