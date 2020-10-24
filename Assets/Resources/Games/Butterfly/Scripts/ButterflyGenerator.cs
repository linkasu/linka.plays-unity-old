using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyGenerator : MonoBehaviour
{
    Vector3 prevPos;
    public GameObject ButterflyPrefab;
    float chick;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
        chick = Time.time;

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - chick > 0.1f)
        {
            if (Vector3.Distance(transform.position, prevPos) > 0)
            {
                            if(!audio.isPlaying)                audio.Play();

                GameObject butterfly = GameObject.Instantiate(ButterflyPrefab);
                butterfly.transform.position = prevPos;
                butterfly.GetComponent<ButterflyController>().LookAt(transform.position);
            }

            else
            {
                audio.Stop();
            }

            prevPos = transform.position;
        
        chick = Time.time;
    }  }
   
}
