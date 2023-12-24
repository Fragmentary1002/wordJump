using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RandomString
{
    private static char BaseChar = 'A';

    /// <summary>
    /// 根据单词内容随机生成字符串
    /// </summary>
    /// <param name="word">单词</param>
    /// <param name="length">生成字符串长度</param>
    /// <param name="minRepeat">单词各字母最小出现次数</param>
    /// <param name="maxRepeat">单词各字母最大出现次数</param>
    /// <returns></returns>
    public static string GetString(string word, int length, int minRepeat, int maxRepeat)
    {
        if (length < word.Length * minRepeat)
        {
            Debug.LogWarningFormat("length({0})无法满足最小次数minRepeat({1})", length, minRepeat);
        }
        if (length < word.Length * maxRepeat)
        {
            Debug.LogWarningFormat("length({0})无法满足最大次数maxRepeat({1})", length, maxRepeat);
        }

        int remain = length;
        Dictionary<char, int> count = new Dictionary<char, int>();
        List<char> charList = new List<char>();         // 记录当前生成过的所有字母
        List<char> otherCharList = new List<char>();    // 记录单词未包含的字母

        for (int i = 0; i < 26; i++)
        {
            otherCharList.Add((char)(BaseChar + i));
        }

        // 生成单词字母
        for (int i = 0; i < word.Length; i++)
        {
            if (!count.ContainsKey(word[i]))
            {
                count.Add(word[i], 0);
                charList.Add(word[i]);
                otherCharList.Remove(word[i]);
            }
            int t = Random.Range(minRepeat, maxRepeat + 1);
            count[word[i]] += t;
            remain -= t;

        }
        // 生成其他字母
        while (remain-- > 0)
        {
            char c = otherCharList[Random.Range(0, otherCharList.Count)];
            if (!count.ContainsKey(c))
            {
                charList.Add(c);
                count.Add(c, 0);
            }
            ++count[c];
        }

        // 构造字符串
        StringBuilder s = new StringBuilder();
        while (length-- > 0)
        {
            int index = Random.Range(0, charList.Count);
            char c = charList[index];
            s.Append(c);

            if (--count[c] == 0)
            {
                charList.RemoveAt(index);
            }
        }

        return s.ToString();
    }
}
