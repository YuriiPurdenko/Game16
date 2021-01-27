using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class OnCklick : MonoBehaviour, IPointerClickHandler
{
    public GameManager gm;
    public GameObject empty;
    public GameObject cube;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("onClick");

        if ((int)cube.transform.position.z == (int)empty.transform.position.z || (int)cube.transform.position.x == (int)empty.transform.position.x)
        {
            List<GameObject> objects = objects = getObjectsbetweenPoints(cube.transform.position);
            if (objects.Count <= 0)
            {
                SwapObjects(cube);
            }
            gm.CompleteLevel();
        }
    }

    void SwapObjects(GameObject x)
    {
        Vector3 tempXPos;
        Vector3 tempEmptyPos;
        Vector3 temp = new Vector3(0, 0, 20);


        tempXPos = cube.transform.position;
        tempEmptyPos = empty.transform.position;
        empty.transform.position = temp;
        cube.transform.position = tempEmptyPos;
        empty.transform.position = tempXPos;

    }
    List<GameObject> getObjectsbetweenPoints(Vector3 x)
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        List<GameObject> betweenObjects = new List<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.tag == "object")
            {
                if (((int)go.transform.position.x == (int)empty.transform.position.x) && ((int)go.transform.position.x == (int)x.x))
                {
                    if (((int)go.transform.position.z > (int)empty.transform.position.z) && ((int)go.transform.position.z < (int)x.z))
                    {
                        betweenObjects.Add(go);
                    }
                    if (((int)go.transform.position.z < (int)empty.transform.position.z) && ((int)go.transform.position.z > (int)x.z))
                    {
                        betweenObjects.Add(go);
                    }
                }
                if (((int)go.transform.position.z == (int)empty.transform.position.z) && ((int)go.transform.position.z == (int)x.z))
                {
                    if ((go.transform.position.x > (int)empty.transform.position.x) && ((int)go.transform.position.x < (int)x.x))
                    {
                        betweenObjects.Add(go);
                    }
                    if (((int)go.transform.position.x < (int)empty.transform.position.x) && ((int)go.transform.position.x > (int)x.x))
                    {
                        betweenObjects.Add(go);
                    }
                }
            }
        }
        return betweenObjects;
    }


}

