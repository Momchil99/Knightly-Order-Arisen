using UnityEngine;

public class Utils : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        
        Ray ray = camera.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            position = raycastHit.point;
        }
        return camera.ScreenToWorldPoint(position);
    }

}