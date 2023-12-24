using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class WordUI : MonoBehaviour
{
    public enum Color { red, green, blue, white }
    [SerializeField] TMP_Text text;
    public Color CompleteColor = Color.green;
    public Color TargetColor = Color.red;
    public Color UncompleteColor = Color.white;

    /// <summary>
    /// 设置UI显示的单词
    /// </summary>
    /// <param name="word">单词</param>
    /// <param name="index">目标字符的下标</param>
    public void SetWord(string word, int index)
    {
        text.text = _getColoredWord(word, index);
    }

    // 为内容添加颜色tag
    private string _addColorTag(string color, string content)
    {
        return $"<color={color}>{content}</color>";
    }

    // 获得上色后的单词
    private string _getColoredWord(string word, int index)
    {
        StringBuilder builder = new StringBuilder();
        if (index > 0)
            builder.Append(_addColorTag(CompleteColor.ToString(), word.Substring(0, index)));
        builder.Append(_addColorTag(TargetColor.ToString(), word[index].ToString()));
        if (word.Length > index + 1)
            builder.Append(_addColorTag(UncompleteColor.ToString(), word.Substring(index + 1, word.Length - index - 1)));

        return builder.ToString();
    }

}
