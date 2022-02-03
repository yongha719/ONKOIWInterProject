using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct TalkData
{
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
public struct ChoiceDatas
{
    public List<ChoiceData> choiceDatas;
}

public interface ITalkLoad
{
    public List<TalkDatas> LoadTalk();
    public List<ChoiceDatas> LoadChoice();
}
