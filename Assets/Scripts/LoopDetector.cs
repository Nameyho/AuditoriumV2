using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDetector : MonoBehaviour
{

#region Private and Protected


public AudioSource[] _AudioSources;

#endregion 
#region Unity API
private void Awake() {
    _AudioSources = GetComponentsInChildren<AudioSource>();

    
    
}

private void Start() {
    for (int i = 0; i < _AudioSources.Length; i++)
    {
        _AudioSources[i].Play();
    }
}

private void Update() {
    
for (int i = 0; i < _AudioSources.Length; i++)
{
    if(!_AudioSources[i].isPlaying){
        for (int j = 0; j < _AudioSources.Length; j++)
        {       
            _AudioSources[j].Stop();
            _AudioSources[j].Play();
        }
        
        
    }
}}


#endregion
}
