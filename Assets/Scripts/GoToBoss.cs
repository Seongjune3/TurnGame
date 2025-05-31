using UnityEngine;

public class GoToBoss : MonoBehaviour
{
    public GameObject goToBossUi;
    private GameObject player;
    private bool stopMove = true;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        stopMove = true;
    }


    void Update()
    {
        if (!stopMove)
        {
            if (player.name == "Ninja")
            {
                var ninjaNomalMove = player.GetComponent<NinjaNomalWalk>();
                ninjaNomalMove.enabled = true;
            }
            else if (player.name == "Paladin")
            {
                var paladinNomalMove = player.GetComponent<PaladinNomalWalk>();
                paladinNomalMove.enabled = true;
            }
            else if (player.name == "Archer")
            {
                var archerNomalMove = player.GetComponent<ArcherNomalWalk>();
                archerNomalMove.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            goToBossUi.SetActive(true);
            stopMove = true;
            if (player.name == "Ninja")
            {
                var ninjaNomalMove = player.GetComponent<NinjaNomalWalk>();
                var ninjaMove = player.GetComponent<NinjaWalk>();

                if (ninjaNomalMove.enabled)
                {
                    ninjaNomalMove.enabled = false;
                }
                else if (ninjaMove.enabled)
                {
                    ninjaMove.enabled = false;
                }
            }
            else if (player.name == "Paladin")
            {
                var paladinNomalMove = player.GetComponent<PaladinNomalWalk>();
                var paladinMove = player.GetComponent<PaladinWalk>();

                if (paladinNomalMove.enabled)
                {
                    paladinNomalMove.enabled = false;
                }
                else if (paladinMove.enabled)
                {
                    paladinMove.enabled = false;
                }
            }
            else if (player.name == "Archer")
            {
                var archerNomalMove = player.GetComponent<ArcherNomalWalk>();
                var archerMove = player.GetComponent<ArcherWalk>();

                if (archerNomalMove.enabled)
                {
                    archerNomalMove.enabled = false;
                }
                else if (archerMove.enabled)
                {
                    archerMove.enabled = false;
                }
            }
        }
    }

    public void YES()
    {
        player.transform.position = new Vector3(-1.336f, 12.48f, -19.86063f);
        stopMove = false;
        goToBossUi.SetActive(false);
    }

    public void NO()
    {
        stopMove = false;
        goToBossUi.SetActive(false);
    }
}
