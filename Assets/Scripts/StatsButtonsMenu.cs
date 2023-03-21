using UnityEngine;

public class StatsButtonsMenu : MonoBehaviour
{
    [SerializeField] 
    private PlayerVisuals playerVisuals;
    [SerializeField] 
    private GameObject statsButtonsPanel;
    [SerializeField] 
    private FillButton runUpgradeButton;
    [SerializeField] 
    private FillButton flyUpgradeButton;
    [SerializeField] 
    private FillButton swimUpgradeButton;

    private void Start()
    {
        runUpgradeButton.ButtonFilled += Hide;
        flyUpgradeButton.ButtonFilled += Hide;
        swimUpgradeButton.ButtonFilled += Hide;
        runUpgradeButton.ButtonFilled += playerVisuals.SetDancingVisuals;
        flyUpgradeButton.ButtonFilled += playerVisuals.SetDancingVisuals;
        swimUpgradeButton.ButtonFilled += playerVisuals.SetDancingVisuals;
        runUpgradeButton.ButtonPressed += playerVisuals.SetRunningVisuals;
        flyUpgradeButton.ButtonPressed += playerVisuals.SetFlyingVisuals;
        swimUpgradeButton.ButtonPressed += playerVisuals.SetSwimmingVisuals;
        runUpgradeButton.ButtonReleased += playerVisuals.SetIdleVisuals;
        flyUpgradeButton.ButtonReleased += playerVisuals.SetIdleVisuals;
        swimUpgradeButton.ButtonReleased += playerVisuals.SetIdleVisuals;
    }

    private void Show()
    {
        statsButtonsPanel.SetActive(true);
    }

    private void Hide()
    {
        statsButtonsPanel.SetActive(false);
    }
}