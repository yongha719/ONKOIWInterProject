using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

[Serializable]
public class Serialization<T>
{
    public Serialization(List<T> list) => target = list;

    public List<T> target;
}

public class JsonLoader : ITalkLoad, ITalkSave
{
    public List<ChoiceDatas> LoadChoice()
    {
        TextAsset txt = Resources.Load<TextAsset>("Choice");

        return JsonUtility.FromJson<Serialization<ChoiceDatas>>(txt.text).target;
        //var json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Choice.json"));
        //return JsonUtility.FromJson<Serialization<ChoiceDatas>>(json).target;
    }

    public List<TalkDatas> LoadTalk()
    {
        TextAsset txt = Resources.Load<TextAsset>("Story");

        return JsonUtility.FromJson<Serialization<TalkDatas>>(txt.text).target;
    }

    public List<KangEndings> LoadKangEnding()
    {
        TextAsset txt = Resources.Load<TextAsset>("KangEnding");

        return JsonUtility.FromJson<Serialization<KangEndings>>(txt.text).target;
    }

    public List<YangEndings> LoadYangEnding()
    {
        TextAsset txt = Resources.Load<TextAsset>("YangEnding");

        return JsonUtility.FromJson<Serialization<YangEndings>>(txt.text).target;
    }

    public List<BaekEndings> LoadBaekEnding()
    {
        TextAsset txt = Resources.Load<TextAsset>("BaekEnding");

        return JsonUtility.FromJson<Serialization<BaekEndings>>(txt.text).target;
    }

    public TalkProgress LoadTalkData()
    {
        TextAsset txt = Resources.Load<TextAsset>("Talk");

        return JsonUtility.FromJson<TalkProgress>(txt.text);
    }

    public SaveData LoadSaveData()
    {
        TextAsset txt = Resources.Load<TextAsset>("SaveData");

        return JsonUtility.FromJson<SaveData>(txt.text);
    }

    public SaveDatas LoadSaveDatas()
    {
        TextAsset txt = Resources.Load<TextAsset>("SaveDatas");

        return JsonUtility.FromJson<SaveDatas>(txt.text);
    }

    public void SaveTalk(TalkProgress talkProgress)
    {
        string json = JsonUtility.ToJson(talkProgress);

        File.WriteAllText(Application.dataPath + "/Resources/Talk.json", json);
    }

    public void SaveData(SaveData savedata)
    {
        string json = JsonUtility.ToJson(savedata);

        File.WriteAllText(Application.dataPath + "/Resources/SaveData.json", json);
    }

    public void SaveDatas(SaveDatas saveDatas)
    {
        string json = JsonUtility.ToJson(saveDatas);

        File.WriteAllText(Application.dataPath + "/Resources/SaveDatas.json", json);
    }

}