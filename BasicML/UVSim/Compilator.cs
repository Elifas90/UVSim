using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVSim
{
    //-----------------------------------------------------------------------------------------------------------------------
    //  File Designed by: Ali Alabdlmohsen

    // Implementation file for the "Compilator" class.

    /// <summary>
    /// Class to complile BasicML to C#
    /// </summary>
    public class Compilator
    {
        private StringBuilder builder = new StringBuilder();
        private MemoryManager memory;
        private IUVSimController window;
        private Dictionary<int, string> isVariable;
        private List<int> isNumber;
        private int charIndex;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mm">Memory</param>
        /// <param name="w">UVSim controller</param>
        public Compilator(MemoryManager mm, IUVSimController w)
        {
            memory = mm;
            window = w;
            isVariable = new Dictionary<int, string>();
            isNumber = new List<int>();
            charIndex = 97;
        }

        /// <summary>
        /// Generate variable name from memory location
        /// </summary>
        /// <param name="n">memory location</param>
        /// <returns>compiled variable</returns>
        private string GetVar(int n)
        {
            // Check if we already generated variable
            if (isVariable.ContainsKey(n))
            {
                return isVariable[n];
            }
            else
            {
                isVariable.Add(n, ((char)charIndex).ToString());
                charIndex++;
                return isVariable[n];
            }
        }

        /// <summary>
        /// Get Double Word from memory
        /// </summary>
        public int ComposeDWORD(ref int pc)
        {
            if (!isNumber.Contains(pc))
                isNumber.Add(pc);

            // get hiword.
            int hiword = memory[pc];

            // Increment the program counter to get to the 2-digit loword.
            pc++;
            if (!isNumber.Contains(pc))
                isNumber.Add(pc);
            int loword = memory[pc] / 100;

            // Combine loword and hiword into 6-digit number
            int dword = hiword * 100 + loword;

            return dword;
        }

        /// <summary>
        /// Compile program
        /// </summary>
        public void Compile()
        {
            // Write first lines
            builder.AppendLine("using System;");
            builder.AppendLine();
            builder.AppendLine("namespace UVSim");
            builder.AppendLine("{");
            builder.AppendLine("\tclass Program");
            builder.AppendLine("\t{");
            builder.AppendLine("\t\tstatic void Main(string[] args)");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\tint acc = 0;");

            try
            {
                // Make run
                for (int i = 0; i < Thread.THREAD_OFFSET; i++)
                {
                    // Get the opCode
                    int opCode = memory[i] / 100;
                    int operand = memory[i] % 100;

                    // Check is this instruction is variable or number then miss it
                    if (isNumber.Contains(i) || isVariable.ContainsKey(i) || isVariable.ContainsKey(i - 1))
                        continue;

                    // Switch statment to execute the targeted instruction based on the opCode.
                    switch (opCode)
                    {
                        // READ
                        case 10:
                            builder.AppendLine($"Label{i}:\tConsole.Write(\"Enter an integer: \");");
                            builder.AppendLine($"\t\t\t{GetVar(operand)} = int.Parse(Console.ReadLine());");
                            break;

                        // WRITE
                        case 11:
                            builder.AppendLine($"Label{i}:\tConsole.WriteLine({GetVar(operand)});");
                            break;

                        // READ - INDIRECT
                        case 12:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tConsole.Write(\"Enter an integer: \");");
                            builder.AppendLine($"\t\t\t{GetVar(operand)} = int.Parse(Console.ReadLine());");
                            break;

                        // WRITE - INDIRECT
                        case 13:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tConsole.WriteLine({GetVar(operand)});");
                            break;

                        // LOAD
                        case 20:
                            builder.AppendLine($"Label{i}:\tacc = {GetVar(operand)};");
                            break;

                        // STORE
                        case 21:
                            builder.AppendLine($"Label{i}:\t{GetVar(operand)} = acc;");
                            break;

                        // LOAD - INDIRECT
                        case 22:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc = {GetVar(operand)};");
                            break;

                        // STORE - INDIRECT
                        case 23:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\t{GetVar(operand)} = acc;");
                            break;

                        // ADD
                        case 30:
                            builder.AppendLine($"Label{i}:\tacc+= {GetVar(operand)};");
                            break;

                        // SUBTRACT
                        case 31:
                            builder.AppendLine($"Label{i}:\tacc-= {GetVar(operand)};");
                            break;

                        // DIVIDE
                        case 32:
                            builder.AppendLine($"Label{i}:\tacc/= {GetVar(operand)};");
                            break;

                        // MULTIPLY
                        case 33:
                            builder.AppendLine($"Label{i}:\tacc*= {GetVar(operand)};");
                            break;

                        // ADD - INDIRECT
                        case 34:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc+= {GetVar(operand)};");
                            break;

                        // SUBTRACT - INDIRECT
                        case 35:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc-= {GetVar(operand)};");
                            break;

                        // DIVIDE - INDIRECT
                        case 36:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc/= {GetVar(operand)};");
                            break;

                        // MULTIPLY - INDIRECT
                        case 37:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc*= {GetVar(operand)};");
                            break;

                        // BRANCH
                        case 40:
                            builder.AppendLine($"Label{i}:\tgoto Label{operand}");
                            break;

                        // BRANCHNEG
                        case 41:
                            builder.AppendLine($"Label{i}:\tif (acc < 0) goto Label{operand};");
                            break;

                        // BRANCHZERO
                        case 42:
                            builder.AppendLine($"Label{i}:\tif (acc == 0) goto Label{operand};");
                            break;

                        // HALT
                        case 43:
                            builder.AppendLine($"Label{i}:\treturn;");
                            break;

                        // BRANCH - INDIRECT
                        case 44:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tgoto Label{operand}");
                            break;

                        // BRANCHNEG - INDIRECT
                        case 45:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tif (acc < 0) goto Label{operand};");
                            break;

                        // BRANCHZERO - INDIRECT
                        case 46:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tif (acc == 0) goto Label{operand};");
                            break;

                        // REMINDER
                        case 50:
                            builder.AppendLine($"Label{i}:\tacc%= {GetVar(operand)};");
                            break;

                        // EXPONENTIATION
                        case 51:
                            builder.AppendLine($"Label{i}:\tacc = (int)Math.Pow(acc, {GetVar(operand)});");
                            break;

                        // REMINDER - INDIRECT
                        case 52:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc%= {GetVar(operand)};");
                            break;

                        // EXPONENTIATION - INDIRECT
                        case 53:
                            i++;
                            operand = memory[i];
                            builder.AppendLine($"Label{i}:\tacc = (int)Math.Pow(acc, {GetVar(operand)});");
                            break;

                        // Defult.
                        default:
                            break;
                    }
                }
                window.Console.WriteLine("Compilation successful!");
            }
            catch (Exception ex)
            {
                window.Error(ex.Message);
            }

            // Iterate through all variables and initialize them
            foreach (int key in isVariable.Keys)
            {
                int location = key;
                builder.Insert(113, $"\t\t\tint {isVariable[key]} = {ComposeDWORD(ref location)};\r\n");
            }

            builder.AppendLine("\t\t}");
            builder.AppendLine("\t}");
            builder.AppendLine("}");

        }

        /// <summary>
        /// Writes results of compilation into file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void WriteToFile(string fileName)
        {
            try
            {
                File.WriteAllText(fileName, builder.ToString());
                window.Console.WriteLine("Successfully stored in file " + fileName);
            }
            catch (Exception)
            {
                window.Error($"Can't write into file {fileName}.");
            }
        }
    }
}
