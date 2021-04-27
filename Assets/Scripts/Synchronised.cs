using UnityEngine;

public class Synchronised : MonoBehaviour
{


#region Private and Protect

private Renderer[] _renderer;
private AudioSource _audiosource;

[SerializeField]
private float _latency =1f;
private float _nextRefresh;

private int _nombreBox;

private float _delay= 2f;

private float _time;

#endregion

#region Unity API

private void Awake() {
    _renderer=GetComponentsInChildren<Renderer>();
   _audiosource = GetComponent<AudioSource>();
   _latency = Time.time;
}

private void Update() {
    if(Time.time>= _latency){
    _nextRefresh =  Time.time + _latency;
    int aRemplir = (int)(_audiosource.volume*10);

    for (int i = 0; i < _renderer.Length; i++)
    {
         
        if(i<= _nombreBox){
 
            _renderer[i].material = m_on;
           
        }else{
           _renderer[i].material = m_off;
        }
       
    }
     if((_time + _delay <Time.time)&&(_nombreBox>=0)){
            _nombreBox--;
        }
    }

    
   
}
 private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Particles")) {
      _nombreBox++;
    
    _time = Time.time;

     
}} 



#endregion

#region Public

public Material m_off;

public Material m_on;
#endregion


}
