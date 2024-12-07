namespace AdventOfCode2024;

public class Day2
{
    public Day2()
    {
    }

    public static int PartOne() 
    {
        var lines = Utilities.GetInputLines(2);
        var count = 0;

        foreach (var line in lines) {
            var nums = Utilities.GetInts(line);
            
            if (IsSafe(nums))
                count++;
        }
        return count;
    }

    public static int PartTwo() 
    {
        var lines = Utilities.GetInputLines(2);
        var count = 0;

        foreach (var line in lines) {
            var nums = Utilities.GetInts(line);
            
            if (IsSafe(nums))
                count++;
            else 
            {
                for (int i = 0; i < nums.Count; i++) {
                    var numsCopy = new List<int>(nums);
                    numsCopy.RemoveAt(i);
                    if (IsSafe(numsCopy)) {
                        count++;
                        break;
                    }
                }
            }
        }
        return count;
    }

    public static bool IsSafe (List<int> nums) {
        var increasing = false;
        var decreasing = false;
            
        var firstDiff = nums[0] - nums[1];
        if (firstDiff >= 1 && firstDiff <= 3) 
        {
            decreasing = true;
        }
        else if (firstDiff <= -1 && firstDiff >= -3) 
        {
            increasing = true;
        }
        else 
        {
            return false;
        }

        for (int i = 1; i < nums.Count - 1; i++)
        {
            var diff = nums[i] - nums[i + 1];

            if (increasing && (diff > -1 || diff < -3))
            {
                return false;
            }

            if (decreasing && (diff < 1 || diff > 3))
            {
                return false;
            }
        }

        return true;
    }
}