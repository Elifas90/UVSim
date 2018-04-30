using System;

namespace UVSim
{
	class Program
	{
		static void Main(string[] args)
		{
			int acc = 0;			int c = 0;
			int b = 0;
			int a = 0;

Label0:	Console.Write("Enter an integer: ");
			a = int.Parse(Console.ReadLine());
Label1:	Console.Write("Enter an integer: ");
			b = int.Parse(Console.ReadLine());
Label2:	acc = a;
Label3:	acc+= b;
Label4:	c = acc;
Label5:	Console.WriteLine(c);
Label6:	return;
		}
	}
}
