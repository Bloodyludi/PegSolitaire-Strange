using UnityEngine;
using strange.extensions.mediation.impl;
using System.Collections;
using Holoville.HOTween;

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

    public void MoveToPosition(Vector3 position)
    {
        HOTween.To(transform, 0.75f,  new TweenParms()
            .Prop("position", position)
            .Ease(EaseType.EaseInOutQuad));
    }

    public void Destroy()
    {
        HOTween.To(transform, 0.5f, new TweenParms()
            .Prop("position", new Vector3(transform.position.x, transform.position.y, -30))
            .Ease(EaseType.EaseInQuad)
            .OnComplete(() => 
                {
                    gameObject.SetActive(false);
                    transform.position = new Vector3(999, 999);
            }));
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