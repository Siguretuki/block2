using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public string nextSceneName;

    private GameObject text;
    private GameObject restartButton;
    private GameObject nextButton;
    private GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text");
        restartButton = GameObject.Find("RestartButton");
        nextButton = GameObject.Find("NextButton");

        // �{�^�����\��
        restartButton.SetActive(false);
        nextButton.SetActive(false);

        // �u���b�N��S�Ď擾
        blocks = GameObject.FindGameObjectsWithTag("Block");

        StartCoroutine(ShowStageName());
    }

    // Update is called once per frame
    void Update()
    {
        // �u���b�N�����ׂĎ擾
        blocks = GameObject.FindGameObjectsWithTag("Block");
        // �u���b�N���Ȃ��Ȃ�����Q�[���N���A
        if (blocks.Length == 0)
        {
            GameClear();
        }
    }

    // �Q�[���I�[�o�[����
    public void GameOver()
    {
        text.GetComponent<Text>().text = "Game Over";

        // �{�^����\��
        restartButton.SetActive(true);
    }

    // ���X�^�[�g����
    public void Restart()
    {
        // ���݂̃V�[�����ēǂݍ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // �Q�[���N���A����
    public void GameClear()
    {
        text.GetComponent<Text>().text = "Game Clear";
        nextButton.SetActive(true);
    }

    public void NextStage()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public IEnumerator ShowStageName( string stageName)
    {
        text.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
        yield return new WaitForSeconds(2.0f);
        text.GetComponent<Text>
    }
}
