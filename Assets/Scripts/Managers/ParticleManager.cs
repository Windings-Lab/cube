using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ParticleManager
{
    static private GameObject parentObject;
    static ParticleManager()
    {
        particleList = Resources.LoadAll<ParticleSystem>("Particles").ToList();
        parentObject = new GameObject("ParticleGarbage");
    }

    static List<ParticleSystem> particleList;

    static void PlayParticle(ParticleSystem particle, Transform obj)
    {
        ParticleSystem newParticle = Object.Instantiate(particle, obj.position, Quaternion.identity, parentObject.transform);
        if (newParticle != null)
            newParticle.Play();
        else
            Debug.LogError("No given particle exists");
    }
    public static void PlayRandomParticle(Transform obj)
    {
        if (particleList.Count() != 0)
        {
            int rnd = Random.Range(0, particleList.Count());
            PlayParticle(particleList[rnd], obj);
        }
        else
        {
            Debug.LogWarning("Particle List is Empty");
        }
    }
}
