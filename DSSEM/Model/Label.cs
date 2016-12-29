namespace DSSEM.Model
{
    public class Label
    {
        public string Name { get; set; }

        public int Base { get; set; }

        public string Value { get; set; }

        public int Adress { get; set; }

        public bool SignBit { get; set; } // 0 false positive, 1 true negative

        public bool isValue { get; set; } //dec bin oct hex = true, 
    }
}
