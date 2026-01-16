using System;
using UnityEngine;

public class BumperHit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;

     private ParticleSystem ps;

       public static event Action<Transform,int> onBumperHit;


    private void Start()
    {
        //Vraag het Particle System Component op als de game start en bewaar hem in je variabele, zodat je er later dingen mee kunt doen
        ps = GetComponent<ParticleSystem>();

        //zet je particle system stil! (? checkt of er wel een particle system is.)
        ps?.Stop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {

            //geef in plaats van de tag nu de transform mee aan het event. Dit is noodzakelijk voor de screenshake!
            onBumperHit?.Invoke(gameObject.transform, scoreValue);

            //zet je Particle System hem eerst weer stil voor het geval hij nog niet klaar was met de vorige loop
            ps?.Stop();

            //speel hem nu af vanaf het begin.
            ps?.Play();
        }
   
    }
}


       
