namespace CSharp_NES.Hardware.CPU
{
    internal struct Instruction
    {
        String Name;
        Func<byte> Opcode;
        Func<byte> Addressmode;
        byte Cycles = 0;

        public Instruction(String name, Func<byte> opcode, Func<byte> addrmode, byte cycles)
        {
            this.Name = name;
            this.Opcode = opcode;
            this.Addressmode = addrmode;
            this.Cycles = cycles;
        }
    }
}
