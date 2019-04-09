using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

public class MeepBehavior : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject grandMeep;
    private bool following = false;
    private GameObject light;
    private bool seenPlayer;
    private bool dying = false;
    public GameObject nope;

    [SerializeField]
    private Animator jump;

    [SerializeField] private AudioClip[] happyAudio;
    [SerializeField] private AudioClip[] sadAudio;
    [SerializeField] private AudioClip[] curiousAudio;
    [SerializeField] private AudioClip[] DeathAudio;
    public AudioSource Source;
    [SerializeField] private float time;

    [SerializeField] private int waitTime;

    public enum state
    {
        followGM,
        followLight,
        idle,
        eaten
    }




    //added this because it wouldn't let me just set a state in MeepEating - Kail
    public state dead = state.eaten;

    public float testDistance;
    [SerializeField]
    public state myState = state.idle;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        grandMeep = GameObject.FindWithTag("Player");
        Source = GetComponent<AudioSource>();
        waitTime = Random.Range(0, 3);
    }

    public void LightSummoned(GameObject newLight)
    {
        light = newLight;
        if (light != null) myState = state.followLight;
        //return null;
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckFollower();
        switch (myState)
        {
            case state.idle:
                if (time > waitTime)
                {
                    if (seenPlayer)
                    {
                        PlayAudio(sadAudio);
                    }
                    else
                    {
                        PlayAudio(happyAudio);
                    }
                }
                GrandMeep.OnSummonedLight -= LightSummoned;
                if (CheckDistance())
                {
                    CheckSight();
                }
                Move(this.gameObject);
                break;
            case state.followGM:
                if (time > waitTime) PlayAudio(happyAudio);
                if (CheckDistance())
                {
                    CheckSight();
                }
                GrandMeep.OnSummonedLight += LightSummoned;
                //check if summoned light will be held down or one time trigger event if so need seperate state for it
                Move(grandMeep);
                break;
            case state.followLight:
                if (time > waitTime) PlayAudio(curiousAudio);
                GrandMeep.OnSummonedLight -= LightSummoned;
                if (light) Move(light);
                else myState = state.idle;
                break;
            case state.eaten:
                GrandMeep.OnSummonedLight -= LightSummoned;
                if (!dying) StartCoroutine(Death());
                break;
        }
        time += Time.deltaTime;
    }

    IEnumerator Death()
    {
        dying = true;
        Move(nope);
        yield return  new WaitForSeconds(1);
        PlayAudio(DeathAudio);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    #region CheckingCode

    private void CheckFollower()
    {
        if (myState == state.followGM)
        {
            if (!following)
            {
                grandMeep.GetComponent<GrandMeep>().meepFollowers++;
                following = true;
            }
        }
        else
        {
            if (following)
            {
                grandMeep.GetComponent<GrandMeep>().meepFollowers--;
                following = false;
            }
        }
    }
    private void CheckSight()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, grandMeep.transform.position, out hit))
        {
            if (hit.transform.gameObject == grandMeep)
            {
                myState = state.followGM;
                return;
            }
            myState = state.idle;
        }
    }

    private bool CheckDistance()
    {
        if (Vector3.Distance(gameObject.transform.position, grandMeep.transform.position) > testDistance)
        {
            myState = state.idle;
            return false;
        }
        return true;
    }


    #endregion
    private void Move(GameObject target)
    {
        jump.SetBool("Jump", navMeshAgent.isOnOffMeshLink);          
        navMeshAgent.destination = target.transform.position;
    }

    public void PlayAudio(AudioClip[] sound)
    {
        if (Random.Range(0, 10) > 7)
        {
            Source.clip = sound[Random.Range(0, sound.Length)];
            Source.Play();
        }
        waitTime = Random.Range(3, 8);
        time = 0;
    }
    /*  collision with grand meep? check for light?
    *   add meeps to event cast from grand meep and target grand meep
    */



    /*  Grand meep Event
    *   when Grand meep makes light at other point change target of meep
    */

    /*  Movement
    *   joined to grandmeeps event
    *   move toward target location
    */

    /*     check if on platform
     *     when on platform disable navmesh agent swap state and activate platform
     *     when platform stops reenable mesh and change state again.
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == grandMeep)
        {
            Physics.IgnoreCollision(grandMeep.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }

    
  

   
    
}
