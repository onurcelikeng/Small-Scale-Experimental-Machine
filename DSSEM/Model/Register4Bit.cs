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
            if (Instruction.Length == 5)
            {
                this.Instruction = this.Instruction.Substring(1, 4);
            }
        }

        public void Load(string instruction)
        {
            this.Instruction = instruction;
        }

      

        public string converter(string number, int fromBase, int toBase)
        {
            return Convert.ToString(Convert.ToInt64(number, fromBase), toBase);
        }

    }
}
