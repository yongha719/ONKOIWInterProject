using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public GameObject[] Item;
    public string[] Explan;
    public GameObject LoadItem;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        Explan[0] = "ㅇㅇ 안녕하세요 수고링";
        Explan[1] = "2";
        Explan[2] = "3";
        Explan[3] = "4";
        Explan[4] = "5";
        Explan[5] = "6";
        Explan[6] = "7";
        Explan[7] = "8";
        Explan[8] = "9";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        GameObject okok = EventSystem.current.currentSelectedGameObject;
        Item[okok.GetComponent<Test_Love>().cheak - 1].SetActive(true);
        text.text = Explan[okok.GetComponent<Test_Love>().cheak - 1].ToString();
        
        //Destroy(EventSystem.current.currentSelectedGameObject);
    }
}
