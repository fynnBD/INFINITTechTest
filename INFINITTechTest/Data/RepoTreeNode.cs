using System.Collections.Generic;
using System.Text;

namespace INFINITTechTest.Data
{
    public class RepoTreeNode
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string RelativePath { get; set; }

        public string Type { get; set; }

        public IList<RepoTreeNode> SubFiles { get; set; }

        public byte[] Data { get; set; }

        public string sha { get; set; }
        
        public RepoTreeNode()
        {
            SubFiles = new List<RepoTreeNode>();
        }

        public string GetContents() => Data != null ? Encoding.UTF8.GetString(Data) : string.Empty;
    }
}
