using UnityEngine;

public class Campfire : MonoBehaviour
{
    private bool isLit;
    public bool IsLit => isLit;

    public void LightFire() {
        isLit = true;

        foreach (ParticleSystem particles in GetComponentsInChildren<ParticleSystem>())
            particles.Play();

        GetComponent<AudioSource>().Play();    
    }
}
