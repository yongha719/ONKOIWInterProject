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
        Name[0] = "����";
        Name[1] = "��Ȳ";
        Name[2] = "���";
        Name[3] = "����";
        Name[4] = "�ʷ�";
        Name[5] = "��Ʈ";
        Name[6] = "�Ķ�";
        Name[7] = "��ȫ";
        Name[8] = "����";

        Explain[0] = "������ �Դϴ�!";
        Explain[1] = "��Ȳ�� �Դϴ�!";
        Explain[2] = "����� �Դϴ�!";
        Explain[3] = "���λ� �Դϴ�!";
        Explain[4] = "�ʷϻ� �Դϴ�!";
        Explain[5] = "��Ʈ�� �Դϴ�!";
        Explain[6] = "�Ķ��� �Դϴ�!";
        Explain[7] = "��ȫ�� �Դϴ�!";
        Explain[8] = "����� �Դϴ�!";
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
