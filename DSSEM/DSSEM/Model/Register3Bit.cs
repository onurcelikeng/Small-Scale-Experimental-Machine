using System;

namespace DSSEM.Model
{
    public class Register3Bit
    {
        public string Instruction { get; set; }


        public Register3Bit()
        {
            this.Instruction = "000";
        }


        public void Clear()
        {
            Instruction = "000";
        }

        public void Increment()
        {
            int _Instruction = Convert.ToInt32(converter(Instruction, 2, 10)) + 1; //increment (++)
            this.Instruction = converter(_Instruction.ToString(), 10, 2);
        }

        public void Decrement()
        {
            int _Instruction = Convert.ToInt32(converter(Instruction, 2, 10)) - 1;
            this.Instruction = converter(_Instruction.ToString(), 10, 2);
        }

        public void Load(string instruction)
        {
            this.Instruction = instruction;
        }

        public void CompleteBit()
        {
            char[] temp = new char[3];

            for (int i = 0; i < temp.Length - Instruction.Length; i++)
            {
                temp[i] = '0';
                temp[2 - i] = ' ';
            }

            string _temp = new string(temp);
            this.Instruction = string.Concat(_temp.Trim().Replace(" ", ""), this.Instruction);
        }

        public string converter(string number, int fromBase, int toBase)
        {
            return Convert.ToString(Convert.ToInt64(number, fromBase), toBase);
        }

    }
}
