using Assignment;
using Interfaces;
using System;

namespace Tool_Library
{
    
    class Program
    {

        static void Main(string[] args)
        {
            LibraryInterface system = new LibraryInterface();
            system.MenuLogin();
        }
    }

}
