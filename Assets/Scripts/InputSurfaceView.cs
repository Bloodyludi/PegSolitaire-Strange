using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class InputSurfaceView : View
{
    internal Signal<Vector2> clickSignal = new Signal<Vector2>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(clickRay, out hitInfo))
            {
                clickSignal.Dispatch(hitInfo.transform.position);
            }
        }
    }
}