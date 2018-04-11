//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Ali Alabdlmohsen, Caleb Hansen, Nikita Pestin, Josh Cooley.


#include "stdafx.h"
#include "vm.h"
#include "Assembler.h"

using namespace std;

int main()
{
	// Creat an Assembler object.
	Assembler prototype;

	// Print welcome messege.
	prototype.printIntroduction();

	// Read the instructions.
	prototype.getInstructions();

	// Create a vm object.
	vm trial(prototype.getMemory());

	// Execute the program.
	trial.execute();

	// Print the accumelator and memory dump.
	cout << "Accumilator: " << trial.getAccumilator() << endl;
	cout << "---------------------------------------------" << endl;
	trial.memoryDump();


	cout << endl << endl;
	cout << "---------------------------------------------" << endl;
	system("PAUSE");

    return 0;
}

