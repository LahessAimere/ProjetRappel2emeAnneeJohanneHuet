public class EnemyStateMachineData
{
    //Enemy Movement Variables
    public float moveSpeed = 5f;
    public EnemyMovement enemyMovement;
    
    //Enemy Shooting Variables
    public float shootInterval;
    public EnemyShoot enemyShoot;
    
    //Enemy Chase player
    public EnemyChasePlayer enemyChasePlayer;
    public Bullet bullet;

}