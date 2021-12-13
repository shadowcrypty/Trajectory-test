using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDummy : Dummy
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform == transform)//touch dummy control
            {

                transform.Rotate(0,45,0);
                Debug.Log("touch detec");
            }
        }
        

    }
}
