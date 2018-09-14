using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterRotate : MonoBehaviour,IDragHandler,IPointerDownHandler
{
    public Transform charaterParent;

    private Vector2 referPos;
    private Vector2 newPos;
    private float deltaDistance;
    private float speed = 0.08f;

    private void OnEnable()
    {
        charaterParent.localEulerAngles = new Vector3(0f, 120f, 0f);    
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        newPos = eventData.position;
        deltaDistance = newPos.x - referPos.x; 
        charaterParent.localEulerAngles -= deltaDistance * speed * Vector3.up;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        referPos = eventData.position;        
    }
   
}
