using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Matrix
    {
        private int x;
        private int y;
        private int[,] matrix;
        private long sum = 0;

        public Matrix(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.matrix = new int[x, y];
        }

        public void ConstructMatrix()
        {
            int value = 0;
            for (int i = 0; i < this.x; i++)
            {
                for (int j = 0; j < this.y; j++)
                {
                    this.matrix[i, j] = value++;
                }
            }
        }

        public void EvilMoves(int evilX, int evilY)
        {
            while (evilX >= 0 && evilY >= 0 )
            {
                if (evilX >= 0 && evilX < this.x && evilY >= 0 && evilY < this.y)
                {
                    this.matrix[evilX, evilY] = 0;
                }
                evilX--;
                evilY--;
            }
        }
        public void IvoMoves(int xI, int yI)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < this.x && yI >= 0 && yI < this.y)
                {
                    this.sum += this.matrix[xI, yI];
                }

                yI++;
                xI--;
            }
        }
        public long ReturnSum => this.sum;
    }
}
