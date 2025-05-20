
int[] nums = { 1, 2, 4, 3 };
Console.WriteLine(ContainsDuplicate(nums));


bool ContainsDuplicate(int[] nums)
{
    // track every element you have seen then check 
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