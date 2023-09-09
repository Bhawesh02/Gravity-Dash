
using System.Collections;
using UnityEngine;

public class PlayerController 
{
    private PlayerView view;
    public PlayerController(PlayerView playerView)
    {
        view = playerView;
    }

    public void OnGroundCheck()
    {
        if (view.PlayerRigidbody.velocity.y != 0)
        {
            view.PlayerAnimator.SetBool("OnGround", false);
            view.OnGround = false;
        }
        else
        {
            view.PlayerAnimator.SetBool("OnGround", true);
            view.OnGround = true;
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
        if (view.ExtraLife)
        {

            RespawnPlayer();
            view.ExtraLifeIcon.SetActive(false);
            return;
        }
        GameManager.Instance.SetMoveLeft(false);
        view.playerDeadUI.SetActive(true);
    }

    public void RecordLastPos()
    {
        if (!view.OnGround && view.lastPlayerPos != Vector3.zero)
            return;
        view.lastPlayerPos = view.gameObject.transform.position;
        view.lastGravityScale = view.PlayerRigidbody.gravityScale;
        view.lastFlipY = view.PlayerSpriteRenderer.flipY;

        view.lastBackgroundPos = GameManager.Instance.BackgroundMove.gameObject.transform.position;
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            view.lastPlatformPos[i] = GameManager.Instance.Platforms[i].transform.position;
        }
        foreach (var type in GameManager.Instance.Pickups)
        {
            type.Value.ForEach(gameObj => RecordPickupPosition(gameObj));
        }
        view.lastGameEndPos = GameManager.Instance.GameEnd.transform.position;
    }


    private void RecordPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        if (view.PickupsLastPos.ContainsKey(gameObj))
            view.PickupsLastPos[gameObj] = gameObj.transform.position;
        else
            view.PickupsLastPos.Add(gameObj, gameObj.transform.position);
    }

    private void RespawnPlayer()
    {


        GameManager.Instance.BackgroundMove.gameObject.transform.position = view.lastBackgroundPos;
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            GameManager.Instance.Platforms[i].transform.position = view.lastPlatformPos[i];
        }
        foreach (var type in GameManager.Instance.Pickups)
        {
            type.Value.ForEach(gameObj => ReloadPickupPosition(gameObj));
        }
        view.PlayerRigidbody.gravityScale = view.lastGravityScale;
        view.PlayerSpriteRenderer.flipY = view.lastFlipY;
        view.PlayerRigidbody.velocity = new(0, 0);
        view.gameObject.transform.position = view.lastPlayerPos;
        GameManager.Instance.GameEnd.transform.position = view.lastGameEndPos;

        view.ExtraLife = false;

    }
    private void ReloadPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        gameObj.transform.position = view.PickupsLastPos[gameObj];
    }
    public void IncreaseMass()
    {
        view.PlayerRigidbody.mass *= view.massChange;
        view.StartCoroutine(ReduceMass());
    }

    IEnumerator ReduceMass()
    {
        yield return new WaitForSeconds(view.increaceMassDuration);
        view.PlayerRigidbody.mass /= view.massChange;
    }
}
