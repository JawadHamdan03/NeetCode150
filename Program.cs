
int[] nums = { 1, 2, 4, 3,3 };
Console.WriteLine(ContainsDuplicate(nums));
Console.WriteLine(ValidAnagram("cat","tac"));
Console.WriteLine(TwoSum(nums,3));

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
    HashSet<int> set = new HashSet<int>();

    for (global::System.Int32 i = 0; i < nums.Length; i++)
    {
        if (set.Contains(target - nums[i]))
            return new int[] { nums[i], target - nums[i] };

        else
            set.Add(nums[i]);
        
    }

    return null;
}