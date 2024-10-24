using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.XR.ARSubsystems;
/*
지면의 Trackable ID를 가지고 오기 위한 스크립트 
*/
public class RaycastInformation : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();     // 충돌 정보를 담을 리스트 

    public TextMeshProUGUI textUI;


    private void Update()
    {
        // 카메라의 스크린으로 0.5 0.5 지점 좌측하단 0, 우측 상단 1이기 때문에 정중앙을 뜻함 
        Vector2 screenCenterPos = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        // PlaneWithinPolygon: plane 까지만 인식을 하겠다는 type 
        if (aRRaycastManager.Raycast(screenCenterPos, hits, TrackableType.PlaneWithinPolygon))
        {
            // 충돌이 되어 리스트에 하나라도 담긴다면 ?
            if (hits.Count > 0)
            {
                // 해당 지면의 TrackableId를 텍스트로 변환 
                textUI.text = hits[0].trackableId.ToString();
            }
        }
    }
}
