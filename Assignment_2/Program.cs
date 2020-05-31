using System;
using System.Reflection.Metadata.Ecma335;

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
        private FiniteStateTable() //Default Finite State Table
        {
            FST = null;
            Console.WriteLine("Default Constructor!");
        }

        private FiniteStateTable(cell_FST[,] fst) //User defined size Finite State Table
        {
            FST = fst;
            Console.WriteLine("User has defined a Finite State Table of total size of {0} by {1}!", fst.GetLength(0),
                fst.GetLength(1));
        }
        
        //Variables
        private cell_FST[,] FST; //2D Array

        //S0                        S1                S2
        //S1 -> ActionX/Y           S2 -> ActionX/Z   S0 -> ActionW
        // S0 -> do_nothing         S0 -> ActionW     S1 -> ActionX/Y
        // Default? -> do_nothing   S1 -> do_nothing  S2 -> do_nothing    

        // private const string FNAME = @"C:\Users\fifac\OneDrive\Desktop\Mechatronics Third Year\313\"; //Reuben
        private const string FNAME = @"C:\Users\Kuanc\Desktop\Fourth Year\MECHENG313\Assignment 2\"; //KUAN
        
        
        // maybe implement an indexer for FST?
        struct cell_FST
        {
            //Variables for the struct
            private int nextState;
            private string action;

            //Getter and setter methods
            // public static int nextState 
            // {
            //     get { return _nextState; }
            //     set { _nextState = value;  }
            // }
            // public static string action
            // {
            //     get { return _action; }
            //     set { _action = value;  }
            // }
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
        
        //Methods
        

        static void Main(string[] args) // entry point 
        {
            
            // shit goes here
            Action[,] Penis = new Action[5, 5];
            var fish = new FiniteStateTable(Penis);
            cell_FST S0 = new cell_FST();
            S0.setAction("peepee");
            S0.setnextState(1);
            fish.FST[0, 0] = S0;
            
            
            
  
            fish.FST = 
            //Console.WriteLine(fish.getAction());

            //code to read strings input from user we will receive a,b,c and use compare
            //we will also need invalid key handling as well as 'q' for quit handling
            //Console.WriteLine("Please enter some bullshit");
            //string age = Console.ReadLine();
            //Console.WriteLine("Your age is: " + age);
            //age.CompareTo("a");

            //Console.WriteLine("Current State is xyz");
            //string foo = Console.ReadLine();
            //Console.WriteLine("Print action associated with transistion");
            //Console.WriteLine("Now in state S1");

            /*string run = "";
            string log = String.Format("{0,0} {1,20} {2,15} {3,15}\n", "TimeStamp", "Trigger", "Event", "Action");

            while (run != "q")
            {
                Console.WriteLine("trigger");
                run = Console.ReadLine();

                log += String.Format("{0,0} {1,10} {2,15} {3,10} {4,-15}\n", DateTime.Now.ToString("yyyy MM dd HH mm ss"), run, "Event", "", "Action");

            }

            //Logging the actions and output to files should happen somewhere here

            Console.WriteLine("File Name:");
            string Name = Console.ReadLine();

            string file_name = FNAME + Name + ".txt";

            System.IO.File.AppendAllText(file_name, (log) + "\n");*/

            
            
        }

    }
    
}
