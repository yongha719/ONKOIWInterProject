using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloneLike : MonoBehaviour
{
    [SerializeField] private Slider LikeSlider;

    public int Like;

    public void ClickGift()
    {
        Like += 5;
        LikeSlider.value = Like / 100;
    }
}
