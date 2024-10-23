using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR;

/*
Plane의 Material을 변경하는 스크립트
*/
public class ChangePlaneMaterial : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public MeshRenderer prefabMeshRenderer;

    public Material grassMaterial;

    public Material groundMaterial;

    private void Start()
    {

    }


    public void OnChangeMaterial(bool isGrass)
    {

        if (isGrass)
        {
            prefabMeshRenderer.material = grassMaterial;

            foreach (var plane in planeManager.trackables)
            {
                plane.GetComponent<MeshRenderer>().material = grassMaterial;
            }
        }
        else
        {
            prefabMeshRenderer.material = groundMaterial;

            foreach (var plane in planeManager.trackables)
            {
                plane.GetComponent<MeshRenderer>().material = groundMaterial;
            }
        }

    }
}
