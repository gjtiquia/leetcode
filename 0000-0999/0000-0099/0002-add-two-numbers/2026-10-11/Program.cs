Console.Write("l1 (comma delimited): ");
var l1Array = Console.ReadLine()
    .Trim()
    .Split(",")
    .Where(x => x.Length > 0)
    .ToList().ConvertAll(x => int.Parse(x))
    .ToArray();

Console.Write("l2 (comma delimited): ");
var l2Array = Console.ReadLine()
    .Trim()
    .Split(",")
    .Where(x => x.Length > 0)
    .ToList().ConvertAll(x => int.Parse(x))
    .ToArray();

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
        // 1,2,3 = 321
        // 4,8   = 84
        // 321 + 84 = 405 = 5,0,4

        // 9,9,9,9 = 9999
        // 1,0,0 = 1
        // 9999 + 1 = 10000 = 0,0,0,0,1

        int val1, val2, sum, carry = 0;
        ListNode outputNode = null;
        ListNode previousNode = null;
        while (true)
        {
            val1 = l1 != null ? l1.val : 0;
            val2 = l2 != null ? l2.val : 0;

            sum = val1 + val2 + carry;
            carry = sum >= 10 ? 1 : 0;

            var currentNode = new ListNode(sum % 10, null);

            if (outputNode == null)
                outputNode = currentNode;

            if (previousNode != null)
                previousNode.next = currentNode;

            previousNode = currentNode;

            l1 = l1 != null ? l1.next : null;
            l2 = l2 != null ? l2.next : null;

            if (l1 == null && l2 == null)
            {
                if (carry != 0)
                    previousNode.next = new ListNode(carry, null);

                break;
            }
        }

        return outputNode;
    }
}

