using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

//[System.Serializable]
//public class EventVector3 : UnityEvent<UnityEngine.Vector3> { };
public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;
    RaycastHit hitInfo;
    // public EventVector3 OnMouseClicked;
    public event Action<Vector3> OnMouseClicked;

    public Texture2D point, doorway, attack, target, arrow;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);

        }
        instance = this;
    }
     void Update()
    {
        SetCursorTexture();
        MouseControl();
    }
   void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hitInfo))
        {
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Groud":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
            }
        }
    }
    void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Groud"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);
            }
        }
    }
}
