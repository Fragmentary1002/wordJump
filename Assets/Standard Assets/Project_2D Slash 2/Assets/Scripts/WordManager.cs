using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance;
    public string Word { get { return _words[_wordIndex]; } }
    [SerializeField] private int _wordsNum;
    [SerializeField] private WordUI _wordUI;
    private string[] _words;
    private int _wordIndex = 0;
    private int _charIndex = 0;

    void Start()
    {
        Instance = this;
        _words = RandomWord.GetWords(_wordsNum);
        _noticeUI();
        EnemyManager.Instance.CreateEnemy();
    }

    public bool isTarget(char c, int slashId)
    {
        if (slashId == 2)
        {
            return Word.IndexOf(c) == -1;
        }
        else
        {
            return isTarget(c);
        }
    }
    /// <summary>
    /// 判断该字符是否为当前目标
    /// </summary>
    /// <param name="c">判定字符</param>
    /// <returns>是否符合目标字符</returns>
    public bool isTarget(char c)
    {
        return c == _words[_wordIndex][_charIndex];
    }

    /// <summary>
    /// 若传入字符符合目标则切换到下一个字符，并返回true
    /// <para>若不符合目标则不会切换，并返回false</para>
    /// <para>到达末尾字符时自动切换到下一个单词</para>
    /// </summary>
    /// <param name="c">判定字符</param>
    /// <returns>是否符合目标字符</returns>
    public bool NextChar(char c)
    {
        if (!isTarget(c))
            return false;

        if (++_charIndex >= _words[_wordIndex].Length)
        {
            _charIndex = 0;
            if (++_wordIndex >= _wordsNum)
            {
                _clearTheGame();
                return true;
            }
            EnemyManager.Instance.CreateEnemy();
        }
        _noticeUI();

        return true;
    }

    public void Reflesh()
    {
        char target = Word[_charIndex];
        while (EnemyManager.Instance.KillCount[target] > 0)
        {
            NextChar(target);
            EnemyManager.Instance.KillCount[target]--;
            target = Word[_charIndex];
        }
    }

    // 修改UI内容
    private void _noticeUI()
    {
        _wordUI.SetWord(_words[_wordIndex], _charIndex);
    }

    // 通关
    private void _clearTheGame()
    {
        EndUI.Instance.GameClear();
    }

}
