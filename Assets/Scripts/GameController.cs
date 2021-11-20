using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private GameObject spawnPoint;
    private GameObject player;
    private AudioController soundController;
    private UIController uiController;

    private bool falling = false;

    void Start()
    {
        player = GameObject.Find("Player");
        soundController = GameObject.Find("Sound").GetComponent<AudioController>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        spawnPoint = GameObject.Find("SpawnPoint");
        Respawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }
        // Check falling
        if (player.transform.position.y >= -1)
        {
            falling = false;
        }

        // If is falling, play falling sound
        if (!falling && player.transform.position.y < -2)
        {
            falling = true;
            soundController.playFallingSfx();
        }

        if (player.transform.position.y < -10)
        {
            Die();
        }
    }

    public void SwitchPause()
    {
        Static.isPause = !Static.isPause;
    }
    public void Die()
    {
        Static.lives -= 1;
        uiController.UpdateUI();
        Respawn();
    }

    private void Respawn()
    {
        player.transform.position = spawnPoint.transform.position + new Vector3(0, 10, 0);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private IEnumerator _CompleteLevel()
    {
        soundController.playCompleteLVSfx();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(++Static.level);
    }

    public void CompleteLevel()
    {
        StartCoroutine(_CompleteLevel());
    }
}
