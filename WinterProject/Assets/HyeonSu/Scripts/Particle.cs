using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    void Start()
    {
        particle.Play();
    }

    private void Update()
    {
        if (particle.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
