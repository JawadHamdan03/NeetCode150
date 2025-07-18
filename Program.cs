﻿
using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

int[] nums = { 10, 1, 5, 6, 7, 1 };
Console.WriteLine(LengthOfLongestSubstring("au"
));

void printArray<T>(T[]arr)
{
    foreach (var item in arr)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine("");
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

List<List<string>> GroupAnagrams(string[] strs)
{
    // sort each string in strs and then map them to a HashMap

    Dictionary<string , List<string> > set = new Dictionary<string, List<string>>();

   foreach(string s in strs)
    {
        char[] charArr = s.ToCharArray();
        Array.Sort(charArr);
        string sortedString = new string(charArr);

        if (!set.ContainsKey(sortedString))
                set[sortedString] = new List<string>();

        set[sortedString].Add(s);
 
        
    }
    
    return set.Values.ToList<List<string>>();
}


int[] TopKFrequent(int[] nums , int k )
{
    Dictionary<int, int> map = new Dictionary<int, int>();
    int[] res = new int[k];
    for (global::System.Int32 i = 0; i < nums.Length; i++)
    {
        if (map.ContainsKey(nums[i]))
            map[nums[i]]++;
        else
            map.Add(nums[i], 1);
    }

    for (global::System.Int32 i = 0; i < k; i++)
    {
        int max = map.Values.Max();
        int index = map.Values.ToList().IndexOf(max);
        int target = map.Keys.ToList().ElementAt(index);
        res[i] = target;
        map.Remove(target);
    }
    
    return res;
}


int[] ProductOfArrayExceptItSelf(int []nums)
{ // O(n)
        
    int[] prefix = new int [nums.Length];
    int[] postfix = new int [nums.Length];
    int[] res = new int [nums.Length];

    prefix[0] = 1;
    postfix[postfix.Length-1] = 1;

    for (global::System.Int32 i = 1; i < nums.Length; i++)
        prefix[i] = nums[i-1]*prefix[i-1];

    for (global::System.Int32 i = postfix.Length-2; i >=0; i--)
        postfix[i]=nums[i+1]*postfix[i+1];

    for (global::System.Int32 i = 0; i < nums.Length; i++)
        res[i]=prefix[i]*postfix[i];

    return res;
}


static bool validSudoku(char[][]matrix)
{
    HashSet<char>[]rows = new HashSet<char> [9]; 
    HashSet<char>[]cols = new HashSet<char> [9]; 
    HashSet<char>[]boxes = new HashSet<char> [9];
    for (global::System.Int32 i = 0; i < 9; i++)
    {
        rows[i] = new HashSet<char>();
        cols[i]=new HashSet<char>();
        boxes[i]=new HashSet<char>();
    }

    for (global::System.Int32 i = 0; i < rows.Length; i++)
    {
        for (global::System.Int32 j = 0; j < cols.Length; j++)
        {
            if (matrix[i][j] == '.') continue;

            if (rows[i].Contains(matrix[i][j]))
                return false;

            rows[i].Add(matrix[i][j]);

            if (cols[j].Contains(matrix[i][j]))
                return false;

            cols[j].Add(matrix[i][j]);

            int idx = (i / 3) * 3 + (j / 3);
            if (boxes[idx].Contains(matrix[i][j]))
                return false;

            boxes[idx].Add(matrix[i][j]);
        }
    }


    return true;
}



static string Encode(IList<string> strs)
{
    string s="";
    foreach (var item in strs)
        s += item + '.';

    return s;
}
static List<string> Decode(string s)
{

    string tempS = "";
    List<string> res = new List<string>();
    foreach (char item in s)
    {
        if (item=='.')
        {
            res.Add(tempS);
            tempS = "";
        }
        else
            tempS += item;
    }
    return res;
}


static int LongestConsecutive(int[] nums)
{
    if (nums.Length == 0)
        return 0;
    if (nums.Length == 1)
        return 1;

    Array.Sort(nums);

    Dictionary<int, int> map = new Dictionary<int, int>();
    int seqNum = 1;
    
    for (global::System.Int32 i = 0; i < nums.Length; i++)
    {
        if (i == 0)
            map.Add(seqNum, 1);

        else if (nums[i] - 1 == nums[i - 1])
            map[seqNum]++;
        else if (nums[i] == nums[i - 1]) continue;

        else
        {
            seqNum++;
            map.Add(seqNum, 1);
        }
    }
    return map.Values.Max();
}


static bool ValidPalindrome(string str)
{
    str = str.ToLower();
    var cleaned = new List<char>();

    foreach (char c in str)
    {
        if (char.IsLetterOrDigit(c))
        {
            cleaned.Add(c);
        }
    }

    int i = 0;
    int j = cleaned.Count - 1;

    while (i < j)
    {
        if (cleaned[i] != cleaned[j])
            return false;

        i++;
        j--;
    }

    return true;
}


int[] TwoSumII(int[] nums , int target)
{
    int sum = 0;
    int left = 0;
    int right = nums.Length - 1;
    while (left<right)
    {
        sum = nums[left] + nums[right];
        

        if (sum>target)
            right--;
        
        else if(sum<target)
            left++;

        return new int[]{left, right};
    }

    return null;
}


List<List<int>> ThreeSum(int[] nums)
{
    Array.Sort(nums);
    List<List<int>> result = new List<List<int>>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] > 0) break;
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        int l = i + 1;
        int r = nums.Length-1;

        while (l<r)
        {
            int sum=nums[i]+nums[l] + nums[r];
            if (sum > 0) r--;
            else if (sum < 0) l++;
            else
            {
                result.Add(new List<int>(new int[]{ nums[i], nums[l], nums[r] }));
                l++;
                r--;

                while (l < r && nums[l] == nums[l - 1])
                    l++;
            }
        }
    }
    return result;
}

int ContainerWithMostWater(int[] height)
{
    int area=0;
    int max = 0;

    int left = 0;
    int right = height.Length - 1;

    int h;
    int w;
    while (left<right)
    {

        h = Math.Min(height[left], height[right]);
        w = right - left;

        area = h * w;
        max = Math.Max(max,area);

        if (height[right] >= height[left])
            left++;

        else 
            right--;
    }
    return max;
}


 int Trap(int[] height)
{
    int left = 0;
    int right = height.Length - 1;

    int total = 0;

    int leftMax = height[0];
    int rightMax = height[right];

    while (left < right)
    {
        if (height[left] < height[right])
        {
            leftMax = Math.Max(leftMax, height[left]);
            if (leftMax - height[left] > 0)
                total += leftMax - height[left];

            left++;
        }

        else
        {
            rightMax = Math.Max(rightMax, height[right]);
            if (rightMax - height[right] > 0)
                total += rightMax - height[right];

            right--;
        }
    }
    return total;
}



int MaxProfit(int[] prices)
{
    int minBuyValue = prices[0];
    int maxProfit = 0;
    for (global::System.Int32 i = 0; i < prices.Length; i++)
    {
        if (prices[i] < minBuyValue) minBuyValue=prices[i];

        if ((prices[i] - minBuyValue) > maxProfit) maxProfit = (prices[i] - minBuyValue);
        
    }

    return maxProfit;

}


int LengthOfLongestSubstring(string s)
{

    if (s == null | s.Length == 0) return 0;

    if (s.Length <= 1) return s.Length;
    int left = 0;
    int right = 0;
    int ans = 0;

    HashSet<char> set =new HashSet<char>();

    while (right<s.Length)
    {
        char c = s[right];
        while (set.Contains(c))
        {
            set.Remove(s[left]);
            left++;
        }
        set.Add(c);
        ans = Math.Max(ans,right-left+1);
        right++;
    }
    return ans;
} 
