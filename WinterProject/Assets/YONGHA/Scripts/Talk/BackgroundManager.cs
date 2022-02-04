using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public List<Image> Backgrounds = new List<Image>();

    ITalkLoad load;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void BackGroundChange()
    {
        load = new JsonLoader();
    }
}
