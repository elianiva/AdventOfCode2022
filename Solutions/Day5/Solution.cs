using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions.Day5;

internal class Solution
{
    private record struct Command(int Count, int From, int Destination);

    private static List<Stack<string>> GetStacks(IEnumerable<string> lines)
    {
        return lines.TakeWhile(line => !string.IsNullOrWhiteSpace(line))
                    .SelectMany(line => line.Select((letter, index) => new { letter = letter.ToString(), index }))
                    .GroupBy(line => line.index, line => line.letter)
                    .Where(stack => stack.Any(s => !string.IsNullOrWhiteSpace(s) && s != "[" && s != "]"))
                    .Select(group => group.SkipLast(1)
                                          .Reverse()
                                          .Where(c => !string.IsNullOrWhiteSpace(c)))
                    .Select(group => new Stack<string>(group))
                    .ToList();
    }

    private static IEnumerable<Command> GetCommands(IEnumerable<string> lines)
    {
        return lines.SkipWhile(line => !string.IsNullOrWhiteSpace(line))
                    .Skip(1)
                    .Select(line => line.Split(" ")
                                        .Where((_, index) => index % 2 != 0)
                                        .Select(n => int.Parse(n))
                                        .ToList())
                    .Select(command => new Command(Count: command[0], From: command[1] - 1, Destination: command[2] - 1));
    }

    public static string FirstPart(Stream fileStream)
    {
        // can't use ToEnumerable here unfortunately :(
        IEnumerable<string> lines = fileStream.ToLines();
        List<Stack<string>> stacks = GetStacks(lines);
        IEnumerable<Command> commands = GetCommands(lines);

        foreach (Command command in commands)
        {
            for (int i = 0; i < command.Count; i++)
            {
                stacks[command.Destination].Push(stacks[command.From].Pop());
            }
        }

        return string.Join(string.Empty, stacks.Select(stack => stack.Peek()));
    }

    public static string SecondPart(Stream fileStream)
    {
        // can't use ToEnumerable here unfortunately :(
        IEnumerable<string> lines = fileStream.ToLines();
        List<Stack<string>> stacks = GetStacks(lines);
        IEnumerable<Command> commands = GetCommands(lines);

        foreach (Command command in commands)
        {
            Stack<string> poppedCrates = new();
            for (int i = 0; i < command.Count; i++)
            {
                poppedCrates.Push(stacks[command.From].Pop());
            }
            for (int i = 0; i < command.Count; i++)
            {
                stacks[command.Destination].Push(poppedCrates.Pop());
            }
        }

        return string.Join(string.Empty, stacks.Select(stack => stack.Peek()));
    }
}
