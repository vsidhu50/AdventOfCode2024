using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class Day3 {
    public static int PartOne() 
    {
        var lines = Utilities.GetInputLines(3);
        var sum = 0;

        foreach (var line in lines) {
            var regex = MulRegex();
            var matches = regex.Matches(line);

            for(int i = 0; i < matches.Count; i++)
            {
                var match = matches[i].Groups;
                var x = int.Parse(match[1].ToString());
                var y = int.Parse(match[2].ToString());
                sum += x * y;
            }
        }
        return sum;
    }

    public  static int PartTwo() 
    {
        var lines = Utilities.GetInputLines(3);
        var sum = 0;
        var doMult = true;

        foreach (var line in lines) {
            var instructionMatches = new List<InstructionMatch>();
            var mulRegex = MulRegex();
            var mulMatches = mulRegex.Matches(line);
            for(int i = 0; i < mulMatches.Count; i++)
            {
                instructionMatches.Add(new InstructionMatch(Instruction.Mul, mulMatches[i]));
            }

            var doRegex = DoRegex();
            var doMatches = doRegex.Matches(line);
            for(int i = 0; i < doMatches.Count; i++)
            {
                instructionMatches.Add(new InstructionMatch(Instruction.Do, doMatches[i]));
            }
            
            var dontRegex = DontRegex();
            var dontMatches = dontRegex.Matches(line);
            for(int i = 0; i < dontMatches.Count; i++)
            {
                instructionMatches.Add(new InstructionMatch(Instruction.Dont, dontMatches[i]));
            }

            instructionMatches = instructionMatches.OrderBy(x => x.Match.Index).ToList();

            foreach (var instructionMatch in instructionMatches) {
                switch (instructionMatch.Instruction) {
                    case Instruction.Do:
                        doMult = true;
                        break;
                    case Instruction.Dont:
                        doMult = false;
                        break;
                    default:
                        if (doMult) {
                            var match = instructionMatch.Match.Groups;
                            var x = int.Parse(match[1].ToString());
                            var y = int.Parse(match[2].ToString());
                            sum += x * y;
                        }
                        break;
                }
            }
        }

        return sum;
    }

    [GeneratedRegex("mul\\((\\d+),(\\d+)\\)")]
    private static partial Regex MulRegex();

    [GeneratedRegex("do\\(\\)")]
    private static partial Regex DoRegex();

    [GeneratedRegex("don't\\(\\)")]
    private static partial Regex DontRegex();

    public record InstructionMatch(Instruction Instruction, Match Match);

    public enum Instruction {
        Mul, Do, Dont
    }
}