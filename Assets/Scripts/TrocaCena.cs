using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    // Nome ou índice da cena que quer carregar
    public string nomeDaCena;

    // Função pública que pode ser chamada pelo botão
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
