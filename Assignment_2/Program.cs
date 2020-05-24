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
        public FiniteStateTable() //Default Finite State Table
        {
            Console.WriteLine("Default Constructor!");
            
        }
        
        //Variables
        public int[,] FST; //2D Array

        struct cell_FST
        {
            //Variables for the struct
            public int nextState;
            public string action;

            //Methods for the struct
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
                return nextState;
            }
            public string getAction()
            {
                return action;
            }
        }
        
        //Methods

        static void Main(string[] args) // entry point 
        {
            // shit goes here
            cell_FST fish = new cell_FST();
        }

    }
    
}
