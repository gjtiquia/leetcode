Console.Write("l1 (comma delimited): ");
var l1Array = Console.ReadLine()
    .Trim()
    .Split(",")
    .Where(x => x.Length > 0)
    .ToList().ConvertAll(x => int.Parse(x))
    .ToArray()
    ;

Console.Write("l2 (comma delimited): ");
var l2Array = Console.ReadLine()
    .Trim()
    .Split(",")
    .Where(x => x.Length > 0)
    .ToList().ConvertAll(x => int.Parse(x))
    .ToArray()
    ;

Console.WriteLine("output: " + new Solution().AddTwoNumbers(new(l1Array), new(l2Array)));

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode(int[] vals)
    {
        if (vals.Length == 1)
        {
            this.val = vals[0];
            this.next = null;
            return;
        }

        var node = new ListNode(vals.Last(), null);
        for (int i = vals.Length - 2; i >= 1; i--)
        {
            var currentNode = new ListNode(vals[i], node);
            node = currentNode;
        }

        this.val = vals.First();
        this.next = node;
    }

    public override string ToString()
    {
        if (next == null)
            return val.ToString();

        return val.ToString() + "," + next.ToString();
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return l1;
    }
}

