using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keymoveUpText;
    [SerializeField] private TextMeshProUGUI keymoveDownText;
    [SerializeField] private TextMeshProUGUI keymoveLeftText;
    [SerializeField] private TextMeshProUGUI keymoveRightText;
    [SerializeField] private TextMeshProUGUI keyinteractText;
    [SerializeField] private TextMeshProUGUI keyinteractalternateText;
    [SerializeField] private TextMeshProUGUI keypauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadMove;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteracyAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keymoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keymoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keymoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keymoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        keyinteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        keyinteractalternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact_Alternate);
        keypauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        //keyGamepadMove.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Move);
        //keyGamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        //keyGamepadInteracyAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact_Alternate);
        //keyGamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
