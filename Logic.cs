using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Logic
    {
        public string CurrentPlayer { get; set; } = X;
        public string NotCurrentPlayer = X;
        private const string X = "X";
        private const string O = "O";
        private string[,] Board = new string[3, 3];

        


        public void SetPlayer()
        {
            if(CurrentPlayer == X)
            {
                CurrentPlayer = O;
            }
            else
            {
                CurrentPlayer = X;
            }

            if(CurrentPlayer == X)
            {
                NotCurrentPlayer = O;

            }
            else
            {
                NotCurrentPlayer = X;
            }
        }
        
        public bool Winner()
        {           
            //Horizontal win

            for(var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[i, 0]))
                {

                    if (Board[i,0] == Board[i, 1] && Board[i,0] == Board[i,2])
                    {
                        return true;
                        
                    }
                }
                
            }

            //Diagnoal win

            if (!String.IsNullOrWhiteSpace(Board[1, 1]))
            {

                if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                {
                    return true;
                }

                if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                {
                    return true;
                }
            }

            //Vertical win
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[0, i]))
                {

                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    {
                        return true;
                    }

                }

            }

            return false;
        }
        internal void UpdateBoard(Position position, string value)
        {
            Board[position.x, position.y] = value;
        }
    }
}
