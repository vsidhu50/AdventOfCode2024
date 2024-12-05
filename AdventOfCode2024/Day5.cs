namespace AdventOfCode2024;

public class Day5 {
    public static int PartOne() {
        var sections = Utilities.GetInputParagraphs(5);
        var sectionOne = Utilities.GetLines(sections[0]);
        var sectionTwo = Utilities.GetLines(sections[1]);
        var sum = 0;

        var rules = new List<(int first, int second)>();
        foreach (var line in sectionOne) {
            var nums = line.Split('|');
            rules.Add((int.Parse(nums[0]), int.Parse(nums[1])));
        }

        var updates = new List<List<int>>();
        foreach (var line in sectionTwo) {
            updates.Add(Utilities.GetNums(line));
        }

        foreach (var update in updates) {
            var correct = true;
            for (int i = 0; i < update.Count; i++) {
                var firstRules = rules.Where(x => x.first == update[i]);
                var secondRules = rules.Where(x => x.second == update[i]);
                
                foreach (var (_, second) in firstRules) {
                    if (update.Contains(second)) {
                        if (i > update.IndexOf(second)) {
                            correct = false;
                            break;
                        }
                    }
                }

                if (!correct) {
                    break;
                }

                foreach (var (first, _) in secondRules) {
                    if (update.Contains(first)) {
                        if (i < update.IndexOf(first)) {
                            correct = false;
                            break;
                        }
                    }
                }

                if (!correct) {
                    break;
                }
            }

            if (correct) {
                sum += update[(update.Count - 1)/2];
            }
        }

        return sum;
    }

    public static int PartTwo() {
        var sections = Utilities.GetInputParagraphs(5);
        var sectionOne = Utilities.GetLines(sections[0]);
        var sectionTwo = Utilities.GetLines(sections[1]);
        var sum = 0;

        var rules = new List<(int first, int second)>();
        foreach (var line in sectionOne) {
            var nums = line.Split('|');
            rules.Add((int.Parse(nums[0]), int.Parse(nums[1])));
        }

        var updates = new List<List<int>>();
        foreach (var line in sectionTwo) {
            updates.Add(Utilities.GetNums(line));
        }

        foreach (var update in updates) {
            var corrected = false;

            for (int i = 0; i < update.Count; i++) {
                var secondRules = rules.Where(x => x.second == update[i]);

                foreach (var (first, _) in secondRules) {
                    if (update.Contains(first)) {
                        var j = update.IndexOf(first);
                        if (i < j) {
                            (update[j], update[i]) = (update[i], update[j]);
                            corrected = true;
                        }
                    }
                }
            }

            for (int i = update.Count - 1; i >= 0; i--) {
                var firstRules = rules.Where(x => x.first == update[i]);
                
                foreach (var (_, second) in firstRules) {
                    if (update.Contains(second)) {
                        var j = update.IndexOf(second);
                        if (i > j) {
                            (update[j], update[i]) = (update[i], update[j]);
                            corrected = true;
                        }
                    }
                }
                
            }

            if (corrected) {
                sum += update[(update.Count - 1)/2];
            }
        }

        return sum;
    }
}