using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFINITTechTest.Data;
using INFINITTechTest.Repositories.Interfaces;

namespace INFINITTechTest.Models.Interfaces
{
    public interface IFileReaderModel
    {
        IList<RepoTreeNode> Nodes { get; set; }
        IList<FileReaderModel.CharCount> CharList { get; set; }
        Task LoadDirectory();
        Task LoadCharList();

        void SetRepoPath(string repoPath);
    }
}
