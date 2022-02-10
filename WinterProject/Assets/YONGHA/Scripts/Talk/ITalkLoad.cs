using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct TalkData
{
    public string Kang;
    public string Yang;
    public string Baek;
    public string background;
    public string name;
    public string talk;
}

[Serializable]
public struct TalkDatas
{
    public List<TalkData> talkDatas;
}

[Serializable]
public struct ChoiceData
{
    public string choice;
    public int like;
}

[Serializable]
public struct KangTalk
{
    public bool istalk;
    public int expression;
    public string name;
    public string talk;
}
[Serializable]
public struct YangTalk
{
    public bool istalk;
    public int expression;
    public string name;
    public string talk;
}
[Serializable]
public struct BaekTalk
{
    public bool istalk;
    public int expression;
    public string name;
    public string talk;
}
[Serializable]
public struct ChoiceDatas
{
    public List<ChoiceData> choiceDatas;
}

public interface ITalkLoad
{
    public List<TalkDatas> LoadTalk();
    public List<ChoiceDatas> LoadChoice();
    public List<KangTalk> LoadKang();
    public List<YangTalk> LoadYang();
    public List<BaekTalk> LoadBaek();
}
