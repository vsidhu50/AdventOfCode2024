namespace AdventOfCode2024;

public class Day9 {
    public static long PartOne() {
        var diskMap = Utilities.GetInputLines(9)[0];
        List<Id> blocks = new();

        for (int i = 0; i < diskMap.Length; i++) {
            if (i % 2 == 0) {
                var id = (i / 2).ToString();
                blocks.AddRange(Enumerable.Repeat(new Id(id), (int) char.GetNumericValue(diskMap[i])));
            } else if (diskMap[i] != '0') {
                blocks.AddRange(Enumerable.Repeat(new Id("."), (int) char.GetNumericValue(diskMap[i])));
            }
        }
        
        var lastIdIndex = blocks.Count - 1;
        for (int i = 0; i < blocks.Count; i++) {
            if (blocks[i].IdNo == ".") {
                while (blocks[lastIdIndex].IdNo == ".") {
                    lastIdIndex--;
                }
                if (lastIdIndex <= i) {
                    break;
                }
                blocks[i] = blocks[lastIdIndex];
                blocks[lastIdIndex] = new(".");
            }
        }

        long sum = 0;
        for (int i = 0; i < blocks.Count; i++) {
            if (blocks[i].IdNo == ".") {
                break;
            }
            sum += i * int.Parse(blocks[i].IdNo);
        }
        
        return sum;
    }

    public static long PartTwo()
    {
        var diskMap = Utilities.GetInputLines(9)[0];
        List<(Id id, int size)> blocks = new();

        for (int i = 0; i < diskMap.Length; i++)
        {
            if (i % 2 == 0)
            {
                var id = (i / 2).ToString();
                blocks.Add((new Id(id), (int)char.GetNumericValue(diskMap[i])));
            }
            else if (diskMap[i] != '0')
            {
                blocks.Add((new Id("."), (int)char.GetNumericValue(diskMap[i])));
            }
        }
        var firstDotIndex = 0;
        for (int i = blocks.Count - 1; i >= 0; i--)
        {
            if (blocks[i].id.IdNo != ".")
            {
                while (blocks[firstDotIndex].id.IdNo != ".")
                {
                    firstDotIndex++;
                }
                if (firstDotIndex > i)
                {
                    break;
                }
                var dotSize = blocks[firstDotIndex].size;
                var fileSize = blocks[i].size;
                if (dotSize == fileSize)
                {
                    blocks[firstDotIndex] = blocks[i];
                    blocks[i] = (new("."), dotSize);
                    if (i + 1 < blocks.Count && blocks[i + 1].id.IdNo == ".")
                    {
                        var newSize = blocks[i].size + blocks[i + 1].size;
                        blocks.RemoveAt(i + 1);
                        blocks[i] = (new("."), newSize);
                    }
                    if (i - 1 >= 0 && blocks[i - 1].id.IdNo == ".")
                    {
                        var newSize = blocks[i].size + blocks[i - 1].size;
                        blocks[i] = (new("."), newSize);
                        blocks.RemoveAt(i - 1);
                    }

                }
                else if (fileSize < dotSize)
                {
                    var newDot = (new Id("."), dotSize - fileSize);
                    blocks[firstDotIndex] = blocks[i];
                    blocks.RemoveAt(i);
                    blocks.Insert(firstDotIndex + 1, newDot);
                    blocks.Insert(i + 1, (new Id("."), fileSize));
                    i++;
                    if (i + 1 < blocks.Count && blocks[i + 1].id.IdNo == ".")
                    {
                        var newSize = blocks[i].size + blocks[i + 1].size;
                        blocks.RemoveAt(i + 1);
                        blocks[i] = (new("."), newSize);
                    }
                    if (i - 1 >= 0 && blocks[i - 1].id.IdNo == ".")
                    {
                        var newSize = blocks[i].size + blocks[i - 1].size;
                        blocks[i] = (new("."), newSize);
                        blocks.RemoveAt(i - 1);
                    }
                }
                else
                {
                    var nextDotIndex = -1;
                    for (int j = firstDotIndex; j < i; j++)
                    {
                        if (blocks[j].id.IdNo == "." && blocks[j].size >= fileSize)
                        {
                            nextDotIndex = j;
                            break;
                        }
                    }

                    if (nextDotIndex != -1)
                    {
                        dotSize = blocks[nextDotIndex].size;
                        if (dotSize == fileSize)
                        {
                            blocks[nextDotIndex] = blocks[i];
                            blocks[i] = (new("."), dotSize);
                            if (i + 1 < blocks.Count && blocks[i + 1].id.IdNo == ".")
                            {
                                var newSize = blocks[i].size + blocks[i + 1].size;
                                blocks.RemoveAt(i + 1);
                                blocks[i] = (new("."), newSize);
                            }
                            if (i - 1 >= 0 && blocks[i - 1].id.IdNo == ".")
                            {
                                var newSize = blocks[i].size + blocks[i - 1].size;
                                blocks[i] = (new("."), newSize);
                                blocks.RemoveAt(i - 1);
                            }
                        }
                        else if (fileSize < dotSize)
                        {
                            var newDot = (new Id("."), dotSize - fileSize);
                            blocks[nextDotIndex] = blocks[i];
                            blocks.RemoveAt(i);
                            blocks.Insert(nextDotIndex + 1, newDot);
                            blocks.Insert(i + 1, (new Id("."), fileSize));
                            i++;
                            if (i + 1 < blocks.Count && blocks[i + 1].id.IdNo == ".")
                            {
                                var newSize = blocks[i].size + blocks[i + 1].size;
                                blocks.RemoveAt(i + 1);
                                blocks[i] = (new("."), newSize);
                            }
                            if (i - 1 >= 0 && blocks[i - 1].id.IdNo == ".")
                            {
                                var newSize = blocks[i].size + blocks[i - 1].size;
                                blocks[i] = (new("."), newSize);
                                blocks.RemoveAt(i - 1);
                            }
                        }
                    }
                }
            }
        }

        long sum = 0;
        var expandedBlocks = new List<Id>();
        for (int i = 0; i < blocks.Count; i++)
        {
            expandedBlocks.AddRange(Enumerable.Repeat(blocks[i].id, blocks[i].size));
        }
        for (int i = 0; i < expandedBlocks.Count; i++)
        {
            if (expandedBlocks[i].IdNo != ".")
            {
                sum += i * int.Parse(expandedBlocks[i].IdNo);
            }
        }

        return sum;
    }

    public record Id(string IdNo);
}