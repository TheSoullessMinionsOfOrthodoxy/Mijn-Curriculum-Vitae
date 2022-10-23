using System.Xml.Linq;
using System.Text;

namespace Mijn_Curriculum_Vitae
{
    // De classes om de data te lezen en schrijven en in de html te gebruiken
    public class XMLData
    {
        public XMLData()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String path = Directory.GetCurrentDirectory();
            Root = XElement.Load(path + "\\Xml" + "\\XMLFile.xml");
            //var records = Root.Elements();
        }

        // XElement en XDoc zijn onze helpers als we met xml en linq werken. Linq? De q is dezelfde q als in SQL. Linq is alleen
        // drie keer beter, leesbaarder en fijner om mee te werken. 
        public XElement Root { get; set; }

        // We initialiseren we het object van het type Curriculum        
        private Curriculum _curriculum;

        // Deze method zorgt ervoor dat het object curriculum wordt gevuld met data uit de xml als de method vanaf de indexpagina
        // wordt aangeroepen
        public Curriculum GetCurriculum()
        {
            _curriculum = new Curriculum();

            _curriculum.Access = Root.Element("access").Value;
            _curriculum.Voornaam = Root.Element("voornaam").Value;
            _curriculum.Tussenvoegsel = Root.Element("tussenvoegsel").Value;
            _curriculum.Achternaam = Root.Element("achternaam").Value;
            _curriculum.Leeftijd = int.Parse(Root.Element("leeftijd").Value);
            _curriculum.Adres = Root.Element("adres").Value;
            _curriculum.Postcode = Root.Element("postcode").Value;
            _curriculum.Woonplaats = Root.Element("woonplaats").Value;
            _curriculum.Email = Root.Element("email").Value;
            _curriculum.Telefoon = Root.Element("telefoon").Value;
            _curriculum.Foto = Root.Element("foto").Value;

            _curriculum.Meta = Root.Element("meta").Value;

            foreach (var ite in Root.Element("container_werkervaring").Elements())
            {
                Werkervaring werkerv = new Werkervaring();
                werkerv.Werkgever = ite.Element("werkgever").Value;
                werkerv.Functie = ite.Element("functie").Value;
                werkerv.Periode = ite.Element("periode").Value;
                werkerv.Referenties = ite.Element("referenties").Value;
                _curriculum.LijstWerkervaring.Add(werkerv);
            }

            foreach (var ite in Root.Element("container_opleiding").Elements())
            {
                Opleiding opl = new Opleiding();
                opl.NaamOpleiding = ite.Element("naamopleiding").Value;
                opl.Niveau = ite.Element("niveau").Value;
                opl.Diploma = ite.Element("diploma").Value;
                opl.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstOpleiding.Add(opl);
            }

            foreach (var ite in Root.Element("container_vaardigheden").Elements())
            {
                Vaardigheden vaar = new Vaardigheden();
                vaar.Omschrijving = ite.Element("omschrijving").Value;
                vaar.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstVaardigheden.Add(vaar);
            }

            foreach (var ite in Root.Element("container_vrijetijdsbesteding").Elements())
            {
                Vrijetijdsbesteding vrijetijd = new Vrijetijdsbesteding();
                vrijetijd.Activiteit = ite.Element("activiteit").Value;
                _curriculum.LijstVrijetijdsbesteding.Add(vrijetijd);
            }

            //ListOFCV.Add(_curriculum);

            return _curriculum;
        }

        // hier bewandelen we de omgekeerde weg: we gebruiken het object curriculum om wijzigingen in de data die de user heeft aangebracht
        // weer in de xml file te krijgen zodat ze een volgende keer ook weer ingelezen kunnen worden.
        public void Save(Curriculum C)
        {
            //Curriculum C = ListOFCV.FirstOrDefault(c => c.Access == Accesscode);

            IEnumerable<XElement> LoopW()
            {
                foreach (var item in C.LijstWerkervaring)
                {
                    XElement LW = new XElement("werkervaring1",
                        new XElement("id", item.Id),
                        new XElement("werkgever", item.Werkgever),
                        new XElement("functie", item.Functie),
                        new XElement("periode", item.Periode),
                        new XElement("referenties", item.Referenties));
                    yield return LW;
                }
            }

            IEnumerable<XElement> LoopO()
            {
                foreach (var item in C.LijstOpleiding)
                {
                    XElement LW = new XElement("opleiding1",
                        new XElement("id", item.Id),
                        new XElement("naamopleiding", item.NaamOpleiding),
                        new XElement("niveau", item.Niveau),
                        new XElement("diploma", item.Diploma),
                        new XElement("toelichting", item.Toelichting));
                    yield return LW;
                }
            }

            IEnumerable<XElement> LoopV()
            {
                foreach (var item in C.LijstVaardigheden)
                {
                    XElement LW = new XElement("vaardigheden1",
                        new XElement("id", item.Id),
                        new XElement("omschrijving", item.Omschrijving),
                        new XElement("toelichting", item.Toelichting));

                    yield return LW;
                }
            }

            IEnumerable<XElement> LoopVB()
            {
                foreach (var item in C.LijstVrijetijdsbesteding)
                {
                    XElement LW = new XElement("vrijetijdsbesteding1",
                        new XElement("id", item.Id),
                        new XElement("activiteit", item.Activiteit));
                    yield return LW;
                }
            }

            XElement Doc = new XElement("cv",
                new XElement("access", C.Access),
                new XElement("voornaam", C.Voornaam),
                new XElement("tussenvoegsel", C.Tussenvoegsel),
                new XElement("achternaam", C.Achternaam),
                new XElement("leeftijd", C.Leeftijd),
                new XElement("adres", C.Adres),
                new XElement("postcode", C.Postcode),
                new XElement("woonplaats", C.Woonplaats),
                new XElement("email", C.Email),
                new XElement("telefoon", C.Telefoon),
                new XElement("foto", C.Foto),
                new XElement("meta", C.Meta),
                new XElement("container_werkervaring",
                    LoopW()),
                new XElement("container_opleiding",
                    LoopO()),
                new XElement("container_vaardigheden",
                    LoopV()),
                new XElement("container_vrijetijdsbesteding",
                    LoopVB()));

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String path = Directory.GetCurrentDirectory();
            Doc.Save(path + "\\Xml" + "\\XMLFile.xml");
        }
    }

    // Onze c# gegevensdrager voor de CV data
    public class Curriculum : Object
    {
        public Curriculum()
        {
            LijstWerkervaring = new List<Werkervaring>();
            LijstOpleiding = new List<Opleiding>();
            LijstVaardigheden = new List<Vaardigheden>();
            LijstVrijetijdsbesteding = new List<Vrijetijdsbesteding>();
        }

        public string Access { get; set; }

        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int Leeftijd { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Foto { get; set; }

        public string Meta { get; set; }

        public List<Werkervaring> LijstWerkervaring;
        public List<Opleiding> LijstOpleiding;
        public List<Vaardigheden> LijstVaardigheden;
        public List<Vrijetijdsbesteding> LijstVrijetijdsbesteding;       
    }

    // De classes die binnen Curriculum worden gebruikt 
    public class Werkervaring
    {
        public int Id { get; set; } = 0;
        public string Werkgever { get; set; }
        public string Functie { get; set; }
        public string Periode { get; set; }
        public string Referenties { get; set; }
    }

    public class Referentie
    {
        public int Id { get; set; } = 0;
        public string Naam { get; set; }
        public string Functie { get; set; }
    }

    public class Opleiding
    {
        public int Id { get; set; } = 0;
        public string NaamOpleiding { get; set; }
        public string Niveau { get; set; }
        public string Diploma { get; set; }
        public string Toelichting { get; set; }
    }

    public class Vaardigheden
    {
        public int Id { get; set; } = 0;
        public string Omschrijving { get; set; }
        public string Toelichting { get; set; }
    }

    public class Vrijetijdsbesteding
    {
        public int Id { get; set; } = 0;
        public string Activiteit { get; set; }
    }


 



}






