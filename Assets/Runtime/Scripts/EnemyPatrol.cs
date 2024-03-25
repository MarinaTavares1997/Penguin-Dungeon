using UnityEngine;

namespace PenguinDungeon
{
    public class EnemyPatrol : MonoBehaviour
    {
        public float m_Velocidade;
        public Transform[] m_Posicao;
        public float m_TempoEspera;
        public Animator animator;

        int m_Randomica;
        float m_Tempo;

        Vector2 movimento;

        // Start is called before the first frame update
        void Start()
        {
            m_Randomica = Random.Range(0, m_Posicao.Length);
            m_Tempo = m_TempoEspera;
            animator.SetFloat("up", -0.7f);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Posicao[m_Randomica].position, m_Velocidade * Time.deltaTime);

            float _dist = Vector2.Distance(transform.position, m_Posicao[m_Randomica].position);

            if(_dist <= .2f)
                if(m_Tempo <= 0)
                {
                    m_Randomica = Random.Range(0, m_Posicao.Length);

                    if(animator.GetFloat("up") == 0.7f && m_Tempo == 0)
                    {
                        m_Tempo = m_TempoEspera;
                        animator.SetFloat("up", -0.7f);
                    }
                    else if (animator.GetFloat("up") != 0.7f && m_Tempo == 0)
                    {
                        m_Tempo = m_TempoEspera;
                        animator.SetFloat("up", 0.7f);
                    }
                }
                else
                {
                    m_Tempo -= Time.deltaTime;
                }
           
            animator.SetFloat("ietevelocidade", movimento.sqrMagnitude);
        }
    }
}
