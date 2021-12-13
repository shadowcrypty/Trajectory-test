using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ProjectileReflectionEmitterUnityNative : MonoBehaviour
{

    public static ProjectileReflectionEmitterUnityNative instance;

    public int maxReflectionCount = 5;// as a dummy count
    public float maxStepDistance = 200;// dummy*mindistance
    public List<Vector3> starts;//ray start vectors
    public List<Vector3> finishs;//ray finish vetors
    public LineRenderer lr;// ray visualating for player
    public int minstepdistance=8;//reflect distance

    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward * 0.25f, this.transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);

        DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionCount);//runing in editor time
    }
    private void OnEnable()
    {
        instance = GetComponent<ProjectileReflectionEmitterUnityNative>();//singleton
    }
    private void Start()
    {
    }
    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (starts.Count>maxReflectionCount)
        {
            // temp solution 
            starts.RemoveAt(0);
            finishs.RemoveAt(0);
            linecomputing();
        }
        if (reflectionsRemaining == 0)
        {
            return;//end of ray reflect
        }

        Vector3 startingPosition = position;
        starts.Add(startingPosition);
        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance) && hit.transform.tag=="Dummy")//just reflect in distance dummy
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            finishs.Add(position);
            maxStepDistance += minstepdistance;//increase ray distance if hit dummy

        }
        else if (Physics.Raycast(ray, out hit, maxStepDistance) && hit.transform.tag == "Goal")//Stoping the goal point
        {
            position = hit.point;
            finishs.Add(position);
        }
        else
        {
            position += direction * maxStepDistance;
            finishs.Add(position);
            maxStepDistance = minstepdistance;// reset ray distance for new computetion
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startingPosition, position);

        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
    }


    void linecomputing()//visualating reflection
    {
        for (int i = 0; i < maxReflectionCount; i++)
        {
            lr.SetPosition(i+1, finishs[i]);

        }
    }
}