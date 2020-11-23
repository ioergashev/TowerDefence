using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingTowerConfigurator : MonoBehaviour
{
    private bool wasUsePhysics = false;
    public bool UsePhysics = false;

    //private void Start()
    //{
    //    if (UsePhysics)
    //    {
    //        gameObject.AddComponent<ParabolicAimCalculator>();
    //    }
    //    else
    //    {
    //        gameObject.AddComponent<LinearAimCalculator>();   
    //    }

    //    wasUsePhysics = UsePhysics;
    //}

    //public void Update()
    //{
    //    if (wasUsePhysics && !UsePhysics)
    //    {
    //        Destroy(GetComponent<ParabolicAimCalculator>());
    //        gameObject.AddComponent<LinearAimCalculator>(); 
    //    }
    //    else if (!wasUsePhysics && UsePhysics)
    //    {
    //        Destroy(GetComponent<LinearAimCalculator>());
    //        gameObject.AddComponent<ParabolicAimCalculator>();
    //    }

    //    wasUsePhysics = UsePhysics;      
    //}
}
