using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Transform hidePosition;
    public static List<GameObject> hide = new List<GameObject>();

    public int index;
    public GameObject Show;
   
    // Start is called before the first frame update
    void Start()
    {
       foreach(Transform ht in hidePosition)
        {
            hide.Add(ht.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hide[index].SetActive(false);
            GameClearManager.Inst.FindHide++;
            Instantiate(Show, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
