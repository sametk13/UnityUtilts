using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace SKUtils.Feedbacks
{
    // Need DoTween asset
    public class PunchScaleFeedBack : MonoBehaviour
    {
        Tweener tweener;
        [SerializeField] float duration = 0.3f;
        [SerializeField] int vibrato = 10;
        [SerializeField] float elasticity = 10;
        [SerializeField] Vector3 punch = new Vector3(0.07f, 0.07f, 0.07f);

        public void PunchScale()
        {
            if (tweener != null)
            {
                tweener.Kill(true);
            }

            tweener = transform.DOPunchScale(punch, duration, vibrato, elasticity);
        }
    }
}
