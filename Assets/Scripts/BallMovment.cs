using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallMovment : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Vector3 _goalPos;
    [SerializeField] private float _speed;
    private float _current, _target;
    public static int _index=0;
    [SerializeField]private List<Vector3> _ballTrajectory;
    private float currentPositon, deltaPositon, lastPositon;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _goalPos = ProjectileReflectionEmitterUnityNative.instance.finishs[_index];
    }
    private void Update()
    {
        Shot();
        FailCheck();
    }
    public void FailCheck()
    {
        if (_ballTrajectory[_ballTrajectory.Count-1] == transform.position && GameManager.Goal == false)
        {
            //check gamemaneger
            Debug.Log("fail");
            GameManager.instance.onFailed();
        }
        if (transform.position==_ballTrajectory[_index] && _ballTrajectory[_index+1]!=null)
        {
            _index++;
        }
    }

    public void Shot()
    {

        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.name == "TouchArea")//touch are control
        {
            _ballTrajectory = ProjectileReflectionEmitterUnityNative.instance.finishs;
            _goalPos = _ballTrajectory[_index];
            if (Input.GetMouseButtonUp(0))
            {
                _target = _target == 0 ? 1 : 0;
            }
            _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);
            rb.MovePosition(Vector3.Lerp(transform.position, _goalPos, _current));
        }
    }


}
