using System;

namespace Assignment_2_Pract
{
    public enum State
    {
        S0,
        S1,
        S2
    }

    public void W() { Console.Write("W"); }
    public void X() { Console.Write("X"); }
    public void Y() { Console.Write("Y"); }
    public void Z() { Console.Write("Z"); }
}
class FiniteStateTable
{
    //Constrcuctors
    private Action[,] fsm;


    //Variables
    public int[,] FST;
    struct cell_FST
    {
        public int nextState;
        public string action;
    }

    //Methods
    public int SetNextState() { GetNextState() = value; }
    public string SetAction() { GetAction() = value; }
    public int GetNextState() { return nextState; }
    public string GetAction() { return action; }

}












}
