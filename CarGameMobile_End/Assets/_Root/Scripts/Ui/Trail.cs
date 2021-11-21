using Tool;
using UnityEngine;

public class Trail : MonoBehaviour
{
    #region ================================= PRIVATE FIELDS
    private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Trail");
    private GameObject objectView;
    private Vector3 fingerPosition;

    #endregion

    #region ============================== PRIVATE METHODS

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            //if (Input.GetTouch(i).phase == TouchPhase.Began)
            //{
            //    fingerPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            //    fingerPosition.z = 0;
            //    GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            //    prefab.transform.position = fingerPosition;
            //    objectView = Object.Instantiate(prefab);
            //}

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

                //trail.SetActive(true);
            }

            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Object.Destroy(objectView);

            }
        }
    }

    #endregion
}
