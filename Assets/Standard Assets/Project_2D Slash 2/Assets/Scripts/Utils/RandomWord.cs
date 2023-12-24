using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWord
{
    /// <summary>
    /// 随机从单词表中选择n个单词
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static string[] GetWords(int n)
    {
        string[] words = new string[n];
        string[] allWords = LoadWords();
        for (int i = 0; i < n; i++)
        {
            words[i] = allWords[Random.Range(0, allWords.Length)].Split('\r')[0];
        }

        return words;
    }

    /// <summary>
    /// 从Resources文件夹读取单词表
    /// </summary>
    /// <returns></returns>
    static string[] LoadWords()
    {
        TextAsset text = Resources.Load<TextAsset>("words");
        return text.text.ToUpper().Split('\n');
    }
}
