using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface iToolLibrarySystem
    {
        void add(iTool tool); // add a new tool to the system

        void add(iTool tool, int amount); //add new pieces of an existing tool to the system

        void delete(iTool tool); //delte a given tool from the system

        void delete(iTool tool, int amount); //remove some pieces of a tool from the system

        void add(iMember member); //add a new memeber to the system

        void delete(iMember member); //delete a member from the system

        void display(string phone); //given the contact phone number of a member, display all the tools that the member are currently renting


        void displayTools(string toolName); // display all the tools of a tool type selected by a member

        void borrowTool(iMember member, iTool tool); //a member borrows a tool from the tool library

        void returnTool(iMember memeber, iTool tool); //a member return a tool to the tool library

        string[] listTools(iMember member); //get a list of tools that are currently held by a given member

        void displayTopTHree(); //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.


    }
}
