using UnityEngine;
using TMPro;
namespace Pollitos
{
    // Localiza solo la interfaz de la nueva escena, sin modificar la demo.
    public class CorralPresentation : MonoBehaviour
    {
        public string gameTitle = "¡CORRAL EN ACCIÓN!";
        TMP_Text[] labels;
        void Start() { labels = FindObjectsByType<TMP_Text>(FindObjectsInactive.Include, FindObjectsSortMode.None); }
        void LateUpdate()
        {
            if (labels == null) return;
            foreach (var label in labels)
            {
                if (!label) continue;
                string s = label.text;
                string t = s.Replace("2 Tanks required", "Elige 2 pollitos").Replace("TANKS!", gameTitle)
                    .Replace("Click To Add Tank", "Elegir pollito").Replace("Player Select", "ELIGE TU POLLITO").Replace("Tank Selection", "Elegir pollitos")
                    .Replace("WINS THE ROUND!", "GANA LA RONDA!").Replace("WINS THE GAME!", "GANA LA PARTIDA!")
                    .Replace("PLAYER ", "POLLITO ").Replace("ROUND ", "RONDA ").Replace(" WINS", " VICTORIAS")
                    .Replace("DRAW!", "EMPATE!").Replace("Speed ", "Velocidad ").Replace("Damage ", "Daño ").Replace("Health:", "Vida:");
                if (t == "Start") t = "¡A jugar!";
                if (t == "Computer") t = "CPU";
                if (t == "Add") t = "Elegir";
                if (t != s) label.text = t;
            }
        }
    }
}
