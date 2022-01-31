using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    public GameObject[] Item;
    public string[] Name;
    public GameObject[] ImageNum;
    public string[] Explain;

    public GameObject LoadItem;
    public Text text;
    public Text ExplainText;
    public GameObject LoadImage;

    public int Check;
    // Start is called before the first frame update
    void Start()
    {
        Name[0] = "빨강";
        Name[1] = "주황";
        Name[2] = "노랑";
        Name[3] = "연두";
        Name[4] = "초록";
        Name[5] = "민트";
        Name[6] = "파랑";
        Name[7] = "분홍";
        Name[8] = "보라";

        Explain[0] = "빨간색 입니다!";
        Explain[1] = "주황색 입니다!";
        Explain[2] = "노란색 입니다!";
        Explain[3] = "연두색 입니다!";
        Explain[4] = "초록색 입니다!";
        Explain[5] = "민트색 입니다!";
        Explain[6] = "파란색 입니다!";
        Explain[7] = "분홍색 입니다!";
        Explain[8] = "보라색 입니다!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        GameObject okok = EventSystem.current.currentSelectedGameObject;
        if (LoadItem != null && LoadImage != null)
        {
            LoadItem.SetActive(false);
            LoadImage.SetActive(false);
            text.text = "";
            ExplainText.text = "";
        }
        LoadItem = Item[okok.GetComponent<ItemLoad>().Check - 1];
        LoadImage = ImageNum[okok.GetComponent<ItemLoad>().Check - 1];

        Item[okok.GetComponent<ItemLoad>().Check - 1].SetActive(true);
        ImageNum[okok.GetComponent<ItemLoad>().Check - 1].SetActive(true);
        ExplainText.text = Explain[okok.GetComponent<ItemLoad>().Check - 1].ToString();
        text.text = Name[okok.GetComponent<ItemLoad>().Check - 1].ToString();
        
        //Destroy(EventSystem.current.currentSelectedGameObject);
    }
}
