using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private const int LeftClick = 0, RightClick = 1;

    public LayerMask layerMask;

    private GameObject ActivePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftClick))
        {
            var target = GetTarget();
            if (target != null && target.gameObject.layer != LayerMask.NameToLayer("Inactive"))
            {
                switch (target.tag)
                {
                    case "Player":
                        ActivePlayer = target.gameObject;
                        Debug.Log(ActivePlayer.name);
                        break;
                    case "Gate":
                        Debug.Log("Gate");
                        break;
                    case "Key":
                        Debug.Log("Key");
                        break;
                    default:
                        Debug.Log($"Unknown target: {target.name} ({target.tag})");
                        break;
                }
                Debug.Log(target?.name ?? "null");
            }
        }
    }

    private Collider GetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider;
        }
        return null;
    }
}
