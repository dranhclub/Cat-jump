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
    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
        player = GameObject.Find("Player");
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            Lives -= 1;
            Respawn();
        }
    }

    private void Respawn()
    {
        player.transform.position = spawnPoint.transform.position + new Vector3(0, 10, 0);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
