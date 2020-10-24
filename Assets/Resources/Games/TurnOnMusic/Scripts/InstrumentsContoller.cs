using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsContoller : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        Disable();
    }

    public void Enable()
    {
        source.volume = 1;
    }
    public void Disable()
    {
        source.volume = 0;
    }
}
