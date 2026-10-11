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

Console.WriteLine("output: " + new Solution().AddTwoNumbers(Solution.CreateNode(l1Array), Solution.CreateNode(l2Array)));

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
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
        // TODO : current methods are limited to int overflows so... we are gonna need to do our own arithmetic

        var sum = ValueOf(l1) + ValueOf(l2);

        var inverseArray = sum.ToString()
            .ToCharArray()
            .Reverse()
            .ToList().ConvertAll(x => int.Parse((x.ToString())))
            .ToArray();

        return CreateNode(inverseArray);
    }

    public static ulong ValueOf(ListNode l)
    {
        ulong sum = 0;

        var currentNode = l;
        var count = 0;
        while (true)
        {
            sum += (ulong)currentNode.val * (ulong)Math.Pow(10, count);
            Console.WriteLine(sum);

            if (currentNode.next == null)
                break;

            currentNode = currentNode.next;
            count++;
        }

        return sum;
    }

    public static ListNode CreateNode(int[] vals)
    {
        if (vals.Length == 1)
        {
            return new(vals[0]);
        }

        var node = new ListNode(vals.Last(), null);
        for (int i = vals.Length - 2; i >= 1; i--)
        {
            var currentNode = new ListNode(vals[i], node);
            node = currentNode;
        }

        return new(vals.First(), node);
    }
}

