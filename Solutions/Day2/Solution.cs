using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022.Solutions.Day2;

internal class Solution
{
    private static Dictionary<string, int> SCORE_MAP = new Dictionary<string, int>()
    {
        { "X", 1 }, // Rock
        { "Y", 2 }, // Paper
        { "Z", 3 }, // Scissors
        { "WIN", 6 },
        { "LOSE", 0 },
        { "DRAW", 3 },
    };

    private static int getWinner(string opponent, string you)
    {
        bool win = (opponent == "A" && you == "Y") || (opponent == "B" && you == "Z") || (opponent == "C" && you == "X");
        bool draw = (opponent == "A" && you == "X") || (opponent == "B" && you == "Y") || (opponent == "C" && you == "Z");
        bool lose = (opponent == "A" && you == "Z") || (opponent == "B" && you == "X") || (opponent == "C" && you == "Y");

        if (win) return SCORE_MAP["WIN"];
        if (draw) return SCORE_MAP["DRAW"];
        if (lose) return SCORE_MAP["LOSE"];
        return 0;
    }

    private static int getScore(string opponent, string you)
    {
        if (opponent == "A")
        {
            return you switch
            {
                "X" => SCORE_MAP["LOSE"] + SCORE_MAP["Z"],
                "Y" => SCORE_MAP["DRAW"] + SCORE_MAP["X"],
                "Z" => SCORE_MAP["WIN"] + SCORE_MAP["Y"],
                _ => 0
            };
        }

        if (opponent == "B")
        {
            return you switch
            {
                "X" => SCORE_MAP["LOSE"] + SCORE_MAP["X"],
                "Y" => SCORE_MAP["DRAW"] + SCORE_MAP["Y"],
                "Z" => SCORE_MAP["WIN"] + SCORE_MAP["Z"],
                _ => 0
            };
        }

        if (opponent == "C")
        {
            return you switch
            {
                "X" => SCORE_MAP["LOSE"] + SCORE_MAP["Y"],
                "Y" => SCORE_MAP["DRAW"] + SCORE_MAP["Z"],
                "Z" => SCORE_MAP["WIN"] + SCORE_MAP["X"],
                _ => 0
            };
        }

        return 0;
    }

    public static int FirstPart(Stream fileStream)
    {
        using StreamReader streamReader = new(fileStream);

        int totalScore = 0;
        while (!streamReader.EndOfStream)
        {
            string? line = streamReader.ReadLine();
            if (line is null) continue;
            int score = line.Split(' ') switch
            {
                [string opponent, string you] => SCORE_MAP[you] + getWinner(opponent, you),
                _ => 0,
            };
            totalScore += score;
        }

        return totalScore;
    }

    public static int SecondPart(Stream fileStream)
    {
        using StreamReader streamReader = new(fileStream);

        int totalScore = 0;
        while (!streamReader.EndOfStream)
        {
            string? line = streamReader.ReadLine();
            if (line is null) continue;
            int score = line.Split(' ') switch
            {
                [string opponent, string you] => getScore(opponent, you),
                _ => 0,
            };
            totalScore += score;
        }

        return totalScore;
    }
}
