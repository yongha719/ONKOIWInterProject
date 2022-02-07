using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloneLike : MonoBehaviour
{
    public Slider ChaeAhLikeSlider;
    public Slider SeHwaLikeSlider;
    public Slider GaYoonLikeSlider;
    [SerializeField] GameObject canVas;
    
    private void Update()
    {
        ItemLoad itemLoad = canVas.GetComponent<ItemLoad>();
        ChaeAhLikeSlider.value = itemLoad.chaeAhlike;
        SeHwaLikeSlider.value = itemLoad.seHwalike;
        GaYoonLikeSlider.value = itemLoad.gaYoonlike;
    }
}
