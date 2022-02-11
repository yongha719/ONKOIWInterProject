using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonTest : MonoBehaviour
{
    public string Hii;
    public Button Choicebtn;
    public RectTransform rtrnChoiceParent;

    List<Button> Choicetexts = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.A))
        {
            Choicetexts.Add(Choicebtn);
            Text choicetext = Choicebtn.transform.Find("Text").gameObject.GetComponent<Text>();
            choicetext.text = Hii;
            var obj = Instantiate(Choicetexts[Random.Range(0, Choicetexts.Count)], rtrnChoiceParent);
        }
    }

}
