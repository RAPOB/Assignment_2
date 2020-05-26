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
            Console.WriteLine("User has defined a Finite State Table of total size {0}!", fst.Length);
        }
        
        //Variables
        public int[,] FST; //2D Array

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
        }

    }
    
}
