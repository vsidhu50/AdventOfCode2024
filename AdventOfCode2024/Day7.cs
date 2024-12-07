namespace AdventOfCode2024;

public class Day7 {
    public static long PartOne() {
        long sum = 0;
        var lines = Utilities.GetInputLines(7);

        foreach (var line in lines) {
            var parts = line.Split(':');
            var testValue = long.Parse(parts[0]);
            var nums = Utilities.GetLongs(parts[1]);

            if (Passes(testValue, nums)) {
                sum += testValue;
            }
        }

        return sum;
    }

    public static bool Passes(long testValue, List<long> nums) {
        return PassesHelper(testValue, 0, nums[0], nums);
    }

    public static bool PassesHelper(long testValue, int currIndex, long total, List<long> nums) {
        if (currIndex == nums.Count - 1) {
            return testValue == total;
        } else {
            if (total > testValue)
                return false;
            return PassesHelper(testValue, currIndex + 1, total + nums[currIndex + 1], nums)
            || PassesHelper(testValue, currIndex + 1, total * nums[currIndex + 1], nums);
        }
    }

    public static long PartTwo() {
        long sum = 0;
        var lines = Utilities.GetInputLines(7);

        foreach (var line in lines) {
            var parts = line.Split(':');
            var testValue = long.Parse(parts[0]);
            var nums = Utilities.GetLongs(parts[1]);

            if (Passes2(testValue, nums)) {
                sum += testValue;
            }
        }

        return sum;
    }

    public static bool Passes2(long testValue, List<long> nums) {
        return PassesHelper2(testValue, 0, nums[0], nums);
    }

    public static bool PassesHelper2(long testValue, int currIndex, long total, List<long> nums) {
        if (currIndex == nums.Count - 1) {
            return testValue == total;
        } else {
            if (total > testValue)
                return false;
            return PassesHelper2(testValue, currIndex + 1, total + nums[currIndex + 1], nums)
            || PassesHelper2(testValue, currIndex + 1, total * nums[currIndex + 1], nums)
            || PassesHelper2(testValue, currIndex + 1, long.Parse(total.ToString() + nums[currIndex + 1].ToString()), nums);
        }
    }
}