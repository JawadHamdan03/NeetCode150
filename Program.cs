
using System.Collections;

int[] nums = { 1, 2, 4, 3,3 };
Console.WriteLine(ContainsDuplicate(nums));
Console.WriteLine(ValidAnagram("cat","tac"));
printArray(TwoSum(nums,3));

void printArray<T>(T[]arr)
{
    foreach (var item in arr)
    {
        Console.Write($"{item} ");
    }
}


bool ContainsDuplicate(int[] nums)
{
    // track every element you have seen then check => O(n)
    HashSet<int> set = new HashSet<int>();

    for (global::System.Int32 i = 0; i < nums.Length; i++)
    {
        if (set.Contains(nums[i]))
        {
            return true;
        }
        set.Add(nums[i]);
    }

    return false;
}

bool ValidAnagram(string s, string t)
{
    // using an array to map the count of each character in the alphabet 
    if (s.Length != t.Length) return false;

    int[] charsCounter = new int[26];

    //increment the count for each char in s
    //decrement the count for each char in t
    for (int i = 0; i < s.Length; i++)
    {
        charsCounter[s[i] - 'a']++;
        charsCounter[t[i] - 'a']--;
    }

    //check if all count are zero
    foreach (int item in charsCounter)
    {
        if (item != 0) return false;
    }
    return true;
}


int[] TwoSum(int[]nums, int target)
{
    // using HashMap to store the numbers we have seen => O(n)

    Dictionary<int , int > map = new Dictionary<int, int>();

    for (global::System.Int32 i = 0; i < nums.Length; i++)
    {
        int temp = nums[i];
        if (map.ContainsKey(target - temp))
        {
            return new int[] { map[target - temp], i};
        }
        map.Add(nums[i],i);
    }

    return null;
}