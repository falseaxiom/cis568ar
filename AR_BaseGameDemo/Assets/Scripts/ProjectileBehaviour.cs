namespace MyFirstARGame
{
    using UnityEngine;
    using Photon.Pun;

    /// <summary>
    /// Controls projectile behaviour. In our case it currently only changes the material of the projectile based on the player that owns it.
    /// </summary>
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Material[] projectileMaterials;

        public int playerId;

        //public float projectileTimer = 5.0f;

        private void Awake()
        {
            // Pick a material based on our player number so that we can distinguish between projectiles. We use the player number
            // but wrap around if we have more players than materials. This number was passed to us when the projectile was instantiated.
            // See ProjectileLauncher.cs for more details.
            var photonView = this.transform.GetComponent<PhotonView>();
            var playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);
            if (this.projectileMaterials.Length > 0)
            {
                var material = this.projectileMaterials[playerId % this.projectileMaterials.Length];
                this.transform.GetComponent<Renderer>().material = material;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Target")
            {
                Debug.Log("ProjectileBehavior: Hit target");

                var photonView = this.transform.GetComponent<PhotonView>();
                var playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);

                GameObject global = GameObject.Find("Global");
                Global g = global.GetComponent<Global>();

                GameObject target = collision.gameObject;
                TargetScript t = target.GetComponent<TargetScript>();

                if (playerId == 2)
                {
                    g.score1 += t.pointValue;
                }
                else if (playerId == 3)
                {
                    g.score2 += t.pointValue;
                }
            }
        }

        // updates the timer on the projectile - 5 secs life
        private void Update()
        {
            //projectileTimer -= Time.deltaTime;
            //if (projectileTimer <= 0)
            //{
            //    Debug.Log("timer ran out - im dead");
            //    Destroy(this.gameObject);
            //}
        }
    }
}
