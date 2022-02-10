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

public class JsonLoader : ITalkLoad
{
    public List<ChoiceDatas> LoadChoice()
    {
        var json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Choice.json"));
        return JsonUtility.FromJson<Serialization<ChoiceDatas>>(json).target;
    }

    public List<TalkDatas> LoadTalk()
    {
        TextAsset txt = Resources.Load<TextAsset>("Talk");

        return JsonUtility.FromJson<Serialization<TalkDatas>>(txt.text).target;
    }
    public List<KangTalk> LoadKang()
    {
        TextAsset txt = Resources.Load<TextAsset>("Kang");

        return JsonUtility.FromJson<Serialization<KangTalk>>(txt.text).target;
    }
    public List<YangTalk> LoadYang()
    {
        TextAsset txt = Resources.Load<TextAsset>("Yang");

        return JsonUtility.FromJson<Serialization<YangTalk>>(txt.text).target;
    }
    public List<BaekTalk> LoadBaek()
    {
        TextAsset txt = Resources.Load<TextAsset>("Baek");

        return JsonUtility.FromJson<Serialization<BaekTalk>>(txt.text).target;
    }
}