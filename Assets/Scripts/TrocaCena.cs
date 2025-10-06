using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    // Nome ou �ndice da cena que quer carregar
    public string nomeDaCena;

    // Fun��o p�blica que pode ser chamada pelo bot�o
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
