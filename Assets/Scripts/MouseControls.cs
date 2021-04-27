using UnityEngine;


public class MouseControls : MonoBehaviour
{

    #region Unity API


    private void OnMouseDrag()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
             _transform.position = _point;
        }
    }

    private void OnMouseEnter()
    {

        //_transform.localScale = Vector3.one * _focusScale;
        _selectionName = this.name;



    }

    private void OnMouseExit()
    {
      //  _transform.localScale = Vector3.one;
        _selectionName = "";


    }

    private void OnGUI()
    {
        if (GUILayout.Button($"Current selection {_selectionName}")) { }
        Vector3 mousePos = new Vector3();
        Event _Currentevent = Event.current;
        mousePos.x = _Currentevent.mousePosition.x;
        mousePos.y = _camera.pixelHeight - _Currentevent.mousePosition.y;
        _point = _camera.ScreenToWorldPoint(new Vector3(mousePos.x - 5, mousePos.y + 5, mousePos.z + 5));
    
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
           RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay (Input.mousePosition));
              if((ray)&&(ray.collider.tag =="MainCamera")){
                _effector=ray.collider.GetComponent<Effector2D>();
                
              }
        }
        if(Input.GetMouseButtonUp(0)){
            _effector= null;
        }
          Ray mousePosition = myCamera.ScreenPointToRay(Input.mousePosition); 

    }


    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main;
        _circlecollider2d = GetComponent<CircleCollider2D>();

    }

    #endregion

    #region Private and Protected

    private Transform _transform;
    private string _selectionName;
    private Camera _camera;
    private Vector3 _point;

    private Effector2D _effector;

    [SerializeField]
    private float _focusScale = 1.1f;
    [SerializeField]
    private Camera myCamera;

    private CircleCollider2D _circlecollider2d;


    #endregion


}
