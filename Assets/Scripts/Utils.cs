using UnityEngine;

public class Utils : MonoBehaviour
{
    Vector3 pos = new Vector3(200, 200, 0);

    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        // i think should be using camera.ScreenPointToRay
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }

}