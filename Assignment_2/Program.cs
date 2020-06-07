using System;
using Assignment_2;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Assignment_2
{
    class FiniteStateMachine // general class for both Finite State Machines (FSM)
    {
        //Constructors
        public FiniteStateMachine() // default constructor initialising the Finite State table 
        {
            FST = new cell_FST[3, 3]; // both finite state tables can be housed within a 3 x 3 2D array
            Console.WriteLine("User has defined a Finite State Table of total size of {0} by {1}!",
                FST.GetLength(0), FST.GetLength(1));
        }

        //Variables
        protected cell_FST[,] FST; // 2D array of type cell Finite State Table (FST)
        private string actionPerform = ""; // records the actions performed to populate the log
        private string actionPerform2 = "";

        protected struct cell_FST // a single cell of the 2D array 'FST' containing a struct with two variables 
        {
            public int nextState;
            public string action;
        }

        //Methods
        public void W() // methods for actions associated with state changes 
        {
            Console.WriteLine("FSM1: Action W");
        } 

        public void X()
        {
            Console.WriteLine("FSM1: Action X");
        }

        public void Y()
        {
            Console.WriteLine("FSM1: Action Y");
        }

        public void Z()
        {
            Console.WriteLine("FSM1: Action Z");
        }

        private void J()
        {
            Console.WriteLine("FSM2: Action J, " + "Thread Number: " + Thread.CurrentThread.ManagedThreadId);
        }

        private void K()
        {
            Console.WriteLine("FSM2: Action K, " + "Thread Number: " + Thread.CurrentThread.ManagedThreadId);
        }

        private void L()
        {
            Console.WriteLine("FSM2: Action L, " + "Thread Number: " + Thread.CurrentThread.ManagedThreadId);
        }

        public void State()
        {
            Console.WriteLine("FSM2: State Change Only");
        }

        public void setnextState(int d_state, int x, int y) // methods to change and read the variables within a cell
                                                            // within the 2D array
        {
            this.FST[x, y].nextState = d_state;
        }

        public void setAction(string d_action, int x, int y)
        {
            this.FST[x, y].action = d_action;
        }

        public int getnextState(int x, int y)
        {
            return this.FST[x, y].nextState;
        }

        public string getAction(int x, int y)
        {
            return this.FST[x, y].action;
        }
        
        public void running(string stuff) // method to run other methods based on a string input pulled from the FST
        {
            string s = stuff; // assign s to the incoming string
            string[] values = s.Split(','); // separate the string based on commas and store in an array of
                                            // strings

            if (stuff != "J,K,L")
            {
                for (int i = 0; i < values.GetLength(0); i++) // loops through based on how many
                                                              // elements in the string array
                {
                    MethodInfo run = this.GetType().GetMethod(values[i]); // @stack overflow runs the associated methods
                                                                          // using the inbuilt MethodInfo class
                    run.Invoke(this, null);

                    actionPerform += values[i] + " "; // appends the actions performed to be printed to the log
                }
            }
            else
            {
                Parallel.Invoke(() => // multi-threading for the J K L methods
                    {
                        J();
                    },

                    () =>
                    {
                        K();
                    },

                    () =>
                    {
                        L();
                    }
                ); //close parallel.invoke

                actionPerform2 = ", " + stuff; // appends the actions performed to be printed to
                // the log

            }
        }
        class MainClass
    {

        private const string FNAME = @"C:\Users\fifac\OneDrive\Desktop\Mechatronics Third Year\313\"; //Reuben records the location of the .txt file output
        //private const string FNAME = @"C:\Users\Kuanc\Desktop\Fourth Year\MECHENG313\Assignment 2\"; //KUAN


        public static void Main(string[] args) // entry point to program
        {
            var fish = new FiniteStateMachine(); // instantiate two classes and assign them to respective objects
            var bear = new FiniteStateMachine();

            //Finite State Table for the first Finite State machine 
            //S0                        S1                   S2
            //S1 -> ActionX/Y           S0 -> ActionW        S0 -> ActionW     //a
            //S0 -> do_nothing          S2 -> ActionX/Z      S2 -> do_nothing  //b
            //S0 -> do_nothing          S1 -> do_nothing     S1 -> ActionX/Y   //c 
            fish.setAction("X,Y", 0, 0); // STATE 0 Transition to state 1
            fish.setnextState(1, 0, 0);
            fish.setAction("W", 0, 1); // STATE 1 Transition to state 0
            fish.setnextState(0, 0, 1);
            fish.setAction("W", 0, 2); // STATE 2 Transition to state 0
            fish.setnextState(0, 0, 2);
            fish.setAction("", 1, 0); // STATE 0 Transition to state 0
            fish.setnextState(0, 1, 0);
            fish.setAction("X,Z", 1, 1); // STATE 1 Transition to state 2
            fish.setnextState(2, 1, 1);
            fish.setAction("", 1, 2); // STATE 2 Transition to state 2
            fish.setnextState(2, 1, 2);
            fish.setAction("", 2, 0); // STATE 0 Transition to state 0
            fish.setnextState(0, 2, 0);
            fish.setAction("", 2, 1); // STATE 1 Transition to state 1
            fish.setnextState(1, 2, 1);
            fish.setAction("X,Y", 2, 2); // STATE 2 Transition to state 1
            fish.setnextState(1, 2, 2);

            //Finite State Table for the second Finite State machine 
            //SA (0)                    SB (1) && S1                   
            //SB -> do_nothing          SA -> Action J/K/L   //a
            //SA -> do_nothing          SA -> Action J/K/L   //b
            //SA -> do_nothing          SA -> Action J/K/L   //c 
            bear.setAction("State", 0, 0); // STATE A Transition to state B
            bear.setnextState(1, 0, 0);
            bear.setAction("J,K,L", 0, 1); // STATE B Transition to state A
            bear.setnextState(0, 0, 1);
            bear.setAction("", 1, 0); // STATE A Transition to state A
            bear.setnextState(1, 1, 0);
            bear.setAction("J,K,L", 1, 1); // STATE B Transition to state A
            bear.setnextState(0, 1, 1);
            bear.setAction("", 2, 0); // STATE A Transition to state A
            bear.setnextState(1, 2, 0);
            bear.setAction("J,K,L", 2, 1); // STATE B Transition to state A
            bear.setnextState(0, 2, 1);




            //Variables                                           
            var timestamp = ""; // timestamps user actions for the log output
            int x; // used to keep track of the key pressed and associated FST row
            var currentState = 0; // tracks the current state of FST 1
            var currentState2 = 1; // tracks the current state of FST 2

            Console.WriteLine("Finite State Machine 1 current state: " + currentState); // prints the initial state
                                                                                        // of both FSMs
            Console.WriteLine("Finite State Machine 2 current state: " + currentState2 + "\n");

            ConsoleKey keyIn = ConsoleKey.Delete; // what this line do

            string log = "TimeStamp \t\t Event \t\t Action \n"; // initialise log file with correct spacing and headers

            //Running Machine
            while (keyIn != ConsoleKey.Q) // constantly checking for a 'q' exit button being pressed
            {
                keyIn = Console.ReadKey(true).Key; // reads the user input from the console

                switch (keyIn) // assigns a value based on the user input 
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
                    default:
                        x = -1;
                        break;
                }

                if (x != -1) // checks the validity of the key press (a, b, c keys only)
                {

                    if ((fish.getAction(x, currentState) != "")) // checks if the state change requested for FSM 1
                                                                 // is valid
                    {
                        fish.running(fish.getAction(x, currentState)); // runs the methods associated with the
                                                                          // state change
                    }

                    if ((currentState == 1 || currentState2 == 0) && bear.getAction(x, currentState2) != "") 
                        // checks if the state change for FSM 2 is valid
                    {
                        bear.running(bear.getAction(x, currentState2)); // runs the methods associated with
                                                                        // the state change

                        currentState2 = bear.getnextState(x, currentState2); // updates the current state with
                                                                             // the new state

                        currentState = fish.getnextState(x, currentState); // updates the current state with the
                                                                           // new state


                        Console.WriteLine("Finite State Machine 1 current state: " +
                                          currentState); // prints to console the (new) current states
                        Console.WriteLine("Finite State Machine 2 current state: " + currentState2 + "\n");


                        timestamp = DateTime.Now.ToString("yyyy MM dd HH mm ss"); // updates the timestamp with
                                                                                  // user interactions
                        log += timestamp + "\t" + " " + keyIn + "\t\t" + " " + fish.actionPerform + fish.actionPerform2 
                               + "\n"; // appends the new concatenated information to the log 
                        fish.actionPerform = ""; // inserts whitespace for aesthetics
                        fish.actionPerform2 = "";
                    }
                }

                //Creating File
                Console.WriteLine("File Name:"); // prompts the user for a file name
                var name = Console.ReadLine(); // stores the user input

                var fileName = FNAME + name + ".txt"; // creates the actual file with location

                System.IO.File.AppendAllText(fileName, (log) + "\n"); // outputs the correct file                 
            }
        }
    }
}