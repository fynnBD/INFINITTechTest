using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INFINITTechTest.Views.Interfaces
{
    public interface IFileReaderView
    {
        TreeView TreeView { get; }
        Button LoadStatsButton { get; }
        ListView CharListView { get; }
    }
}
