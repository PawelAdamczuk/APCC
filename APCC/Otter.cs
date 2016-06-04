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
            "Hi, I am an otter",
            "Hello and welcome",
            "Sweet otter FTW",
            "This app is THE best",
            "You gonna eat that?",
            "Stop messing with my fur",
            "Stop. Messing. With the fur.",
            "Java sucks",
            "C# rules",
            "C++ is cool as well (dem pointerz)",
            "Worship the otter and its aristocratic fur.",
            "Feel free to try all the buttons up there",
            "Creating builds is so cool",
            "You got 'nam flashbacks as well..?",
            "I ain't touchin' you, you're one of them AGH people.",
            "I am not too fond of mice",
            "Can you move that mouse thingie away?",
            "Bulk first, fur later.",
            "The best thing to hold onto in life is each otter.",
            "I like garlic",
            "I like garlic so much",
            "Got any idea why the other otters always move away fronm me?",
            "Neither do I",
            "Alright, get back to your business",
            "My wife was the Miss Otter in '67",
            "Good ol' times..."
        };

        // User statistics
        static string[] hintUserStats = new string[]{
            "This is the user statistics view",
            "It shows you your slacking off factor",
            "Click 'Close' to... well, close"
        };

        // Global statistics
        static string[] hintGlobalStats = new string[]{
            "These are the system statistics",
            "The 'Global' tab shows the overall statistics",
            "The 'Users' tab shows single user statistics",
            "Use the dropdown menu to change the shown user"
        };

        // Builds show
        static string[] hintBuilds = new string[]{
            "Here you can show the builds",
            "After highlighting the build you can see its components",
            "Below, there are build properties such as its status and author",
            "On the right hand side you will find a bunch of useful buttons",
            "'Add new' shows the build adding window",
            "'Edit panel' shows the build properties and editing window",
            "'Delete'... well, go figure.",
            "'Accept' lets you accept the build after you proved it to be correct",
            "'Close'... are you still wondering what that button does?"
        };

        // Show components
        static string[] hintComponents = new string[]{
            "This is the place where you can see all the available components",
            "Use the dropdown menu on the left hand side to list \n the components of a given type",
            "'Add new' lets you add new components",
            "'Details' shows the highlighted component's summary",
            "The 'Delete' button... you might be getting the hang of it already",
            "If you don't like a particular component, go ahead and edit it after clicking the 'Edit' button",
            "Click 'Close' if all the mambo jambo makes you feel dizzy"
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
            "Velcome to the privilege management and user role editing window.",
            "You can see the roles that can be assigned to the users",
            "Add new role after clicking 'Add'",
            "You can also delete a role with 'Delete'",
            "Click 'Edit' to change the highlighted role's properties",
            "Watch out! You cannot edit the 'administrator' and 'null' roles",
            "Click 'Close' already, you megalomaniac"
        };

        // Show users
        static string[] hintShowUsers = new string[]{
            "This window lets you manage the system's users",
            "The left hand side shows the user list",
            "The right side, on the otter hand, shows the builds created by the highlighted user",
            "The 'Add' button opens the user adding window",
            "Click 'Delete' to delete the user.",
            "No, just his account you psychopath.",
            "'Edit' edits the selected user ACCOUNT",
            "'Details' shows the build details",
            "'Close' ends the dreams of getting rid of your coworkers"
        };

        // Show options
        static string[] hintOptions = new string[]{
            "Here you can change some options, friendo",
            "The first and only option lets you turn me on",
            "That's awkward though, I only see you as a friend",
            "So yeah, don't mess with that checkbox",
            "BFF's <3"
        };

        // Show options
        static string[] hintProfil = new string[]{
            "User profile management",
            "You can change your password here.",
            "No password confirmation textbox, don't use when drunk"
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
