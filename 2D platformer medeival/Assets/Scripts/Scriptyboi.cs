using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptyboi : MonoBehaviour
{
    public GameObject Billy;
    public GameObject Bob;
    
    public enum objType{Billy, Bob}

    public objType dupes;

    public void spawn()
    {
        if (dupes == objType.Billy)
        {
            Instantiate(Billy, new Vector2(0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Bob, new Vector2(0, 0), Quaternion.identity);
        }
    }
}
