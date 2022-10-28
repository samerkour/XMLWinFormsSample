using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace RACWinFormsSample.Model
{
    [Serializable()]
    //[DesignerCategory("code")]
    //[XmlType(AnonymousType = true)]
    [XmlRoot("Project"/*,Namespace = "http://www.w3.org/2001/XMLSchema-instance",DataType = "Project.xsd"*/, IsNullable = false)]
    public class Project
    {

        public ProjectInformation Information;


        [XmlArrayItem("Value", IsNullable = false)]
        public List<decimal> Data;

    }

    /// <remarks/>
    [Serializable()]
    //[DesignerCategory("code")]
    //[XmlType(AnonymousType = true)]
    public class ProjectInformation
    {

        public string Name;

        public string Type;

    }


}
