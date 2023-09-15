
using System.Collections;
using UnityEngine;

public class PlayerController 
{
    private PlayerView view;
    public PlayerModel Model { get; }
    public PlayerController(PlayerView playerView, PlayerScriptableObject playerScriptableObject)
    {
        view = playerView;
        Model = new(playerScriptableObject);
    }

    public void OnGroundCheck()
    {
        if (view.PlayerRigidbody.velocity.y != 0)
        {
            view.PlayerAnimator.SetBool("OnGround", false);
            Model.OnGround = false;
        }
        else
        {
            view.PlayerAnimator.SetBool("OnGround", true);
            Model.OnGround = true;
        }
    }

    public void GravitySwitch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            view.PlayerRigidbody.gravityScale *= -1;
            view.PlayerSpriteRenderer.flipY = !view.PlayerSpriteRenderer.flipY;
        }
    }
    public void PlayerDead()
    {
        if (Model.ExtraLife)
        {

            RespawnPlayer();
            view.ExtraLifeIcon.SetActive(false);
            return;
        }
        EventService.Instance.InvokePlayerDied();
        GameManager.Instance.SetMoveLeft(false);
    }

    public void RecordLastPos()
    {
        if (!Model.OnGround && Model.LastPlayerPos != Vector3.zero)
            return;
        Model.LastPlayerPos = view.gameObject.transform.position;
        Model.LastGravityScale = view.PlayerRigidbody.gravityScale;
        Model.LastFlipY = view.PlayerSpriteRenderer.flipY;

        Model.LastBackgroundPos = GameManager.Instance.BackgroundMove.gameObject.transform.position;
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            Model.LastPlatformPos[i] = GameManager.Instance.Platforms[i].transform.position;
        }
        foreach (var type in GameManager.Instance.Pickups)
        {
            type.Value.ForEach(gameObj => RecordPickupPosition(gameObj));
        }
        Model.LastGameEndPos = GameManager.Instance.GameEnd.transform.position;
    }


    private void RecordPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        if (Model.PickupsLastPos.ContainsKey(gameObj))
            Model.PickupsLastPos[gameObj] = gameObj.transform.position;
        else
            Model.PickupsLastPos.Add(gameObj, gameObj.transform.position);
    }

    private void RespawnPlayer()
    {


        GameManager.Instance.BackgroundMove.gameObject.transform.position = Model.LastBackgroundPos;
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            GameManager.Instance.Platforms[i].transform.position = Model    .LastPlatformPos[i];
        }
        foreach (var type in GameManager.Instance.Pickups)
        {
            type.Value.ForEach(gameObj => ReloadPickupPosition(gameObj));
        }
        view.PlayerRigidbody.gravityScale = Model.LastGravityScale;
        view.PlayerSpriteRenderer.flipY = Model.LastFlipY;
        view.PlayerRigidbody.velocity = new(0, 0);
        view.gameObject.transform.position = Model.LastPlayerPos;
        GameManager.Instance.GameEnd.transform.position = Model.LastGameEndPos;

        Model.ExtraLife = false;

    }
    private void ReloadPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        gameObj.transform.position = Model.PickupsLastPos[gameObj];
    }
    public void IncreaseMass()
    {
        view.PlayerRigidbody.mass *= Model.MassChange;
        view.StartCoroutine(ReduceMass());
    }

    IEnumerator ReduceMass()
    {
        yield return new WaitForSeconds(Model.IncreaseMassDuration);
        view.PlayerRigidbody.mass /= Model.MassChange;
    }
}
