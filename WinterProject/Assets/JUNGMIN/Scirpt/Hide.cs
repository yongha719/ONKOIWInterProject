using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public Transform hidePosition;
    public static List<GameObject> hide = new List<GameObject>();

    public int index;
    public GameObject Show;

    [SerializeField] GameObject Panel;
    [SerializeField] Text Hidetext;
    [SerializeField] string[] Showtext;

    BackGround backGround;
    // Start is called before the first frame update
    void Start()
    {
       foreach(Transform ht in hidePosition)
       {
            hide.Add(ht.gameObject);
       }

        Showtext[0] = "안경케이스";
        Showtext[1] = "작은노트";
        Showtext[2] = "필통";
        backGround = GameObject.Find("background").GetComponent<BackGround>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            backGround.isClickCoolTime = false;
            hide[index].SetActive(false);
            GameClearManager.Inst.FindHide++;
            Instantiate(Show, new Vector3(0, 1, 0), Quaternion.identity);
            Hidetext.text = Showtext[index].ToString();
            Panel.SetActive(true);
            Invoke("Delete", 1.14f);
            backGround.Invoke("CoolTime", 1.6f);
        }
    }

    void Delete()
    {
        Hidetext.text = "";
        Panel.SetActive(false);
    }
}
