using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource scream;
    public AudioSource footstep;
    public AudioSource bite;
    public AudioSource getHit;
    public AudioSource die;
    public AudioSource playerAxe;
    public AudioSource playerGetHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scream()
    {
        scream.Play();
    }

    public void Walk()
    {
        footstep.Play();
    }

    public void Bite()
    {
        bite.Play();
    }

    public void GetHit()
    {
        getHit.Play();
    }
    public void Die()
    {
        die.Play();
    }

    public void AxeSwing()
    {
        playerAxe.Play();
    }

    public void PlayerGetHit()
    {
        playerGetHit.Play();
    }
}
