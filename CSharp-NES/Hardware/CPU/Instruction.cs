namespace CSharp_NES.Hardware.CPU
{
    internal struct Instruction
    {
        String name;
        Func<byte> opcode;
        Func<byte> addressmode;
        byte cycles = 0;

        public Instruction(String name, Func<byte> opcode, Func<byte> addrmode, byte cycles)
        {
            this.name = name;
            this.opcode = opcode;
            this.addressmode = addrmode;
            this.cycles = cycles;
        }
    }
}
