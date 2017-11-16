using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    float speed = 400f;
    Rigidbody rgd;

    SphereCollider col;

    int type = 0;
    int count = 0;

    bool swing = true;

    float skillSpeed = 0.04f;

    float posX, posY, posZ;

    SoundManager soundManager;

	// Use this for initialization
	void Start () {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        rgd = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        col.radius = 0.15f;

        rgd.AddForce(transform.up * 30f);
        rgd.AddForce(transform.forward * speed);

        type = Random.Range(1, 3);

        if (type == 2)
            Debug.Log("슬라이드");
        else
            Debug.Log("직구");

        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        soundManager.PlaySound(soundManager.sndThrow[Random.Range(0, soundManager.clipThrow.Length)]);

        //transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if(type == 2)
        {
            if(swing)
            {
                count++;
                if(count < 30)
                    transform.position = new Vector3(transform.position.x + skillSpeed, transform.position.y, transform.position.z);
                else
                {
                    swing = false;
                    count = 0;
                }
            }
            else
            {
                count++;
                if(count < 30)
                    transform.position = new Vector3(transform.position.x - skillSpeed, transform.position.y, transform.position.z);
                else
                {
                    swing = true;
                    count = 0;
                }
            }
        }
    }

    void Move()
    {
        //transform.Translate(Vector3.forward * speed);
        //rgd.AddForce()
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        bool isPlay = false;

        for (int i = 0; i < soundManager.sndCrowdHit.Length; i++)
            if (soundManager.sndCrowdHit[i].isPlaying)
                isPlay = true;

        if (type != -1)
        {
            if (collision.gameObject.name == "Bat")
            {
                soundManager.PlaySound(soundManager.sndHit[Random.Range(0, soundManager.sndHit.Length)]);

                //for (int i = 0; i < soundManager.sndCrowdHit.Length; i++)
                //    if (soundManager.sndCrowdHit[i].isPlaying)
                //        isPlay = true;

                if (!isPlay)
                    soundManager.PlaySound(soundManager.sndCrowdHit[Random.Range(0, soundManager.sndCrowdHit.Length)]);

                type = -1;
            }
        }

        if(type != -1)
        {
            for (int i = 0; i < soundManager.sndCrowdBoo.Length; i++)
                if (soundManager.sndCrowdBoo[i].isPlaying)
                    isPlay = true;

            if(!isPlay)
                if (collision.transform.parent.gameObject.name == "Stadium")
                    soundManager.PlaySound(soundManager.sndCrowdBoo[Random.Range(0, soundManager.sndCrowdBoo.Length)]);
        }

        col.radius = 0.05f;
        type = -1;
    }
}
