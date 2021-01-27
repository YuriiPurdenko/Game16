using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    // Update is called once per frame
    public void CompleteLevel()
    {
        Debug.Log(checkPositions());
        if (checkPositions())
        {
            completeLevelUI.SetActive(true);
        }
    }


    bool checkPositions()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.tag == "object")
            {
                int column = Convert.ToInt32(go.name) % 4;
                Debug.Log("column " + go.name + "  -> " + column);
                Debug.Log("name " + go.name + " -> " + go.transform.position.x + " " + go.transform.position.y + " " + go.transform.position.z);
                   switch (column)
                {
                    case 1:
                        if ((int)go.transform.position.x != -6)
                        {
                            return false;
                        }
                        break;
                    case 2:
                        if ((int)go.transform.position.x != -2)
                        {
                            return false;
                        }
                        break;
                    case 3:
                        if ((int)go.transform.position.x != 1)
                        {
                            return false;
                        }
                        break;
                    case 0:
                        if ((int)go.transform.position.x != 6)
                        {
                            return false;
                        }
                        break;
                }

                int row = Convert.ToInt32(go.name);
                Debug.Log("row " + go.name + "  -> " + row);
                if (row <= 4)
                {
                    if((int)go.transform.position.z != 6){
                        return false;
                    }
                }
                else if (row <= 8)
                {
                    if ((int)go.transform.position.z != 2)
                    {
                        return false;
                    }
                }
                else if (row <= 12)
                {
                    if ((int)go.transform.position.z != -2)
                    {
                        return false;
                    }
                }
                else if (row <= 15)
                {
                    if ((int)go.transform.position.z != -6)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
