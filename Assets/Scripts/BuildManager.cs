using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    public GameObject turretModel;
    public GameObject missileLauncher;
    public GameObject particle;
    public Vector3 particleOffset;

    public bool canBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    //Deprecated, new method used
    //public GameObject getCurrentTurret()
    //{
    //    return turretToBuild;
    //}

    //This is new method lol
    public void buildObject(Cube cube)
    {
        if (Stats.cash < turretToBuild.cost)
        {
            return;
        }
        Stats.cash -= turretToBuild.cost;
        Debug.Log("Cash: " + Stats.cash);
        GameObject tempObject = (GameObject)Instantiate(turretToBuild.prefab, cube.transform.position + cube.offset, cube.transform.rotation);
        cube.objectToBuild = tempObject;
        Instantiate(particle.transform, cube.gameObject.transform.position + particleOffset, particle.transform.rotation);
    }
    
    //Singleton Pattern
    //Call only one Build Manager in scene to save memory
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null) return; else
            instance = this;
    }

    public void setTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

    }
    //Obsolete, just for testing
    //private void start()
    //{
    //    turrettobuild = turretmodel;
    //}
}
