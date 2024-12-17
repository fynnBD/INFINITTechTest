using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFINITTechTest.Data;
using INFINITTechTest.Factories.Interfaces;
using INFINITTechTest.Repositories.Interfaces;
using Newtonsoft.Json;

using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace INFINITTechTest.Repositories
{
    public class ApiReaderRepository : IAPIReaderRepository
    {
        private readonly HttpClient _client;

        public ApiReaderRepository(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateHttpClient();
        }

        public async Task<IList<RepoTreeNode>> GetRepoFiles()
        {
            return await GetRepoFiles(ConfigurationManager.AppSettings.Get("repoURL"), "");
        }

        public async Task<IList<RepoTreeNode>> GetRepoFiles(string repoPath, string path, string SHA = null)
        {
            string getUrl; TreeResponse node;
            if (SHA == null)
            {
                getUrl = BuildGetTreePath(repoPath);
            }
            else
            {
                getUrl = BuildGetTreePath(repoPath, SHA);
            }

            try
            {
                HttpResponseMessage response = _client.GetAsync(getUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    node = JsonConvert.DeserializeObject<TreeResponse>(response.Content.ReadAsStringAsync().Result);

                    foreach (RepoTreeNode r in node.Tree)
                    {
                        r.RelativePath = path + "/" + r.Path;
                        if (r.Type == "tree")
                        {

                            r.SubFiles = await GetRepoFiles(repoPath, r.RelativePath, r.sha);
                        }
                    }

                    return node.Tree;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Was unable to get repo at " + path + "\n" + e.Message);
            }

            return null;
        }

        public Task<IDictionary<char, int>> GetDictionaryFromDirectoryTree(IList<RepoTreeNode> nodes)
        {
            IDictionary<char, int> charDictionary = CreateEmptyLetterList();
            return GetDictionaryRecursive(charDictionary, nodes);
        }

        private async Task<IDictionary<char, int>> GetDictionaryRecursive(IDictionary<char, int> charDictionary, IList<RepoTreeNode> nodes)
        {
            string repoPath = ConfigurationManager.AppSettings["repoURL"];

            foreach (RepoTreeNode node in nodes)
            {
                try
                {
                    if (node.Type == "blob" && node.Path.EndsWith(".js"))
                    {
                        var v = await GetContentOfFile(node.RelativePath, repoPath);
                        foreach (char c in v.Where(char.IsLetter))
                        {
                            if (!charDictionary.Keys.Contains(char.ToLower(c)))
                            {
                                charDictionary.Add(char.ToLower(c), 1);
                            }
                            charDictionary[char.ToLower(c)]++;
                        }
                    }
                    else if (node.Type == "tree")
                    {
                        GetDictionaryRecursive(charDictionary, node.SubFiles);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Could not get file at " + repoPath + "  " + e.Message);
                }
            }

            return charDictionary;
        }

        private IDictionary<char, int> CreateEmptyLetterList()
        {
            IDictionary<char, int> charDictionary = new Dictionary<char, int>();
            foreach (char c in "abcdefghikjlmnopqrstuvwxyéz")
            {
                charDictionary.Add(c, 0);
            }

            return charDictionary;
        }

        private async Task<string> GetContentOfFile(string path, string repoPath)
        {
            HttpResponseMessage response = _client.GetAsync(BuildGetFilePath(repoPath, path)).Result;
            if (response.IsSuccessStatusCode)
            {
                FileResponse node = JsonConvert.DeserializeObject<FileResponse>(await response.Content.ReadAsStringAsync());
                byte[] data = Convert.FromBase64String(node.Content);
                return Encoding.UTF8.GetString(data);
            }
            
            MessageBox.Show("Was unable to get file " + path + "\n" + response.ReasonPhrase);
            return null;
        }


        private string BuildGetTreePath(string repoPath)
        {
            StringBuilder s = new StringBuilder();
            s.Append("/repos");
            s.Append(repoPath);
            s.Append("/git/trees/main");

            return s.ToString();
        }

        private string BuildGetTreePath(string repoPath, string SHA)
        {
            StringBuilder s = new StringBuilder();
            s.Append("/repos");
            s.Append(repoPath);
            s.Append("/git/trees/");
            s.Append(SHA);

            return s.ToString();
        }

        private string BuildGetFilePath(string repoPath, string path)
        {
            StringBuilder s = new StringBuilder();
            s.Append("/repos");
            s.Append(repoPath);
            s.Append("/contents");
            s.Append(path);

            return s.ToString();
        }

        public class TreeResponse
        {
            public IList<RepoTreeNode> Tree;
            public TreeResponse(IList<RepoTreeNode> repoFiles)
            {
                Tree = repoFiles;
            }
        }

        private class FileResponse
        {
            public string Name;
            public string Content;
        }
    }
}
