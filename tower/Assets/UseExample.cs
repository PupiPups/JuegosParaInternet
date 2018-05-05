using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseExample : MonoBehaviour
{
    public Text titleText;
    public Text subTittleText;

    [Space(10)]
    public string playerName;
    public int score;

    DataManager dataManager { get { return GetComponent<DataManager>(); } }
    ScoreManager scoreManager { get { return GetComponent<ScoreManager>(); } }

    void Start()
    {
        //le pedimos al data manager que cargue las cosas
        dataManager.DownloadDataModel(ShowError);
        //nos suscribimos para saber cuando termina la cosa
        RequestManager.instance.OnRequestFinished += AssingData;
    }

    void ShowError(string errorMessage)
    {
        Debug.Log(errorMessage);
    }

    void AssingData()
    {
        //una vez que termina, no nos interesa mas la cosa. nos desuscribimos
        RequestManager.instance.OnRequestFinished -= AssingData;

        //ponemos el texto donde va
        titleText.text = dataManager.dataModel.gameName;
        subTittleText.text = dataManager.dataModel.gameDescription;
    }

    public void SendMyScore()
    {
        //enviamos el score
        scoreManager.SendScore(playerName, score, ShowError);
    }

    public void GetScores()
    {
        //pedimos los scores, a la vuelta la respuesta la maneja ShowScores
        scoreManager.GetLeaderboard(ShowScores, ShowError);
    }

    public void ShowScores(LeaderboardModel model)
    {
        //lo mostramos en la UI
        //implementacion libre :D
    }
}
