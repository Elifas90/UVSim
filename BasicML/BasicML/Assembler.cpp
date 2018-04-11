//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Ali Alabdlmohsen

// Implementation file for the "Assembler" class.

#include "stdafx.h"
#include "Assembler.h"

using namespace std;

// Defult constructor.
Assembler::Assembler()
{
	instructionsNum = 0;

	// Clear the memory.
	for (int i = 0; i < MEMORY_SIZE; i++)
	{
		memory[i] = 0;
	}
}

// A function that prints the introduction of the programm.
void Assembler::printIntroduction()
{
	cout << "Welcome to UVUsim prototype" << endl;
	cout << "---------------------------------------------" << endl;
}

// A function that svaes the instructions into the memory array.
void Assembler::getInstructions()
{
	string input;

	// A loop to read until the end of the memory or until STOP_CODE is entered.
	while (instructionsNum < MEMORY_SIZE)
	{
		cout << "Ins #" << setw(2) << setfill('0') << instructionsNum << ": ";
		cin >> input;
		int num = stoi(input);

		// If the STOP_CODE is encountered, stop the loop.
		if (num == STOP_CODE)
		{
			cout << "---------------------------------------------" << endl;
			break;
		}

		// If the STOP_CODE isn't encountered yet, increment and loop back.
		else
		{
			memory[instructionsNum] = num;
			instructionsNum++;
		}
	}
}

// Read instructions from a file for debugging purposes.
void Assembler::readFile()
{
	// Declare an "ifstream" object and try to open the file.
	ifstream dataIn;
	dataIn.open("test2.txt");

	// If the file could not be openned.
	if (dataIn.fail())
	{
		// Display error message.
		cout << "error..." << endl;
		cout << "'" << "test.txt" << "'" << " could not be openned.";

		// Return the error code.
		return;
	}

	// If the file was openned successfully.
	else
	{
		// Declare needed local variable.
		string input;
		int fileLineNumber = 1;

		// Read until the end of the file.
		while (getline(dataIn, input) && instructionsNum < MEMORY_SIZE)
		{
			// Find the index of the ';'.
			int i = input.find(';');

			// Take the line before ';'
			input = input.substr(0, i);

			// Check if the whole line is not a comment.
			if (i != 0)
			{

				int num = stoi(input);

				// If the STOP_CODE is encountered, stop the loop.
				if (num == STOP_CODE)
				{
					cout << "---------------------------------------------" << endl;
					break;
				}

				// If the STOP_CODE isn't encountered yet, increment and loop back.
				else
				{
					// Store the instruction in the memory array.
					memory[instructionsNum] = num;

					// Print a simulation line.
					cout << "Ins #" << setw(2) << setfill('0') << instructionsNum << ": " << memory[instructionsNum] << endl;

					instructionsNum++;
				}
			}
		}
	}
}

int* Assembler::getMemory()
{
	return memory;
}