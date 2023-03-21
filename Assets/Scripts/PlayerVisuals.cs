using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] 
    private Animator playerAnimator;

    private int _runHash;
    private int _flyHash;
    private int _swimHash;
    private int _danceHash;
    
    void Start()
    {
        // Set the initial visuals for the player
        /*swimmingVisuals.SetActive(false);
        runningVisuals.SetActive(true);
        flyingVisuals.SetActive(false);*/
        _runHash = Animator.StringToHash("Run");
        _flyHash = Animator.StringToHash("Fly");
        _swimHash = Animator.StringToHash("Swim");
        _danceHash = Animator.StringToHash("Dance");
    }

    public void SetSwimmingVisuals()
    {
        /*swimmingVisuals.SetActive(true);
        runningVisuals.SetActive(false);
        flyingVisuals.SetActive(false);*/
        playerAnimator.SetBool(_runHash, false);
        playerAnimator.SetBool(_danceHash, false);
        playerAnimator.SetBool(_flyHash, false);
        playerAnimator.SetBool(_swimHash, true);
    }

    public void SetRunningVisuals()
    {
        /*swimmingVisuals.SetActive(false);
        runningVisuals.SetActive(true);
        flyingVisuals.SetActive(false);*/
        playerAnimator.SetBool(_swimHash, false);
        playerAnimator.SetBool(_danceHash, false);
        playerAnimator.SetBool(_flyHash, false);
        playerAnimator.SetBool(_runHash, true);
    }

    public void SetFlyingVisuals()
    {
        /*swimmingVisuals.SetActive(false);
        runningVisuals.SetActive(false);
        flyingVisuals.SetActive(true);*/
        playerAnimator.SetBool(_swimHash, false);
        playerAnimator.SetBool(_runHash, false);
        playerAnimator.SetBool(_danceHash, false);
        playerAnimator.SetBool(_flyHash, true);
    }

    public void SetDancingVisuals()
    {
        /*swimmingVisuals.SetActive(false);
        runningVisuals.SetActive(false);
        flyingVisuals.SetActive(true);*/
        playerAnimator.SetBool(_swimHash, false);
        playerAnimator.SetBool(_runHash, false);
        playerAnimator.SetBool(_flyHash, false);
        playerAnimator.SetBool(_danceHash, true);
    }

    public void SetIdleVisuals()
    {
        playerAnimator.SetBool(_swimHash, false);
        playerAnimator.SetBool(_runHash, false);
        playerAnimator.SetBool(_flyHash, false);
        playerAnimator.SetBool(_danceHash, false);
    }
}
