using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System;
using System.Security.Cryptography.Xml;
using System.Drawing;
using Microsoft.VisualBasic;

//
// De c# motor van dit ding. Een verzameling classes met het gereedschap dat nodig is.
//
namespace Mijn_Curriculum_Vitae
{
    // De class die de data files leest en schrijft
    public class XMLData
    {
        public XMLData()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String path = Directory.GetCurrentDirectory();
            Root = XElement.Load(path + "\\Xml" + "\\XMLFile.xml");
            //var records = Root.Elements();
        }

        public XElement Root { get; set; }
        
        private Curriculum _curriculum;

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

    // De class die de data uit de xml gebruikt in de c# en razor/blazor omgeving
    public class Curriculum : Object
    {
        public Curriculum()
        {

        LijstWerkervaring = new List<Werkervaring>();
        LijstOpleiding = new List<Opleiding>();
        LijstVaardigheden = new List<Vaardigheden>();
        LijstVrijetijdsbesteding = new List<Vrijetijdsbesteding>();
        //FlexDirection = new Dictionary<string, string>()
        //{
        //    {"werkervaring", "ddd"},
        //};
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

        //public Dictionary<string, string> FlexDirection; new Dictionary<string, string>(){ }
        
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


    //  Class die static rand bevat zodat in de rand geen patronen herkenbaar zijn
    public class Rand
    {
		static Random ranDom = new Random();

		public static Random getRandom { get => ranDom; }
	}



    /// <summary>
    /// /////////////////////////////////////////////////
    /// </summary>
    // Class die het echte werk doet bij het samenstellen van de kleurcombinaties
    ///////////////////////////////////////////////////

    public class Colors
    {
        public static string button;
        
        // Eigenlijk zou dit een void moeten zijn maar die kan niet vanaf een andere component worden aangeroepen
        // de return value van deze method wordt niet gebruikt. De method zet de values van de vier kleuren die gebruikt worden 
        // voor de kleurcombinatie.
        public  int SetValues(string buttn, int minmax)
        {
            int x = 0;
            if (buttn == "Rood")
            { 
                int xx = Rand.getRandom.Next(330, 360);
                int xxx = Rand.getRandom.Next(0, 30);
                int xxxx = Rand.getRandom.Next(1, 3);

                if (xxxx % 2 == 0)
                    x = xx;
                else
                    x = xxx;
            }

            if (buttn == "Geel")
                { x = Rand.getRandom.Next(30, 90);}

            if (buttn == "Groen")
                { x = Rand.getRandom.Next(90, 150);}

            if (buttn == "Cyaan")
                { x = Rand.getRandom.Next(150, 210 );}

            if (buttn == "Blauw")
                { x = Rand.getRandom.Next(210, 270);}

            if (buttn == "Magenta")
                { x = Rand.getRandom.Next(270, 330);}

            #region MyRegion
            basisKleur = x;

            if (x + 180 >= 360)
                { basisKleurTegenover = x + 180 - 360; }
            else
                {basisKleurTegenover = x + 180;}

            if (basisKleur % 2 == 0)
            {
                if (x + minmax >= 360)
                    { basisKleur_Plus = x + minmax - 360; }
                else
                    {basisKleur_Plus = x + minmax;}

                if (x - minmax < 0)
                    {basisKleur_Min = x + 360 - minmax;}
                else
                    {basisKleur_Min = x - minmax;}
            }
            else
            {
                if (x + minmax >= 360)
                    { basisKleur_Min = x + minmax - 360; }
                else
                    {basisKleur_Min = x + minmax;}

                if (x - minmax < 0)
                    {basisKleur_Plus = x + 360 - minmax;}
                else
                    {basisKleur_Plus = x - minmax;}
            }
            #endregion

            return 0;   
        } 
        
        public  int basisKleur; 
        public  int basisKleurTegenover;
        public  int basisKleur_Min;
        public  int basisKleur_Plus;

        public string basisKleurSL(int smin, int smx, int lmin, int lmax)
        {
            string sat = Rand.getRandom.Next(smin, smx).ToString(); 

            int helderheid = Rand.getRandom.Next(lmin, lmax);
            string light = helderheid.ToString();

            string bk = basisKleur.ToString() + ", " + sat.ToString() + "%, " + light.ToString() + "%"; 

            return bk;
        }

        public string basisKleurTegenoverSL(int smin, int smx, int lmin, int lmax)
        {
            string bk = "";
            string sat = Rand.getRandom.Next(smin, smx).ToString(); 
            string light = Rand.getRandom.Next(lmin, lmax).ToString();

            bk = "hsl(" + basisKleur.ToString() + ", " + sat.ToString() + "%, " + light.ToString() + "%);"; 

            return bk;
        }

        public static string Rood{ get => "hsl(0,   100%, 50%);";}

        public static string Geel{ get =>  "hsl(60,  100%, 50%);";}

        public static string Groen{ get => "hsl(120, 100%, 50%);";}

        public static string Cyaan{ get => "hsl(180, 100%, 50%);";}

        public static string Blauw{ get => "hsl(240, 100%, 50%);";}

        public static string Magenta{ get => "hsl(300, 100%, 50%);";}
    }
    
    // Class die nodig is om communicatie mogelijk te maken tussen parent en child. Kan waarschijnlijk veel efficienter
    // met razor code maar daar zijn we niet aan toe gekomen. Probleem is opgelost en dat is wat nu even belangrijker was
    public class ColorCombi
    {
        public  int baseC; 
        public  int baseC_Oppo;
        public  int baseC_Min;
        public  int baseC_Plus;
    }

public interface IColor
{
    
}




}






