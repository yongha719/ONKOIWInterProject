using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ItemLoad : MonoBehaviour
{
    public GameObject[] Item;
    public GameObject LoadItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        GameObject okok = EventSystem.current.currentSelectedGameObject;
        Item[okok.GetComponent<Test_Love>().cheak - 1].SetActive(true);
        if (LoadItem != null)
        {
            LoadItem.SetActive(false);
        }
        LoadItem = Item[okok.GetComponent<Test_Love>().cheak - 1];

        //Destroy(EventSystem.current.currentSelectedGameObject);
    }
}
