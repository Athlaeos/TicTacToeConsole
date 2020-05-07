using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeEngine;


namespace TicTacToeConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            new TicTacToe();
        }
    }

    class TicTacToe
    {
        TicTacToeEngine.TicTacToeEngine t = new TicTacToeEngine.TicTacToeEngine();
        public TicTacToe()
        {
            while (true)
            {
                Console.WriteLine(Board(t.Board));
                Console.Write("Please enter a cell [1-9] or type 'quit':");
                string entry = Console.ReadLine();
                if (entry == "quit")
                {
                    t.Quit();
                }
                if (entry == "reset")
                {
                    t.Reset();
                    Console.WriteLine("Board reset.");
                    continue;
                }
                int cell = 0;
                try
                {
                cell = Int32.Parse(entry);
                } catch (FormatException e)
                {
                    Console.WriteLine("That's not an option.");
                    continue;
                }
                if (t.ChooseCell(cell))
                {
                    if (t.Status == TicTacToeEngine.TicTacToeEngine.GameStatus.PlayerOWins)
                    {
                        Console.WriteLine("\n\nPlayer O Wins!\n\n\n");
                        t.Reset();
                    } else if (t.Status == TicTacToeEngine.TicTacToeEngine.GameStatus.PlayerXWins)
                    {
                        Console.WriteLine("\n\n\nPlayer X Wins!\n\n\n");
                        t.Reset();
                    } else if (t.Status == TicTacToeEngine.TicTacToeEngine.GameStatus.Tie)
                    {
                        Console.WriteLine("\n\n\nGame is tied, nobody wins.\n\n\n");
                        t.Reset();
                    }
                } else
                {
                    Console.WriteLine("Cell not available, pick something else.");
                }
            }
        }

        public string Board(String[] board)
        {
            string b = string.Format("_______\n|{0}|{1}|{2}|\n|{3}|{4}|{5}|\n|{6}|{7}|{8}|\n-------", board[0], board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8]);
            return b;
        }
    }
}
