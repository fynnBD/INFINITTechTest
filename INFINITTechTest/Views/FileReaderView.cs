using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac.Integration.Web;
using INFINITTechTest.Controller;
using INFINITTechTest.Controller.Interfaces;
using INFINITTechTest.Models.Interfaces;
using INFINITTechTest.Repositories.Interfaces;
using INFINITTechTest.Views.Interfaces;

namespace INFINITTechTest
{
    public partial class FileReaderView : Form, IFileReaderView
    {
        private IFileReaderController fileReaderController;

        

        public TreeView TreeView => this.treeView1;
        public Button LoadStatsButton => button1;
        public ListView CharListView => charListView;

        public FileReaderView(IFileReaderController fileReaderController, IFileReaderModel fileReaderModel, IAPIReaderRepository apiReaderRepository)
        {
            InitializeComponent();
            this.fileReaderController = fileReaderController;

            fileReaderController.SetView(this);
            fileReaderController.SetModel(fileReaderModel);

            LoadControllerAsync();
        }

        private void LoadControllerAsync()
        {
            Task.Run(() =>
            {
                fileReaderController.InternalWireUpEvents();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                button1.Invoke((MethodInvoker)(() => { fileReaderController.LoadStats(); }));
            });
        }
    }
}
