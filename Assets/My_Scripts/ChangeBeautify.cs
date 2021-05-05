using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeautifyEffect;

public class ChangeBeautify : MonoBehaviour
{
    public Beautify _beautify;
    public BeautifyProfile _beautifyProfile;
    // Start is called before the first frame update
    void Start()
    {
        _beautify = GetComponent<Beautify>();
    }

    public void ChangeBeautifyProfile()
    {
        _beautify.profile = _beautifyProfile;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
