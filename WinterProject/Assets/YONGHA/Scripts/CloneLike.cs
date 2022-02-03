using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloneLike : MonoBehaviour
{
    [SerializeField] private Slider LikeSlider;
    [SerializeField]GameObject a;
    private void Update()
    {
        LikeSlider.value = a.GetComponent<ItemLoad>().like / 100;
    }

}
