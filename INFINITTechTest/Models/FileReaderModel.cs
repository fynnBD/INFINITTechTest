using System.Collections.Generic;
using System.Threading.Tasks;
using INFINITTechTest.Data;
using INFINITTechTest.Models.Interfaces;
using INFINITTechTest.Repositories.Interfaces;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace INFINITTechTest.Models
{
    public class FileReaderModel : IFileReaderModel
    {
        public IList<RepoTreeNode> Nodes { get; set; }
        public IList<CharCount> CharList { get; set; }

        private string _repoPath;
        private IAPIReaderRepository ReaderRepository { get; }
        public FileReaderModel(IAPIReaderRepository apiReaderRepository)
        {
            this.ReaderRepository = apiReaderRepository;

            Nodes = new List<RepoTreeNode>();
        }
        public async Task LoadDirectory()
        {
            Nodes = await ReaderRepository.GetRepoFiles(_repoPath ?? ConfigurationManager.AppSettings.Get("repoURL"), "");
        }

        public async Task LoadCharList()
        {
            IDictionary<char, int> charDictionary = await ReaderRepository.GetDictionaryFromDirectoryTree(Nodes);
            CharList = new List<CharCount>();

            foreach (char c in charDictionary.Keys)
            {
                CharList.Add(new CharCount(c, charDictionary[c]));
            }
        }

        public void SetRepoPath(string repoPath)
        {
            _repoPath = repoPath;
        }

        public class CharCount
        {
            public char Character;
            public int Count;

            public CharCount(char c, int i)
            {
                this.Count = i;
                this.Character = c;
            }
        }
    }
}
