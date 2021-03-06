using System;
using System.Collections.Generic;
using System.Text;
using Tool_Library;

namespace Assignment
{
    //The specification of ToolCollection ADT, which is used to store and manipulate a collection of tools
    interface iToolCollection
    {
        int Number // get the number of the types of tools in the community library
        {
            get;
        }
        void add(iTool tool); //add a given tool to this tool collection
        void delete(iTool tool); //delete a given tool from this tool collection
        Boolean search(iTool tool); //search a given tool in this tool collection. Return true if this tool is in the tool collection; return false otherwise
        iTool[] toArray(); // output the tools in this tool collection to an array of iTool
    }
    /*
     * implementing the iToolCollection interface
     */
    
}
