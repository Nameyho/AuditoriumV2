using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    #region Private and Protect

    [SerializeField]
    private Texture2D _CursorMove;

    [SerializeField]
    private Texture2D _cursorResize;

    private Transform _transform;

    [SerializeField]
    private float _ModifCentre ;

    #endregion


    #region  Unity API

    private void Awake()
    {
        _transform = transform;

    }
    private void Update()
    {
        
        RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        Vector3 point3d = ray.point;
        point3d.z = _transform.position.z;
        if ((ray) && (ray.collider.tag == "Effector"))
        {

            if ( Vector3.Distance(point3d , _transform.position)<= _ModifCentre )
            {

                Cursor.SetCursor(_CursorMove, new Vector2(16,16), CursorMode.Auto);
            }else{
                  Cursor.SetCursor(_cursorResize, new Vector2 (16,16), CursorMode.Auto);
            }
        }
        
        

          

        


    }
    #endregion

}
