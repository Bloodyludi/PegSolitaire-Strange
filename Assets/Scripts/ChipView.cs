using UnityEngine;
using strange.extensions.mediation.impl;
using System.Collections;

public class ChipView : View
{
    [SerializeField] Renderer mesh;

    public void Highlight(bool enabled)
    {
        mesh.material.color = enabled ? Color.green : Color.white;
    }

    public void TriggerRestrictedAnimation()
    {
        StartCoroutine(RestrictedAnimation(0.6f, 0.2f));
    }

    IEnumerator RestrictedAnimation(float duration, float blinkTime)
    {
        while (duration > 0f)
        {
            duration -= blinkTime;

            //toggle renderer
            mesh.material.color = Color.red;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);

            duration -= blinkTime;

            mesh.material.color = Color.white;

            yield return new WaitForSeconds(blinkTime);
        }

        mesh.material.color = Color.white;
    }

}