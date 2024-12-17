using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using INFINITTechTest.Models.Interfaces;
using INFINITTechTest.Views.Interfaces;

namespace INFINITTechTest.Controller.Interfaces
{
    public interface IFileReaderController
    {
        void SetView(IFileReaderView view);

        void SetModel(IFileReaderModel FileReaderModel);

        Task InternalWireUpEvents();

        void LoadStats();
    }
}
