using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            RaycastHit hit;
            var target = GetTarget(out hit);
            if (target != null && target.layer != LayerMask.NameToLayer("Inactive"))
            {
                Debug.Log(target.name);
                switch (target.tag)
                {
                    case "Player":
                        ActivePlayer = target;
                        //
                        break;
                    case "Gate":
                        Debug.Log(target.name);
                        //target.GetComponent<Animator>().get
                        target.transform.Rotate(0, 90, 0);
                        break;
                    case "Key":
                        Debug.Log("Key");
                        break;
                    default:
                        ActivePlayer = null;
                        break;
                }
            }
        }
        else if (Input.GetMouseButtonDown(RightClick))
        {
            RaycastHit hit;
            var target = GetTarget(out hit);
            if (target != null && target.layer == LayerMask.NameToLayer("Ground"))
            {
                ActivePlayer.GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
    }

    private GameObject GetTarget(out RaycastHit raycastHit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out raycastHit))
        {
            //return raycastHit.collider.gameObject.parent;
        }
        return null;
    }
}
