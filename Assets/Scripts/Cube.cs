using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor = Color.white;
    public GameObject objectToBuild;
    public GameObject tempObj;
    public Vector3 offset;

    private void OnMouseEnter()
    {
        if (BuildManager.instance.canBuild == false)
            return;
        GetComponent<Renderer>().material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = defaultColor;
    }

    private void OnMouseDown()
    {
        if (BuildManager.instance.canBuild == false)
            return;
        if (objectToBuild != null)
        {
            Debug.Log("Space occupied");
            return;
        }
        //Obsolete
        //objectToBuild = (GameObject)Instantiate(tempObj, transform.position + offset, transform.rotation);
        BuildManager.instance.buildObject(this);
    }
}
