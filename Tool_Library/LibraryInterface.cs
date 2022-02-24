using Assignment;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_Library
{

    class LibraryInterface : iToolLibrarySystem
    {
        private iMember Loggedin_user; //variable for quick access for the current user
        private iTool[] top3 = { new Tool("Null"), new Tool("Null"), new Tool("Null") }; //top three storage array
        private BSTree MemberTree = new BSTree(); //member tree
        private BSTree AdminTree = new BSTree(); //admin tree
        //Collection of tools, stored in array's, with each array contianing multiple tool types for each collection
        private Toolcollection[][] AllTools = {
            new Toolcollection[] {new Toolcollection("Line Trimmers"),new Toolcollection("Lawn Mowers"), new Toolcollection("Hand Tools"),new Toolcollection("Wheelbarrows"),new Toolcollection("Garden Power Tools")},
            new Toolcollection[] {new Toolcollection("Scrapers"),new Toolcollection("Floor Lasers"),new Toolcollection("Floor Levelling Tools"),new Toolcollection("Floor Levelling Materials"),new Toolcollection("Floor Hand Tools"),new Toolcollection("Tiling Tools")},
            new Toolcollection[] {new Toolcollection("Hand Tools"),new Toolcollection("Electric Fencing"), new Toolcollection("Steel Fencing Tools"),new Toolcollection("Power Tools"),new Toolcollection("Fencing Accessories")},
            new Toolcollection[] {new Toolcollection("Distance Tools"), new Toolcollection("Laser Measurer"), new Toolcollection("Measuring Jugs"),new Toolcollection("Temperature & Humidity Tools"),new Toolcollection("Levelling Tools"),new Toolcollection("Markers")},
            new Toolcollection[] {new Toolcollection("Draining"), new Toolcollection("Car Cleaning"),new Toolcollection("Vaccum"),new Toolcollection("Pressure Cleaners"),new Toolcollection("Pool Cleaning"),new Toolcollection("Floor Cleaning")},
            new Toolcollection[] {new Toolcollection("Sanding Tools"),new Toolcollection("Brushes"),new Toolcollection("Rollers"),new Toolcollection("Paint Removal Tools"),new Toolcollection("Paint Scrapers"),new Toolcollection("Sprayers")},
            new Toolcollection[] {new Toolcollection("Voltage Tester"),new Toolcollection("Oscilloscopes"),new Toolcollection("Thermal Imaging"),new Toolcollection("Data Test Tool"),new Toolcollection("Insulation Testers")},
            new Toolcollection[] {new Toolcollection("Test Equipment"),new Toolcollection("Safety Equipment"),new Toolcollection("Basic Hand Tools"),new Toolcollection("Circuit Protection"),new Toolcollection("Cabel Tools")},
            new Toolcollection[] {new Toolcollection("Jacks"),new Toolcollection("Air Compressors"),new Toolcollection("Battery Chargers"),new Toolcollection("Socket Tools"),new Toolcollection("Braking"),new Toolcollection("Drivetrain")},
        };
        /*
         * Helper function to make console wait for user input
         */
        public void wait() {
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }
        /*
         * initalise some variables into the program
         */
        public LibraryInterface()
        {
            MemberTree.add(new Member("Sophia", "Politylo", "0434949966", "pass1234"));
            MemberTree.add(new Member("Joshua", "Politylo", "034224141241", "pass7654"));
            MemberTree.add(new Member("Jim", "Smith", "0321413", "word9876"));
            MemberTree.add(new Member("Jim", "Hwake", "9352252626", "word4321"));
            MemberTree.add(new Member("Alpha", "Zappter", "2526161715", "word4321"));
            MemberTree.add(new Member("Zac", "Braff", "0424244", "password"));
            MemberTree.add(new Member("Grace", "Mcsmith", "9292999", "password"));
            MemberTree.add(new Member("Tim", "Obrain", "05259529502", "password"));
            MemberTree.add(new Member("Katie", "Roman", "0242574735", "password"));
            AdminTree.add(new Member("staff", "", "04343434", "today123"));

            AllTools[4][1].add(new Tool("metal shine", 2));
            AllTools[4][1].add(new Tool("shining speed", 2));
            AllTools[4][2].add(new Tool("Zqw123 Vaccum", 1));
            AllTools[4][2].add(new Tool("Ab-3343 Vaccum", 2));
            AllTools[4][2].add(new Tool("jumbo Vac", 1));
            AllTools[4][3].add(new Tool("The yellow Gerni", 1));
            AllTools[4][3].add(new Tool("5000 high pressure washer", 10));
            AllTools[4][4].add(new Tool("Bottom cleaner 5420", 1));
            AllTools[4][4].add(new Tool("The aqua Roomba", 6));
            AllTools[4][5].add(new Tool("Steam vac", 6));
            AllTools[4][5].add(new Tool("Mop and bucket", 15));
            AllTools[4][2].add(new Tool("1674-Z Vaccum", 10));
            AllTools[3][2].add(new Tool("1L jug", 2));
            AllTools[3][3].add(new Tool("thermometer", 20));
            AllTools[3][3].add(new Tool("weather balloon", 1));
            AllTools[3][5].add(new Tool("cone", 30));
            AllTools[3][5].add(new Tool("chalk marker", 3));
            AllTools[3][5].add(new Tool("chalk line marker 3m", 2));
            AllTools[2][0].add(new Tool("Mallet 1kg", 10));
            AllTools[2][0].add(new Tool("Mallet 450g", 3));
            AllTools[2][1].add(new Tool("Stainless steel electric fence 10m", 23));
            AllTools[2][1].add(new Tool("strip cell grazing electric fence", 12));
            AllTools[3][0].add(new Tool("20m tape measure", 2));
            AllTools[3][0].add(new Tool("2m tape measure", 25));
            AllTools[3][0].add(new Tool("1m ruler", 10));
            AllTools[3][0].add(new Tool("30cm ruler", 2));
            AllTools[3][0].add(new Tool("Square3 ruler", 2));
            AllTools[3][0].add(new Tool("Sliding ruler", 2));
            AllTools[3][0].add(new Tool("angle ruler", 2));
            AllTools[3][0].add(new Tool("ruler 49", 2));
            AllTools[3][0].add(new Tool("seven edges", 2));
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[0]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[2]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[2]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[2]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[2]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[2]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[2]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[1]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[1]);




            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[7]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[6]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[6]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[6]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[6]);

            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[4]);
            borrowTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[3]);
            returnTool(new Member("Zac", "Braff", "0424244", "password"), AllTools[3][0].toArray()[3]);
            AllTools[1][4].add(new Tool("Floor Hammer", 2));
            AllTools[1][5].add(new Tool("The tile placer", 1));
            AllTools[1][5].add(new Tool("Grout scraper", 2));
            AllTools[1][0].add(new Tool("scraper", 3));
            AllTools[1][1].add(new Tool("The striaght line maker", 1));
            AllTools[1][1].add(new Tool("The Standard lazer", 3));
            AllTools[1][2].add(new Tool("The leveler", 3));
            AllTools[1][2].add(new Tool("The good ol' yellow", 30));
            AllTools[1][3].add(new Tool("Pine wood", 120));
            AllTools[1][3].add(new Tool("1970 vinyl", 400));
            AllTools[1][3].add(new Tool("The shagster", 10));
            AllTools[0][3].add(new Tool("the little Wheeler", 10));
            AllTools[0][3].add(new Tool("the personal dump truck", 2));
            AllTools[0][4].add(new Tool("The power trimmer", 1));
            AllTools[0][0].add(new Tool("the straight Cutter"));
            AllTools[0][0].add(new Tool("The fancy boy cutter"));
            AllTools[0][1].add(new Tool("GrassTrimmer 4300"));
            AllTools[0][1].add(new Tool("ZXQ-343X"));
            AllTools[0][1].add(new Tool("ZXQ-343X"));
            AllTools[0][1].add(new Tool("ZXQ-343X"));
            AllTools[0][1].add(new Tool("ZXQ-343X"));
            AllTools[0][1].add(new Tool("Mower T-20"));
            borrowTool(MemberTree.search(new string[] { "Grace", "Mcsmith" }), AllTools[3][0].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Grace", "Mcsmith" }), AllTools[0][0].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Katie", "Roman" }), AllTools[1][2].toArray()[1]);
            borrowTool(MemberTree.search(new string[] { "Tim", "Obrain" }), AllTools[3][2].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Tim", "Obrain" }), AllTools[0][3].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Tim", "Obrain" }), AllTools[0][3].toArray()[0]);

        }

        /*
         * Checks if readline is only numbers
         */
        private bool IsDigitsOnly(string str)
        {
            if ((string.IsNullOrWhiteSpace(str)) | (string.IsNullOrEmpty(str))) {
                return false;
            }
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        /*
         *Generic title and line output function 
         */
        public void displaydynamic(string title, string output)
        {
            Console.WriteLine("Welcome to the Tool Libray");
            Console.WriteLine("=========={0}==========", title);
            Console.WriteLine("{0}", output);
        }
        /*
         * Functions to display a list of tools t othe  user in the form of 
         * a numbered list to chose an action
         * takes string, title for screen
         *          tool[] tools to display
         */
        public int displaychoice(string title, iTool[] inputs)
        {
            Console.Clear();
            int command = -1;
            //write title
            Console.WriteLine("Welcome to the Tool Libray");
            Console.WriteLine("=========={0}==========", title);
            int num = 1;
            int leng = 20 + title.Length;
            //prints out the tools in a list
            foreach (Tool action in inputs)
            {
                Console.WriteLine("{0}. {1}", num, action.Name);
                num++;
            }
            Console.WriteLine("0. Exit");
            for (int i = 0; i < leng; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine();
            Console.WriteLine("please make a selection (1-{0}, or 0 to exit", num);
            while (command == -1)
            {
                string input = Console.ReadLine();
                if (IsDigitsOnly(input)) { command = int.Parse(input); }

            }
            return command;
        }
        /*
         * Function to display a list of stirngs in a form of a list of actions the user can take 
         * takes: string, title for menu
         *          string[], options for the user to select
         */
        public int displaychoice(string title, string[] inputs)
        {
            Console.Clear();
            int command = -1;
            string input;
            //write title of page to screen
            Console.WriteLine("Welcome to the Tool Libray");
            Console.WriteLine("=========={0}==========", title);
            int num = 1;
            int leng = 20 + title.Length;
            //write options for the user to the screen
            foreach (string action in inputs)
            {
                Console.WriteLine("{0}. {1}", num, action);
                num++;
            }
            Console.WriteLine("0. Exit");
            for (int i = 0; i < leng; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine();
            Console.WriteLine("please make a selection (1-{0}, or 0 to exit", num);
            //waiting for the user's input
            while (command == -1)
            {
                command = -1;
                input = Console.ReadLine();
                //checking if the user's input is a nuumber
                if (IsDigitsOnly(input)) {
                    command = int.Parse(input);
                }

            }
            return command;
        }
        /*
         * Login meun screen to display to the user
         */
        public void MenuLogin()
        {

            Loggedin_user = null;//set current logged in user to null
            string[] options = { "staff login", "Member Login" }; //ask the user who is login in
            int command = displaychoice("Main Menu", options);
            Console.Clear();
            //checks if the user is an admin or a normal member
            switch (command)
            {
                case 1:
                    {
                        displaydynamic("Staff Login", "Please enter Username, or 0 to exit");
                        string uname = Console.ReadLine();
                        Console.WriteLine("please enter user password, or 0 to exit");
                        string password = Console.ReadLine();
                        string[] uname_search = uname.Split(' ');
                        //returns the member if they exist within the bs tree
                        IComparable exists = AdminTree.search(uname_search);
                        //checks password if user exists
                        if (exists != null)
                        {
                            Member user = (Member)exists;
                            //compares the passowrd entered and the password the user gave
                            if (user.PIN == password)
                            {
                                Console.WriteLine("You have been logged in");
                                Console.Clear();
                                //sets the logged in user to this member
                                Loggedin_user = user;
                                //takes the user to the correct main menu screen
                                Menustaff();
                            }
                        }

                        break;
                    }

                case 2:
                    {
                        displaydynamic("User Login", "Please enter Username, or 0 to exit");
                        string uname = Console.ReadLine();
                        Console.WriteLine("please enter user password, or 0 to exit");
                        string password = Console.ReadLine();
                        string[] uname_search = uname.Split(' ');
                        //returns the member if they exist within the bs tree
                        IComparable exists = MemberTree.search(uname_search);
                        //checks password if user exists
                        if (exists != null)
                        {
                            //compares the passowrd entered and the password the user gave
                            Member user = (Member)exists;
                            if (user.PIN == password)
                            {
                                Console.WriteLine("You have been logged in");
                                Console.Clear();
                                //sets the logged in user to this member
                                Loggedin_user = user;
                                //takes the user to the correct main menu screen
                                MenuUser();
                            }

                        }

                        break;
                    }

                case 3:
                    //special case to run tests
                    test();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
            MenuLogin();
        }
        /*
         * Choose which sub catigory to display a select list from
         * this function is used for the display tool function as it allows for the user to view all tools in a catigory
         */
        public int displaySubCatAll(int com)
        {
            int command = -1;
            com++;
            string[] options = { "null" };
            switch (com)
            {
                case 1:
                    options = new string[] { "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools", "All" };
                    break;
                case 2:
                    options = new string[] { "Scrapers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools", "All" };
                    break;
                case 3:
                    options = new string[] { "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories", "All" };
                    break;
                case 4:
                    options = new string[] { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers", "All" };
                    break;
                case 5:
                    options = new string[] { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning", "All" };
                    break;
                case 6:
                    options = new string[] { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers", "All" };
                    break;
                case 7:
                    options = new string[] { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers", "All" };
                    break;
                case 8:
                    options = new string[] { "Test Equipment", "Safety Equipment", "Basic Hand tools", "Circuit Protection", "Cable Tools", "All" };
                    break;
                case 9:
                    options = new string[] { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain", "All" };
                    break;
            }
            command = displaychoice("Select tool Type", options);
            return command;
        }
        /*
         * Choose which sub catigory to display a select list from
         */
        public int displaySubCat(int com) {
            int command = -1;
            com++;
            string[] options = { "null" };
            switch (com)
            {
                case 1:
                    options = new string[] { "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools" };
                    break;
                case 2:
                    options = new string[] { "Scrapers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" };
                    break;
                case 3:
                    options = new string[] { "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
                    break;
                case 4:
                    options = new string[] { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" };
                    break;
                case 5:
                    options = new string[] { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };
                    break;
                case 6:
                    options = new string[] { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
                    break;
                case 7:
                    options = new string[] { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
                    break;
                case 8:
                    options = new string[] { "Test Equipment", "Safety Equipment", "Basic Hand tools", "Circuit Protection", "Cable Tools" };
                    break;
                case 9:
                    options = new string[] { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };
                    break;
            }
            command = displaychoice("Select tool Type", options);
            return command;
        }
        /*
         * Displays the chooses the user has when they are logged in as an admin
         */
        public void Menustaff() {
            string[] options = { "Add new Tool", "Add an existing tool", "Remove a tool", "Register a new member", "Remove a member", "Find a contact number", "Find user's rented tools" };
            int com = displaychoice("Staff Menu", options);
            switch (com)
            {
                case 1:
                    MenuAddTool();
                    break;
                case 2:
                    MenuAddexistingTool();
                    break;
                case 3:
                    MenuRemoveTool();
                    break;
                case 4:
                    MenuAddUserMenu();
                    break;
                case 5:
                    MenuRemoveUser();
                    break;
                case 6:
                    MenuContact();
                    break;
                case 7:
                    MenufindTools();
                    break;
                case 0:
                    MenuLogin();
                    break;
            }
            Menustaff();


        }
        /*
        * Displays the menu for a normal user, with all actions they can  preform
        */
        public void MenuUser() {
            string[] options = { "Display all tools of a given type", "Borrow a tool", "Return a tool", "List my rented tools", "Display top 3 rented tools" };
            int com = displaychoice("Member Menu", options);
            switch (com)
            {
                case 1:
                    MenuDisplayTools();
                    break;
                case 2:
                    MenuBorrow();
                    break;
                case 3:
                    MenuReturn();
                    break;
                case 4:
                    MenuRenting();
                    break;
                case 5:
                    displayTopTHree();
                    break;
                case 0:
                    MenuLogin();
                    break;
            }
            MenuUser();
        }
        public void MenufindTools() {
            Console.Clear();
            displaydynamic("Find A Members rented tools", "Enter a members Phone Number:");
            string phone = Console.ReadLine();
            display(phone);
        }
        /*
        * Menu for admin to add a new tool to the tool library
        */
        public void MenuAddTool() {
            Console.Clear();
            //display the Categories for all the tools and get the user to select one 
            string[] Cats = { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools" };
            int toolCategory = displaychoice("Select tool Categories", Cats) - 1;
            //display the tool types for that categories and let the user select one
            int tooltype = -1;
            if (toolCategory != -1) {
                tooltype = displaySubCat(toolCategory) - 1;
            }
            Console.Clear();
            if (tooltype != -1) {
                Console.WriteLine("-------Current Tools in Subcategory-------");
                iTool[] Toolcol = AllTools[toolCategory][tooltype].toArray();
                //print out the tools to let the user see if it has already been added
                if (Toolcol.Length > 0)
                {
                    foreach (Tool t in Toolcol)
                    {
                        Console.WriteLine(t.tostring());
                    }
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
                //get the name and the amount of the new tool to add
                displaydynamic("Select tool Name", string.Format("The new tool will be created in:\n    Category: {0} \n    As type: {1}\n\nenter a name for this tool", Cats[toolCategory], AllTools[toolCategory][tooltype].collectiontype()));
                string name = Console.ReadLine();
                displaydynamic("Amount to Add", "Enter amount to add: ");
                string amountstr = Console.ReadLine();
                int amount = 1;
                //check that amount is a number
                if (IsDigitsOnly(amountstr)) {
                    amount = Math.Abs(int.Parse(amountstr));
                }
                //add new tool to the tool type selected
                AllTools[toolCategory][tooltype].add(new Tool(name, amount));
                Console.Clear();
                //print out the updated tool type list
                Console.WriteLine("-------Updated Tools in Subcategory-------");
                Toolcol = AllTools[toolCategory][tooltype].toArray();
                if (Toolcol.Length > 0)
                {
                    foreach (Tool t in Toolcol)
                    {
                        Console.WriteLine(t.tostring());
                    }
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
            }
        }
        /*
        * Menu for an admin to remove a tool from the tool library
        */
        public void MenuRemoveTool()
        {
            Console.Clear();
            //get the Category to remove to
            string[] Cats = { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools" };
            int toolCategory = displaychoice("Select tool Categories", Cats) - 1;
            int tooltype = -1;
            int tool = -1;
            //get the type to remove to
            if (toolCategory >= 0) {
                tooltype = displaySubCat(toolCategory) - 1;
            }
            //get the tool to remove
            if (tooltype >= 0) {
                tool = displaychoice("Select tool to Remove", AllTools[toolCategory][tooltype].toArray()) - 1;
            }

            if ((tool >= 0)) {
                //get the amount to remove
                displaydynamic("Amount to Remove", $"{AllTools[toolCategory][tooltype].toArray()[tool].Name} has {AllTools[toolCategory][tooltype].toArray()[tool].Quantity}\nEnter amount to remove (enter nothing to remove all):");
                string amountstr = Console.ReadLine();
                int amount;
                //check that the amoun to remove is a number
                if (!IsDigitsOnly(amountstr))
                {
                    amount = AllTools[toolCategory][tooltype].toArray()[tool].AvailableQuantity;
                }
                //else set the total amount to remove the available quantity
                else
                {
                    amount = int.Parse(amountstr);
                    if (amount > AllTools[toolCategory][tooltype].toArray()[tool].AvailableQuantity)
                    {
                        amount = AllTools[toolCategory][tooltype].toArray()[tool].AvailableQuantity;
                    }
                }
                //removing the requested amunt of the tool
                AllTools[toolCategory][tooltype].delete(AllTools[toolCategory][tooltype].toArray()[tool], amount);
                Console.WriteLine("------------Updated tool array------------");
                foreach (Tool t in AllTools[toolCategory][tooltype].toArray()) {
                    Console.WriteLine(t.tostring());
                }
                Console.WriteLine("------------------------------------------");
                wait();
            }

        }
        /*
        * Menu for admin to add more of a pre existing to into the tool library
        */
        public void MenuAddexistingTool() {
            Console.Clear();
            string[] Cats = { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools" };
            int toolCategory = displaychoice("Select tool Categories", Cats) - 1;
            int tooltype = -1;
            if (toolCategory != -1) {
                tooltype = displaySubCat(toolCategory) - 1;
            }
            int tool = -1;
            if (tooltype != -1)
            {
                tool = displaychoice("Select tool to add to", AllTools[toolCategory][tooltype].toArray()) - 1;
            }
            if (tool != -1) {
                displaydynamic("Amount to add", $"{AllTools[toolCategory][tooltype].toArray()[tool].Name} has {AllTools[toolCategory][tooltype].toArray()[tool].Quantity}\nEnter amount to add:");
                string amountstr = Console.ReadLine();
                int amount = 1;
                if (IsDigitsOnly(amountstr))
                {
                    amount = int.Parse(amountstr);
                }
                Tool temp = new Tool(AllTools[toolCategory][tooltype].toArray()[tool].Name, amount);
                AllTools[toolCategory][tooltype].add(temp);
                foreach (Tool t in AllTools[toolCategory][tooltype].toArray())
                {
                    Console.WriteLine(t.tostring());
                }
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
            }

        }
        /*
        * menu for admin to a a new user into the member collection
        */
        public void MenuAddUserMenu()
        {
            Console.Clear();
            displaydynamic("Add New member", "Enter User's First name:");
            string fname = Console.ReadLine();
            Console.Write("Enter User's Last Name:");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter User's phone number:");
            string PhoneNum = Console.ReadLine();
            Console.WriteLine("Enter User's password");
            string password = Console.ReadLine();
            string[] uname_search = { fname, lname };
            Member toadd = new Member(fname, lname, PhoneNum, password);
            add(toadd);
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Menustaff();
        }
        /*
        * menu for admin to remove a user in the binary search tree
        */
        public void MenuRemoveUser() {
            Console.Clear();
            string[] option = { "Admin", "Member" };
            int usertype = displaychoice("Select User type to remove", option);
            Console.Clear();
            displaydynamic("Remove user", "please enter a user's firstname and lastname, with a space in bettween both:");
            string name = Console.ReadLine();
            string[] uname_search = name.Split(' ');
            IComparable existsAdmin = AdminTree.search(uname_search);
            IComparable exists = MemberTree.search(uname_search);
            Member user = null;
            if (exists != null)
            {
                user = (Member)exists;
            }
            else if (existsAdmin != null) {
                user = (Member)existsAdmin;
            }
            if (user != null)
            {
                delete(user);
            }
            else {
                Console.WriteLine("User does not exist in the database");
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Menustaff();

        }
        /*
        * Finds a user's contact phone number via a user's first name and last name
        */
        public void MenuContact() {
            Console.Clear();
            displaydynamic("Find Contact number for user", "please enter a users first name last name or both");
            string name = Console.ReadLine();
            string[] uname_search = name.Split(' ');
            IComparable exists = MemberTree.search(uname_search);
            Member user = null;
            if (exists != null)
            {
                user = (Member)exists;
            }
            else {
                exists = AdminTree.search(uname_search);
                if (exists != null)
                {
                    user = (Member)exists;
                }
            }
            if (user != null)
            {
                Console.WriteLine("The phone number for {0} is {1}", name, user.ContactNumber);
            }
            else {
                Console.WriteLine("no member with the name {0} was found ", name);
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Menustaff();

        }
        /*
        * Menu for a normal member to view all the tools in the tool library
        */
        public void MenuDisplayTools() {
            Console.Clear();
            string[] Cats = { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools", "All" };
            int toolCategory = displaychoice("Select tool Categories", Cats) - 1;
            int tooltype = -1;
            Console.Clear();
            if ((toolCategory != 9) & (toolCategory != -1))
            {
                tooltype = displaySubCatAll(toolCategory) - 1;
                if (tooltype != -1) {
                    Console.WriteLine("{0} {1}", tooltype, AllTools[toolCategory].Length);
                    if (tooltype != (AllTools[toolCategory].Length) | (tooltype != -1))
                    {
                        iTool[] Toolcol = AllTools[toolCategory][tooltype].toArray();
                        if (Toolcol.Length > 0)
                        {
                            foreach (Tool t in Toolcol)
                            {
                                Console.WriteLine(t.tostring());
                            }
                        }
                    }
                    else if (tooltype != -1) {
                        foreach (Toolcollection TC in AllTools[toolCategory])
                        {
                            Console.WriteLine("----------{0}----------", TC.collectiontype());
                            iTool[] toolcol = TC.toArray();
                            if (toolcol.Length > 0) {
                                foreach (Tool T in toolcol) {
                                    Console.WriteLine(T.tostring());
                                }
                            }

                        }
                    }
                }
            }
            else if (toolCategory != -1) {
                foreach (Toolcollection[] TCA in AllTools)
                {
                    Console.WriteLine();
                    Console.WriteLine("++++++++++New Tool Category++++++++++");
                    foreach (Toolcollection TC in TCA)
                    {
                        Console.WriteLine("----------{0}----------", TC.collectiontype());
                        iTool[] toolcol = TC.toArray();
                        if (toolcol.Length > 0)
                        {
                            foreach (Tool T in toolcol)
                            {
                                Console.WriteLine(T.tostring());
                            }
                        }

                    }
                }
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();

        }
        /*
         * Menu to allow a member to rent out a new tool
        */
        public void MenuBorrow() {
            Console.Clear();
            int toolindex = -1;
            string[] Cats = { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools" };
            int toolCategory = displaychoice("Select tool Categories", Cats) - 1;
            if ((toolCategory < 9) & (toolCategory != -1))
            {
                int tooltype = displaySubCat(toolCategory) - 1;
                if ((tooltype > -1) & (tooltype < AllTools[toolCategory].Length))
                {
                    toolindex = displaychoice("Select Tool to borrow", AllTools[toolCategory][tooltype].toArray()) - 1;
                    if ((toolindex != -1))
                    {
                        if ((toolindex < AllTools[toolCategory][tooltype].toArray().Length))
                        {
                            borrowTool(Loggedin_user, AllTools[toolCategory][tooltype].toArray()[toolindex]);
                        }
                    }
                }
            }
            wait();
        }
        /*
        * Menu allowing the user to return a tool they are currently renting
        */
        public void MenuReturn() {
            Console.Clear();
            string[] rented = listTools(Loggedin_user);
            if (rented != null)
            {
                int tool_return = displaychoice("Select tool to return", rented) - 1;
                if (tool_return != -1) {
                    bool completed = false;
                    for (int i = 0; ((i < Loggedin_user.Tool_list.Length) & completed == false); i++) {
                        if (rented[tool_return] == Loggedin_user.Tool_list[i].Name) {
                            returnTool(Loggedin_user, Loggedin_user.Tool_list[i]);
                            completed = true;
                        }
                    }

                }
            }
            wait();
        }
        /*
        * Menu to show all the current tools the user is renting
        */
        public void MenuRenting() {
            Console.Clear();
            string[] rented = listTools(Loggedin_user);
            if (rented != null)
            {
                Console.WriteLine("Current rented tools:");
                foreach (string i in rented) {
                    Console.WriteLine($"-   {i}");
                }
            }
            else {
                Console.WriteLine("You are currently not renting any tools");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }
        /*
        * Function to allow the class to add a new tool to the tool library
        */
        public void add(iTool tool)
        {
            string[] Cats = { "Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools", "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools" };
            int toolCategory = displaychoice("Select tool Categories", Cats) - 1;
            int tooltype = displaySubCat(toolCategory) - 1;
            AllTools[toolCategory][tooltype].add(tool);
        }
        /*
        * Function to allow the class to add a new tool to the tool library
        */

        public void add(iTool tool, int amount)
        {
            //searches the Alltool toolcollection array trying to find the tool to add to
            bool updated = false;
            foreach (iToolCollection[] TCA in AllTools)
            {
                foreach (Toolcollection TC in TCA)
                {
                    foreach (Tool t in TC.toArray())
                    {
                        //if the tool is found increase the tool's quantity
                        if (t.Name == tool.Name)
                        {
                            Tool temp = new Tool(tool.Name, amount);
                            TC.add(temp);
                            updated = true;
                        }
                    }
                }
            }
            //adds the tool as if it is new if it was not able to update an existing tool
            if (updated == false) {
                Console.WriteLine("That tool does not exist within the library please insert it manually");
                Tool temp = new Tool(tool.Name, amount);
                add(temp);
            }
        }
        /*
        * Function to allow the class to add a new member to the tool library
        */
        public void add(iMember member)
        {
            //checks which array to place the user into
            string[] option = { "Admin", "Member" };
            int usertype = displaychoice("Select User type", option);
            string[] search = new string[] { member.FirstName, member.LastName };
            if (usertype == 1)
            {
                //make sure the user does not exist
                IComparable exists = AdminTree.search(search);
                if (exists == null)
                {
                    //adds the member to the admin tree
                    AdminTree.add(member);
                    Console.WriteLine("{0} {1} has been added to the admin database", member.FirstName, member.LastName);
                    //prints out the new admin tree
                    Console.WriteLine("Updated Admin tree");
                    AdminTree.InOrderTraverse();
                }
                else
                {
                    Console.WriteLine("{0} {1} already Exists in the admin database", member.FirstName, member.LastName);
                }
            }
            else if (usertype == 2)
            {
                //make sure the user does not exist
                IComparable exists = MemberTree.search(search);
                if (exists == null)
                {
                    //adds the new member to the member tree
                    MemberTree.add(member);
                    Console.WriteLine("{0} {1} has been added to the member database", member.FirstName, member.LastName);
                    //displays the updated members tree
                    Console.WriteLine("Updated member tree");
                    MemberTree.InOrderTraverse();
                }
                else
                {
                    Console.WriteLine("{0} {1} already Exists in the member database", member.FirstName, member.LastName);
                }
            }
        }
        /*
        * Function to allow the class to let a member rent out a tool
        */
        public void borrowTool(iMember member, iTool tool)
        {
            //checks that the user is borrwoing less than three and the tool is available
            if ((member.Tools.Length < 3) & (tool.AvailableQuantity > 0))
            {
                //updates both the tools and the members, renting list
                member.addTool(tool);
                tool.addBorrower(member);
                //finds the toolcollection that needs to be re sorted now that a tool has been rented
                foreach (iToolCollection[] TCA in AllTools)
                {
                    foreach (Toolcollection TC in TCA)
                    {
                        foreach (Tool t in TC.toArray()) {
                            if (t == tool) {
                                //sorts the array with the rented tool
                                TC.sort();
                            }

                        }
                    }
                }
                Console.WriteLine("you have successfully borrowed {0}", tool.Name);
            }
            else {
                if (member.Tools.Length == 3)
                {
                    Console.WriteLine("You are already borrowing 3 tools, please return 1 to get a new one out");
                }
                else
                {
                    Console.WriteLine("This tool is currently rented out please choose another tool.");
                }
            }
        }
        /*
        * Function to allow the class to delete a tool from the tool library
        */
        public void delete(iTool tool)
        {
            delete(tool, tool.AvailableQuantity);
        }
        /*
        * Function to allow the class to delete a tool from the tool library
        */
        public void delete(iTool tool, int amount)
        {
            //finds the tool to remove within the toolcollection arrays
            foreach (iToolCollection[] TCA in AllTools) {
                foreach (Toolcollection TC in TCA) {
                    foreach (Tool t in TC.toArray()) {
                        if (t.Name == tool.Name) {
                            TC.delete(tool, amount);
                        }
                    }
                }
            }
        }
        /*
        * Function to allow the class to delete a member from the tool library system
        */
        public void delete(iMember member)
        {
            //removes a member if they are borrwoing no tools
            if (member.Tools.Length == 0)
            {
                AdminTree.delete(member);
                MemberTree.delete(member);
                Console.WriteLine("{0} {1} has been deleted from the database", member.FirstName, member.LastName);
            } else
            {
                //asks the admin if they are sure they want to delete a user that is renting tools
                Console.WriteLine("{0} {1} is currently still renting out tools", member.FirstName, member.LastName);
                Console.WriteLine("have they already been return y/n");
                string returned = Console.ReadLine();
                //deletes the user and returns the tools if the admin is happy and has the tools
                if (returned.ToLower() == "y")
                {
                    Console.WriteLine("automatically returning all tools");
                    iTool[] rTools = member.Tool_list;
                    foreach (Tool t in rTools)
                    {
                        returnTool(member, t);
                    }
                    MemberTree.delete(member);
                    AdminTree.delete(member);
                    Console.WriteLine("{0} {1} has been deleted from the database", member.FirstName, member.LastName);
                }
                //else asks the admin to get the tools before removing
                else {
                    Console.WriteLine("PLease Get all the rented tools before removing a user");
                    Console.WriteLine("{0} {1} can be contacted via the phone number {2}", member.FirstName, member.LastName, member.ContactNumber);
                }
            }

        }
        /*
        * Function to display a user's rented tools when given a user phone number
        */
        public void display(string phone)
        {
            //searchs the bs tree for the member with the given phone number
            iMember member = MemberTree.search(new string[] { phone });
            //checks  that the member exists in the tree
            if (member != null)
            {
                Console.WriteLine($"The following phone number {phone} belogns to {member.FirstName} {member.LastName}");
                string[] tools = member.Tools;
                if (tools.Length > 0)
                {
                    Console.WriteLine("They are currently renting ou the following tools:");
                    //prints out all the tools within the members rented toolcollection if it has a length greater then 0
                    foreach (string t in tools)
                    {
                        if (t != null) {
                            Console.WriteLine("-    {0}", t);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("They are currnelty renting no tools");
                }
            }
            else {
                Console.WriteLine($"A user with {phone} does not exist");
            }
            wait();
        }
        /*
        * 
        */
        public void displayTools(string toolName)
        {
            //search the toolcolections looking for the tool collection with the passed name
            foreach (iToolCollection[] TCA in AllTools) {
                foreach (Toolcollection TC in TCA) {
                    //if the tool collection has the given name the array of tools will be printed
                    if (TC.collectiontype() == toolName) {
                        Console.WriteLine("----------{0}----------", TC.collectiontype());
                        iTool[] toolcol = TC.toArray();
                        //make sure the toolcollection has tool in it
                        if (toolcol.Length > 0)
                        {
                            //print out all the tools in the collection
                            foreach (Tool T in toolcol)
                            {
                                Console.WriteLine(T.tostring());
                            }
                        }
                    }
                }
            }
            wait();
        }
        /*
        * Displays the top 3 rented tools
        */
        public void displayTopTHree()
        {
            Console.Clear();
            //loop through each tool collection within the library
            foreach (iToolCollection[] tooltype in AllTools)
            {
                foreach (iToolCollection toolcol in tooltype)
                {
                    iTool[] toolarray = toolcol.toArray();
                    //check that tools exist in that collection
                    if (toolarray.Length > 0)
                    {
                        //go over the top three tools in that collection
                        for (int ti = 0; (ti < 3) & (ti < toolarray.Length); ti++)
                        {
                            int insetpos = -1;
                            //if the tool is the most rented tool
                            if (toolarray[ti].NoBorrowings > top3[0].NoBorrowings)
                            {
                                insetpos = 0;
                            }
                            //if the tool is the second most rented tool and not the first
                            else if ((toolarray[ti].NoBorrowings > top3[1].NoBorrowings) & (toolarray[ti].Name != top3[0].Name))
                            {
                                insetpos = 1;
                            }
                            //if the tool is the third most rented tool and not in the second or first top 3 array
                            else if ((toolarray[ti].NoBorrowings > top3[2].NoBorrowings) & (toolarray[ti].Name != top3[0].Name) & (toolarray[ti].Name != top3[1].Name))
                            {
                                insetpos = 2;
                            }
                            //add the tool to the top3 array if it is in the top three so far
                            if (insetpos > -1)
                            {
                                //move down the other tools if the new tool is 1st or 2nd
                                if (insetpos != 2)
                                {
                                    iTool[] temp3 = new iTool[3];
                                    top3.CopyTo(temp3,0);
                                    for (int i = insetpos; i < 2; i++)
                                    {
                                        top3[i + 1] = temp3[i];
                                    }
                                }
                                //insert new tool into it's correct postion 
                                top3[insetpos] = toolarray[ti];
                            }
                            else if ((insetpos == -1) | (insetpos == 2)) {
                                ti = 3;
                            }
                        }
                    }
                }
            }
        
            Console.WriteLine("         Top 3 retned tools        ");
            Console.WriteLine("-----------------------------------");
            for(int i= 0;i < top3.Length;i++)
            {
                Console.WriteLine("{0}. {1} rented {2} times",i+1,top3[i].Name,top3[i].NoBorrowings);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            wait();
        }
        /*
        * get a string list of all the tools a given user is renting
        */
        public string[] listTools(iMember member)
        {
            string[] borrowing = member.Tools;
            //check if the user is renting tools
            if (borrowing.Length > 0)
            {

                return borrowing;
            }

            return null;
        }
        /*
        * FUnction to allow the class to return a tool given a member and a tool
        */
        public void returnTool(iMember memeber, iTool tool)
        {
            //serch the all tool collection array, to find the correct tool
            for (int i =0; i<AllTools.Length;i++) {
                for (int j =0; j<AllTools[i].Length;j++) {
                    //if the tool is able to be returned this will return true 
                   if (AllTools[i][j].ReturnTool(tool, memeber)) { 
                        //remove the tool the user is renting from their rented array
                        memeber.deleteTool(tool);
                        Console.WriteLine("You have successfully returned the following tool {0}", tool.Name);
                        return;
                    }
                    
                }
            }
            Console.WriteLine("You were not renting the following tool {0}",tool.Name);
        }
        /*
         * -------------------------------------------------------------------------------------------------------------------
         * -----------------------------------------------------DEBUGGING AND TESTING CODE-----------------------------------
         * -------------------------------------------------------------------------------------------------------------------
         */
        /*
        * test function used for debugging purposes
        * Used to check if the tool current borrowers members tree works as expected
        */
        private void testuserborrowing(Tool t) {
            BSTree b = (BSTree)t.GetBorrowers;
            b.InOrderTraverse();
        }
        /*
        * Fucntions to run all the test cases
        */
        public void test()
        {
            Console.WriteLine("RUN");
            borrow3();
            borrowsame();
            removerented();
            deleterentinguser();
            unabaiable();
            returnWhenNoRenting();
            returnrented();
            renttool();
            addtool();
            addtoolofsametype();
            removehalfoftools();
            removealltools();
            adduser();
            removeuser();
            searchphone();
            viewrentedtoolswhennull();
            sorttest();
            top3changing();
        }
        /*
        * Check what haapens when a user trys to borrow four tools
        */
        public void borrow3()
        {
            Console.Clear();
            Console.WriteLine("----Borrowing more than three tools----");
           
            borrowTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[0][0].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[1][0].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[2][1].toArray()[1]);
            string[] m = MemberTree.search(new string[] { "Sophia", "Politylo" }).Tools;
            Console.WriteLine("---------------------------");
            Console.WriteLine("Rented tools at 3");
            foreach (string s in m) {
                Console.WriteLine(s);
            }
            Console.WriteLine("---------------------------");
            borrowTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[3][2].toArray()[0]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Rented tools after trying to rent 4");
            m = MemberTree.search(new string[] { "Sophia", "Politylo" }).Tools;
            foreach (string s in m)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("---------------------------");
            Console.ReadLine();
        }
        /*
        * check if a user can borrow two of the same tools
        */
        public void borrowsame()
        {
            Console.Clear();
            Console.WriteLine("----Borrowing two of the same tools----");
            borrowTool(MemberTree.search(new string[] { "Zac", "Braff" }), AllTools[1][4].toArray()[0]);
            borrowTool(MemberTree.search(new string[] { "Zac", "Braff" }), AllTools[1][4].toArray()[0]);
            string[] m = MemberTree.search(new string[] { "Zac", "Braff" }).Tools;
            Console.WriteLine("---------------------------");
            Console.WriteLine("Rented tools at 3");
            foreach (string s in m)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("---------------------------");
            Console.ReadLine();
        }
        /*
        * Check what happens when a tool deleted but a user is currently renting out all and same of them
        */
        public void removerented()
        {
            Console.Clear();
            Console.WriteLine("----Deleting a tool that is fully rented----");
            delete(AllTools[1][4].toArray()[0]);
            iTool[] a = AllTools[1][4].toArray();
            Console.WriteLine("---------------------------");
            foreach (Tool t in a) {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("----Deleting a tool that is partially rented----");
            returnTool(MemberTree.search(new string[] { "Zac", "Braff" }), AllTools[1][4].toArray()[0]);
            delete(AllTools[1][4].toArray()[0]);
            a = AllTools[1][4].toArray();
            Console.WriteLine("---------------------------");
            foreach (Tool t in a)
            {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("---------------------------");
            Console.ReadLine();

        }
        /*
        * Check what happens when a user is deleted but they are currently renting out a tool
        */
        public void deleterentinguser()
        {
            Console.Clear();
            Console.WriteLine("----Deleting a user who is renting----");
            delete(MemberTree.search(new string[] { "Zac", "Braff" }));
            Console.WriteLine("leaving in renting user");
            Console.WriteLine("Does Zac Braff still exist in tree: {0}",MemberTree.search(new Member( "Zac", "Braff", "0424244", "password")));
            Console.WriteLine("Current renters of {0}", AllTools[1][4].toArray()[0].Name);
            testuserborrowing((Tool) AllTools[1][4].toArray()[0]);
            Console.WriteLine("---------------------------------------");
            delete(MemberTree.search(new string[] { "Zac", "Braff" }));
            Console.WriteLine("Removing in renting user");
            Console.WriteLine("Does Zac Braff still exist in tree: {0}", MemberTree.search(new Member("Zac", "Braff", "0424244", "password")));
            Console.WriteLine("Current renters of {0}", AllTools[4][4].toArray()[1].Name);
            testuserborrowing((Tool)AllTools[4][4].toArray()[1]);
            Console.ReadLine();

        }
        /*
        * Check what happens when a user tries to rent out an unaviable tool
        */
        public void unabaiable()
        {
            borrowTool(MemberTree.search(new string[] { "Jim", "Smith" }), AllTools[4][2].toArray()[0]);
            Console.Clear();
            Console.WriteLine("----Trying to rent an unaviable tool----");
            borrowTool(MemberTree.search(new string[] { "Alpha", "Zappter" }), AllTools[4][2].toArray()[0]);
            Console.WriteLine("rented array After trying to rent tool:");
            display(MemberTree.search(new string[] { "Alpha", "Zappter" }).ContactNumber);
            Console.ReadLine();


        }
        /*
        * check what happens when a user tries to return a tool they aren't renting
        */
        public void returnWhenNoRenting()
        {
            Console.Clear();
            Console.WriteLine("----Trying to return a tool you aren't renting----");
            Console.WriteLine("rented array before trying to return:");
            display(MemberTree.search(new string[] { "Jim", "Hwake" }).ContactNumber);
            Console.WriteLine();
            returnTool(MemberTree.search(new string[] {"Jim", "Hwake"}), AllTools[0][0].toArray()[0]);
            Console.WriteLine();
            Console.WriteLine("rented array after trying to return");
            display(MemberTree.search(new string[] { "Jim", "Hwake" }).ContactNumber);
            Console.ReadLine();
        }
        /*
        * Check if the rent rented function works in a normal case
        */
        public void returnrented()
        {
            Console.Clear();
            Console.WriteLine("----Returning rented item----");
            Console.WriteLine("rented array before returning:");
            display(MemberTree.search(new string[] { "Sophia", "Politylo" }).ContactNumber);
            returnTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), new Tool (AllTools[2][1].toArray()[1].Name, 1));
            Console.WriteLine();
            Console.WriteLine("rented array after returning:");
            display(MemberTree.search(new string[] { "Sophia", "Politylo" }).ContactNumber);
            Console.ReadLine();
        }
        /*
        * check if renting a tool works under normal conditions
        */
        public void renttool()
        {
            Console.Clear();
            Console.WriteLine("----Renting tool----");
            Console.WriteLine("rented array before renting:");
            display(MemberTree.search(new string[] { "Sophia", "Politylo" }).ContactNumber);
            borrowTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[1][1].toArray()[0]);
            Console.WriteLine();
            Console.WriteLine("rented array after renting:");
            display(MemberTree.search(new string[] { "Sophia", "Politylo" }).ContactNumber);
            Console.ReadLine();
        }
        /*
        * Check if a new tool can be added to the library system
        */
        public void addtool()
        {
            Console.Clear();
            Console.WriteLine("----Adding a new tool----");
            iTool[] ta = AllTools[5][0].toArray();
            Console.WriteLine("Tools in cat before insert");
            if (ta.Length == 0) {
                Console.WriteLine($"No tools are in the cat {AllTools[5][0].collectiontype()}");
            }
            Console.WriteLine();
            AllTools[5][0].add(new Tool("1mm sand paper", 10));
            ta = AllTools[5][0].toArray();
            Console.WriteLine("Tools in {0} after insert", AllTools[5][0].collectiontype());
            foreach (Tool t in ta) {
                Console.WriteLine(t.tostring());
            }
            Console.ReadLine();
        }
        /*
        * checks if a tool quantity can be updated in the library system
        */
        public void addtoolofsametype()
        {
            Console.Clear();
            Console.WriteLine("----Adding a tool that already exists----");
            Console.WriteLine("tools in {0} before update", AllTools[5][0].collectiontype());
            iTool[] ta = AllTools[5][0].toArray();
            foreach (Tool t in ta) {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("----------------------");
            iTool temp = new Tool(AllTools[5][0].toArray()[0].Name,5);
            AllTools[5][0].add(temp);
            Console.WriteLine("tools in {0} after update", AllTools[5][0].collectiontype());
            ta = AllTools[5][0].toArray();
            foreach (Tool t in ta)
            {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("----------------------");
            Console.ReadLine();
        }
        /*
        * checks if the quantity of a tool can be decreassed
        */
        public void removehalfoftools()
        {
            Console.Clear();
            Console.WriteLine("----removing only a few tools of a given type----");
            Console.WriteLine("tools in {0} before remove", AllTools[5][0].collectiontype());
            iTool[] ta = AllTools[5][0].toArray();
            foreach (Tool t in ta)
            {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("----------------------");
            delete(AllTools[5][0].toArray()[0], 5);
            Console.WriteLine("tools in {0} after remove", AllTools[5][0].collectiontype());
            ta = AllTools[5][0].toArray();
            foreach (Tool t in ta)
            {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("----------------------");
            Console.ReadLine();
        }
        /*
        * checks if a tool can be fully removed from the tool library
        */
        public void removealltools()
        {
            Console.Clear();
            Console.WriteLine("----removing all tools----");
            Console.WriteLine("tools in {0} before remove", AllTools[5][0].collectiontype());
            iTool[] ta = AllTools[5][0].toArray();
            foreach (Tool t in ta)
            {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("----------------------");
            delete(AllTools[5][0].toArray()[0], 10);
            Console.WriteLine("tools in {0} after remove", AllTools[5][0].collectiontype());
            ta = AllTools[5][0].toArray();
            foreach (Tool t in ta)
            {
                Console.WriteLine(t.tostring());
            }
            Console.WriteLine("----------------------");
            Console.ReadLine();
        }
        /*
        * Checks if a new user can be added to the member tree
        */
        public void adduser()
        {
            Console.Clear();
            Console.WriteLine("----Adding a new member to the tree----");
            Console.WriteLine("Before adding user");
            Console.WriteLine($"Does New AUser exist in the member tree: {MemberTree.search(new Member("New", "AUser", "11111111111111", "donttell"))}");
            MemberTree.add(new Member("New", "AUser", "11111111111111","donttell"));
            Console.WriteLine("After adding user");
            Console.WriteLine($"Does New AUser exist in the member tree: {MemberTree.search(new Member("New", "AUser", "11111111111111", "donttell"))}");
            Console.WriteLine("---------Member tree---------");
            MemberTree.InOrderTraverse();
            Console.ReadLine();
        }
        /*
        * checks if a user can be removed from the member tree
        */
        public void removeuser()
        {
            Console.Clear();
            Console.WriteLine("----removing user----");
            Console.WriteLine("Before removing user");
            Console.WriteLine($"Does New AUser exist in the member tree: {MemberTree.search(new Member("New", "AUser", "11111111111111", "donttell"))}");
            delete(new Member("New", "AUser", "11111111111111", "donttell"));
            Console.WriteLine("After removing user");
            Console.WriteLine($"Does New AUser exist in the member tree: {MemberTree.search(new Member("New", "AUser", "11111111111111", "donttell"))}");
            Console.WriteLine("---------Member tree---------");
            MemberTree.InOrderTraverse();
            Console.ReadLine();
        }
        /*
        * check if the display(phone) function works
        */
        public void searchphone()
        {
            Console.Clear();
            Console.WriteLine("----finidng the rented tools through a user phone number----");
            string phone = "0434949966";
            display(phone);
            Console.ReadLine();
        }
        /*
        * Check what is displayed when the user has no tools rented
        */
        public void viewrentedtoolswhennull()
        {
            MemberTree.add(new Member("Alex", "Rena", "0345525622", "password"));
            Console.Clear();
            Console.WriteLine("----Viewing rented tool with no renting----");
            string phone = "0345525622";
            display(phone);
            Console.ReadLine();
        }
        /*
        * Check if the merge sort function for the tool collection class works
        */
        public void sorttest() {
            foreach (Toolcollection[] tca in AllTools) {
                foreach (Toolcollection tc in tca) {
                    tc.sort();
                }
            }
            Console.Clear();
            Console.WriteLine("----Sorted tool array----");
            Console.WriteLine($"{AllTools[3][0].collectiontype()} sotred via times borrowed in descending");
            foreach (Tool t in AllTools[3][0].toArray()) {
                Console.WriteLine(t.tostring());
            }
            Console.ReadLine();
        }
        /*
        * check if finding the top three borrowed tools work
        * Also displays it 2 times after a new tool becomes the top rented
        */
        public void top3changing()
        {
            Console.Clear();
            Console.WriteLine("----Displaying top 3 tools----");
            Console.WriteLine("--- First top three ---");
            displayTopTHree();
            for (int i = 0; i < 50; i++) {
                borrowTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[0][0].toArray()[0]);
                returnTool(MemberTree.search(new string[] { "Sophia", "Politylo" }), AllTools[0][0].toArray()[0]);
            }
            AllTools[0][0].sort();
            Console.WriteLine("--- top three after borrowing {0} 50 times ---", AllTools[0][0].toArray()[0].Name);
            displayTopTHree();
            Console.ReadLine();
        }
    }
}
