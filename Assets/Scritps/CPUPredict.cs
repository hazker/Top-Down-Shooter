using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CPUPredict : MonoBehaviour
{
    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;

    public CPUController cpu;


    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward * 0.25f, this.transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);

        DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionCount);
    }

    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        


        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;

        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance) && hit.transform.tag != "VoidZone" && hit.transform.tag != "Bullet" && hit.transform.tag != "CPU")
        {
            if (hit.transform.tag == "Player")
            {
                cpu.trickshot = true;
                cpu.raycastStartSpot = transform;
                cpu.DoTrickShot();

            }
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;

        }
        else
        {
            position += direction * maxStepDistance;

        }
        cpu.trickshot = false;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startingPosition, position);



        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);

    }
}