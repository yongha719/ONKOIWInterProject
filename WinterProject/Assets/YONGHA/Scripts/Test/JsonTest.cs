using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test
{
    public int[] a = new int[] { 1, 2, 3 };
}

public class JsonTest : MonoBehaviour
{
    public Button[] ConTalk;
    public Test test = new Test();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            string json = JsonUtility.ToJson(test);

            print(Application.dataPath);

            File.WriteAllText(Application.dataPath + "/Resources/Test.json", json);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
           
        }
    }

}
