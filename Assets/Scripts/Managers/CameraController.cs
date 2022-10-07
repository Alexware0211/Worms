using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [Header("Transforms")]
    public Transform cam;
    private Vector3 _cameraOffset;
    public Transform currWorm;

    [Header("Floats")]
    public float camRotationSpeed = 5;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    private bool _lookAtPlayer = false;
    private bool _chanceCamera;
    private Vector3 previousPosition;
    private bool _rotateAroundPlayer = true;

    

    void Awake()
    {
        GameObject gm = GameObject.FindWithTag("GameManager");
        currWorm = gm.GetComponent<TurnManager>().activeWorm;
    }

    void Start()
    {
        _cameraOffset = transform.position - currWorm.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f )// Scrolling Forward
        {
            _cameraOffset.z--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f )// Scrolling Backwards
        {
            _cameraOffset.z++;
        }

        GameObject gm = GameObject.FindWithTag("GameManager");
        currWorm = gm.GetComponent<TurnManager>().activeWorm;
    }


    public void LateUpdate()
    {
        if (_rotateAroundPlayer)
        {
            Quaternion CamTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * camRotationSpeed, Vector3.up);
            _cameraOffset = CamTurnAngle * _cameraOffset;
        }

        
        Vector3 newPos = currWorm.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (_lookAtPlayer || _rotateAroundPlayer)
        {
            transform.LookAt(currWorm);
        }
        
    }


}
