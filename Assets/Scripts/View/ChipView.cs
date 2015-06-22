using UnityEngine;
using strange.extensions.mediation.impl;
using System.Collections;
using Holoville.HOTween;
using System;

public class ChipView : View
{
    [SerializeField] Renderer mesh;

    public void Highlight(bool enabled)
    {
        mesh.material.color = enabled ? Color.green : Color.white;
    }

    public void TriggerRestrictedAnimation()
    {
        StartCoroutine(RestrictedAnimation(0.45f, 0.15f));
    }

    public void MoveToPosition(Vector3 position)
    {
        HOTween.To(transform, 0.75f,  new TweenParms()
            .Prop("position", position)
            .Ease(EaseType.EaseInOutQuad));
    }

    public void Destroy(Action onComplete)
    {
        HOTween.To(transform, 0.5f, new TweenParms()
            .Prop("position", new Vector3(transform.position.x, transform.position.y, -30))
            .Ease(EaseType.EaseInQuad)
            .OnComplete(() => onComplete()));
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