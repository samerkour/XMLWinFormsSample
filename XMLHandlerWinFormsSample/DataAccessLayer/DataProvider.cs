using RACWinFormsSample.Extensions;
using RACWinFormsSample.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RACWinFormsSample.DataAccessLayer
{
    public class DataProvider : IDataProvider
    {

        private readonly string XsdFilePathe = ConfigurationManager.AppSettings["XsdFilePathe"];

        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }

        public void LoadProject(string path)
        {
            using (var fileStream = File.Open(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));
                var XMLDocument = (Project)serializer.Deserialize(fileStream);

                _project = XMLDocument;
            }
        }

       
        public async Task<bool> ValidateXmlDocumentAndSaveAsync(Project project, string path)
        {

           
            var task = await Task.Factory.StartNew(() => {

                //XmlDocument document = new XmlDocument();
                //document.Load(reader);

                //https://stackoverflow.com/questions/45623791/how-to-create-root-node-with-xmlnsxsi-but-no-prefix

                string uri = "http://www.w3.org/2001/XMLSchema-instance";

                var document = new XmlDocument();
                document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", null));

                var root = document.CreateElement("Project");
                document.AppendChild(root);

                XmlElement info = document.CreateElement("Information");
                XmlElement name = document.CreateElement("Name");
                name.InnerText = project.Information.Name;

                XmlElement type = document.CreateElement("Type");
                type.InnerText = project.Information.Type;

                info.AppendChild(name);
                info.AppendChild(type);
                root.AppendChild(info);


                XmlElement data = document.CreateElement("Data");


                project.Data.ForEach(item => {
                    XmlElement value = document.CreateElement("Value");
                    value.InnerText = item.ToString();

                    data.AppendChild(value);
                });

                root.AppendChild(data);

                var attr = document.CreateAttribute("xsi", "noNamespaceSchemaLocation", uri);
                attr.InnerText = "Project.xsd";
                root.SetAttributeNode(attr);




                //XmlReaderSettings booksSettings = new XmlReaderSettings();
                //booksSettings.Schemas.Add("http://www.w3.org/2001/XMLSchema", @"Data\Project.xsd");
                //booksSettings.ValidationType = ValidationType.Schema;
                //booksSettings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                //XmlReader books = XmlReader.Create(path, booksSettings);

                //while (books.Read())
                //{
                //}

                //XmlSerializer writer = new XmlSerializer(typeof(Project));



                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add("", XmlReader.Create(XsdFilePathe));

                bool hasErrors = false;
                var xDoc = document.ToXDocument();
                xDoc.Validate(schemas, (o, e) =>
                {

                    hasErrors = true;
                    //exceptions bubble up to the next exception handler up the chain.
                    throw new Exception(e.Message);
                });

                if (!hasErrors)
                {
                    //Creates or overwrites a file in the specified path.
                    FileStream file = File.Create(path);
                    document.Save(file);

                    return true;
                }

                return false;
            });

            return task;
        }



        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }

        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file
        public void WriteXML(Project project, string path)
        {

            XmlSerializer writer = new XmlSerializer(typeof(Project));

            //Creates or overwrites a file in the specified path.
            FileStream file = File.Create(path);

            writer.Serialize(file, project);

            file.Close();
        }

        //https://learn.microsoft.com/en-us/dotnet/standard/linq/validate-xsd
        public void ValidateUsingXSD_LINQtoXML(Project project)
        {

            XDocument doc = new XDocument();
            using (var wr = doc.CreateWriter())
            {
                // write xml into the writer
                var serializer = new DataContractSerializer(project.GetType());
                serializer.WriteObject(wr, project);
            }



          
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(@"Data\Project.xsd"));

            bool errors = false;

            doc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
        }

    }
}
