using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var operations = (await File.ReadAllLinesAsync("data.txt"))
    .Select(line => new Instruction(line))
    .ToArray();

var accumulator = 0;
var line = 0;
var instructionsRun = new List<int>();

while (line >= 0 && line < operations.Length)
{
    if (instructionsRun.Contains(line))
    {
        break;
    }
    else
    {
        instructionsRun.Add(line);
    }

    var operation = operations[line];
    Console.WriteLine($"Instruction {line} | Value {accumulator} - Operation {operation}");
    switch (operation.Operation)
    {
        case Operation.ACC:
            {
                accumulator += operation.Attribute;
                line++;
                break;
            }
        case Operation.JMP:
            {
                line += operation.Attribute;
                break;
            }
        case Operation.NOP:
            {
                line++;
                break;
            }
    }
}

Console.WriteLine($"🧮 is {accumulator}");