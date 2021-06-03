using System;
using System.Threading;

namespace EXAMS
{
	class Program
	{
		static Random random = new Random();
		static int size = random.Next(100);
		static void Main()
		{
			int rnum = random.Next(3, 50);
			Console.WriteLine("У змаганнi беруть участь " + rnum + " бiгунiв.\nДовжина траси "+ size + "");

			Thread[] runners = new Thread[rnum];

			for (int i = 0; i < rnum; i++)
			{
				runners[i] = new Thread(Run);
				runners[i].Start(i);
			}

			foreach (Thread t in runners)
				t.Join();
		}

		static void Run(object num)
		{
			const int bound = int.MaxValue / 100;

			for (int i = size; i != 0; i--)
			{
				int rnd;
					rnd = random.Next();
				if (rnd < bound)
					Thread.Sleep(1);
			}
				Console.WriteLine("Бiгун за номером "+num+" досяг фiнiшу!");
		}
	}
}
