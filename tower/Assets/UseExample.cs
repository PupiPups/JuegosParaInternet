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
    public GameObject canvas;
    public GameObject preRank;

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
            dificultad.options.Add(new Dropdown.OptionData() { text = s.name });
        }
        playerName = dataManager.dataModel.player.name;
        PlayerPrefs.SetString("Player_Nombre", playerName);
        PlayerPrefs.SetInt("Player_Vida", dataManager.dataModel.player.health);
        PlayerPrefs.SetInt("Player_Danio", dataManager.dataModel.player.damage);
        PlayerPrefs.SetInt("Player_Velocidad", dataManager.dataModel.player.speed);

        PlayerPrefs.SetString("Enemy_Nombre", dataManager.dataModel.minion.name);
        PlayerPrefs.SetInt("Enemy_Vida", dataManager.dataModel.minion.health);
        PlayerPrefs.SetInt("Enemy_Danio", dataManager.dataModel.minion.damage);
        int minion_v = Mathf.RoundToInt((float)dataManager.dataModel.minion.speed); ;
        PlayerPrefs.SetInt("Enemy_Velocidad", minion_v);

        PlayerPrefs.SetString("Boss_Nombre", dataManager.dataModel.boss.name);
        PlayerPrefs.SetInt("Boss_Vida", dataManager.dataModel.boss.health);
        PlayerPrefs.SetInt("Boss_Danio", dataManager.dataModel.boss.damage);
        int boss_v = Mathf.RoundToInt((float)dataManager.dataModel.boss.speed); ;
        PlayerPrefs.SetInt("Boss_Velocidad", boss_v);


    }

    public void SendMyScore()
    {
        //enviamos el score
        scoreManager.SendScore(PlayerPrefs.GetString("Player_Nombre"), PlayerPrefs.GetInt("Puntos"), ShowError);
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
            GameObject go = (GameObject)Instantiate(preRank);
            go.transform.SetParent(canvas.transform);
            nombre = s.playername;
            puntos = s.score;
            go.transform.position.Set(0f, 0f, 0f);

            
            preRank.GetComponent<Text>().text = nombre + " - " + puntos;

        }
    }

    public void CambiarNombre(string nuevo_nombre)
    {
        PlayerPrefs.SetString("Player_Nombre", nuevo_nombre);


    }
}
