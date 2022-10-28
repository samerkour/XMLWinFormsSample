using RACWinFormsSample.Model;
using System.Threading.Tasks;

namespace RACWinFormsSample.DataAccessLayer
{
    public interface IDataProvider
    {
        Project Project { get; set; }



        void LoadProject(string path);
        // Asynchronous method
        Task<bool> ValidateXmlDocumentAndSaveAsync(Project project, string path);
        void WriteXML(Project project, string path);
        void ValidateUsingXSD_LINQtoXML(Project project);


    }
}