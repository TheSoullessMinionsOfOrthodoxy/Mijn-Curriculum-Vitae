using System.Xml.Linq;
using System.Text;
using Mijn_Curriculum_Vitae.CV_Edit;
using Mijn_Curriculum_Vitae;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Drawing;
using System;

namespace Mijn_Curriculum_Vitae
{
    //  Class die static rand bevat zodat in de rand geen patronen herkenbaar zijn
    // Dit kleine stukje code is waarschijnlijk de meest gebruikte code van het hele project
    public class Rand
    {
		static Random ranDom = new();
        public static Random getRandom => ranDom;
    }

    /// <summary>
    /// /////////////////////////////////////////////////
    /// </summary>
    // Class die het echte werk doet bij het samenstellen van de kleurcombinaties
    ///////////////////////////////////////////////////

    public class Colors 
    {
        public Colors()
        {
            KleurenBoek = new();
        }
		private Dictionary<string, string> kleurenBoek;
        public Dictionary<string, string> KleurenBoek { get => kleurenBoek; set => kleurenBoek = value; }
		public static string button;
        //Dit zijn de kleuren die in de bovenstaande method worden geset en in de css van de indexpagina worden gebruikt.
        public  int basisKleur; 
        public  int basisKleurTegenover;
        public  int basisKleur_Min;
        public  int basisKleur_Plus;
        // deze zorgen ervoor dat de kleurkeuze buttons op de indexpagina de juiste kleur krijgen
        public static string Rood{ get => "hsl(0,   100%, 50%);";}
        public static string Geel{ get =>  "hsl(60,  100%, 50%);";}
        public static string Groen{ get => "hsl(120, 100%, 50%);";}
        public static string Cyaan{ get => "hsl(180, 100%, 50%);";}
        public static string Blauw{ get => "hsl(240, 100%, 50%);";}
        public static string Magenta{ get => "hsl(300, 100%, 50%);";}

        #region Sleutels voor strings kleurwaarden CSS
        public string InputBackground { get; set; } = "InputBackground";
        public string Bg_Grid_Container_Background { get; set; } = "Bg_Grid_Container_Background";
        public string Bg_Grid_Container_Div { get; set; } = "Bg_Grid_Container_Div";  //color: hsl(@Top.basisKleur_Min,77%,65%); 

        public string Bg_Item1_Background { get; set; } = "Bg_Item1_Background"; // hsl(@Top.basisKleur,50%,13%) !important;}
        public string Bg_Item2_Background { get; set; } = "Bg_Item2_Background";//  hsl(@Top.basisKleur_Min,  50%,@Rand.getRandom.Next(80,90)%) !important;}
        public string Bg_Item3_Background { get; set; } = "Bg_Item3_Background"; // hsl(@Top.basisKleur_Min+20,  50%,@Rand.getRandom.Next(48,95)%) !important;}
        public string Bg_Item4_Background { get; set; } = "Bg_Item4_Background"; // hsl(@Top.basisKleur_Min+15,  40%,@Rand.getRandom.Next(40,95)%) !important;}
        public string Bg_Item5_Background { get; set; } = "Bg_Item5_Background"; // hsl(@Top.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        public string Bg_Item6_Background { get; set; } = "Bg_Item6_Background"; // hsl(@Top.basisKleurSL(50,53,18,28)) !important;}
        public string Bg_Item7_Background { get; set; } = "Bg_Item7_Background"; //  hsl(@Top.basisKleur_Min,  40%,@Rand.getRandom.Next(80,90)%) !important;
        public string Bg_Item7_Border { get; set; } = "Bg_Item7_Border"; // :dashed 15px hsl(@Top.basisKleur,50%,12%);

        public string Bg_Item8_Background { get; set; } = "Bg_Item8_Background"; // hsl(@Top.basisKleur_Min_20,  40%,@Rand.getRandom.Next(40,90)%) !important;}
        public string Bg_Item9_Background { get; set; } = "Bg_Item9_Background"; // hsl(@Top.basisKleur_Min+10,  20%,@Rand.getRandom.Next(40,90)%) !important;}
        public string Bg_Item10_Background_Image { get; set; } = "Bg_Item10_Background_Image"; // :linear_gradient(hsl(@Top.basisKleurSL(30, 80, 70,90)), hsl(@Top.basisKleurSL(30, 80, 10, 20)));

        public string Bg_Item11_Background { get; set; } = "Bg_Item11_Background"; // hsl(@Top.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        public string Bg_Item12_Background { get; set; } = "Bg_Item12_Background"; // hsl(@Top.basisKleur_Plus, 60%,@Rand.getRandom.Next(50,65)%) !important;}
        public string Bg_Item13_Background { get; set; } = "Bg_Item13_Background"; // hsl(@Top.basisKleur_Min,  70%,@Rand.getRandom.Next(80,95)%) !important;}
        public string Bg_Item14_Background { get; set; } = "Bg_Item14_Background"; // hsl(@Top.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        public string Bg_Item15_Background { get; set; } = "Bg_Item15_Background"; // hsl(@Top.basisKleur_Min, 60%,@Rand.getRandom.Next(40,90)%) !important;}

        public string Btn_Primary_Background { get; set; } = "Btn_Primary_Background";  // hsl(@Top.basisKleurSL(98,101,48,52));} 
        public string Btn_Primary_Hover_Background { get; set; } = "Btn_Primary_Hover_Background"; //  hsl(@(Top.basisKleur + 20), 100%, 50%);}

        public string Fs_Background_Image { get; set; } = "Fs_Background_Image"; // linear_gradient(to left top, hsl(@Top.basisKleurSL(30, 80, 70, 90)), hsl(@Top.basisKleurSL(60, 80, 35,60)));
        public string Fs_Span_Background { get; set; } = "Fs_Span_Background"; //hsl(@Top.basisKleurSL(50, 60, 20, 30));

        public string DataDrager_Dating_Background { get; set; } = "DataDrager_Dating_Background"; //hsl(@Top.basisKleurSL(20, 60, 20, 80));}
        public string DataDrager_B_Background { get; set; } = "DataDrager_B_Background";  //hsl(@Top.basisKleurSL(20, 60, 20, 80));}

        public string Fieldset_Background { get; set; } = "Fieldset_Background";//hsl(@Top.basisKleurSL(45, 60, 40, 42));

        public string Divcolorbuttons_Background { get; set; } = "Divcolorbuttons_Background"; //hsl(@Top.basisKleurSL(20,70,20,80));} 
        public string Nuance1_Background { get; set; } = "Nuance1_Background";//hsl(@Top.basisKleurSL(49,80,15,25));
        public string Nuance2_Background { get; set; } = "Nuance2_Background";//hsl(@Top.basisKleurSL(40,80,30,40));
        public string Nuance3_Background { get; set; } = "Nuance3_Background";  // hsl(@Top.basisKleurSL(40,80,45,55));
        public string Nuance4_Background { get; set; } = "Nuance4_Background";//hsl(@Top.basisKleurSL(40,80,60,70));
        public string Nuance5_Background { get; set; } = "Nuance5_Background";//hsl(@Top.basisKleurSL(40,80,75,85));
        public string Nuance6_Background { get; set; } = "Nuance6_Background";//hsl(@Top.basisKleurSL(40,80,88,95));

        public string HouseofcolorsBEE_Background { get; set; } = "HouseofcolorsBEE_Background"; //hsl(@Top.basisKleur,100%,50%);}
        public string HouseofcolorsHoC_Background { get; set; } = "HouseofcolorsHoC_Background"; //hsl(@Top.basisKleurTegenover,100%,50%);}
        public string HouseofcolorsHusk_Background { get; set; } = "HouseofcolorsHusk_Background"; //hsl(@Top.basisKleur_Plus,100%,50%);}
        public string HouseofcolorsHeerlen_Background { get; set; } = "HouseofcolorsHeerlen_Background"; //hsl(@Top.basisKleur_Min,100%,50%);}
		
		#endregion

		// Eigenlijk zou dit een void moeten zijn maar die kan (voorzover onze kennis reikt) niet vanaf een andere component worden aangeroepen
		// de return value van deze method wordt niet gebruikt. De method zet de values van de vier kleuren die gebruikt worden 
		// voor de kleurcombinatie.

        public  int SetValues(string buttn, int minmax)
        {
            KleurenBoek.Clear();
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

            VulKleurenboek();
            return 0;   
        } 

		public void VulKleurenboek()
        {
            KleurenBoek.Add(InputBackground,                $"hsl({basisKleur},            100%,90%) !important");
            KleurenBoek.Add(Bg_Grid_Container_Background,   $"hsl({basisKleur},            50%, 12%) !important");
            KleurenBoek.Add(Bg_Grid_Container_Div,          $"hsl({basisKleur_Min},        77%, 65%) !important");
            KleurenBoek.Add(Bg_Item1_Background,            $"hsl({basisKleur},            50%, 13%) !important");
            KleurenBoek.Add(Bg_Item2_Background,            $"hsl({basisKleur_Min},        50%, {Rand.getRandom.Next(80, 90)}%) !important");
            KleurenBoek.Add(Bg_Item3_Background,            $"hsl({(basisKleur_Min + 20)}, 50%, {Rand.getRandom.Next(48, 95)}%) !important");
            KleurenBoek.Add(Bg_Item4_Background,            $"hsl({(basisKleur_Min + 15)}, 50%, {Rand.getRandom.Next(48, 95)}%) !important");
            KleurenBoek.Add(Bg_Item5_Background,            $"hsl({basisKleur_Min},        60%, {Rand.getRandom.Next(20, 30)}%) !important");
            KleurenBoek.Add(Bg_Item6_Background,            $"hsl({basisKleur},            50%, 22%) !important");
            KleurenBoek.Add(Bg_Item7_Background,            $"hsl({basisKleur_Min},        40%, 85%) !important");
            KleurenBoek.Add(Bg_Item7_Border,                $"dashed 15px hsl({basisKleur},50%, 12%) !important");
            KleurenBoek.Add(Bg_Item8_Background,            $"hsl({(basisKleur_Min - 20)}, 40%, {Rand.getRandom.Next(40, 90)}%) !important");
            KleurenBoek.Add(Bg_Item9_Background,            $"hsl({(basisKleur_Min + 10)}, 20%, {Rand.getRandom.Next(40, 90)}%) !important");
            KleurenBoek.Add(Bg_Item10_Background_Image,     $"linear-gradient(hsl({basisKleur},48%, 80%), hsl({basisKleur},50%, 15%))");
            KleurenBoek.Add(Bg_Item11_Background,           $"hsl({basisKleur_Min},        60%, {Rand.getRandom.Next(20, 30)}%) !important");
            KleurenBoek.Add(Bg_Item12_Background,           $"hsl({basisKleur_Plus},       60%, {Rand.getRandom.Next(50, 65)}%) !important");
            KleurenBoek.Add(Bg_Item13_Background,           $"hsl({basisKleur_Min},        70%, {Rand.getRandom.Next(80, 95)}%) !important");
            KleurenBoek.Add(Bg_Item14_Background,           $"hsl({basisKleur_Min},        60%, {Rand.getRandom.Next(20, 30)}%) !important");
            KleurenBoek.Add(Bg_Item15_Background,           $"hsl({basisKleur_Min},        60%, {Rand.getRandom.Next(40, 90)}%) !important");
            KleurenBoek.Add(Btn_Primary_Background,         $"hsl({basisKleur},            98%, 48%)");
            KleurenBoek.Add(Btn_Primary_Hover_Background,   $"hsl({(basisKleur + 20)},     100%,50%)");
            KleurenBoek.Add(Fs_Background_Image,            $"linear-gradient(to left top, hsl({basisKleur}, 50%, 80%), hsl({basisKleur}, 70%, 45%))");
            KleurenBoek.Add(Fs_Span_Background,             $"hsl({basisKleur},            55%, 25%) !important");
            KleurenBoek.Add(DataDrager_Dating_Background,   $"hsl({basisKleur},            40%, 60%) !important");
            KleurenBoek.Add(DataDrager_B_Background,        $"hsl({basisKleur},            50%, 55%) !important");
            KleurenBoek.Add(Fieldset_Background,            $"hsl({basisKleur},            50%, 40%) !important");
            KleurenBoek.Add(Divcolorbuttons_Background,     $"hsl({basisKleur},            40%, 70%) !important");
            KleurenBoek.Add(Nuance1_Background,             $"hsl({basisKleur},            50%, 20%) !important");
            KleurenBoek.Add(Nuance2_Background,             $"hsl({basisKleur},            50%, 35%) !important");
            KleurenBoek.Add(Nuance3_Background,             $"hsl({basisKleur},            50%, 50%) !important");
            KleurenBoek.Add(Nuance4_Background,             $"hsl({basisKleur},            50%, 65%) !important");
            KleurenBoek.Add(Nuance5_Background,             $"hsl({basisKleur},            50%, 80%) !important");
            KleurenBoek.Add(Nuance6_Background,             $"hsl({basisKleur},            50%, 95%) !important");
            KleurenBoek.Add(HouseofcolorsBEE_Background,    $"hsl({basisKleur},            100%,50%)");
            KleurenBoek.Add(HouseofcolorsHoC_Background,    $"hsl({basisKleurTegenover},   100%,50%)");
            KleurenBoek.Add(HouseofcolorsHusk_Background,   $"hsl({basisKleur_Plus},       100%,50%)");
            KleurenBoek.Add(HouseofcolorsHeerlen_Background,$"hsl({basisKleur_Min},        100%,50%)");       
        }

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


    }
    

 
    

// we wilden graag een keer met een interface werken maar het was weer eens helemaal niet nodig. Toch gaan we hem nodig maken zodat we 
// leren ermee te werken.



public class KleurenHelper
{




Dictionary<string,string> KleurenBoek = new();
        public void VulKleurenboek()
        {
            //KleurenBoek.Add(InputBackground, $"hsl({basisKleur.ToString()},100%,90%)");
            //KleurenBoek.Add(Bg_Grid_Container_Background, $"hsl({basisKleur.ToString()},50%,12%)");
            //KleurenBoek.Add(Bg_Grid_Container_Div, $"hsl({basisKleur_Min.ToString()},77%,65%)");
            //KleurenBoek.Add(Bg_Item1_Background, $"hsl({basisKleur.ToString()},50%,13%) !important");
            //KleurenBoek.Add(Bg_Item2_Background, $"hsl({basisKleur_Min.ToString()},50%,{Rand.getRandom.Next(80,90).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item3_Background, $"hsl({(basisKleur_Min + 20).ToString()},50%,{Rand.getRandom.Next(48,95).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item4_Background, $"hsl({(basisKleur_Min + 15).ToString()},50%,{Rand.getRandom.Next(48,95).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item5_Background, $"hsl({basisKleur_Min.ToString()},60%,{Rand.getRandom.Next(20,30).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item6_Background, $"hsl({basisKleur.ToString()}, 50%,22%)");
            //KleurenBoek.Add(Bg_Item7_Background, $"hsl({basisKleur_Min},40%,85%) !important");
            //KleurenBoek.Add(Bg_Item7_Border, $"dashed 15px hsl({basisKleur.ToString()},50%,12%)");
            //KleurenBoek.Add(Bg_Item8_Background, $"hsl({(basisKleur_Min-20).ToString()},  40%,{Rand.getRandom.Next(40,90).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item9_Background, $"hsl({(basisKleur_Min+10).ToString()},20%,{Rand.getRandom.Next(40,90).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item10_Background_Image, $"");
            //KleurenBoek.Add(Bg_Item11_Background, $"hsl({basisKleur_Min.ToString()},  60%,{Rand.getRandom.Next(20,30).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item12_Background, $"hsl({basisKleur_Plus.ToString()}, 60%,{Rand.getRandom.Next(50,65).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item13_Background, $"hsl({basisKleur_Min.ToString()},  70%,{Rand.getRandom.Next(80,95).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item14_Background, $"hsl({basisKleur_Min.ToString()},  60%,{Rand.getRandom.Next(20,30).ToString()}%) !important");
            //KleurenBoek.Add(Bg_Item15_Background, $"hsl({basisKleur_Min.ToString()}, 60%,{Rand.getRandom.Next(40,90).ToString()}%) !important");
            //KleurenBoek.Add(Btn_Primary_Background, $"hsl({basisKleur.ToString()},98%,48%)");
            //KleurenBoek.Add(Btn_Primary_Hover_Background, $"hsl({(basisKleur + 20).ToString()}, 100%, 50%)");
            //KleurenBoek.Add(Fs_Background_Image, $"linear_gradient(to left top, hsl({basisKleur.ToString()}, 50%, 80%), hsl({basisKleur.ToString()}, 70%, 45)");
            //KleurenBoek.Add(Fs_Span_Background, $"hsl({basisKleur.ToString()}, 55%, 25%)");
            //KleurenBoek.Add(DataDrager_Dating_Background, $"hsl({basisKleur.ToString()}, 40%, 60%)");
            //KleurenBoek.Add(DataDrager_B_Background, $"hsl({basisKleur.ToString()}, 50%, 55%)");


            //KleurenBoek.Add(Fieldset_Background, $"hsl({basisKleur.ToString()}, 50%,40%)");
            //KleurenBoek.Add(Divcolorbuttons_Background, "hsl({basisKleur.ToString()},40,70)");

            //KleurenBoek.Add(Nuance1_Background, $"hsl({basisKleur.ToString()}, 50%, 20%)");
            //KleurenBoek.Add(Nuance2_Background, $"hsl({basisKleur.ToString()}, 50%, 35%)");
            //KleurenBoek.Add(Nuance3_Background, $"hsl({basisKleur.ToString()}, 50%, 50%)");
            //KleurenBoek.Add(Nuance4_Background, $"hsl({basisKleur.ToString()}, 50%, 65%)");
            //KleurenBoek.Add(Nuance5_Background, $"hsl({basisKleur.ToString()}, 50%, 80%)");
            //KleurenBoek.Add(Nuance6_Background, $"hsl({basisKleur.ToString()}, 50%, 95%)");

            //KleurenBoek.Add(HouseofcolorsBEE_Background, $"hsl({basisKleur.ToString()},100%,50%)");
            //KleurenBoek.Add(HouseofcolorsHoC_Background, $"hsl({basisKleurTegenover.ToString()},100%,50%)");
            //KleurenBoek.Add(HouseofcolorsHusk_Background, $"hsl({basisKleur_Plus.ToString()},100%,50%)");
            //KleurenBoek.Add(HouseofcolorsHeerlen_Background, $"hsl({basisKleur_Min.ToString()},100%,50%)");       
        }

        #region MyRegion

        string InputBackground ="";
        // hsl(@Top.basisKleur,100%,90%);

        string Bg_Grid_Container_Background ="";
        //	hsl(@Top.basisKleur,50%,12%);

        string Bg_Grid_Container_Div;
        //color: hsl(@Top.basisKleur_Min,77%,65%); 
        //}

        string Bg_Item1_Background =""; // hsl(@Top.basisKleur,50%,13%) !important;}
        string Bg_Item2_Background ="";//  hsl(@Top.basisKleur_Min,  50%,@Rand.getRandom.Next(80,90)%) !important;}
        string Bg_Item3_Background =""; // hsl(@Top.basisKleur_Min+20,  50%,@Rand.getRandom.Next(48,95)%) !important;}
        string Bg_Item4_Background =""; // hsl(@Top.basisKleur_Min+15,  40%,@Rand.getRandom.Next(40,95)%) !important;}
        string Bg_Item5_Background =""; // hsl(@Top.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        string Bg_Item6_Background =""; // hsl(@Top.basisKleurSL(50,53,18,28)) !important;}
        string Bg_Item7_Background =""; //  hsl(@Top.basisKleur_Min,  40%,@Rand.getRandom.Next(80,90)%) !important;
        string Bg_Item7_Border; // :dashed 15px hsl(@Top.basisKleur,50%,12%);
                                //}
        string Bg_Item8_Background =""; // hsl(@Top.basisKleur_Min_20,  40%,@Rand.getRandom.Next(40,90)%) !important;}
        string Bg_Item9_Background =""; // hsl(@Top.basisKleur_Min+10,  20%,@Rand.getRandom.Next(40,90)%) !important;}
        string Bg_Item10_Background_Image; // :linear_gradient(hsl(@Top.basisKleurSL(30, 80, 70,90)), hsl(@Top.basisKleurSL(30, 80, 10, 20)));
                                           //	}

        string Bg_Item11_Background =""; // hsl(@Top.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        string Bg_Item12_Background =""; // hsl(@Top.basisKleur_Plus, 60%,@Rand.getRandom.Next(50,65)%) !important;}
        string Bg_Item13_Background =""; // hsl(@Top.basisKleur_Min,  70%,@Rand.getRandom.Next(80,95)%) !important;}
        string Bg_Item14_Background =""; // hsl(@Top.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        string Bg_Item15_Background =""; // hsl(@Top.basisKleur_Min, 60%,@Rand.getRandom.Next(40,90)%) !important;}

        string Btn_Primary_Background ="";  // hsl(@Top.basisKleurSL(98,101,48,52));} 
        string Btn_Primary_Hover_Background =""; //  hsl(@(Top.basisKleur + 20), 100%, 50%);}

        string Fs_Background_Image; // linear_gradient(to left top, hsl(@Top.basisKleurSL(30, 80, 70, 90)), hsl(@Top.basisKleurSL(60, 80, 35,60)));
                                    //}

        string Fs_Span_Background ="";
        //hsl(@Top.basisKleurSL(50, 60, 20, 30));

        string DataDrager_Dating_Background ="";
        //hsl(@Top.basisKleurSL(20, 60, 20, 80));}
        string DataDrager_B_Background ="";
        //hsl(@Top.basisKleurSL(20, 60, 20, 80));}

        string Fieldset_Background ;
//hsl(@Top.basisKleurSL(45, 60, 40, 42));
//}
string Divcolorbuttons_Background =""; 
//hsl(@Top.basisKleurSL(20,70,20,80));} 

string Nuance1_Background ="";
//hsl(@Top.basisKleurSL(49,80,15,25));

string Nuance2_Background ="";
//hsl(@Top.basisKleurSL(40,80,30,40));

string Nuance3_Background ="";  // hsl(@Top.basisKleurSL(40,80,45,55));

string Nuance4_Background ="";
//hsl(@Top.basisKleurSL(40,80,60,70));

string Nuance5_Background ="";
//hsl(@Top.basisKleurSL(40,80,75,85));

string Nuance6_Background ="";
//hsl(@Top.basisKleurSL(40,80,88,95));

string HouseofcolorsBEE_Background =""; //hsl(@Top.basisKleur,100%,50%);}
string HouseofcolorsHoC_Background =""; //hsl(@Top.basisKleurTegenover,100%,50%);}
string HouseofcolorsHusk_Background =""; //hsl(@Top.basisKleur_Plus,100%,50%);}
string HouseofcolorsHeerlen_Background ="";
//hsl(@Top.basisKleur_Min,100%,50%);}



        #endregion







///////////////////////////////////////



    }

}






