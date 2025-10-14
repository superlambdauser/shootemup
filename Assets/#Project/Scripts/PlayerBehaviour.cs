using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //     Le joueur à 3 vie, à chaque fois qu’il percute un
    // ennemis, il en perd une et devient invincible pendant
    // 1 seconde. (ce temps peut être allongés ou raccourcis
    // si vu le jugé nécessaire).
    // Suite à la collision l’ennemi est détruit (attention au
    // pooling).
    // Les vies du joueur sont affichée sur l’écran.
    // Pour le moment ne faites rien quand les vies
    // atteignent 0.
    [SerializeField] private int lives;

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Enemy"))
//         {
//             lives -= 1;
            
//         }
//     }
}
