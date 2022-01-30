using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Test_Love : MonoBehaviour
{
    public int cheak;
    int a;
    public GameObject[] Item;
    public string[] explan;
    private void Start()
    {

    }
    public void Click()
    {
        GameObject okok = EventSystem.current.currentSelectedGameObject;
        Item[okok.GetComponent<Test_Love>().cheak - 1].SetActive(true);
        //Destroy(EventSystem.current.currentSelectedGameObject);
    }
}
