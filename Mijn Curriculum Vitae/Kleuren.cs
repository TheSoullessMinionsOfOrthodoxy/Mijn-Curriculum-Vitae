using System.Xml.Linq;
using System.Text;

namespace Mijn_Curriculum_Vitae
{
    //  Class die static rand bevat zodat in de rand geen patronen herkenbaar zijn
    // Dit kleine stukje code is waarschijnlijk de meest gebruikte code van het hele project
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

    public class Colors : IColor
    {
        public static string button;
        
        // Eigenlijk zou dit een void moeten zijn maar die kan (voorzover onze kennis reikt) niet vanaf een andere component worden aangeroepen
        // de return value van deze method wordt niet gebruikt. De method zet de values van de vier kleuren die gebruikt worden 
        // voor de kleurcombinatie.

        public void GaMetDeBanaan()
        { }

        public  int SetValues(string buttn, int minmax)
        {
            int x = 0;
            if (buttn == "Rood")
            { 
                int xx = Rand.getRandom.Next(330, 360);
                int xxx = Rand.getRandom.Next(0, 30);
                int xxxx = Rand.getRandom.Next(1, 3);

                if (xxxx % 2 == 0) // de operator % laat de (eventuele) rest zien van een deling. Ideaal icm een randwaarde.                                   
                    x = xx; // if en else kun je ook zonder {} schrijven als ze maar 1 statement bevatten
                else
                    x = xxx;
            }

            if (buttn == "Geel")
                { x = Rand.getRandom.Next(30, 90);} // 30 en 90 zijn de grenzen tussen rood/geel en geel/groen. dit is het gebied
                                                    // waaruit de random de basiskleur trekt

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
        
        //Dit zijn de kleuren die in de bovenstaande method worden geset en in de css van de indexpagina worden gebruikt.
        public  int basisKleur; 
        public  int basisKleurTegenover;
        public  int basisKleur_Min;
        public  int basisKleur_Plus;

        // Deze methods worden in de css gebruikt om de css string te creeren. Dit is een onderdeel dat niet af is en er
        // zouden er nog een paar bij moeten zodat we ook de andere kleuren uit het pakket kant en klaar in stringvorm op de 
        // indexagina kunnen gebruiken
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

        // deze zorgen ervoor dat de kleurkeuze buttons op de indexpagina de juiste kleur krijgen
        public static string Rood{ get => "hsl(0,   100%, 50%);";}

        public static string Geel{ get =>  "hsl(60,  100%, 50%);";}

        public static string Groen{ get => "hsl(120, 100%, 50%);";}

        public static string Cyaan{ get => "hsl(180, 100%, 50%);";}

        public static string Blauw{ get => "hsl(240, 100%, 50%);";}

        public static string Magenta{ get => "hsl(300, 100%, 50%);";}

        public void BasisKleur()
        {
            basisKleur.ToString();
        }
    }
    

 
    

// we wilden graag een keer met een interface werken maar het was weer eens helemaal niet nodig. Toch gaan we hem nodig maken zodat we 
// leren ermee te werken.
interface IColor
{
    void GaMetDeBanaan()
    { 
        
        
    }
}




}






