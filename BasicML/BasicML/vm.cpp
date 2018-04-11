//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Josh Cooley

// Implementation file for the "vm" class.


#include "stdafx.h"
#include "vm.h"

using namespace std;

// Defult constructor.
vm::vm(int* m)
{
	accumilator = 0;
	pc = 0;
	memory = m;
}

// A function that returns the accumilator.
int vm::getAccumilator()
{
	return accumilator;
}


// A function to execute the instruction from the memory array.
void vm::execute()
{
	int opCode;
	int operand;

	// A loop to go over the memory until HALT is encountered.
	while (true)
	{
		// Create an object of the ALU class.
		ALU alu;

		// Get the opCode and operand.
		opCode = memory[pc] / 100;
		operand = memory[pc] % 100;

		// Switch statment to execute the targeted instruction based on the opCode.
		switch (opCode)
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Josh Cooley

			// READ
		case 10:

			// Read an integer from the keyboard, and store it in a memory location based on the operand.
			cout << "Enter an integer: ";
			cin >> memory[operand];

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Josh Cooley

			// WRITE
		case 11:

			// Read an integer from a memory location based on the operand, and print it.
			cout << memory[operand] << endl;

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Josh Cooley

			// READ - INDIRECT
		case 12:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Read an integer from the keyboard, and store it in a memory location based on the operand.
			cout << "Enter an integer: ";
			cin >> memory[operand];

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Josh Cooley

			// WRITE - INDIRECT
		case 13:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Read an integer from a memory location based on the operand, and print it.
			cout << memory[operand] << endl;

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Josh Cooley

			// LOAD
		case 20:

			// Read an integer from a memory location based on the operand, and load it in the accumilator.
			accumilator = memory[operand];

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// STORE
		case 21:

			// Read an integer from the accumilator, and store it in a memory location based on the operand.
			memory[operand] = accumilator;

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// LOAD - INDIRECT
		case 22:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Read an integer from a memory location based on the operand, and load it in the accumilator.
			accumilator = memory[operand];

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// STORE - INDIRECT
		case 23:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Read an integer from the accumilator, and store it in a memory location based on the operand.
			memory[operand] = accumilator;

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// ADD
		case 30:

			// Add an integer from a memory location based on the operand to the accumilator.
			accumilator = alu.add(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// SUBTRACT
		case 31:

			// Subtract the integer in a memory location based on the operand from the accumilator.
			accumilator = alu.subtract(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Caleb Hansen

			// DIVIDE
		case 32:

			// Devide accumilator by the integer in a memory location based on the operand.
			accumilator = alu.divide(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Caleb Hansen

			// MULTIPLY
		case 33:

			// Multiply the integer in a memory location based on the operand by the integer in the accumilator.
			accumilator = alu.multiply(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// ADD - INDIRECT
		case 34:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Add an integer from a memory location based on the operand to the accumilator.
			accumilator = alu.add(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// SUBTRACT - INDIRECT
		case 35:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Subtract the integer in a memory location based on the operand from the accumilator.
			accumilator = alu.subtract(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// DIVIDE - INDIRECT
		case 36:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Devide accumilator by the integer in a memory location based on the operand.
			accumilator = alu.divide(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Nikita Pestin

			// MULTIPLY - INDIRECT
		case 37:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Multiply the integer in a memory location based on the operand by the integer in the accumilator.
			accumilator = alu.multiply(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Caleb Hansen

			// BRANCH
		case 40:

			// Branch to a location in memory based on the operand.
			pc = operand;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// BRANCHNEG
		case 41:

			// If the integer in the accumilator is negative, branch to a location in memory based on the operand.
			if (accumilator < 0) pc = operand;

			// If not, increment the program counter.
			else pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// BRANCHZERO
		case 42:

			// If the integer in the accumilator is zero, branch to a location in memory based on the operand.
			if (accumilator == 0) pc = operand;

			// If not, increment the program counter.
			else pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// HALT
		case 43:

			// End the execution.
			cout << "---------------------------------------------" << endl;
			return;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Caleb Hansen

			// BRANCH - Josh Cooley
		case 44:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Branch to a location in memory based on the operand.
			pc = operand;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// BRANCHNEG - INDIRECT
		case 45:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// If the integer in the accumilator is negative, branch to a location in memory based on the operand.
			if (accumilator < 0) pc = operand;

			// If not, increment the program counter.
			else pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// BRANCHZERO - INDIRECT
		case 46:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// If the integer in the accumilator is zero, branch to a location in memory based on the operand.
			if (accumilator == 0) pc = operand;

			// If not, increment the program counter.
			else pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// REMINDER
		case 50:

			// Get the reminder of the number in the accumilator devided by a number in memory location specified by the operand.
			accumilator = alu.reminder(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// EXPONENTIATION
		case 51:

			// Raise the number in the accumilator to the power of the number in memory location specified by the operand.
			accumilator = alu.exponential(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// REMINDER - INDIRECT
		case 52:

			// Increment the program counter to get to the operand.
			pc++;
			operand = memory[pc];

			// Get the reminder of the number in the accumilator devided by a number in memory location specified by the operand.
			accumilator = alu.reminder(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			//-----------------------------------------------------------------------------------------------------------------------
			// Coded by: Ali Alabdlmohsen

			// EXPONENTIATION - INDIRECT
		case 53:

			// Increment the program counter to get to the operand.
			accumilator = alu.exponential(accumilator, memory[operand]);
			
			// Raise the number in the accumilator to the power of the number in memory location specified by the operand.
			accumilator = pow(accumilator, memory[operand]);

			// Increment the program counter.
			pc++;

			break;

			// Defult.
		default:

			// Increment the program counter.
			pc++;

			break;

		}
	}
}

// A function that prints the contents of the memory array.
void vm::memoryDump()
{
	int count = 0;

	cout << "Memory Dump:" << endl;
	cout << "------------" << endl;

	// Print the first row.
	cout << " #" << "     ";
	for (int i = 0; i < MEMORY_SIZE / 100; i++)
	{
		cout << setw(4) << i << "\t";
	}
	cout << endl;

	// Print the second row.
	cout << "       ";
	for (int i = 0; i < MEMORY_SIZE / 100; i++)
	{
		cout << "----" << "\t";
	}
	cout << endl;

	// Print the memory dumb.
	cout << setw(3) << setfill('0') << 0 << " " << ":" << "  ";
	for (int i = 0; i < MEMORY_SIZE; i++)
	{
		cout << setw(4) << setfill('0') <<  memory[i] << "\t";
		count++;

		// Formatting
		if (count == 10 && i < MEMORY_SIZE-1)
		{
			count = 0;
			cout << endl;
			cout << setw(3) << setfill('0') << i+1 << " " << ":" << "  ";
		}
	}
}