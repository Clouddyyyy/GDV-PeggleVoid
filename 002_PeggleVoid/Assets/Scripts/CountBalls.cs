using System;
using UnityEngine;
public class CountBalls : MonoBehaviour
{
    public static event Action onBallLost;          
    public static event Action onBallsDepleted;     
    [SerializeField]private int ballsLeft = 5;      
    private void Start(){
        
        Shoot.onShootBall += CountOnShot;
    }
    private void OnDisable(){
       
        Shoot.onShootBall -= CountOnShot;
    }
    private void CountOnShot(){


        //Check of je nog genoeg ballen over hebt
        if(ballsLeft > 0){
            //pas je ballen reserve aan
            ballsLeft--;
        }else{
            //verstuur event als ze op zijn
            onBallsDepleted?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Check of de bal uit het scherm gaat
        if (collision.gameObject.CompareTag("Ball")) {
            //verstur een event
            onBallLost?.Invoke();
            //vernietig de bal
            Destroy(collision.gameObject);
        }
    }
}
