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

        #region Segments
        string[] codeSegment = new string[16]; //9
        string[] dataSegment = new string[16]; //9
        string[] stackSegment = new string[8]; //9
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
        string path;
        bool FGI = false;
        bool IEN = false;
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
            //microOperationListBox.Items.Clear();



            time = Convert.ToInt32(convert(SC.Instruction, 2, 10));

            if (isFinished == false)
            {
                if (time == 0) //FETCH
                {
                    IR.Load(codeSegment[Convert.ToInt32(convert(PC.Instruction, 2, 10))]);
                    SC.Increment();
                    microOperationListBox.Items.Add("T0 : IR <-- C[PC]");
                }

                if (time == 1) //DECODE
                {
                    D = Convert.ToInt32(convert(IR.Instruction.Substring(1, 4), 2, 10));
                    PC.Increment();
                    SC.Increment();
                    microOperationListBox.Items.Add("T1 : D0...D15 <-- DECODE IR(5~8), PC <-- PC + 1");
                }

                if (time == 2 && IR.Instruction[0] == '1') //Indirect
                {
                    AR.Load(dataSegment[Convert.ToInt32(convert(AR.Instruction, 2, 10))].Substring(5, 4));
                    SC.Increment();
                    microOperationListBox.Items.Add("T2 : AR <-- D[AR]");
                }
                else if (time == 2 && IR.Instruction[0] == '0')
                {
                    SC.Increment();
                }
            }

            if (time > 2)
            {
                if (D == 1 || D == 2 || D == 3 || D == 4 || D == 5 || D == 6 || D == 8 || D == 9 || D == 15)
                {
                    if (time == 4)
                    {
                        bool flagg = true;
                    }
                    AR.Load(IR.Instruction.Substring(5, 4));
                    MemoryReference(D, time);
                }

                if (D == 0 && IR.Instruction[0] == '0' && time == 3)
                {
                    RegisterReference(IR.Instruction.Substring(5, 4));
                }

                if (D == 0 && IR.Instruction[0] == '1' && (3 <= time && time <= 4))
                {
                    StackReference(D, IR.Instruction.Substring(5, 4), time);
                }
            }
            pcTextBox.Text = PC.Instruction;
            arTextBox.Text = "AR" + AR.Instruction;
            r1TextBox.Text = "SC" + SC.Instruction;
            r2TextBox.Text = "DR" + DR.Instruction;
            r3TextBox.Text = "IR" + IR.Instruction;
            r4TextBox.Text = "AC" + AC.Instruction;
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

                    microOperationListBox.Items.Add("D1T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    char[] temp = new char[9];

                    for (int i = 0; i < AC.Instruction.Length; i++)
                    {
                        if (AC.Instruction[i] == '0' && IR.Instruction[i] == '0')
                        {
                            temp[i] = '0';
                        }

                        else
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

                    microOperationListBox.Items.Add("D2T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    char[] temp = new char[AC.Instruction.Length];

                    for (int i = 0; i < AC.Instruction.Length; i++)
                    {
                        if (AC.Instruction[i] == '1' && IR.Instruction[i] == '1')
                        {
                            temp[i] = '1';
                        }

                        else
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

                    microOperationListBox.Items.Add("D3T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    char[] temp = new char[9];

                    for (int i = 0; i < AC.Instruction.Length; i++)
                    {
                        if (AC.Instruction[i] == IR.Instruction[i])
                        {
                            temp[i] = '0';
                        }

                        else
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

                    microOperationListBox.Items.Add("D4T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    int sum = Convert.ToInt32(convert(AC.Instruction, 2, 10)) + Convert.ToInt32(convert(DR.Instruction, 2, 10));
                    string _sum = convert(sum.ToString(), 10, 2);

                    if (_sum.Length >= 5)
                    {
                        _sum = _sum.Substring(1, 4);
                        E = '1';
                    }

                    else
                    {
                        E = '0';
                    }

                    AC.Load(_sum);
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

                    PC.Load(dataSegment[_AR].Substring(5, 3));
                    
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
                        SC.Increment();

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

                    microOperationListBox.Items.Add("D15T3 : DR <-- D[AR]");
                }

                if (T == 4)
                {
                    DR.Increment();
                    SC.Increment();

                    microOperationListBox.Items.Add("D15T4 : DR <-- DR + 1");
                }

                if (T == 5)
                {
                    int _AR = Convert.ToInt32(convert(AR.Instruction, 2, 10));
                    dataSegment[_AR] = DR.Instruction;
                    dataSegment[_AR] = completeData(9, dataSegment[_AR] );
                    int _DR = Convert.ToInt32(convert(DR.Instruction, 2, 10));
                    if (_DR==0)
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

            if (B == 0) //SZE
            {
                if (E == '0')
                {
                    PC.Increment();

                    microOperationListBox.Items.Add("rB0 : if(E = 0) then (PC <-- PC + 1)");
                }
            }

            if (B == 1) //CLA
            {
                AC.Clear();

                microOperationListBox.Items.Add("rB1 : AC <-- 0");
            }

            if (B == 2) //SZA
            {
                if (AC.Instruction == "0000")
                {
                    PC.Increment();

                    microOperationListBox.Items.Add("rB2 : if(AC = 0) then (PC <-- PC + 1)");
                }
            }

            if (B == 3) //SNA
            {
                if (AC.Instruction.Substring(0, 1) == "1")
                {
                    PC.Increment();

                    microOperationListBox.Items.Add("rB3 : if(AC(9) = 1) then (PC <-- PC + 1)");
                }
            }

            if (B == 4) //CMA
            {
                char[] temp = new char[AC.Instruction.Length];

                for (int i = 0; i < AC.Instruction.Length; i++)
                {
                    if (AC.Instruction[i] == '0') temp[i] = '1';
                    if (AC.Instruction[i] == '1') temp[i] = '0';
                }

                string _temp = new string(temp);
                AC.Load(_temp);

                microOperationListBox.Items.Add("rB4 : AC <-- AC'");
            }

            if (B == 5) //INC
            {
                AC.Increment();

                microOperationListBox.Items.Add("rB5 : AC <-- AC + 1");
            }

            if (B == 7) //ASHR
            {
                char[] temp = new char[AC.Instruction.Length];
                temp[0] = AR.Instruction[0];

                for (int i = 1; i < temp.Length; i++)
                {
                    temp[i] = AR.Instruction[i - 1];
                }

                string _temp = new string(temp);
                AR.Load(_temp);

                microOperationListBox.Items.Add("rB7 : AC <-- shr(AC)");
            }

            if (B == 8) //ASHL
            {
                char[] temp = new char[AC.Instruction.Length];

                for (int i = 0; i < temp.Length; i++)
                {
                    if (i + 1 < AC.Instruction.Length)
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

            if (B == 9) //HLT
            {
                SC.Clear();

                microOperationListBox.Items.Add("rB9 : SC <-- 0");

                isFinished = true;
                DisplayScreen();
                MessageBox.Show("Finished");
            }
        }

        private void StackReference(int D, string _IR, int T)
        {
            SC.Clear();

            if (D == 1 || D == 9) //PUSH
            {
                if (T == 3)
                {
                    SP.Increment();
                    SC.Increment();
                    microOperationListBox.Items.Add("(D1+D9)T3 : SP <-- SP + 1");
                }

                if (T == 4)
                {
                    stackSegment[Convert.ToInt32(convert(SP.Instruction, 2, 10))] = DR.Instruction;
                    SC.Clear();
                    microOperationListBox.Items.Add("(D1+D9)T4 :  S[SP] <-- DR");
                }
            }

            if (D == 2 || D == 10) //POP
            {
                if (T == 3)
                {
                    DR.Load(stackSegment[Convert.ToInt32(convert(SP.Instruction, 2, 10))]);
                    SC.Increment();
                    microOperationListBox.Items.Add("(D2+D10)T3 : DR <-- S[SP]");
                }

                if (T == 4)
                {
                    SP.Decrement();
                    SC.Clear();
                    microOperationListBox.Items.Add("(D2+D10)T4 : SP <-- SP -1");
                }
            }

            if (D == 3 || D == 11) //SZEMPTY
            {
                int SZEmpty = Convert.ToInt32(convert(SP.Instruction, 2, 10));

                if (SZEmpty == 0)
                {
                    PC.Increment();
                }
                SC.Clear();
                microOperationListBox.Items.Add("(D3+D11)T3 : if(SP = 0) then PC <-- PC + 1");
            }

            if (D == 4 || D == 12) //SZFULL
            {
                int SZFull = Convert.ToInt32(convert(SP.Instruction, 2, 10));

                if (SZFull == 7)
                {
                    PC.Increment();
                }
                SC.Clear();
                microOperationListBox.Items.Add("(D4+D12)T3 : if(SP = 7) then PC <-- PC + 1");
            }

            if (D == 7 || D == 15) // I/O 
            {
                // AC.Load(inputRegisterTextBox.Text);
            }
        }

        private void Parse(string value)
        {
            if (value.Contains(","))
            {
                var item = new Model.Label();

                if (value.Contains("-")) item.SignBit = true;

                string[] array = value.Split('%');
                string[] subArray = array[0].Trim().Split(',');
                item.Name = subArray[0];

                string[] subSubArray = subArray[1].Trim().Split(' ');

                if (subSubArray[0] == "BIN" || subSubArray[0] == "DEC" || subSubArray[0] == "HEX" || subSubArray[0] == "OCT")
                {
                    item.isValue = true;

                    if (subSubArray[0] == "BIN")
                    {
                        item.Value = convert(subSubArray[1], 2, 2);
                        item.Value = completeData(4, item.Value);
                    }

                    else
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
                        if (item.SignBit == true)
                        {
                            item.Value = completeData(3, item.Value);
                            char[] temp = new char[item.Value.Length];

                            for (int i = 0; i < item.Value.Length; i++)
                            {
                                if (item.Value[i] == '0') temp[i] = '1';
                                if (item.Value[i] == '1') temp[i] = '0';
                            }

                            string _temp = new string(temp);
                            int num = Convert.ToInt32(convert(_temp, 2, 10)) + 1;
                            _temp = "";
                            _temp = convert(num.ToString(), 10, 2);
                            _temp = completeData(3, _temp);
                            item.Value = string.Concat("1", _temp);
                        }
                    }

                    item.Base = 2;
                }

                else
                {
                    assemblyCodeList.Add(subArray[1].Trim());
                    item.Value = "0000";
                    item.Base = 2;
                    item.isValue = false;
                }

                labelList.Add(item);
            }

            else
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
                while ((line = streamReader.ReadLine()) != null)
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

            for (int i = 0; i < 16; i++)            ///  16 bits for code segment and data segment 
            {
                codeSegmentDataGridView.Rows.Add(i, codeSegment[i]);
                dataSegmentDataGridView.Rows.Add(i, dataSegment[i]);

            }
            for (int i = 0; i < stackSegment.Length; i++)    ///  8 bits for stack segment
            {
                stackSementDataGridView.Rows.Add(i, stackSegment[i]);
            }

            for (int i = 0; i < labelList.Count; i++)
            {
                labelDataGridView.Rows.Add(labelList[i].Name, "D" + labelList[i].Adress);
            }
        }

        private string completeData(int size, string value)
        {
            string newValue = null;

            for (int i = 0; i < size - value.Length; i++)
            {
                newValue += "0";
            }

            return newValue + value;
        }

        private string convert(string number, int fromBase, int toBase)
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
                    PC.CompleteBit();
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
                        codeSegmentDataGridView.Rows[index].Cells[0].Value = index;
                        codeSegmentDataGridView.Rows[index].Cells[1].Value = codeSegment[index];
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
                    AR.CompleteBit();
                }
            }

            int count = 0;

            for (int i = 0; i < 16; i++)
            {
                if (count < labelList.Count)
                {
                    if (i == labelList[count].Adress)   ///  If there is an instruction to write in this address
                    {
                        dataSegment[i] = completeData(9, convert(labelList[count].Value, labelList[count].Base, 2));
                        count++;
                    }

                    else
                    {
                        dataSegment[i] = "000000000";
                    }
                }

                else
                {
                    dataSegment[i] = "000000000";
                }
            }
        }

        private void createStackSegmentTable()
        {
            for (int i = 0; i < stackSegment.Length; i++)
            {
                stackSegment[i] = "00000000";
            }
        }

        #endregion

        #region File Menu

        private void openButton_Click(object sender, EventArgs e)
        {
            if (isReadFile == false)  ///  Is the asm/basm file opened
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
                for (int i = 0; i < labelList.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (!labelList[i].isValue && list[j].Contains(labelList[i].Name+",")) {
                            labelList[i].Value =convert((j + codeSegmentStart).ToString(),10,2);
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
            StreamWriter file = new StreamWriter("result.mif");   ///  saves the mif file to the path ../bin/debug

            file.WriteLine("END");
            file.Close();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.Filter = "(*.mif)|*.mif|(*.hex)|*.hex";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Debug Menu

        private void startDebugButton_Click(object sender, EventArgs e)
        {
            Microoperations();
        }

        private void NextInstructionButton_Click(object sender, EventArgs e)
        {
            if (instructionCounter == assemblyCodeList.Count + labelList.Count)
            {
                MessageBox.Show("esd");
            }
            else
            {
                assemblyCodeListBox.SelectedIndex = instructionCounter;
                instructionCounter++;
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

        private void convertButton_Click(object sender, EventArgs e)
        {

        }

        private void selectBase_SelectedIndexChanged(object sender, EventArgs e)    ///  base convertion
        {
            int toBase = 0;

            if (selectBase.SelectedIndex == 0) toBase = 2;
            if (selectBase.SelectedIndex == 1) toBase = 8;
            if (selectBase.SelectedIndex == 2) toBase = 10;
            if (selectBase.SelectedIndex == 3) toBase = 16;

            for (int i = 0; i < 16; i++)
            {
                codeSegment[i] = completeData(9, convert(codeSegment[i], lastBase, toBase));
                dataSegment[i] = completeData(9, convert(dataSegment[i], lastBase, toBase));
                if (i < 8)
                {
                    stackSegment[i] = completeData(9, convert(stackSegment[i], lastBase, toBase));
                }
            }

            for (int i = 0; i < labelList.Count; i++)
            {
                labelList[i].Value = convert(labelList[i].Value, lastBase, toBase);
            }

            ///  current selected base
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
