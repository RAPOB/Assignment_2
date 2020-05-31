﻿using System;

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

        // private const string FNAME = @"C:\Users\fifac\OneDrive\Desktop\Mechatronics Third Year\313\"; //Reuben
        private const string FNAME = @"C:\Users\Kuanc\Desktop\Fourth Year\MECHENG313\Assignment 2\"; //KUAN
        
        
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
        
        //Methods
        

        static void Main(string[] args) // entry point 
        {
            cell_FST[,] FSM = new cell_FST[3, 3];
            var fish = new FiniteStateTable(FSM);

            //S0                        S1                S2
            //S1 -> ActionX/Y           S0 -> ActionW     S0 -> ActionW     //a
            //S0 -> do_nothing          S2 -> ActionX/Z   S2 -> do_nothing  //b
            //S0 -> do_nothing          S1 -> do_nothing  S1 -> ActionX/Y   //c 
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
            
            var current_state = 0;
            //current.state = state 1
            
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
