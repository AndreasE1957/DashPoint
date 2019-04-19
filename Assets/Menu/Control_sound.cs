using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_sound : MonoBehaviour
{
    public AudioSource asound;
    public Slider sd;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Con_sound()
    {
        asound.volume = sd.value;
    }
}
