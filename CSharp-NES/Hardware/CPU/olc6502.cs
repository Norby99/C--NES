using CSharp_NES.Hardware.BUS;

namespace CSharp_NES.Hardware.CPU
{
    internal class olc6502 : ICPU
    {
        private IBus BUS;

        private Opcodes OpcodesFN;
        private AddressingModes AModes;

        private Registers RG = new Registers();
        private InternalVar IV = new InternalVar();

        public List<Instruction> Lookup { get; private set; }

        private const ushort stackPDef = 0x0100;    // the stack pointer starts at index 0x0100 (it is hardcoded in the CPU)

        public olc6502()
        {
            OpcodesFN = new Opcodes(this, RG, IV, stackPDef);
            AModes = new AddressingModes(this, RG, IV);

            Lookup = LookupInstructions(OpcodesFN, AModes);
        }

        /// <summary>
        /// Sets up the Instructions list
        /// </summary>
        /// <param name="ops"> The opcodes class </param>
        /// <param name="ads"> the addressing modes class </param>
        /// <returns></returns>
        private List<Instruction> LookupInstructions(Opcodes ops, AddressingModes ads)
        {
            return new List<Instruction>
            {
                new Instruction("BRK", ops.BRK, ads.IMM, 7),
                new Instruction("ORA", ops.ORA, ads.IZX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 3),
                new Instruction("ORA", ops.ORA, ads.ZP0, 3),
                new Instruction("ASL", ops.ASL, ads.ZP0, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("PHP", ops.PHP, ads.IMP, 3),
                new Instruction("ORA", ops.ORA, ads.IMM, 2),
                new Instruction("ASL", ops.ASL, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("ORA", ops.ORA, ads.ABS, 4),
                new Instruction("ASL", ops.ASL, ads.ABS, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("BPL", ops.BPL, ads.REL, 2),
                new Instruction("ORA", ops.ORA, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("ORA", ops.ORA, ads.ZPX, 4),
                new Instruction("ASL", ops.ASL, ads.ZPX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("CLC", ops.CLC, ads.IMP, 2),
                new Instruction("ORA", ops.ORA, ads.ABY, 4),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("ORA", ops.ORA, ads.ABX, 4),
                new Instruction("ASL", ops.ASL, ads.ABX, 7),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("JSR", ops.JSR, ads.ABS, 6),
                new Instruction("AND", ops.AND, ads.IZX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("BIT", ops.BIT, ads.ZP0, 3),
                new Instruction("AND", ops.AND, ads.ZP0, 3),
                new Instruction("ROL", ops.ROL, ads.ZP0, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("PLP", ops.PLP, ads.IMP, 4),
                new Instruction("AND", ops.AND, ads.IMM, 2),
                new Instruction("ROL", ops.ROL, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("BIT", ops.BIT, ads.ABS, 4),
                new Instruction("AND", ops.AND, ads.ABS, 4),
                new Instruction("ROL", ops.ROL, ads.ABS, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("BMI", ops.BMI, ads.REL, 2),
                new Instruction("AND", ops.AND, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("AND", ops.AND, ads.ZPX, 4),
                new Instruction("ROL", ops.ROL, ads.ZPX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("SEC", ops.SEC, ads.IMP, 2),
                new Instruction("AND", ops.AND, ads.ABY, 4),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("AND", ops.AND, ads.ABX, 4),
                new Instruction("ROL", ops.ROL, ads.ABX, 7),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("RTI", ops.RTI, ads.IMP, 6),
                new Instruction("EOR", ops.EOR, ads.IZX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 3),
                new Instruction("EOR", ops.EOR, ads.ZP0, 3),
                new Instruction("LSR", ops.LSR, ads.ZP0, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("PHA", ops.PHA, ads.IMP, 3),
                new Instruction("EOR", ops.EOR, ads.IMM, 2),
                new Instruction("LSR", ops.LSR, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("JMP", ops.JMP, ads.ABS, 3),
                new Instruction("EOR", ops.EOR, ads.ABS, 4),
                new Instruction("LSR", ops.LSR, ads.ABS, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("BVC", ops.BVC, ads.REL, 2),
                new Instruction("EOR", ops.EOR, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("EOR", ops.EOR, ads.ZPX, 4),
                new Instruction("LSR", ops.LSR, ads.ZPX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("CLI", ops.CLI, ads.IMP, 2),
                new Instruction("EOR", ops.EOR, ads.ABY, 4),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("EOR", ops.EOR, ads.ABX, 4),
                new Instruction("LSR", ops.LSR, ads.ABX, 7),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("RTS", ops.RTS, ads.IMP, 6),
                new Instruction("ADC", ops.ADC, ads.IZX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 3),
                new Instruction("ADC", ops.ADC, ads.ZP0, 3),
                new Instruction("ROR", ops.ROR, ads.ZP0, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("PLA", ops.PLA, ads.IMP, 4),
                new Instruction("ADC", ops.ADC, ads.IMM, 2),
                new Instruction("ROR", ops.ROR, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("JMP", ops.JMP, ads.IND, 5),
                new Instruction("ADC", ops.ADC, ads.ABS, 4),
                new Instruction("ROR", ops.ROR, ads.ABS, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("BVS", ops.BVS, ads.REL, 2),
                new Instruction("ADC", ops.ADC, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("ADC", ops.ADC, ads.ZPX, 4),
                new Instruction("ROR", ops.ROR, ads.ZPX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("SEI", ops.SEI, ads.IMP, 2),
                new Instruction("ADC", ops.ADC, ads.ABY, 4),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("ADC", ops.ADC, ads.ABX, 4),
                new Instruction("ROR", ops.ROR, ads.ABX, 7),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("STA", ops.STA, ads.IZX, 6),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("STY", ops.STY, ads.ZP0, 3),
                new Instruction("STA", ops.STA, ads.ZP0, 3),
                new Instruction("STX", ops.STX, ads.ZP0, 3),
                new Instruction("???", ops.XXX, ads.IMP, 3),
                new Instruction("DEY", ops.DEY, ads.IMP, 2),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("TXA", ops.TXA, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("STY", ops.STY, ads.ABS, 4),
                new Instruction("STA", ops.STA, ads.ABS, 4),
                new Instruction("STX", ops.STX, ads.ABS, 4),
                new Instruction("???", ops.XXX, ads.IMP, 4),
                new Instruction("BCC", ops.BCC, ads.REL, 2),
                new Instruction("STA", ops.STA, ads.IZY, 6),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("STY", ops.STY, ads.ZPX, 4),
                new Instruction("STA", ops.STA, ads.ZPX, 4),
                new Instruction("STX", ops.STX, ads.ZPY, 4),
                new Instruction("???", ops.XXX, ads.IMP, 4),
                new Instruction("TYA", ops.TYA, ads.IMP, 2),
                new Instruction("STA", ops.STA, ads.ABY, 5),
                new Instruction("TXS", ops.TXS, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("???", ops.NOP, ads.IMP, 5),
                new Instruction("STA", ops.STA, ads.ABX, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("LDY", ops.LDY, ads.IMM, 2),
                new Instruction("LDA", ops.LDA, ads.IZX, 6),
                new Instruction("LDX", ops.LDX, ads.IMM, 2),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("LDY", ops.LDY, ads.ZP0, 3),
                new Instruction("LDA", ops.LDA, ads.ZP0, 3),
                new Instruction("LDX", ops.LDX, ads.ZP0, 3),
                new Instruction("???", ops.XXX, ads.IMP, 3),
                new Instruction("TAY", ops.TAY, ads.IMP, 2),
                new Instruction("LDA", ops.LDA, ads.IMM, 2),
                new Instruction("TAX", ops.TAX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("LDY", ops.LDY, ads.ABS, 4),
                new Instruction("LDA", ops.LDA, ads.ABS, 4),
                new Instruction("LDX", ops.LDX, ads.ABS, 4),
                new Instruction("???", ops.XXX, ads.IMP, 4),
                new Instruction("BCS", ops.BCS, ads.REL, 2),
                new Instruction("LDA", ops.LDA, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("LDY", ops.LDY, ads.ZPX, 4),
                new Instruction("LDA", ops.LDA, ads.ZPX, 4),
                new Instruction("LDX", ops.LDX, ads.ZPY, 4),
                new Instruction("???", ops.XXX, ads.IMP, 4),
                new Instruction("CLV", ops.CLV, ads.IMP, 2),
                new Instruction("LDA", ops.LDA, ads.ABY, 4),
                new Instruction("TSX", ops.TSX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 4),
                new Instruction("LDY", ops.LDY, ads.ABX, 4),
                new Instruction("LDA", ops.LDA, ads.ABX, 4),
                new Instruction("LDX", ops.LDX, ads.ABY, 4),
                new Instruction("???", ops.XXX, ads.IMP, 4),
                new Instruction("CPY", ops.CPY, ads.IMM, 2),
                new Instruction("CMP", ops.CMP, ads.IZX, 6),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("CPY", ops.CPY, ads.ZP0, 3),
                new Instruction("CMP", ops.CMP, ads.ZP0, 3),
                new Instruction("DEC", ops.DEC, ads.ZP0, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("INY", ops.INY, ads.IMP, 2),
                new Instruction("CMP", ops.CMP, ads.IMM, 2),
                new Instruction("DEX", ops.DEX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("CPY", ops.CPY, ads.ABS, 4),
                new Instruction("CMP", ops.CMP, ads.ABS, 4),
                new Instruction("DEC", ops.DEC, ads.ABS, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("BNE", ops.BNE, ads.REL, 2),
                new Instruction("CMP", ops.CMP, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("CMP", ops.CMP, ads.ZPX, 4),
                new Instruction("DEC", ops.DEC, ads.ZPX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("CLD", ops.CLD, ads.IMP, 2),
                new Instruction("CMP", ops.CMP, ads.ABY, 4),
                new Instruction("NOP", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("CMP", ops.CMP, ads.ABX, 4),
                new Instruction("DEC", ops.DEC, ads.ABX, 7),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("CPX", ops.CPX, ads.IMM, 2),
                new Instruction("SBC", ops.SBC, ads.IZX, 6),
                new Instruction("???", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("CPX", ops.CPX, ads.ZP0, 3),
                new Instruction("SBC", ops.SBC, ads.ZP0, 3),
                new Instruction("INC", ops.INC, ads.ZP0, 5),
                new Instruction("???", ops.XXX, ads.IMP, 5),
                new Instruction("INX", ops.INX, ads.IMP, 2),
                new Instruction("SBC", ops.SBC, ads.IMM, 2),
                new Instruction("NOP", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.SBC, ads.IMP, 2),
                new Instruction("CPX", ops.CPX, ads.ABS, 4),
                new Instruction("SBC", ops.SBC, ads.ABS, 4),
                new Instruction("INC", ops.INC, ads.ABS, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("BEQ", ops.BEQ, ads.REL, 2),
                new Instruction("SBC", ops.SBC, ads.IZY, 5),
                new Instruction("???", ops.XXX, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 8),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("SBC", ops.SBC, ads.ZPX, 4),
                new Instruction("INC", ops.INC, ads.ZPX, 6),
                new Instruction("???", ops.XXX, ads.IMP, 6),
                new Instruction("SED", ops.SED, ads.IMP, 2),
                new Instruction("SBC", ops.SBC, ads.ABY, 4),
                new Instruction("NOP", ops.NOP, ads.IMP, 2),
                new Instruction("???", ops.XXX, ads.IMP, 7),
                new Instruction("???", ops.NOP, ads.IMP, 4),
                new Instruction("SBC", ops.SBC, ads.ABX, 4),
                new Instruction("INC", ops.INC, ads.ABX, 7),
                new Instruction("???", ops.XXX, ads.IMP, 7),
            };
        }

        public void ConnectBus(IBus n)
        {
            BUS = n;
        }

        public void Write(ushort addr, byte data)
        {
            BUS.Write(addr, data);
        }

        public byte Read(ushort addr)
        {
            return BUS.Read(addr, false);
        }

        public byte GetFlag(FLAGS6502 flag)
        {
            return (byte)(((RG.Status & (byte)flag) > 0) ? 1 : 0);
        }

        public void SetFlag(FLAGS6502 flag, bool value)
        {
            if (value)
            {
                RG.Status |= (byte)flag;
            }
            else
            {
                RG.Status &= (byte)(~flag);
            }
        }

        public byte Fetch()
        {
            if (Lookup[IV.Opcode].Addressmode == AModes.IMP)
            {
                IV.Fetched = Read(IV.AddrAbs);
            }

            return IV.Fetched;
        }

        /// <summary>
        /// Configures the CPU to a known state
        /// </summary>
        public void Reset()
        {
            RG.A = 0x0000;
            RG.X = 0x0000;
            RG.Y = 0x0000;
            RG.STKP = 0x00FD;
            RG.Status = (byte)(0x0000 | FLAGS6502.U);

            IV.AddrAbs = 0xFFFC;
            UInt16 lo = Read((ushort)(IV.AddrAbs + 0));
            UInt16 hi = Read((ushort)(IV.AddrAbs + 1));

            RG.PC = (ushort)((hi << 8) | lo);

            IV.AddrRel = 0x0000;
            IV.AddrAbs = 0x0000;
            IV.Fetched = 0x0000;

            IV.Cycles = 8;
        }

        /// <summary>
        /// Internal requests (interrupt)
        /// </summary>
        public void IRQ()
        {
            if (GetFlag(FLAGS6502.I) != 0)
            {
                return;
            }

            Write((ushort)(stackPDef + RG.STKP), (byte)((RG.PC >> 8) & 0x00FF));
            RG.STKP--;
            Write((ushort)(stackPDef + RG.STKP), (byte)(RG.PC & 0x00FF));
            RG.STKP--;

            SetFlag(FLAGS6502.B, false);
            SetFlag(FLAGS6502.U, true);
            SetFlag(FLAGS6502.I, true);

            Write((ushort)(stackPDef + RG.STKP), RG.Status);
            RG.STKP--;

            IV.AddrAbs = 0xFFFE;
            UInt16 lo = Read((ushort)(IV.AddrAbs + 0));
            UInt16 hi = Read((ushort)(IV.AddrAbs + 1));

            RG.PC = (ushort)((hi << 8) | lo);

            IV.Cycles = 7;
        }

        /// <summary>
        /// Non mascable interrupt
        /// </summary>
        public void NMI()
        {
            Write((ushort)(stackPDef + RG.STKP), (byte)((RG.PC >> 8) & 0x00FF));
            RG.STKP--;
            Write((ushort)(stackPDef + RG.STKP), (byte)(RG.PC & 0x00FF));
            RG.STKP--;

            SetFlag(FLAGS6502.B, false);
            SetFlag(FLAGS6502.U, true);
            SetFlag(FLAGS6502.I, true);

            Write((ushort)(stackPDef + RG.STKP), RG.Status);
            RG.STKP--;

            IV.AddrAbs = 0xFFFA;
            UInt16 lo = Read((ushort)(IV.AddrAbs + 0));
            UInt16 hi = Read((ushort)(IV.AddrAbs + 1));

            RG.PC = (ushort)((hi << 8) | lo);

            IV.Cycles = 8;
        }

        public void Clock()
        {
            if (IV.Cycles == 0)
            {
                IV.Opcode = Read(RG.PC);
                RG.PC++;

                IV.Cycles = Lookup[0].Cycles;

                byte additionalCycle1 = Lookup[IV.Opcode].Addressmode();
                byte additionalCycle2 = Lookup[IV.Opcode].Operate();

                IV.Cycles += (byte)(additionalCycle1 & additionalCycle2);
            }

            IV.Cycles--;
        }
    }
}
