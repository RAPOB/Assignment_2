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
    

    public delegate void action();
    class FiniteStateMachine
    {
        //Constructors

        public FiniteStateMachine() //User defined size Finite State Table
        {
            FST = new cell_FST[3,3];
            Console.WriteLine("User has defined a Finite State Table of total size of {0} by {1}!", FST.GetLength(0),
                FST.GetLength(1));
        }

        //Variables
        protected cell_FST[,] FST; //2D Array
            
        public void W() { Console.WriteLine("FSM1: Action W"); }       
        public void X() { Console.WriteLine("FSM1: Action X"); }
        public void Y() { Console.WriteLine("FSM1: Action Y"); }
        public void Z() { Console.WriteLine("FSM1: Action Z"); }
        public void J() { Console.WriteLine("FSM2: Action J, " + "Thread Number: " + Thread.CurrentThread.ManagedThreadId);  }       
        public void K() { Console.WriteLine("FSM2: Action K, " + "Thread Number: " + Thread.CurrentThread.ManagedThreadId); }
        public void L() { Console.WriteLine("FSM2: Action L, " + "Thread Number: " + Thread.CurrentThread.ManagedThreadId); }
        
        public void State() { Console.WriteLine("FSM2: State Change Only"); }

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

        public string actionPerform = "";

        public void running(string stuff)
        {
            if (stuff != "J,K,L")
            {
                //magic is pulling apart
                string s = stuff;
                string[] values = s.Split(',');


                for (int i = 0; i < values.GetLength(0); i++)
                {
                    MethodInfo run = this.GetType().GetMethod(values[i]); //@stack overflow
                    run.Invoke(this, null);

                    actionPerform += values[i] + " ";
                }
            }
            else
            {
                Parallel.Invoke(() =>
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

            }
        }             
        
    }

    class MainClass 
    {   

        //private const string FNAME = @"C:\Users\fifac\OneDrive\Desktop\Mechatronics Third Year\313\"; //Reuben
        private const string FNAME = @"C:\Users\Kuanc\Desktop\Fourth Year\MECHENG313\Assignment 2\"; //KUAN

         
        public static void Main(string[] args) // entry point 
        {
            var fish = new FiniteStateMachine();
            var bear =  new FiniteStateMachine();
            
            //S0                        S1                   S2
            //S1 -> ActionX/Y           S0 -> ActionW        S0 -> ActionW     //a
            //S0 -> do_nothing          S2 -> ActionX/Z      S2 -> do_nothing  //b
            //S0 -> do_nothing          S1 -> do_nothing     S1 -> ActionX/Y   //c 
            fish.setAction("X,Y", 0 , 0); // STATE 0 Transition to state 1
            fish.setnextState(1, 0, 0);
            fish.setAction("W", 0 , 1); // STATE 1 Transition to state 0
            fish.setnextState(0 , 0 , 1);
            fish.setAction("W", 0 , 2); // STATE 2 Transition to state 0
            fish.setnextState(0 , 0, 2);
            fish.setAction("" ,1, 0); // STATE 0 Transition to state 0
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
            
            //SA (0)                    SB (1) && S1                   
            //SB -> do_nothing          SA -> Action J/K/L   //a
            //SA -> do_nothing          SA -> Action J/K/L   //b
            //SA -> do_nothing          SA -> Action J/K/L   //c 
            bear.setAction("State", 0, 0);
            bear.setnextState(1, 0, 0);
            bear.setAction("J,K,L", 0, 1);
            bear.setnextState(0, 0, 1);
            bear.setAction("", 1, 0);
            bear.setnextState(1, 1, 0);
            bear.setAction("J,K,L", 1, 1);
            bear.setnextState(0, 1, 1);
            bear.setAction("", 2, 0);
            bear.setnextState(1, 2, 0);
            bear.setAction("J,K,L", 2, 1);
            bear.setnextState(0, 2, 1);
           



            //Variables                                           
            string timestamp = "";

            int x; 
            int current_state = 0;
            int current_state_2 = 1;  
            Console.WriteLine("Finite State Machine 1 current state: " + current_state);
            Console.WriteLine("Finite State Machine 2 current state: " + current_state_2 + "\n");

            ConsoleKey key_in = ConsoleKey.Delete; //what this line do
            
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
                    default:
                        x = -1;
                        break;
                }
                
                if (x != -1)
                {

                    if ((fish.getAction(x, current_state) != ""))
                    {
                        fish.running(fish.getAction(x, current_state));
                    }
                    
                    if ((current_state == 1 || current_state_2 == 0) && bear.getAction(x, current_state_2) != "")
                    {
                        bear.running(bear.getAction(x, current_state_2));
                        current_state_2 = bear.getnextState(x, current_state_2);
                    }
                    
                    current_state = fish.getnextState(x, current_state);

                    Console.WriteLine("Finite State Machine 1 current state: " + current_state);
                    Console.WriteLine("Finite State Machine 2 current state: " + current_state_2 + "\n");
                    
                    

                    timestamp = DateTime.Now.ToString("yyyy MM dd HH mm ss");
                    log += timestamp + "\t" + " " + key_in + "\t\t" + " " + fish.actionPerform + "\n";
                    fish.actionPerform = "";
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
