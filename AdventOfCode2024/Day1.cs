namespace AdventOfCode2024;

public class Day1
{
	public Day1()
	{
	}

	public static int PartOne()
	{
        var lines = Utilities.GetInputLines(1);
        var left = new List<int>();
        var right  = new List<int>();
        var sum = 0;

        foreach (var line in lines) {
            var nums = Utilities.GetNums(line);
            left.Add(nums[0]);
            right.Add(nums[1]);
        }

        left.Sort();
        right.Sort();

        for (int i = 0; i < left.Count; i++) {
            sum += Math.Abs(left[i] - right[i]);
        }

		return sum;
	}

	public static int PartTwo()
	{
		var lines = Utilities.GetInputLines(1);
        var left = new List<int>();
        var right  = new List<int>();
        var sum = 0;

        foreach (var line in lines) {
            var nums = Utilities.GetNums(line);
            left.Add(nums[0]);
            right.Add(nums[1]);
        }

        return left.Sum(x => x * right.Count(y => y == x));
	}
}