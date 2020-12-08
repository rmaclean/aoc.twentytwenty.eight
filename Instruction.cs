using System;
public record Instruction
{
    public Operation Operation { get; }
    public int Attribute { get; }

    public Instruction(string line)
    {
        switch (line.Substring(0, 3))
        {
            case "nop": {
                Operation = Operation.NOP;
                break;
            }
            case "acc": {
                Operation = Operation.ACC;
                break;
            }
            case "jmp": {
                Operation = Operation.JMP;
                break;
            }
        }

        Attribute = Convert.ToInt32(line.Substring(4));
    }
}

public enum Operation
{
    NOP,
    ACC,
    JMP,
}

