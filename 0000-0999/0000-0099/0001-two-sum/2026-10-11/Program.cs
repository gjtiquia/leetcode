Console.Write("nums (space delimited): ");
var numsString = Console.ReadLine();
var numsArray = numsString
    .Trim()
    .Split(" ")
    .Where(x => x.Length > 0)
    .ToList().ConvertAll(x => int.Parse(x))
    .ToArray();

Console.Write("target: ");
var targetString = Console.ReadLine();
var target = int.Parse(targetString);

var solution = new Solution();
Console.WriteLine("output: " + string.Join(", ", solution.TwoSum(numsArray, target)));

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var sum = nums[i] + nums[j];
                if (sum == target)
                    return [i, j];
            }
        }
        return [];
    }
}
