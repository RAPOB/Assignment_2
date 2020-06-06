using System;
using Assignment_2;

namespace Assignment_2
{
    class FiniteStateTable
    {
        //Constructors

        public FiniteStateTable() //User defined size Finite State Table
        {
            FST = new cell_FST[3, 3];
            Console.WriteLine("User has defined a Finite State Table of total size of {0} by {1}!", FST.GetLength(0),
                FST.GetLength(1));
        }

        //Variables
        protected cell_FST[,] FST; //2D Array

        protected struct cell_FST
        {
            //Variables for the struct
            public int nextState;
            public string action;
        }

        //Methods
        public void setnextState(int d_state, int x, int y)
        {
           this.FST[x,y].nextState = d_state;
        }

        public void setAction(string d_action, int x, int y)
        {
            this.FST[x,y].action = d_action;
        }

        public int getnextState(int x, int y)
        {
            return this.FST[x,y].nextState;
        }

        public string getAction(int x, int y)
        {
            return this.FST[x,y].action;
        }
       
        
    }

    class MainClass 
    {
        //private const string FNAME = @"C:\Users\fifac\OneDrive\Desktop\Mechatronics Third Year\313\"; //Reuben
        private const string FNAME = @"C:\Users\Kuanc\Desktop\Fourth Year\MECHENG313\Assignment 2\"; //KUAN
         //needs be its on classssss
        public static void Main(string[] args) // entry point 
        {
            var fish = new FiniteStateTable();

            //S0                        S1                   S2
            //S1 -> ActionX/Y           S0 -> ActionW        S0 -> ActionW     //a
            //S0 -> do_nothing          S2 -> ActionX/Z      S2 -> do_nothing  //b
            //S0 -> do_nothing          S1 -> do_nothing     S1 -> ActionX/Y   //c 
            
            
            fish.setAction("ActionX/Y", 0 , 0); // STATE 0 Transition to state 1
            fish.setnextState(1, 0, 0);
            fish.setAction("ActionW", 0 , 1); // STATE 1 Transition to state 0
            fish.setnextState(0 , 0 , 1);
            fish.setAction("ActionW", 0 , 2); // STATE 2 Transition to state 0
            fish.setnextState(0 , 0, 2);
            fish.setAction("Do Nothing" ,1, 0); // STATE 0 Transition to state 0
            fish.setnextState(0, 1, 0);
            fish.setAction("ActionX/Z", 1, 1); // STATE 1 Transition to state 2
            fish.setnextState(2, 1, 1);
            fish.setAction("Do Nothing", 1, 2); // STATE 2 Transition to state 2
            fish.setnextState(2, 1, 2);
            fish.setAction("Do Nothing", 2, 0); // STATE 0 Transition to state 0
            fish.setnextState(0, 2, 0);
            fish.setAction("Do Nothing", 2, 1); // STATE 1 Transition to state 1
            fish.setnextState(1, 2, 1);
            fish.setAction("ActionX/Y", 2, 2); // STATE 2 Transition to state 1
            fish.setnextState(1, 2, 2);
            
            //Variables
            string actionPerform = "";                                
            string timestamp = "";

            int x = -1; 
            int current_state = 0;

            ConsoleKey key_in = ConsoleKey.Delete; 
            
            string log = "TimeStamp \t\t Event \t\t Action \n"; //initialise log file

            //Runnning Machine
            while (key_in != ConsoleKey.Q)
            {             
                key_in = Console.ReadKey(true).Key;
                
                    switch (key_in)
                {
                    case ConsoleKey.A:                                                
                        x = 0;                               
                        break;
                    case ConsoleKey.B:
                        x = 1;
                        break;
                    case ConsoleKey.C:
                        x = 2;                     
                        break;
                }
                
                if (key_in == ConsoleKey.A || key_in == ConsoleKey.B || key_in == ConsoleKey.C)
                {
                    actionPerform = (fish.FST[x, current_state].getAction());
                    current_state = fish.FST[x, current_state].getnextState();

                    Console.WriteLine(current_state);
                    Console.WriteLine(actionPerform);

                    timestamp = DateTime.Now.ToString("yyyy MM dd HH mm ss");
                    log += timestamp + "\t" + " " + key_in + "\t\t" + " " + actionPerform + "\n";
                }                                  
            }

            //Creating File
            Console.WriteLine("File Name:");
            string Name = Console.ReadLine();

            string file_name = FNAME + Name + ".txt";

            System.IO.File.AppendAllText(file_name, (log) + "\n");                 
        }
    }    
}
