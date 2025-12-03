using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour
{
    private const string ANIMATOR_PARAM_FLASH = "IsFlashing";
    [SerializeField] private StoveCounter stoveCounter;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnStoveBurnWarningChanged;
        animator.SetBool(ANIMATOR_PARAM_FLASH, false);
    }

    private void StoveCounter_OnStoveBurnWarningChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
        animator.SetBool(ANIMATOR_PARAM_FLASH, show);
    }
}
