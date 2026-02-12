using System;
using UnityEngine;

public class PerkUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_strengthIcon;
    [SerializeField] private SpriteRenderer m_reviveIcon;
    [SerializeField] private SpriteRenderer m_staminaIcon;

    private void Start()
    {
        m_strengthIcon.enabled = false;
        m_reviveIcon.enabled = false;
        m_staminaIcon.enabled = false;
    }

    /// <summary>
    /// Displays the strength buff icon when perk is active.
    /// </summary>
    public void StrengthIcon()
    {
        m_strengthIcon.enabled = true;
    }

    /// <summary>
    /// Displays the revive buff icon when perk is active.
    /// </summary>
    public void ReviveIcon()
    {
        m_reviveIcon.enabled = true;
    }

    /// <summary>
    /// Displays the stamina buff icon when perk is active.
    /// </summary>
    public void StaminaIcon()
    {
        m_staminaIcon.enabled = true;
    }
}
