using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2
{
    class FiniteStateTable
    {
        //Constructor template
        // public FiniteStateTable() {}
        // public FiniteStateTable (int idInit) {
        //     this.idSensor = idInit;
        //}

        //Constructors
      
        private FiniteStateTable(cell_FST[,] fst) //User defined size Finite State Table
        {
            FST = fst;
            Console.WriteLine("User has defined a Finite State Table of total size of {0} by {1}!", fst.GetLength(0),
                fst.GetLength(1));
        }
        
        //Variables
        private cell_FST[,] FST; //2D Array

        private const string FNAME = @"C:\Users\fifac\OneDrive\Desktop\Mechatronics Third Year\313\"; //Reuben
        //private const string FNAME = @"C:\Users\Kuanc\Desktop\Fourth Year\MECHENG313\Assignment 2\"; //KUAN

      //  protected Action ActionX(void)      

        
        
        // maybe implement an indexer for FST?
        struct cell_FST
        {
            //Variables for the struct
            private int nextState;
            private string action;

            //Getter and setter methods
            public void setnextState(int d_state)
            {
                this.nextState = d_state;
            }
            public void setAction(string d_action)
            {
                this.action = d_action;
            }
            public int getnextState()
            {
                return this.nextState;
            }
            public string getAction()
            {
                return this.action;
            }
        }   

        //Methods //needs be its on classssss
        static void Main(string[] args) // entry point 
        {
            cell_FST[,] FSM = new cell_FST[3, 3];
            var fish = new FiniteStateTable(FSM);

            //S0                        S1                   S2
            //S1 -> ActionX/Y           S0 -> ActionW        S0 -> ActionW     //a
            //S0 -> do_nothing          S2 -> ActionX/Z      S2 -> do_nothing  //b
            //S0 -> do_nothing          S1 -> do_nothing     S1 -> ActionX/Y   //c 

            fish.FST[0,0].setAction("ActionX/Y"); // STATE 0 Transition to state 1
            fish.FST[0,0].setnextState(1);
            fish.FST[0,1].setAction("ActionW"); // STATE 1 Transition to state 0
            fish.FST[0,1].setnextState(0);
            fish.FST[0,2].setAction("ActionW"); // STATE 2 Transition to state 0
            fish.FST[0,2].setnextState(0);
            fish.FST[1,0].setAction("Do Nothing"); // STATE 0 Transition to state 0
            fish.FST[1,0].setnextState(0);
            fish.FST[1,1].setAction("ActionX/Z"); // STATE 1 Transition to state 2
            fish.FST[1,1].setnextState(2);
            fish.FST[1,2].setAction("Do Nothing"); // STATE 2 Transition to state 2
            fish.FST[1,2].setnextState(2);
            fish.FST[2,0].setAction("Do Nothing"); // STATE 0 Transition to state 0
            fish.FST[2,0].setnextState(0);
            fish.FST[2,1].setAction("Do Nothing"); // STATE 1 Transition to state 1
            fish.FST[2,1].setnextState(1);
            fish.FST[2,2].setAction("ActionX/Y"); // STATE 2 Transition to state 1
            fish.FST[2,2].setnextState(1);
            
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
