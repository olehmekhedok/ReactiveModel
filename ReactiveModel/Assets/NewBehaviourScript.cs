using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

[ExecuteInEditMode]
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject GO;
    public Camera Camera;

    public LineRenderer _lineRenderer;
    private bool _isDrugging;


    private void OnEnable()
    {

       // _lineRenderer.positionCount = 2;

    }

    private void Update()
    {

      //  if (Input.mousePresent)
        {
            _lineRenderer.SetPosition(0, transform.position);

            var pos = Camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;
            _lineRenderer.SetPosition(1, pos);



            ContactFilter2D f = new ContactFilter2D();

            f.SetLayerMask(1 << 8);


            var hits = new List<RaycastHit2D>();




            Physics2D.Raycast(_lineRenderer.GetPosition(0), (pos - _lineRenderer.GetPosition(0)).normalized, f, hits);

           var dsd = hits.FirstOrDefault();

            GO.transform.position = new Vector3(dsd.point.x,dsd.point.y, 0 );



            if (dsd.transform != null)
            {

                Debug.Log("AAAAAAA");

            }

            


        }
    }
}
