using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_Library
{
    /*
     * Implementation of the iTool class
     */
    class Tool : iTool
    {
        private string TName; //name of the tool
        private int quantity = 0; //number of this tool type
        private int Aviablity; //amount of the tool current available to rent
        private int TimesBorrowed; //times the tool has been borrowed
        private iMemberCollection borrowers = new BSTree(); //members currently renting the tool
        public Tool(string name, int quantity =1) {
            Name = name;
            this.quantity+= quantity;
            Aviablity = this.quantity;
            TimesBorrowed = 0;
        }
        /*
         * get the string representation of the tool
         */
        public string tostring() {
            return $"{Name}, quantity: {Quantity}, avilable: {AvailableQuantity}, times borrowed: {NoBorrowings}";
        }
        
        public override string ToString() {
            return $"{ Name}, avilable: { AvailableQuantity}";
        }
        
        public string Name { get { return TName; } set { TName = value; } }
        public int Quantity { get { return quantity; } set {  Aviablity= Aviablity+value; quantity = quantity+value; } }
        public int AvailableQuantity { get { return Aviablity; } set { Aviablity = value; } }
        public int NoBorrowings { get { return TimesBorrowed; } set { TimesBorrowed += value; } }

        public iMemberCollection GetBorrowers { get{ return borrowers; } }
        /*
         * Add a new borrower to the tool by decreassing aviablity, 
         * adding 1 to NOborrowings and adding a new member to the borrowers tree
         * takes: imember: member to rent out the tool
         */
        public void addBorrower(iMember newM)
        {
            //check if any tools are free to rent
            if (Aviablity > 0) {
                //add a new borrower to the tool
                Aviablity--;
                NoBorrowings =1;
                borrowers.add(newM);
            }
        }
        /*
         * Function for a member to return a tool
         * Increases aviablity and remove the member from the borrowers tree
         * takes: imember: member to remove from borrowers
         */
        public void deleteBorrower(iMember removeM)
        {
            borrowers.delete(removeM);
            Aviablity++;
        }
    }
}
