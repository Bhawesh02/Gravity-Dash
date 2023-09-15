using UnityEngine;

public class PlayerView : MonoBehaviour
{
   
    public Rigidbody2D PlayerRigidbody { get; private set; }

    public SpriteRenderer PlayerSpriteRenderer { get; private set; }

    public Animator PlayerAnimator { get; private set; }


    public PlayerScriptableObject PlayerScriptableObject;

    public PlayerController Controller { get; private set; }

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        Controller = new(this, PlayerScriptableObject);
    }
    private void Start()
    {
        
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            Controller.Model.LastPlatformPos.Add(GameManager.Instance.Platforms[i].transform.position);
        }
        EventService.Instance.PickupCollected += Controller.PickupColledted;
    }
    private void OnDestroy()
    {
        EventService.Instance.PickupCollected -= Controller.PickupColledted;

    }
    private void Update()
    {
        Controller.GravitySwitch();
        Controller.OnGroundCheck();
    }

    
}
