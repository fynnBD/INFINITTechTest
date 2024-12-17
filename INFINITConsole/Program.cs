// See https://aka.ms/new-console-template for more information

using INFINITTechTest.Data;
using INFINITTechTest.Factories;
using INFINITTechTest.Factories.Interfaces;
using INFINITTechTest.Models;
using INFINITTechTest.Repositories;
using INFINITTechTest.Repositories.Interfaces;


IHttpClientFactory factory = new HttpClientFactory();
IAPIReaderRepository readerRepository = new ApiReaderRepository(factory);

IList<RepoTreeNode> tree = await readerRepository.GetRepoFiles();
IList<FileReaderModel.CharCount> characters = new List<FileReaderModel.CharCount>();
IDictionary<char, int> dict = await readerRepository.GetDictionaryFromDirectoryTree(tree);

foreach (char v in dict.Keys)
{
    characters.Add(new FileReaderModel.CharCount(v, dict[v]));
}

foreach (FileReaderModel.CharCount c in characters.OrderByDescending(t => t.Count))
{
    Console.WriteLine($"{c.Character} : {c.Count}");
}