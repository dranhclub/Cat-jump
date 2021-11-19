using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private int lives;

    [SerializeField]
    private TextMeshProUGUI livesTxt;
    [SerializeField]
    private TextMeshProUGUI levelTxt;
    [SerializeField]
    private GameObject spawnPoint;
    private GameObject player;
    private SoundController soundController;

    private bool falling = false;
    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
        player = GameObject.Find("Player");
        soundController = GameObject.Find("Sound").GetComponent<SoundController>();
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= -1)
        {
            falling = false;
        }
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

    public void Die()
    {
        Lives -= 1;
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
        SceneController.NextScene();
    }
    public void CompleteLevel()
    {
        StartCoroutine(_CompleteLevel());
    }

    public void UpdateUI()
    {
        livesTxt.text = $"Lives: {lives}";
        levelTxt.text = $"Level: {SceneController.Level}";
    }

    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
            UpdateUI();
        }
    }
}
