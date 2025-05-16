public class EnemyLooking : LookingTarget
{
    private void Update()
    {
        this.LookAtTarget(this.transform.parent, this.target.transform);
    }
}