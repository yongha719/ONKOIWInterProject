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
}