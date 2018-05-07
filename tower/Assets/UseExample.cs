using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseExample : MonoBehaviour
{
    public Text titleText;
    public Text subTittleText;
    public Button showLeader;
	public Dropdown dificultad;

    [Space(10)]
    public string playerName;
    public int score;
    public LeaderboardModel lbm;

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
        showLeader.onClick.AddListener(() => { GetScores(); ShowScores(lbm); });
		dificultad.options.Clear();
		foreach (DataModel.Hardness s in dataManager.dataModel.hardness) {
			dificultad.options.Add (new Dropdown.OptionData () { text = s.name });
		}
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
        lbm = scoreManager.leaderboardModel ;

    }

    public void ShowScores(LeaderboardModel model)
    {
        string nombre;
        string puntos;
        foreach (LeaderboardModel.PlayerScore s in lbm.leaderboard)
        {
			
            nombre = s.playername;
            puntos = s.score;
            print(nombre + " - " + puntos);

        }
    }
}
