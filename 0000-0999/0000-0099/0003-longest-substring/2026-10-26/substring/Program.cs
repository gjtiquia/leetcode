Console.Write("input: ");
var input = Console.ReadLine()!;

Console.WriteLine(new Solution().LengthOfLongestSubstring(input));

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> characterCountDict = new();

        var length = 0;
        var longestLength = 0;
        foreach (var character in s)
        {
            // Console.WriteLine(character);

            if (!characterCountDict.ContainsKey(character))
            {
                // Console.WriteLine($"adding {character}");
                characterCountDict.Add(character, 1);
                length++;

                if (length > longestLength)
                    longestLength = length;
            }
            else
            {
                // Console.WriteLine("duplicate found");
                length = 0;
                characterCountDict.Clear();
            }
        }

        return longestLength;
    }
}
