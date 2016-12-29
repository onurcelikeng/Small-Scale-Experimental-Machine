using System;

namespace DSSEM.Model
{
    public class Register4Bit
    {
        public string Instruction { get; set; }


        public Register4Bit()
        {
            this.Instruction = "0000";
        }


        public void Clear()
        {
            Instruction = "0000";
        }

        public void Increment()
        {
            int _Instruction = Convert.ToInt32(converter(Instruction, 2, 10)) + 1; //increment (++)
            this.Instruction = converter(_Instruction.ToString(), 10, 2);
        }

        public void Load(string instruction)
        {
            this.Instruction = instruction;
        }

        public void CompleteBit()
        {
            char[] temp = new char[4];

            for (int i = 0; i < temp.Length - Instruction.Length; i++)
            {
                temp[i] = '0';
                temp[3 - i] = ' ';
            }

            string _temp = new string(temp);
            this.Instruction = string.Concat(_temp.Trim().Replace(" ",""), this.Instruction);
        }

        public string converter(string number, int fromBase, int toBase)
        {
            return Convert.ToString(Convert.ToInt64(number, fromBase), toBase);
        }

    }
}
