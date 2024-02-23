namespace CSharp_NES.Hardware.CPU
{
    internal struct Instruction
    {
        public String Name;
        public Func<byte> Operate;
        public Func<byte> Addressmode;
        public byte Cycles = 0;

        public Instruction(String name, Func<byte> opcode, Func<byte> addrmode, byte cycles)
        {
            this.Name = name;
            this.Operate = opcode;
            this.Addressmode = addrmode;
            this.Cycles = cycles;
        }
    }
}
