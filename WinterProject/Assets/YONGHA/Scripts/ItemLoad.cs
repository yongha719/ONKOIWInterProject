using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemLoad : MonoBehaviour
{
    [SerializeField] GameObject[] Items;
    [SerializeField] string[] Names;
    [SerializeField] GameObject[] ImageNums;
    [SerializeField] string[] Explans;

    [SerializeField] GameObject LoadItem;
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ExplainText;
    [SerializeField] GameObject LoadImage;

    public int check;

    void Start()
    {
        Names[0] = "빨강";
        Names[1] = "주황";
        Names[2] = "노랑";
        Names[3] = "연두";
        Names[4] = "초록";
        Names[5] = "민트";
        Names[6] = "파랑";
        Names[7] = "분홍";
        Names[8] = "보라";

        Explans[0] = "빨간색 입니다!";
        Explans[1] = "주황색 입니다!";
        Explans[2] = "노란색 입니다!";
        Explans[3] = "연두색 입니다!";
        Explans[4] = "초록색 입니다!";
        Explans[5] = "민트색 입니다!";
        Explans[6] = "파란색 입니다!";
        Explans[7] = "분홍색 입니다!";
        Explans[8] = "보라색 입니다!";
    }

    public void Click()
    {
        GameObject ClickBtnItem = EventSystem.current.currentSelectedGameObject;
        if (LoadItem != null && LoadImage != null)
        {
            LoadItem.SetActive(false);
            LoadImage.SetActive(false);
            ItemNameText.text = "";
            ExplainText.text = "";
        }
        LoadItem = Items[ClickBtnItem.GetComponent<ItemLoad>().check - 1];
        LoadImage = ImageNums[ClickBtnItem.GetComponent<ItemLoad>().check - 1];

        Items[ClickBtnItem.GetComponent<ItemLoad>().check - 1].SetActive(true);
        ImageNums[ClickBtnItem.GetComponent<ItemLoad>().check - 1].SetActive(true);
        ExplainText.text = Explans[ClickBtnItem.GetComponent<ItemLoad>().check - 1].ToString();
        ItemNameText.text = Names[ClickBtnItem.GetComponent<ItemLoad>().check - 1].ToString();
        
        //Destroy(EventSystem.current.currentSelectedGameObject);
    }
}
