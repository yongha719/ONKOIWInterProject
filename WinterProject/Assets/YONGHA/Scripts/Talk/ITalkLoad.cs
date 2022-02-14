using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct TalkData
{
    public int Kang;
    public int Yang;
    public int Baek;
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
    public int Kang;
    public int Yang;
    public int Baek;
    public string choice;
    public int like;
    public string reply;
}

[Serializable]
public struct ChoiceDatas
{
    public List<ChoiceData> choiceDatas;
}

[Serializable]
public struct TalkProgress
{
    public List<int> Talkprog;
}

[SerializeField]
public struct SaveData
{
    public bool IsSave;
    public List<int> Savedata;
    public string Date;
}
[SerializeField]
public struct SaveDatas
{
    public List<SaveData> savedatas;
}

public interface ITalkLoad
{
    public List<TalkDatas> LoadTalk();
    public List<ChoiceDatas> LoadChoice();
    public TalkProgress LoadTalkData();
    public List<SaveDatas> LoadSaveData();
}
public interface ITalkSave
{
    public void SaveTalk(TalkProgress talkProgress);

    public void SaveData(SaveDatas saveDatas);
}
