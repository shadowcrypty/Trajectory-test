using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public static InputHandler instance;

    public GameObject emitter;
    private Vector3 currentPositon, deltaPositon, lastPositon;
    bool leftCliked = false;
    public bool action = false;


    private void OnEnable()
    {
        instance = this;
    }
    void Update()
    {
        leftClick();


    }

    void leftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("leftclickdown");
           
            leftCliked = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("leftclickup");
            leftCliked = false;
            emitter.SetActive(false);
            action = true;

        }
        //computing mouse delta position for emitter trajectory
        if (leftCliked)
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.name == "TouchArea")//touch are control
            {
                emitter.SetActive(true);
                Debug.Log("emitter working");
                currentPositon = Input.mousePosition;
                deltaPositon = currentPositon - lastPositon;
                lastPositon = currentPositon;
                emitter.transform.Rotate(0, deltaPositon.x, 0);
            }
            
        }
    }
}
