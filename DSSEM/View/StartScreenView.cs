using System;
using System.IO;
using DSSEM.Model;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DSSEM.View
{
    public partial class StartScreenView : Form
    {
        List<Model.Instruction> instructionList = new List<Model.Instruction>();
        List<Model.Label> labelList = new List<Model.Label>();
        List<string> assemblyCodeList = new List<string>();
        List<string> list = new List<string>();
        bool stepInstruction = false;

        #region Segments
        string[] codeSegment = new string[16]; //9
        string[] dataSegment = new string[16]; //9
        string[] stackSegment = new string[8]; //9

        string[] codeDisplay = new string[16]; //9
        string[] dataDisplay = new string[16]; //9
        string[] stackDisplay = new string[8]; //9
        #endregion

        #region Registers
        Register9Bit IR = new Register9Bit();
        Register4Bit AR = new Register4Bit();
        Register4Bit PC = new Register4Bit();
        Register4Bit DR = new Register4Bit();
        Register4Bit AC = new Register4Bit();
        Register3Bit SP = new Register3Bit();
        Register3Bit SC = new Register3Bit();
        Register4Bit INPR = new Register4Bit();
        #endregion

        #region Variables
        int instructionCounter = 0;
        char E = '0';
        int codeSegmentStart = 0;
        int dataSegmentStart = 0;
        bool isReadFile = false;
        int lastBase = 2;
        int toBase = 0;
        string path;
        int time = 0;
        int D = 0;
        bool isFinished = false;
        #endregion


        public StartScreenView()
        {
            InitializeComponent();
            loadInstruction();
            selectBase.SelectedIndex = 0;
        }


        private void Microoperations()
        {
            time = Convert.ToInt32(convert(SC.Instruction, 2, 10));
            if (time == 0)
            {
                microOperationListBox.Items.Clear();
            }
            if (isFinished == false)
            {
                if (time == 0) //FETCH
                {
                    IR.Load(codeSegment[Convert.ToInt32(convert(PC.Instruction, 2, 10))]);
                    SC.Increment();
                    if (stepInstruction)
                    {
                        time = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("T0 : IR <-- C[PC]");
                }

                if (time == 1) //DECODE
                {
                    D = Convert.ToInt32(convert(IR.Instruction.Substring(1, 4), 2, 10));
                    PC.Increment();
                    SC.Increment();
                    if (stepInstruction)
                    {
                        time = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }

                    microOperationListBox.Items.Add("T1 : D0...D15 <-- DECODE IR(5~8), PC <-- PC + 1");
                }

                if (time == 2 && IR.Instruction[0] == '1') // Indirect
                {
                    AR.Load(dataSegment[Convert.ToInt32(convert(AR.Instruction, 2, 10))].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        time = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("T2 : AR <-- D[AR]");
                }
                else if (time == 2 && IR.Instruction[0] == '0') // Direct
                {
                    SC.Increment();
                    if (stepInstruction)
                    {
                        time = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                }
            }

            if (time > 2) // EXECUTE
            {
                if (D == 1 || D == 2 || D == 3 || D == 4 || D == 5 || D == 6 || D == 8 || D == 9 || D == 15) // Memory Reference
                {
                    AR.Load(IR.Instruction.Substring(5, 4));
                    MemoryReference(D, time);
                }

                if (D == 0 && IR.Instruction[0] == '0' && time == 3) // Register Reference
                {
                    RegisterReference(IR.Instruction.Substring(5, 4));
                }

                if (D == 0 && IR.Instruction[0] == '1') // Stack Reference
                {
                    StackReference(D, IR.Instruction.Substring(5, 4), time);
                }
            }

            // Filling Register Boxes
            pcTextBox.Text = convert(PC.Instruction,2,toBase);
            arTextBox.Text = convert(AR.Instruction, 2, toBase);
            r1TextBox.Text = convert(SC.Instruction, 2, toBase);
            r2TextBox.Text = convert(DR.Instruction, 2, toBase);
            ırTextBox.Text = convert(IR.Instruction, 2, toBase);
            r4TextBox.Text = convert(AC.Instruction, 2, toBase);
            spTextBox.Text = convert(SP.Instruction, 2, toBase);
            DisplayScreen();
        }

        private void MemoryReference(int D, int T)
        {
            #region OR

            if (D == 1)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    DR.Load(dataSegment[_AR].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }

                    microOperationListBox.Items.Add("D1T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    char[] temp = new char[9];

                    for (int i = 0; i < AC.Instruction.Length; i++)
                    {
                        if (AC.Instruction[i] == '0' && IR.Instruction[i] == '0') // 0 v 0 = 0
                        {
                            temp[i] = '0';
                        }

                        else // Other situations = 1
                        {
                            temp[i] = '1';
                        }
                    }
                    string _temp = new string(temp);
                    AC.Load(_temp);
                    SC.Clear();

                    microOperationListBox.Items.Add("D1T4 : AC <-- AC v DR, SC <-- 0");
                }
            }

            #endregion

            #region AND

            if (D == 2)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    DR.Load(dataSegment[_AR].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("D2T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    char[] temp = new char[AC.Instruction.Length];

                    for (int i = 0; i < AC.Instruction.Length; i++)
                    {
                        if (AC.Instruction[i] == '1' && DR.Instruction[i] == '1') // 1 ^ 1 = 1
                        {
                            temp[i] = '1';
                        }

                        else // Other Situations = 0
                        {
                            temp[i] = '0';
                        }
                    }
                    string _temp = new string(temp);
                    AC.Load(_temp);
                    SC.Clear();

                    microOperationListBox.Items.Add("D2T4 : AC <-- AC ^ DR, SC <-- 0");
                }
            }

            #endregion

            #region XOR

            if (D == 3)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    DR.Load(dataSegment[_AR].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("D3T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    char[] temp = new char[9];

                    for (int i = 0; i < AC.Instruction.Length; i++)
                    {
                        if (AC.Instruction[i] == IR.Instruction[i]) // 1 xor 1 = 0 || 0 xor 0 = 0
                        {
                            temp[i] = '0';
                        }

                        else // 1 xor 0 = 1
                        {
                            temp[i] = '1';
                        }
                    }
                    string _temp = new string(temp);
                    AC.Load(temp.ToString());
                    SC.Clear();

                    microOperationListBox.Items.Add("D3T4 : AC <-- AC xor DR, SC <-- 0");
                }
            }

            #endregion

            #region ADD

            if (D == 4)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    DR.Load(dataSegment[_AR].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("D4T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    int sum = Convert.ToInt32(convert(AC.Instruction, 2, 10)) + Convert.ToInt32(convert(DR.Instruction, 2, 10));
                    string _sum = convert(sum.ToString(), 10, 2);

                    if (_sum.Length >= 5) // Numbers are 4 bits
                    {
                        _sum = _sum.Substring(1, 4);
                        E = '1'; // There is a Remainder
                    }

                    else
                    {
                        E = '0'; // No remainder
                    }

                    AC.Load(_sum);
                    AC.Instruction = completeData(4, AC.Instruction);
                    SC.Clear();

                    microOperationListBox.Items.Add("D4T4 : AC <-- AC + DR, E <-- Cout, SC <-- 0");
                }
            }

            #endregion

            #region LDA

            if (D == 5)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    DR.Load(dataSegment[_AR].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("D5T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    AC.Load(DR.Instruction);
                    SC.Clear();

                    microOperationListBox.Items.Add("D5T4 : AC <-- DR, SC <-- 0");
                }
            }

            #endregion

            #region STA

            if (D == 6)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    dataSegment[_AR] = completeData(9, AC.Instruction);
                    dataDisplay[_AR] = completeData(9, AC.Instruction);
                    SC.Clear();

                    microOperationListBox.Items.Add("D6T3 : D[AR] <-- AC, SC <-- 0");
                }
            }

            #endregion

            #region BUN

            if (D == 8)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));

                    PC.Load(dataSegment[_AR].Substring(5, 4));

                    SC.Clear();

                    microOperationListBox.Items.Add("D8T3 : PC <-- S[SP], SP <-- SP - 1, SC <-- 0");
                }
            }

            #endregion

            #region BSA

            if (D == 9)
            {
                if (T == 3)
                {
                    int _SP = Convert.ToInt32(convert(SP.Instruction, 2, 10));

                    if (_SP > 7)
                    {
                        MessageBox.Show("Stack overflow!");
                    }

                    else if (_SP <= 7)
                    {
                        stackSegment[_SP] = completeData(9, PC.Instruction);
                        stackDisplay[_SP] = completeData(9, PC.Instruction);
                        SC.Increment();
                        if (stepInstruction)
                        {
                            T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                        }
                        microOperationListBox.Items.Add("D9T3 S[SP] <-- PC");
                    }
                }

                if (T == 4)
                {
                    PC.Load(IR.Instruction.Substring(5, 4));
                    SP.Increment();
                    SC.Clear();

                    microOperationListBox.Items.Add("D9T4 : PC <-- IR[5~8], SP <-- SP + 1, SC <-- 0");
                }
            }

            #endregion

            #region ISZ

            if (D == 15)
            {
                if (T == 3)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    DR.Load(dataSegment[_AR].Substring(5, 4));
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("D15T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    DR.Increment();
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }

                    microOperationListBox.Items.Add("D15T4 : DR <-- DR + 1");
                }

                if (T == 5)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    dataSegment[_AR] = DR.Instruction;
                    dataSegment[_AR] = completeData(9, dataSegment[_AR]);
                    dataDisplay[_AR] = DR.Instruction;
                    dataDisplay[_AR] = completeData(9, dataDisplay[_AR]);
                    int _DR = Convert.ToInt32(convert(DR.Instruction, 2, 10));
                    if (_DR == 0)
                    {
                        PC.Increment();
                    }

                    SC.Clear();

                    microOperationListBox.Items.Add("D15T5 : D[AR] <-- DR, if(DR = 0) then (AR <-- AR + 1), SC <-- 0");
                }

            }

            #endregion
        }

        private void RegisterReference(string _IR)
        {
            SC.Clear();

            int B = Convert.ToInt32(convert(_IR, 2, 10));

            #region SZE
            if (B == 0)
            {
                if (E == '0')
                {
                    PC.Increment();

                    microOperationListBox.Items.Add("rB0 : if(E = 0) then (PC <-- PC + 1)");
                }
            }
            #endregion

            #region CLA
            if (B == 1)
            {
                AC.Clear();

                microOperationListBox.Items.Add("rB1 : AC <-- 0");
            }
            #endregion

            #region SZA
            if (B == 2)
            {
                if (AC.Instruction == "0000")
                {
                    PC.Increment();

                    microOperationListBox.Items.Add("rB2 : if(AC = 0) then (PC <-- PC + 1)");
                }
            }
            #endregion

            #region SNA
            if (B == 3)
            {
                if (AC.Instruction.Substring(0, 1) == "1")
                {
                    PC.Increment();

                    microOperationListBox.Items.Add("rB3 : if(AC(9) = 1) then (PC <-- PC + 1)");
                }
            }
            #endregion

            #region CMA
            if (B == 4)
            {
                char[] temp = new char[AC.Instruction.Length];

                for (int i = 0; i < AC.Instruction.Length; i++)  // Take complement of the bits
                {
                    if (AC.Instruction[i] == '0') temp[i] = '1';
                    if (AC.Instruction[i] == '1') temp[i] = '0';
                }

                string _temp = new string(temp);
                AC.Load(_temp);

                microOperationListBox.Items.Add("rB4 : AC <-- AC'");
            }
            #endregion

            #region INC
            if (B == 5)
            {
                AC.Increment();

                microOperationListBox.Items.Add("rB5 : AC <-- AC + 1");
            }
            #endregion

            #region ASHR
            if (B == 7)
            {
                char[] temp = new char[AC.Instruction.Length];
                temp[0] = AR.Instruction[0]; // Keep the sign bit as the first bit of the shifted instruction

                for (int i = 1; i < temp.Length; i++) // Shift all the bits to right
                {
                    temp[i] = AR.Instruction[i - 1];
                }

                string _temp = new string(temp);
                AR.Load(_temp);

                microOperationListBox.Items.Add("rB7 : AC <-- shr(AC)");
            }
            #endregion

            #region ASHL
            if (B == 8)
            {
                char[] temp = new char[AC.Instruction.Length];

                for (int i = 0; i < temp.Length; i++)
                {
                    if (i + 1 < AC.Instruction.Length) // Shift all the bits to the left and add 0 to the last bit
                    {
                        temp[i] = AC.Instruction[i + 1];
                        temp[i + 1] = '0';
                        break;
                    }
                }

                string _temp = new string(temp);
                AC.Load(_temp);

                microOperationListBox.Items.Add("rB8 : AC <-- shl(AC)");
            }
            #endregion

            #region HLT
            if (B == 9)
            {
                SC.Clear();

                microOperationListBox.Items.Add("rB9 : SC <-- 0");

                isFinished = true;
                DisplayScreen();
                MessageBox.Show("Finished");
            }
            #endregion
        }

        private void StackReference(int D, string _IR, int T)
        {
            D = Convert.ToInt32(convert(_IR, 2, 10));

            #region PUSH
            if (D == 9)
            {
                if (T == 3)
                {
                    SP.Increment();
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("(D1+D9)T3 : SP <-- SP + 1");
                }

                if (T == 4)
                {
                    stackSegment[Convert.ToInt32(convert(SP.Instruction, 2, 10))] = DR.Instruction;
                    stackDisplay[Convert.ToInt32(convert(SP.Instruction, 2, 10))] = DR.Instruction;
                    SC.Clear();
                    microOperationListBox.Items.Add("(D1+D9)T4 :  S[SP] <-- DR");
                }
            }
            #endregion

            #region POP
            if (D == 10)
            {
                if (T == 3)
                {
                    SP.Decrement();
                    SC.Increment();
                    if (stepInstruction)
                    {
                        T = Convert.ToInt32(convert(SC.Instruction, 2, 10));
                    }
                    microOperationListBox.Items.Add("(D2+D10)T4 : SP <-- SP -1");
                }

                if (T == 4)
                {
                    AC.Load(stackSegment[Convert.ToInt32(convert(SP.Instruction, 2, 10))].Substring(5,4));
                    
                    SC.Clear();
                    microOperationListBox.Items.Add("(D2+D10)T3 : AC <-- S[SP]");
                }
            }
            #endregion

            #region SZEMPTY
            if (D == 11)
            {
                int SZEmpty = Convert.ToInt32(convert(SP.Instruction, 2, 10));

                if (SZEmpty == 0)
                {
                    PC.Increment();
                }
                SC.Clear();
                microOperationListBox.Items.Add("(D3+D11)T3 : if(SP = 0) then PC <-- PC + 1");
            }
            #endregion

            #region SZFULL
            if (D == 12)
            {
                int SZFull = Convert.ToInt32(convert(SP.Instruction, 2, 10));

                if (SZFull == 7)
                {
                    PC.Increment();
                }
                SC.Clear();
                microOperationListBox.Items.Add("(D4+D12)T3 : if(SP = 7) then PC <-- PC + 1");
            }
            #endregion

            #region INP
            if (D == 15)
            {
                string value = inputRegisterTextBox.Text;

                if (value != "")
                {
                    value = completeData(4, convert(inputRegisterTextBox.Text, 16, 2));
                    AC.Load(value);
                }






            }
            #endregion
        }

        private void Parse(string value)
        {
            if (value.Contains(","))
            {
                var item = new Model.Label();

                if (value.Contains("-")) item.SignBit = true; // If the label includes "-", the value is negative

                string[] array = value.Split('%'); // Split the comments
                string[] subArray = array[0].Trim().Split(','); // Split the labels
                item.Name = subArray[0];// item.Name = Label name

                string[] subSubArray = subArray[1].Trim().Split(' '); // subSubArray = the base of the label's value

                if (subSubArray[0] == "BIN" || subSubArray[0] == "DEC" || subSubArray[0] == "HEX" || subSubArray[0] == "OCT")
                {
                    item.isValue = true; // Not a loop label

                    if (subSubArray[0] == "BIN")
                    {
                        item.Value = convert(subSubArray[1], 2, 2);
                        item.Value = completeData(4, item.Value);
                    }

                    else // Convert all the base types to binary
                    {
                        if (subSubArray[0] == "OCT")
                        {
                            item.Value = convert(subSubArray[1].Replace("-", ""), 8, 2);

                        }

                        if (subSubArray[0] == "DEC")
                        {
                            item.Value = convert(subSubArray[1].Replace("-", ""), 10, 2);


                        }
                        if (subSubArray[0] == "HEX")
                        {
                            item.Value = convert(subSubArray[1].Replace("-", ""), 16, 2);
                        }
                        if (item.SignBit == true) // If negative
                        {
                            item.Value = completeData(3, item.Value);
                            char[] temp = new char[item.Value.Length];

                            for (int i = 0; i < item.Value.Length; i++) // Complement
                            {
                                if (item.Value[i] == '0') temp[i] = '1';
                                if (item.Value[i] == '1') temp[i] = '0';
                            }

                            string _temp = new string(temp);
                            int num = Convert.ToInt32(convert(_temp, 2, 10)) + 1; // Two's Complement
                            _temp = "";
                            _temp = convert(num.ToString(), 10, 2);
                            _temp = completeData(3, _temp);
                            item.Value = string.Concat("1", _temp); // Add 1 as the sign bit (4th bit)
                        }
                    }

                    item.Base = 2;
                }

                else // Loop label
                {
                    assemblyCodeList.Add(subArray[1].Trim());
                    item.Value = "0000";
                    item.Base = 2;
                    item.isValue = false;
                }

                labelList.Add(item);
            }

            else // No label
            {
                string[] array = value.Split('%');
                assemblyCodeList.Add(array[0].Trim());
            }
        }

        private void loadInstruction()
        {
            using (StreamReader streamReader = new StreamReader("Instruction.txt"))   ///  read computer instructions from text file
            {
                string line;
                while ((line = streamReader.ReadLine()) != null) // While the line is not null
                {
                    var item = new Instruction();

                    string[] array = line.Split(' ');
                    item.Symbol = array[0];
                    item.Binary = array[1];
                    item.Octal = array[2];
                    item.Decimal = array[3];
                    item.Hexadecimal = array[4];
                    item.ReferanceType = array[5];

                    instructionList.Add(item);
                }
            }
        }

        private void DisplayScreen()
        {
            codeSegmentDataGridView.Rows.Clear();
            dataSegmentDataGridView.Rows.Clear();
            stackSementDataGridView.Rows.Clear();
            labelDataGridView.Rows.Clear();

            for (int i = 0; i < 16; i++) // 16 bits for code segment and data segment 
            {
                codeSegmentDataGridView.Rows.Add(i, codeDisplay[i]);
                dataSegmentDataGridView.Rows.Add(i, dataDisplay[i]);

            }
            for (int i = 0; i < stackSegment.Length; i++) // 8 bits for stack segment
            {
                stackSementDataGridView.Rows.Add(i, stackDisplay[i]);
            }

            for (int i = 0; i < labelList.Count; i++)
            {
                labelDataGridView.Rows.Add(labelList[i].Name, "D" + labelList[i].Adress);
            }
        }

        private string completeData(int size, string value) // Completes the data length by adding 0s
        {
            string newValue = null;

            for (int i = 0; i < size - value.Length; i++)
            {
                newValue += "0";
            }

            return newValue + value;
        }

        private string convert(string number, int fromBase, int toBase) // Convertion between the bases
        {
            return Convert.ToString(Convert.ToInt64(number, fromBase), toBase);
        }


        #region Create Tables

        private void createLabelTable()
        {
            for (int i = 0; i < assemblyCodeList.Count; i++)
            {
                if (assemblyCodeList[i].Contains("ORG D"))
                {
                    string[] array = assemblyCodeList[i].Split(' ');
                    dataSegmentStart = Convert.ToInt32(array[2]);
                }
            }

            int index = dataSegmentStart;

            for (int i = 0; i < labelList.Count; i++)
            {
                labelList[i].Adress = index;
                labelDataGridView.Rows.Add(labelList[i].Name, "D" + index++);
            }
        }

        private void createCodeSegmentTable()
        {
            for (int i = 0; i < assemblyCodeList.Count; i++)
            {
                if (assemblyCodeList[i].Contains("ORG C"))
                {
                    string[] array = assemblyCodeList[i].Split(' ');
                    codeSegmentStart = Convert.ToInt32(array[2]);
                    PC.Load(convert(array[2], 10, 2));
                }
            }

            int cursor = 1;
            int index = codeSegmentStart;

            for (int k = 0; k < 16; k++)
            {
                string[] array = assemblyCodeList[cursor].Trim().Split(' ');

                for (int i = 0; i < instructionList.Count; i++)
                {
                    if (array[0] == instructionList[i].Symbol)
                    {
                        if (instructionList[i].ReferanceType == "Memory-Reference") // I Opcode Address
                        {
                            if (assemblyCodeList[cursor].Contains(" I")) path = "1";
                            else path = "0";

                            path += instructionList[i].Binary;

                            for (int j = 0; j < labelList.Count; j++)
                            {
                                if (array.Length > 1 && labelList[j].Name == array[1])
                                {
                                    string result = convert(labelList[j].Adress.ToString(), 10, 2);
                                    path += completeData(4, result);
                                }
                            }
                        }

                        if (instructionList[i].ReferanceType == "Register-Reference") // 0 0000 Register-Opcode
                        {
                            path = "00000" + instructionList[i].Binary;
                        }

                        if (instructionList[i].ReferanceType == "I/O-Reference") // 1 0000 I/O-Opcode
                        {
                            path = "10000" + instructionList[i].Binary;
                        }

                        if (instructionList[i].ReferanceType == "Stack-Reference") // 1 0000 Stack-Opcode
                        {
                            path = "10000" + instructionList[i].Binary;
                        }

                        codeSegment[index] = path;
                        codeDisplay[index] = path;
                        codeSegmentDataGridView.Rows[index].Cells[0].Value = index;
                        codeSegmentDataGridView.Rows[index].Cells[1].Value = codeDisplay[index];
                        index++;
                        cursor++;
                    }
                }
            }
        }

        private void createDataSegmentTable()
        {
            for (int i = 0; i < assemblyCodeList.Count; i++)
            {
                if (assemblyCodeList[i].Contains("ORG D"))
                {
                    string[] array = assemblyCodeList[i].Split(' ');
                    dataSegmentStart = Convert.ToInt32(array[2]);
                    AR.Load(convert(array[2], 10, 2));
                }
            }

            int count = 0;

            for (int i = 0; i < 16; i++)
            {
                if (count < labelList.Count)
                {
                    if (i == labelList[count].Adress) // If there is an instruction to write in this address
                    {
                        dataSegment[i] = completeData(9, convert(labelList[count].Value, labelList[count].Base, 2));
                        dataDisplay[i] = completeData(9, convert(labelList[count].Value, labelList[count].Base, 2));
                        count++;
                    }

                    else
                    {
                        dataSegment[i] = "000000000";
                        dataDisplay[i] = "000000000";
                    }
                }

                else
                {
                    dataSegment[i] = "000000000";
                    dataDisplay[i] = "000000000";
                }
            }
        }

        private void createStackSegmentTable()
        {
            for (int i = 0; i < stackSegment.Length; i++)
            {
                stackSegment[i] = "000000000";
                stackDisplay[i] = "000000000";
            }
        }

        #endregion

        #region File Menu

        private void openButton_Click(object sender, EventArgs e)
        {
            if (isReadFile == false) // Is the asm/basm file opened
            {
                isReadFile = true;
                assemblyCodeListBox.Items.Clear();

                openFileDialog.ShowDialog();
                if (openFileDialog.FileName == "") return;

                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Parse(line);
                        if (line.Contains("%"))
                        {
                            string[] array = line.Split('%');
                            list.Add(array[0].Trim());
                        }

                        else
                        {
                            list.Add(line.Trim());
                        }

                        assemblyCodeListBox.Items.Add(line);
                    }
                }
                createCodeSegmentTable();
                for (int i = 0; i < labelList.Count; i++) // Add the loop label to the label list
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (!labelList[i].isValue && list[j].Contains(labelList[i].Name + ","))
                        {
                            labelList[i].Value = convert((j + codeSegmentStart - 1).ToString(), 10, 2);
                        }
                    }
                }

                createLabelTable();
                createCodeSegmentTable();
                createDataSegmentTable();
                createStackSegmentTable();
                DisplayScreen();
            }

            else
            {
                MessageBox.Show("The progress is already started!");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Code Segment

            // Find the path of the desktop
            string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"CodeSegment.mif");
            // Create file
            StreamWriter file = new StreamWriter(logPath);

            // Write the first line
            file.WriteLine("DEPTH = 16;");

            //Other lines
            file.WriteLine("WIDTH = 9;");
            file.WriteLine("ADDRESS_RADIX = HEX;");
            file.WriteLine("DATA_RADIX = BIN;");
            file.WriteLine("CONTENT");
            file.WriteLine("BEGIN");
            for (int i = 0; i < 16; i++)
            {
                if (codeSegment[i] == null)
                {
                    file.WriteLine("0" + convert(i.ToString(), 10, 16).ToUpper()  + " : " + "000000000;");
                }
                else
                    file.WriteLine("0" + convert(i.ToString(), 10, 16).ToUpper()  + " : " + codeSegment[i]+";");
            }
            file.WriteLine("END;");

            //Close the file..
            file.Close();
            logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CodeSegment.hex");
            file = new StreamWriter(logPath);

            String line = "";
            for (int i = 0; i < 16; i++)
            {
                string BB = completeData(4, convert(i.ToString(), 10, 16));
                string DD = completeData(4, convert(codeSegment[i], 2, 16));
                line = ":02" + BB + "00" + DD;
                int EE = 2 + Convert.ToInt32(convert(BB.Substring(0, 2), 16, 10)) + Convert.ToInt32(convert(BB.Substring(2, 2), 16, 10)) + Convert.ToInt32(convert(DD.Substring(0, 2), 16, 10)) + Convert.ToInt32(convert(DD.Substring(2, 2), 16, 10));
                EE = -EE;
                string _EE = convert(EE.ToString(), 10, 16);
                string temp = _EE.Substring(_EE.Length - 2, 2);
                temp.ToUpper();
                line += temp;
                file.WriteLine(line.ToUpper());
            }
            file.WriteLine(":00000001FF");
            file.Close();
            //Data Segment

            logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DataSegment.mif");
            file = new StreamWriter(logPath);

            file.WriteLine("DEPTH = 16;");
            file.WriteLine("WIDTH = 9;");
            file.WriteLine("ADDRESS_RADIX = HEX;");
            file.WriteLine("DATA_RADIX = BIN;");
            file.WriteLine("CONTENT");
            file.WriteLine("BEGIN");
            for (int i = 0; i < 16; i++)
            {
                if (dataSegment[i] == null)
                {
                    file.WriteLine("0" + convert(i.ToString(), 10, 16).ToUpper() + " : " + "000000000;");
                }
                else
                    file.WriteLine("0" + convert(i.ToString(), 10, 16).ToUpper() + " : "  + dataSegment[i]+";");
            }
            file.WriteLine("END;");

            file.Close();

            logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DataSegment.hex");
        
            file = new StreamWriter(logPath);
            line = "";
            for (int i = 0; i < 16; i++)
            {
                string BB = completeData(4, convert(i.ToString(), 10, 16));
                string DD = completeData(4, convert(dataSegment[i], 2, 16));
                line = ":02" + BB + "00" + DD;
                int EE = 2 + Convert.ToInt32(convert(BB.Substring(0, 2), 16, 10)) + Convert.ToInt32(convert(BB.Substring(2, 2), 16, 10)) + Convert.ToInt32(convert(DD.Substring(0, 2), 16, 10)) + Convert.ToInt32(convert(DD.Substring(2, 2), 16, 10));
                EE = -EE;
                string _EE = convert(EE.ToString(), 10, 16);
                string temp = _EE.Substring(_EE.Length - 2, 2);
                 temp.ToUpper() ;
                line += temp;
                file.WriteLine(line.ToUpper());
            }
            file.WriteLine(":00000001FF");
            file.Close();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Debug Menu

        private void startDebugButton_Click(object sender, EventArgs e)
        {
            if (!isFinished)
                if (instructionCounter == assemblyCodeList.Count + labelList.Count)
                {
                    MessageBox.Show("FILE DO NOT OPEN !!!");
                }

                else
                {
                    stepInstruction = true;
                    Microoperations();
                }
            else
            {
                MessageBox.Show("Program was finished");
            }
        }

        private void NextInstructionButton_Click(object sender, EventArgs e)
        {
            if (!isFinished)
                if (instructionCounter == assemblyCodeList.Count + labelList.Count)
                {
                    MessageBox.Show("FILE DO NOT OPEN !!!");
                }

                else
                {
                    stepInstruction = false;
                    Microoperations();
                }
            else
            {
                MessageBox.Show("Program was finished");
            }
        }

        #endregion

        #region Help Menu

        private void guideButtonClick(object sender, EventArgs e)
        {
            GuideScreenView screen = new GuideScreenView();
            screen.Show();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutScreenView screen = new AboutScreenView();
            screen.Show();
        }

        #endregion

        #region Program Buttons

        private void selectBase_SelectedIndexChanged(object sender, EventArgs e) // base convertion
        {
            

            if (selectBase.SelectedIndex == 0) toBase = 2;
            if (selectBase.SelectedIndex == 1) toBase = 8;
            if (selectBase.SelectedIndex == 2) toBase = 10;
            if (selectBase.SelectedIndex == 3) toBase = 16;

            for (int i = 0; i < 16; i++)
            {
                codeDisplay[i] = completeData(9, convert(codeDisplay[i], lastBase, toBase));
                dataDisplay[i] = completeData(9, convert(dataDisplay[i], lastBase, toBase));
          
                if (i < 8)
                {
                    stackDisplay[i] = completeData(9, convert(stackDisplay[i], lastBase, toBase));
                }
            }

            for (int i = 0; i < labelList.Count; i++)
            {
                labelList[i].Value = convert(labelList[i].Value, lastBase, toBase);
            }

            // current selected base
            string header = null;
            if (toBase == 2) header = "BIN";
            if (toBase == 8) header = "OCT";
            if (toBase == 10) header = "DEC";
            if (toBase == 16) header = "HEX";

            valueCodeSegmentDataGridView.HeaderText = "Data (" + header + ")";
            valueDataSegmentDataGridView.HeaderText = "Data (" + header + ")";
            valueStackSegmentDataGridView.HeaderText = "Data (" + header + ")";

            lastBase = toBase;
            DisplayScreen();
        }

        #endregion


    }
}
