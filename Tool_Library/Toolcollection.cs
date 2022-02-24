using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_Library
{
    class Toolcollection : iToolCollection
    {
        private int num = 0; //number of tools in the toolcollection
        private iTool[] tools = { }; //tool collection array of tools
        private string type; //name of the collection

        int iToolCollection.Number { get { return tools.Length; } }
        public Toolcollection(string type)
        {
            this.type = type;
        }
        public string collectiontype()
        {
            return type;
        }

        /*
         * check if a tool alreeady exists and if it does update the quantity of the tool
         * takes: iTool: tool to check if it exists
         *        int: amount to add to the given itool
         * returns bool: true if tool is found, else false
         */
        private bool updatetool(iTool tool, int dir)
        {
            //loop through every tool untill match is found
            foreach (iTool t in tools)
            {

                if (t.Name == tool.Name)
                {
                    t.Quantity = dir;
                    return true;
                }
            }
            return false;
        }
        /*
         * function to add a new tool to the tool array
         * takes: iTool: tool to add to the array
         */
        public void add(iTool tool)
        {
            //amount to add of the new tool            
            int quantity = tool.Quantity;
            //case for when tool array is empty
            if (num == 0)
            {
                tools = new iTool[] { tool, };
                num++;
            }
            //else normal
            else
            {
                //check if the tool already exists and update it
                if (updatetool(tool, quantity))
                {
                    Console.WriteLine("{0} aready exited, so Quantity was updated", tool.Name);
                }
                //else add it to the tool array
                else
                {
                    num++;
                    //new expened tool array
                    iTool[] newtools = new iTool[num];
                    int i = 0;
                    //copying all the old values into the new array
                    foreach (Tool t in tools)
                    {
                        newtools[i] = t;
                        i++;
                    }
                    //adding the new tool to the end
                    newtools[i] = tool;
                    tools = newtools;
                }

            }


        }
        /*
         * Function to delete a given tool from the array
         * takes: iTool: tool to remove from array
         *         int: amount of the tool to remove from it's quantity
         */
        public void delete(iTool tool, int amount)
        {
            //new size of the array
            int numnew = num;
            //making sure that the number formating is standard
            iTool[] newtools = new iTool[num];
            amount = Math.Abs(amount);
            //checking if there is enough tool available for them to be removed
            if (amount > tool.AvailableQuantity)
            {
                amount = -tool.AvailableQuantity;
            }
            else
            {
                amount = -amount;
            }
            //checking if the tool will have 0 quantity left after the amount is removed
            //if yes decrease the array size by 1
            if (Math.Abs(amount) == tool.Quantity)
            {
                numnew += -1;
                newtools = new iTool[numnew];
                Console.WriteLine($"{tool.Name} has been fully removed from the collection");
            }
            else {
                Console.WriteLine($"{tool.Name} has now a quantity of {tool.Quantity - Math.Abs(amount)}");
            }

            int inew = 0;
            //loop through the array
            for (int i = 0; i < num; i++)
            {
                //if tool is the tool that needs to be removed, remove the required amount
                if (tools[i].Name == tool.Name)
                {

                    tools[i].Quantity = amount;
                }
                //check if the tool has a quantity greater than 0 if so add to the new array
                if (tools[i].Quantity > 0)
                {
                    newtools[inew] = tools[i];
                    inew++;
                }
            }
            num = numnew;
            tools = newtools;

        }
        /*
         * function to allow a user to return a tool they are renting
         * takes: iTool: tool that is being returned
         *        imeber: member who iss returning the tool
         * returns bool: true if the member was able to return the tool, false otherwise
         */
        public bool ReturnTool(iTool ToReturn, iMember removeM)
        {
            //loop through all the tools in the array
            foreach (iTool t in tools)
            {
                //check if the tool being returned exists and the member was borrwoing it
                if ((t.Name == ToReturn.Name) & (t.GetBorrowers.search(removeM)))
                {
                    //remove the borrower
                    t.deleteBorrower(removeM);
                    return true;
                }
            }
            return false;
        }
        /*
         * function that deletes all tools of a given type
         * takes: iTool: tool to fully remove from the array
         */
        public void delete(iTool tool)
        {
            int amount = tool.Quantity;
            delete(tool, amount);
        }
        /*
         * Function that searchs for a given tool within the collection
         * takes: itool: Tool to search the array for
         * returns bool, true if tools was found in the array, false otherwise
         */
        public bool search(iTool tool)
        {
            string tname = tool.Name;
            //loop through the array
            for (int i = 0; i < num; i++)
            {
                //if tool names match return true
                if (string.Compare(tools[i].Name, tname) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        /*
         * Function to return the iTool array to other class or fuction outside of the ToolCollections
         */
        public iTool[] toArray()
        {
            return tools;
        }
        /*
         * Function for merge sort that merges two split up arrays into a single sorted array
         * takes: iTool a1; array 1 to merge
         *        iTool a2; array 2 to merge
         * returns iTool[] merged sorted array of a1 and a2
         */
        private iTool[] merge(iTool[] a1, iTool[] a2)
        {
            iTool[] merged = new iTool[a1.Length + a2.Length];
            int indexm = 0;
            int index1 = 0;
            int index2 = 0;
            while ((index1 < a1.Length) | (index2 < a2.Length))
            {
                if ((index1 < a1.Length) & (index2 < a2.Length))
                {
                    if (a1[index1].NoBorrowings > a2[index2].NoBorrowings)
                    {
                        merged[indexm] = a1[index1];
                        index1++;
                    }
                    else
                    {
                        merged[indexm] = a2[index2];
                        index2++;
                    }
                }
                else if (index1 >= a1.Length)
                {
                    merged[indexm] = a2[index2];
                    index2++;
                }
                else if (index2 >= a2.Length)
                {
                    merged[indexm] = a1[index1];
                    index1++;
                }
                indexm++;
            }
            return merged;
        }
        /*
         * Function for merge sort, splits a given array into two arrays to be sorted
         * Takes: iTool[]; array to sort
         *        int size; size of the new split array
         *        int start; index to start saving values into the splited array
         */
        private iTool[] split(iTool[] array, int size, int start)
        {
            iTool[] a = new iTool[size];
            for (int i = 0; i < size; i++)
            {
                a[i] = array[start + i];
            }

            return a;
        }
        /*
         * merge sort function that implements both the split and merge function into a single function
         * takes: iTool[]; array to sort and split for merge sort
         * returns: iTool[]; sorted input array
         */
        public iTool[] sort(iTool[] array)
        {
            iTool[] asort = array;
            if (array.Length > 1)
            {
                int split1 = array.Length / 2;
                int split2 = array.Length - split1;
                iTool[] a1 = split(array, split1, 0);
                iTool[] a2 = split(array, split2, split1);
                a1 = sort(a1);
                a2 = sort(a2);
                asort = merge(a1, a2);
            }
            return asort;
        }
        /*
         * Initial function to call to sort the tools array within the tool collection class
         */
        public void sort()
        {
            if (tools.Length > 1)
            {
                int split1 = tools.Length / 2;
                int split2 = tools.Length - split1;
                iTool[] a1 = split(tools, split1, 0);
                iTool[] a2 = split(tools, split2, split1);
                a1 = sort(a1);
                a2 = sort(a2);
                tools = merge(a1, a2);

            }
        }
    }
}
