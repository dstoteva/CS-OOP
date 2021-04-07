﻿using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            Matrix matrix = new Matrix(x, y);
            matrix.ConstructMatrix();

            string command = Console.ReadLine();
            
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int xE = evil[0];
                int yE = evil[1];

                matrix.EvilMoves(xE, yE);

                int xI = ivoS[0];
                int yI = ivoS[1];

                matrix.IvoMoves(xI, yI);

                command = Console.ReadLine();
            }

            Console.WriteLine(matrix.ReturnSum);

        }
    }
}
