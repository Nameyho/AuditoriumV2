using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesGeneratorController : MonoBehaviour
{
    #region Private 
    [SerializeField]
    private float _rhythm = 1f;
    private Transform _transform;
    [SerializeField]
    private GameObject _particlesPrefab;

    [SerializeField]
    private float _directionX = 1f;

    [SerializeField]
    private float _directionY = 1f;


    private float _nextSpawnTime;

    [SerializeField]
    private float _speed= 1;

    [SerializeField]
    private float _distanceArrêt = 100f;
    #endregion

    #region Unity API

    private void Start()
    {
        _transform = transform;
    }

    private void Awake()
    {
        _nextSpawnTime = Time.time;

    }

    private void Update()
    {


        if (Time.time >= _nextSpawnTime)
        {
            
            _nextSpawnTime = Time.time + _rhythm;
            GameObject newParticles = Instantiate
            (_particlesPrefab, (Random.insideUnitCircle * 0.5f) + new Vector2(_transform.position.x, _transform.position.y),
             _transform.rotation);
            Rigidbody2D rigidbody = newParticles.GetComponent<Rigidbody2D>();
            rigidbody.velocity= ((new Vector2(_directionX,_directionY)*_speed));
            float DistanceDestruction = _distanceArrêt/rigidbody.velocity.magnitude;
            Destroy(newParticles,DistanceDestruction);
   
        }


    }
    #endregion

}
