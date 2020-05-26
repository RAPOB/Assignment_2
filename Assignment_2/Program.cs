using System;

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

        private FiniteStateTable(int[,] fst) //User defined size Finite State Table
        {
            FST = fst;
            Console.WriteLine("User has defined a Finite State Table of total size of {0} by {1}!", fst.GetLength(0),
                fst.GetLength(1));
        }
        
        //Variables
        public int[,] FST; //2D Array
        
        //S0                        S1                S2
        //S1 -> ActionX/Y           S2 -> ActionX/Z   S0 -> ActionW
        // S0 -> do_nothing         S0 -> ActionW     S1 -> ActionX/Y
        // Default? -> do_nothing   S1 -> do_nothing  S2 -> do_nothing    

        
        // maybe implement an indexer for FST?
        struct cell_FST
        {
            //Variables for the struct
            private static int _nextState { get; set; }
            private static string _action { get; set; }

            //Getter and setter methods
            public static int nextState 
            {
                get { return _nextState; }
                set { _nextState = value;  }
            }
            public static string action
            {
                get { return _action; }
                set { _action = value;  }
            }
            
            //Constructor
        }
        
        //Methods
        public void setnextState(int d_state)
        {
            cell_FST.nextState = d_state;
        }
        public void setAction(string d_action)
        {
            cell_FST.action = d_action;
        }
        public int getnextState()
        {
            return cell_FST.nextState;
        }
        public string getAction()
        {
            return cell_FST.action;
        }

        static void Main(string[] args) // entry point 
        {
            // shit goes here
            var amn = new int[5 , 5];
            FiniteStateTable fish = new FiniteStateTable(amn);
            fish.setAction("peepee");
            Console.WriteLine(fish.getAction());
            
            //code to read strings input from user we will recieve a,b,c and use compare 
            //we will also need invalid key handling as well as 'q' for quit handling 
            Console.WriteLine("Please enter some bullshit");
            string age = Console.ReadLine();
            Console.WriteLine("Your age is: " + age);
            age.CompareTo("a");
            
            Console.WriteLine("Current State is xyz");
            string foo = Console.ReadLine();
            Console.WriteLine("Print action associated with transistion");
            Console.WriteLine("Now in state S1");
            
            //Logging the actions and output to files should happen somewhere here


            
            
        }

    }
    
}
