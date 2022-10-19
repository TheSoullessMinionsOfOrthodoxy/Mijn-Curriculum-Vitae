using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;
using System.IO;
namespace Mijn_Curriculum_Vitae
{
    public class XMLVoortgang
    {
        public XMLVoortgang()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String path = Directory.GetCurrentDirectory();
            Root = XElement.Load(path + "\\Voortgang.xml");
            var records = Root.Elements();
        }

        public XElement Root { get; set; }
    }

    public class TodoItem : Object
    {
        //TodoItem()
        //{
        //    Date = DateTime.Now;
        //}
        public string? Subject = "";
        public bool Important { get; set; } = false;
        public bool Urgent { get; set; } = false;
        public bool Done { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
        public int Id { get; set; } = 0;
    }
}
