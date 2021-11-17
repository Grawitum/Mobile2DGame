using Tool;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Trail");
    private GameObject objectView;
    private Vector3 fingerPosition;

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                fingerPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                fingerPosition.z = 0;
                if (objectView == null)
                {
                    GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
                    prefab.transform.position = fingerPosition;
                    objectView = Object.Instantiate(prefab);
                }
                objectView.transform.position = fingerPosition;
            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Object.Destroy(objectView);
            }
        }
    }
}
