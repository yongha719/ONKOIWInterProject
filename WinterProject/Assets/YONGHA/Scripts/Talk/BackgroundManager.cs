using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance { get; private set; } = null;
    [SerializeField] Image backgroundImage;
    [SerializeField] List<Sprite> Backgrounds = new List<Sprite>();
    [SerializeField] GameObject Kangs;
    [SerializeField] GameObject Yangs;
    [SerializeField] GameObject Baeks;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            backgroundImage.sprite = Backgrounds[0];
    }
    public void CharChange(string Kang, string Yang, string Baek)
    {
        switch (Kang)
        {
            case "null":
                Kangs.SetActive(false);
                break;
            case "default":
                Kangs.SetActive(true);
                break;
        }
        switch (Yang)
        {
            case "null":
                Yangs.SetActive(false);
                break;
            case "default":
                Yangs.SetActive(true);
                break;
        }
        switch (Baek)
        {
            case "null":
                Baeks.SetActive(false);
                break;
            case "default":
                Baeks.SetActive(true);
                break;
        }
    }
    public void BackGroundChange(string Bgimage)
    {
        switch (Bgimage)
        {
            case "road":
                backgroundImage.sprite = Backgrounds[0];
                break;
            case "school":
                backgroundImage.sprite = Backgrounds[1];
                break;
            case "library":
                backgroundImage.sprite = Backgrounds[2];
                break;
            default:
                break;
        }
    }
}
