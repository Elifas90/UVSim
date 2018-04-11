//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Nikita Pestin


// Header file for the "Assembler" class.



#include "stdafx.h"
#include <string>
#include <iostream>
#include <iomanip>
#include <stdlib.h>
#include <fstream>

// Declare needed constants.
const int MEMORY_SIZE = 1000;
const int STOP_CODE = -99999;


class Assembler
{
	// Declare data members of the class.
private:
	int instructionsNum;
	int memory[MEMORY_SIZE];

	// Declare functions of the class.
public:
	Assembler();
	void printIntroduction();
	void getInstructions();
	void readFile();	// For debugging purposes.
	int* getMemory();
};

