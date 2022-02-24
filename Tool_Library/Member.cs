using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_Library
{
    /*
     * Implementing the iMember interface
     */
    class Member : iMember
    {
        private string fname; //first name of user
        private string lname; //last name of user
        private string phone; //phone number of user
        private string password; //password for user
        private Toolcollection rented = new Toolcollection(""); //ToolCollection class to store the user's borrowed tools
        private int rentnum = 0; //number of tools rented
        public iTool[] Tool_list { get { return rented.toArray(); } }
        public string FirstName { get { return fname; } set { fname = value; } }
        public string LastName { get { return lname; } set { lname = value; } }
        public string ContactNumber { get { return phone; } set { phone = value; } }
        public string PIN { get { return password; } set { password = value; } }
        public Member(string FirstName, string LastName, string PhoneNumber, string Password)
        {
            this.fname = FirstName;
            this.lname = LastName;
            this.phone = PhoneNumber;
            this.password = Password;
        }
        /*
         * returns a string[] of the names of all the tools the user is renting 
         */
        public string[] Tools
        {
            get
            {
                //array of tool names
                string[] names = new string[rentnum];
                int i = 0;
                //make sure the user is renting tools
                if (rented.toArray().Length > 0)
                {
                    //loop through each tool within the tool array
                    foreach (Tool t in rented.toArray())
                    {
                        //error handeling
                        if (null != t)
                        {
                            
                            int add = 0;
                            //checks to see how many tools of a single type the user is renting
                            while (add < t.Quantity)
                            {
                                //adds the name of the tool more than once if the user is borrwoing more than 1
                                add++;
                                names[i] = t.Name;
                                i++;
                            }
                        }
                    }
                }
                return names;
            }
        }
        /*
         * Add a new tool to the renting toolcollection, checks if the user has less than three rented out before renting it out
         * takes: iTool; tool the user wnats to rent
         */
        public void addTool(iTool tool)
        {
            //checks that the user is renting less then three tools
            if (rentnum < 3)
            {
                //adds the new tool to the rented tool aray
                Tool tool_add = new Tool(tool.Name);
                rentnum++;
                rented.add(tool_add);

            }
        }
        /*
         * Checks if all the strings in the array are present in the member class
         * can take a range of array lengths from 1 to 3, where each string represents one of the following feilds
         * first name, last name and phone number. if more than one string is given all must bbe in the class
         * takes: string[]; values to check the member class for haivng
         * returns: true if all strings match the member firstname, lastname or phone variables, else false
         */
        public bool search_string(string[] to_check)
        {
            int correct = 0;
            int accuracy = to_check.Length;
            //loops through all the variables to check
            foreach (var search in to_check)
            {
                if (fname.ToLower() == search.ToLower())
                {
                    correct++;
                }
                else if (lname.ToLower() == search.ToLower())
                {
                    correct++;
                }
                else if (phone == search)
                {
                    correct++;
                }
            }
            //all the strings passed to the method must have returned as true,
            //exists within this user for the function to return true
            if (correct == accuracy)
            {
                return true;
            }
            return false;
        }
        /*
         * Compares two member objects to each other, checking which one should come first
         * takes: object; imember to compare this member to
         * retuen: 0 if both users are the same; 
         *      -1 if obj is before this member;
         *      1 if obj goes after this member
         */
        public int CompareTo(object obj)
        {
            Member ComMember = (Member)obj;
            if (this.lname.CompareTo(ComMember.LastName) < 0)
            {
                return -1;
            }
            else if (this.lname.CompareTo(ComMember.LastName) == 0)
            {
                return this.fname.CompareTo(ComMember.FirstName);
            }
            else
            {
                return 1;
            }

        }
        /*
         * Renter a tool the member is currently renting out
         * takes: iTool; tool the user wants to return
         */
        public void deleteTool(iTool tool)
        {
            if (rentnum > 0)
            {
                rented.delete(tool, 1);
                rentnum--;
            }
        }
        /*
         * Overload for the ToString method so that the member class can return a readable string to the console
         */
        public override string ToString()
        {
            return (FirstName + " " + LastName + " " + phone.ToString() + "\n");
        }

    }
}
