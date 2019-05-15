using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bm;
    public TurretBlueprint turret;
    public TurretBlueprint missileLauncher;
    private void Start()
    {
        bm = BuildManager.instance;
    }
    public void buildTurret()
    {
        bm.setTurretToBuild(turret);
    }
    public void buildMissile()
    {
        bm.setTurretToBuild(missileLauncher);
    }
}
