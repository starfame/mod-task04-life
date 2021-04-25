using System;
using System.Threading;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Life
    {
		private Random random = new Random();
		const int width = 10;
		const int height = 10;
		int [,] space;
		private int life_count;
		public Life()
		{
			space = new int[width + 2, height + 2];
			for (int i = 0; i < width + 2; i++)
			{
				for (int j = 0; j < height + 2; j++)
				{
					space[i,j] = 0;
				}
			}
		}
		public void Generate()
		{
			for (int i = 1; i < width + 1; i++)
			{
				for (int j = 1; j < height + 1; j++)
				{
					space[i,j] = random.Next(0, 2);
				}
			}
		}
		public void PrintSpace()
		{
			for (int i = 1; i < width + 1; i++)
			{
				for (int j = 1; j < height + 1; j++)
				{
					if (space[i,j] == 1)
						Console.Write("*");
					else
						Console.Write(" ");
				}
				Console.Write("\n");
			}
		}
		public void CheckRules(int i, int j)
		{
			life_count = 0;
			for (int k = i - 1; k < i + 2; k++)
            {
				for (int l = j - 1; l < j+2; l++)
                {
					life_count = life_count + space[k, l];
                }
            }
			life_count = life_count - space[i, j];

			if (life_count == 3 && space[i,j] == 0)
            {
				space[i, j] = 1;
            }
			if ((life_count < 2 || life_count > 3) && space[i, j] == 1)
			{
				space[i, j] = 0;
            }
		}

		public void Run()
        {
			Generate();
			PrintSpace();
			Thread.Sleep(10);
			Console.SetCursorPosition(0, 0);
			while (true)
			{
				for (int i = 1; i < width + 1; i++)
				{
					for (int j = 1; j < height + 1; j++)
					{
						CheckRules(i, j);
					}
				}
				PrintSpace();
				Thread.Sleep(10);
				Console.SetCursorPosition(0, 0);
			}
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
			Life life = new Life();
			life.Run();
		}
    }
}
