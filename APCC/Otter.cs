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
            "Pokazuje jak bardzo obijasz się w pracy",
            "Naciśnij 'Close' aby zamknąć"
        };

        // Global statistics
        static string[] hintGlobalStats = new string[]{
            "Oto statystyki aplikacji",
            "Zakładka 'Global' pokazuje statystyki ogólne",
            "Zakładka 'Users' pokazuje statystyki poszczególnych użytkowników",
            "Użyj rozwijanego menu aby zmienić wyświetlanego użytkownika"
        };

        // Builds show
        static string[] hintBuilds = new string[]{
            "Tutaj można wyświetlić buildy",
            "A po kliknięciu na build wyświetlają się jego podzespoły",
            "Poniżej znajdują się szczegóły takie jak twórca buildu i jego stan akceptacji",
            "Po prawej znajdują się bardzo pomocne przyciski",
            "'Add new' dodaje nowy build",
            "'Edit panel' wyświetla panel gdzie można przeglądnąć szczegóły buildu \n oraz przeprowadzić jego edycję",
            "Przycisk 'Delete' usuwa wskazany build",
            "'Accept' pozwala na zaakceptowanie buildu i potwierdza jego poprawność",
            "'Close' zamyka okno dialogowe"
        };

        // Show components
        static string[] hintComponents = new string[]{
            "Oto miejsce gdzie możesz wyświetlić wszystkie podzespoły",
            "Użyj rozwijanego menu po lewej stronie aby wyświetlić \n podzespoły poszczególnych typów",
            "Dzięki 'Add new' możesz dodawać nowe podzespoły komputerowe",
            "'Details' wyświetla podsumowane informacje o zaznaczonym podzespole",
            "Przycisk 'Delete' służy jak można się domyślić do usuwania podzespołów",
            "Jeżeli nie podoba Ci się jakiś podzespół możesz śmiało rozpocząć \n jego edycję klikająć na przycisk 'Edit'",
            "Kliknij na 'Close' jeżeli masz dosyć oglądania podzespołów"
        };

        // Show components
        static string[] hintComponentTypes = new string[]{
            "Tutaj znajdują się typy podzespołów",
            "Dodaj typ aby móc dodawać podzespoły tego typu w aplikacji",
            "Przycisk 'Add' służy do dodawania typów",
            "Klikając przycisk 'Delete' usuniesz typ",
            "Edycja typu znajduje się pod 'Edit'",
            "Jeżeli masz już dość wydry gadającej o typach podzespołów kliknij 'Close'"
        };

        // Show roles and permissions
        static string[] hintRoles = new string[]{
            "Witaj w oknie zarządzania uprawnieniami oraz rolami użytkowników",
            "Widzisz tu poszczególne role które możesz potem przypisać użytkownikom",
            "Dodaj nową role przyciskiem 'Add'",
            "Możesz równierz usunąć role przyciskiem 'Delete'",
            "Kliknij 'Edit' by zedytować zaznaczoną role",
            "Uważaj ! Nie możesz edytować roli 'administrator' i 'null'",
            "Żeby wyjść kliknij 'Close'"
        };

        // Show users
        static string[] hintShowUsers = new string[]{
            "To okienko służy do zarządzania użytkowniami",
            "Po lewej wyświetlją się użytkownicy",
            "Natomiast po prawej buildy które stworzył zaznaczony użytkownik",
            "Przycisk 'Add' służy do dodawania użytkowników",
            "Kliknij 'Delete' aby usunąć użytkownika",
            "'Edit' edytuje zaznaczone użytkownika",
            "'Details' wyświetla szczegóły o zaznaczonym buildzie",
            "'Close' zamyka okienko"
        };

        // Show options
        static string[] hintOptions = new string[]{
            "Tutaj możesz zmienić opcje mój przyjacielu",
            "Pierwsza opcja z góry to opcja pokazywania i chowania wydry",
            "Masz jej nie klikac bo chce tu być"
        };

        // Show options
        static string[] hintProfil = new string[]{
            "Zarządzanie profilem użytkownika",
            "Możesz sobie tutaj zmienić hasło"
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
                if (lType == typeof(Forms.GlobalStatisticsForm))
                    { activeHints = hintGlobalStats; lTypeFound = true; }
                if (lType == typeof(Forms.UserStatisticsForm))
                    { activeHints = hintUserStats; lTypeFound = true;}
                if (lType == typeof(Forms.BuildsManagerForm))
                    { activeHints = hintBuilds; lTypeFound = true; }
                if (lType == typeof(Forms.ShowComponentsForm))
                    { activeHints = hintComponents; lTypeFound = true; }
                if (lType == typeof(Forms.TypesManagerForm))
                    { activeHints = hintComponentTypes; lTypeFound = true; }
                if (lType == typeof(Forms.RolesManagerForm))
                    { activeHints = hintRoles; lTypeFound = true; }
                if (lType == typeof(Forms.UsersManageForm))
                    { activeHints = hintShowUsers; lTypeFound = true; }
                if (lType == typeof(Forms.Options))
                    { activeHints = hintOptions; lTypeFound = true; }
                if (lType == typeof(ProfilManage))
                    { activeHints = hintProfil; lTypeFound = true; }

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
