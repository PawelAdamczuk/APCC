using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APCC
{
    class Otter
    {
        //
        // Hints for Forms
        //

        // Default 
        static string[] hintDefault = new string[]{
            "Cześć, jestem wyderką",
            "Witam serdecznie",
            "Słodka wyderka zawsze spoko",
            "Ten program jest najlepszy",
            "Dasz mi coś do jedzonka ?",
            "Przestań klikać, niszczysz futerko",
            "Nie rozumiesz ?",
            "Java jest do kitu",
            "Tylko C#",
            "Albo C++ ze wskaźnikami",
            "Czcij wyderkę i jej szlachetne futro",
            "Zapraszam do kliknięcia w powyższe przyciski",
            "Robienie buildów takie fajne",
            "Czy ty też miewasz flashbacki z Wietnamu ?",
            "Nie podam Ci łapki, jesteś z AGH",
            "Nie lubie myszy",
            "Możesz wziąć stąd tą mysz ?",
            "Najpierw masa, potem futro",
            "Być albo nie być wydrą, oto jest pytanie",
            "Lubie czosnek",
            "Bardzo lubie czosnek",
            "Wiesz czemu inne wydry ode mnie uciekają ?",
            "Ja też nie",
            "Dobra, zajmij się sobą",
            "Moja żona wydra była Miss Otter w '67",
            "To były czasy..."
        };

        // User statistics
        static string[] hintUserStats = new string[]{
            "Oto okienko statystyk użytkownika",
            "Pokazuje jak bardzo obijasz się w pracy"
        };

        // Global statistics
        static string[] hintGlobalStats = new string[]{
            "Oto statystyki aplikacji",
            "Zakładka 'Global' pokazuje statystyki ogólne",
            "Zakładka 'Users' pokazuje statystyki poszczególnych użytkowników"
        };

        //
        // System
        //
        static private Form activeForm = null;
        static private int hintNumber = 0;

        static private string[] activeHints = hintDefault;

        static public string Click( Form pActiveForm ) {
            if (pActiveForm != null)
            {
                Type lType = pActiveForm.GetType();
                bool lTypeFound = false;

                // Types of Forms
                if (lType == typeof(Forms.GlobalStatisticsForm)) {
                    activeHints = hintGlobalStats;
                    lTypeFound = true;
                }

                if (lType == typeof(Forms.UserStatisticsForm))
                {
                    activeHints = hintUserStats;
                    lTypeFound = true;
                }

                if (!lTypeFound)
                {
                    if (activeForm == null){
                        hintNumber++;
                    } else {
                        activeHints = hintDefault;
                        hintNumber = 0;
                    }

                    activeForm = null;
                } else {

                    if (activeForm != null && activeForm.GetType() == pActiveForm.GetType())
                    {
                        hintNumber++;
                    }
                    else {
                        hintNumber = 0;
                        activeForm = pActiveForm;
                    }
                }
            }
            else {
                if (activeForm == null)
                {
                    hintNumber++;
                }
                else {
                    activeHints = hintDefault;
                    hintNumber = 0;
                }

                activeForm = null;
            }

            hintNumber = hintNumber % activeHints.Length;
            return activeHints[hintNumber];
        }
    }
}
