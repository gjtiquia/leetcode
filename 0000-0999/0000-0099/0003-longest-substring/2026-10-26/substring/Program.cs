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
        var currentIndex = -1;
        char? lastChar = null;
        foreach (var currentChar in s)
        {
            // Console.WriteLine(currentChar);

            currentIndex++;

            if (!characterCountDict.ContainsKey(currentChar))
            {
                characterCountDict.Add(currentChar, currentIndex);
                length++;

                if (length > longestLength)
                    longestLength = length;

                // Console.WriteLine($"adding {currentChar}, len: {length}");
            }
            else
            {
                var duplicateCharIndex = characterCountDict[currentChar];

                if (currentChar == lastChar)
                {
                    characterCountDict.Clear();
                    length = 1;

                    // Console.WriteLine($"current char {currentChar} duplicate as last char {lastChar}, resetting length to {length}");
                }
                else
                {
                    length = currentIndex - duplicateCharIndex;

                    // Console.WriteLine($"duplicate {currentChar} found, resetting length to {currentIndex} - {duplicateCharIndex} = {length}");

                    foreach (var (charKey, indexValue) in characterCountDict)
                    {
                        if (indexValue < duplicateCharIndex)
                            characterCountDict.Remove(charKey);
                    }
                }

                characterCountDict[currentChar] = currentIndex;

            }

            // Console.WriteLine($"last char: {lastChar}");
            lastChar = currentChar;
        }

        return longestLength;
    }
}
