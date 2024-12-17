using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using INFINITTechTest.Data;
using INFINITTechTest.Factories.Interfaces;

namespace INFINITTechTest.Repositories.Interfaces
{
    public interface IAPIReaderRepository
    {
        Task<IList<RepoTreeNode>> GetRepoFiles(string repoPath, string path, string SHA = null);

        Task<IList<RepoTreeNode>> GetRepoFiles();

        Task<IDictionary<char, int>> GetDictionaryFromDirectoryTree(IList<RepoTreeNode> nodes);
    }
}
