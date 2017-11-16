using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip clipBgm;
    public AudioClip[] clipHit = new AudioClip[6];
    //private AudioClip[] clipBunt = new AudioClip[3];
    public AudioClip[] clipCrowdHit = new AudioClip[5];
    public AudioClip[] clipCrowdBoo = new AudioClip[2];
    public AudioClip[] clipThrow = new AudioClip[5];

    public AudioSource sndBgm;
    public AudioSource[] sndHit = new AudioSource[6];
    public AudioSource[] sndCrowdHit = new AudioSource[5];
    public AudioSource[] sndCrowdBoo = new AudioSource[2];
    public AudioSource[] sndThrow = new AudioSource[5];

    private void Start()
    {
        InitClip();
        InitSource();
    }

    private void Update()
    {
        if (!sndBgm.isPlaying)
            PlaySound(sndBgm);
    }

    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }

    private void InitClip()
    {
        clipBgm = Resources.Load<AudioClip>("AudioClips/sndCrowdHit");

        for (int i = 0; i < clipHit.Length; i++)
            clipHit[i] = Resources.Load<AudioClip>("AudioClips/sndHit" + (i + 1));

        for (int i = 0; i < clipCrowdHit.Length; i++)
            clipCrowdHit[i] = Resources.Load<AudioClip>("AudioClips/sndCrowdHit" + (i + 1));

        for (int i = 0; i < clipCrowdBoo.Length; i++)
            clipCrowdBoo[i] = Resources.Load<AudioClip>("AudioClips/sndCrowdBoo" + (i + 1));

        for (int i = 0; i < clipThrow.Length; i++)
            clipThrow[i] = Resources.Load<AudioClip>("AudioClips/sndThrow" + (i + 1));
    }

    private void InitSource()
    {
        sndBgm = gameObject.AddComponent<AudioSource>() as AudioSource;
        sndBgm.clip = clipBgm;
        sndBgm.loop = true;
        sndBgm.volume = 1f;

        PlaySound(sndBgm);

        for (int i = 0; i < clipHit.Length; i++)
        {
            sndHit[i] = gameObject.AddComponent<AudioSource>() as AudioSource;
            sndHit[i].clip = clipHit[i];
            sndHit[i].loop = false;
            sndHit[i].playOnAwake = false;
        }

        for (int i = 0; i < clipCrowdHit.Length; i++)
        {
            sndCrowdHit[i] = gameObject.AddComponent<AudioSource>() as AudioSource;
            sndCrowdHit[i].clip = clipCrowdHit[i];
            sndCrowdHit[i].loop = false;
            sndCrowdHit[i].playOnAwake = false;

            sndCrowdHit[i].volume = 0.7f;
        }

        for (int i = 0; i < clipCrowdBoo.Length; i++)
        {
            sndCrowdBoo[i] = gameObject.AddComponent<AudioSource>() as AudioSource;
            sndCrowdBoo[i].clip = clipCrowdBoo[i];
            sndCrowdBoo[i].loop = false;
            sndCrowdBoo[i].playOnAwake = false;

            sndCrowdBoo[i].volume = 0.7f;
        }

        for (int i = 0; i < clipThrow.Length; i++)
        {
            sndThrow[i] = gameObject.AddComponent<AudioSource>() as AudioSource;
            sndThrow[i].clip = clipThrow[i];
            sndThrow[i].loop = false;
            sndThrow[i].playOnAwake = false;
        }
    }
}
