using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance { get; private set; } = null;
    [SerializeField] Image backgroundImage;
    [SerializeField] List<Image> Kangs = new List<Image>();
    [SerializeField] List<Image> Yangs = new List<Image>();
    [SerializeField] List<Image> Baeks = new List<Image>();
    [SerializeField] List<Sprite> Backgrounds = new List<Sprite>();

    ITalkLoad load;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            backgroundImage.sprite = Backgrounds[0];
    }
    public void BackGroundChange(string Bgimage)
    {
        switch (Bgimage)
        {
            case "road":
                backgroundImage.sprite = Backgrounds[0];
                break;
        }
    }
}
