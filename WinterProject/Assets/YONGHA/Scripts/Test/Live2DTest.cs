using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Live2D.Cubism;
using Live2D;

public class Live2DTest : MonoBehaviour
{
    public Animator Animator;
    public int Max;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Animator.SetInteger("num", Charchoice.Instance.live);
    }

}
