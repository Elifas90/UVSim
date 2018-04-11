//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Caleb Hansen

// Header file for the "vm" class.



#include "stdafx.h"
#include <string>
#include <iostream>
#include <iomanip>
#include <stdlib.h>
#include <fstream>
#include "ALU.h"




class vm
{
	// Declare needed constants.
	const int MEMORY_SIZE = 1000;

	// Declare data members of the class.
private:
	int accumilator;
	int pc;
	int* memory;

	// Declare functions of the class.
public:
	vm(int * m);
	int getAccumilator();
	void execute();
	void memoryDump();
};

