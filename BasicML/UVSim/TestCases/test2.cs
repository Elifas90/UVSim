using System;

namespace UVSim
{
	class Program
	{
		static void Main(string[] args)
		{
			int acc = 0;			int b = 0;
			int a = 0;

Label0:	Console.Write("Enter an integer: ");
			a = int.Parse(Console.ReadLine());
Label1:	Console.Write("Enter an integer: ");
			b = int.Parse(Console.ReadLine());
Label2:	acc = a;
Label3:	acc-= b;
Label4:	if (acc < 0) goto Label7;
Label5:	Console.WriteLine(a);
Label6:	return;
Label7:	Console.WriteLine(b);
Label8:	return;
		}
	}
}
