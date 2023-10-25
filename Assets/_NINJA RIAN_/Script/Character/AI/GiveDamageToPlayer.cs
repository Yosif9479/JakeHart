using UnityEngine;
using System.Collections;

public class GiveDamageToPlayer : MonoBehaviour {
	[Header("Option")]
	[Tooltip("destroy this object when hit player?")]
	public bool isDestroyWhenHitPlayer = false;
	public GameObject DestroyFx;

    [Header("Make Damage")]
    public int DamageToPlayer = 35;
	[Tooltip("delay a moment before give next damage to Player")]
	public float rateDamage = 0.2f;
    public Vector2 pushPlayerBack = new Vector2(8, 5);
    float nextDamage;

    [Header("Option Can Be Jump On Head")]
    [Tooltip("Give damage to this object when Player jump on his head")]
	public bool canBeKillOnHead = false;
    public Vector2 pushPlayerBeJumpOn = new Vector2(0, 6);
    public int damageOnHead;
    public Transform headPoint;

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerStay2D(Collider2D other){
		//var Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		var Player = other.GetComponent<Player> ();
		Debug.Log(Player);
		if (Player == null)
		{
            Debug.Log("Я здесь1");
            return;
		}

		if (!Player.isPlaying)
		{
            Debug.Log("Я здесь2");
            return;
		}

		if (Time.time < nextDamage + rateDamage)
		{
			Debug.Log("Я здесь3");
			return;
		}

		nextDamage = Time.time;

		if (canBeKillOnHead && Player.transform.position.y > (headPoint!=null? headPoint.position.y: transform.position.y)) {

			Player.SetForce(pushPlayerBeJumpOn);
			var canTakeDamage = (ICanTakeDamage) GetComponent (typeof(ICanTakeDamage));
			if (canTakeDamage != null)
				canTakeDamage.TakeDamage (damageOnHead, Vector2.zero, gameObject, Vector2.zero);
			
			return;
		}
        
		if (DamageToPlayer == 0)
			return;

		var facingDirectionX = Mathf.Sign (Player.transform.position.x - transform.position.x);
		var facingDirectionY = Mathf.Sign (Player.velocity.y);

		Player.SetForce(new Vector2 (pushPlayerBack.x * facingDirectionX,
            pushPlayerBack.y * facingDirectionY * -1));

		Player.TakeDamage (DamageToPlayer, Vector2.zero, gameObject, Vector2.zero);

		if (isDestroyWhenHitPlayer) {
			if (DestroyFx != null)
				Instantiate (DestroyFx, transform.position, Quaternion.identity);

			Destroy (gameObject);
		}
	}
	void Attack()
	{
        var Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //var Player = other.GetComponent<Player> ();
        Debug.Log(Player);
        Debug.Log("Показывает игрока");
        if (Player == null)
        {
            Debug.Log("Я здесь1");
            return;
        }

        if (!Player.isPlaying)
        {
            Debug.Log("Я здесь2");
            return;
        }

        if (Time.time < nextDamage + rateDamage)
        {
            Debug.Log("Я здесь3");
            return;
        }

        nextDamage = Time.time;

        if (canBeKillOnHead && Player.transform.position.y > (headPoint != null ? headPoint.position.y : transform.position.y))
        {

            Player.SetForce(pushPlayerBeJumpOn);
            var canTakeDamage = (ICanTakeDamage)GetComponent(typeof(ICanTakeDamage));
            if (canTakeDamage != null)
                canTakeDamage.TakeDamage(damageOnHead, Vector2.zero, gameObject, Vector2.zero);

            return;
        }

        if (DamageToPlayer == 0)
            return;

        var facingDirectionX = Mathf.Sign(Player.transform.position.x - transform.position.x);
        var facingDirectionY = Mathf.Sign(Player.velocity.y);

        Player.SetForce(new Vector2(pushPlayerBack.x * facingDirectionX,
            pushPlayerBack.y * facingDirectionY * -1));

        Player.TakeDamage(DamageToPlayer, Vector2.zero, gameObject, Vector2.zero);

        if (isDestroyWhenHitPlayer)
        {
            if (DestroyFx != null)
                Instantiate(DestroyFx, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
