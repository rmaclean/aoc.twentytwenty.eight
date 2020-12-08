using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var operations = (await File.ReadAllLinesAsync("data.txt"))
    .Select(line => new Instruction(line))
    .ToArray();

var possibles = new List<int>();
var tried = new List<int>();
var firstRun = true;

while (true)
{
    if (ExecuteProgram())
    {
        Console.WriteLine($"🏆 took {tried.Count} attempts");
        return;
    } 
    else 
    {
        if (firstRun) 
        {
            firstRun = false;
        } 
        else
        {
            var lastTried = tried.Last();
            var lastTriedOp = operations[tried.Last()];
            Console.WriteLine($"🐬 Going to flip BACK {lastTriedOp} at {lastTried}");
            lastTriedOp.Flip();
        }
    }

    var availableToTry = possibles.Except(tried).First();
    tried.Add(availableToTry);
    var opToFlip = operations[availableToTry];
    Console.WriteLine();
    Console.WriteLine($"🐬 Going to flip {opToFlip} at {availableToTry}");
    opToFlip.Flip();
}

bool ExecuteProgram()
{
    Console.WriteLine();
    Console.WriteLine("⛳ start");
    var accumulator = 0;
    var line = 0;
    var instructionsRun = new List<int>();

    while (line < operations.Length)
    {
        if (instructionsRun.AddIfMissing(line))
        {
            return false;
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
                    possibles.AddIfMissing(line);
                    line += operation.Attribute;
                    break;
                }
            case Operation.NOP:
                {
                    possibles.AddIfMissing(line);
                    line++;
                    break;
                }
        }
    }

    Console.WriteLine($"🧮 is {accumulator}");
    return true;
}