using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip burp;
    public static AudioClip[] shots=new AudioClip[6];
    AudioSource audioSrc;
    public float volumen=10f;
    // Start is called before the first frame update
    void Start()
    {
        burp = Resources.Load<AudioClip>("Burpx");

        shots[0]= Resources.Load<AudioClip>("1");
        shots[1]= Resources.Load<AudioClip>("2");
        shots[2]= Resources.Load<AudioClip>("3");
        shots[3]= Resources.Load<AudioClip>("4");
        shots[4]= Resources.Load<AudioClip>("5");
        shots[5]= Resources.Load<AudioClip>("6");

        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume=volumen/100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound (string clip)
    {
        switch (clip)
        {
            case "burp":
                audioSrc.PlayOneShot(burp);
                break;
            case "shot":
                int rndNum = Random.Range(0, 5);
                audioSrc.PlayOneShot(shots[rndNum]);
                break;
        }
    }
}
