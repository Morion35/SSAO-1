using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Object = System.Object;
using Random = UnityEngine.Random;
using UnityEngine.Networking;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof (CharacterController))]
    [RequireComponent(typeof (AudioSource))]
    public class FirstPersonController : MonoBehaviour
    {
        [SerializeField] private bool m_IsWalking;
        [SerializeField] public float m_WalkSpeed;
        [SerializeField] private float m_RunSpeed;
        [SerializeField] private float m_RunstepLenghten;
        [SerializeField] private float m_JumpSpeed;
        [SerializeField] private float m_StickToGroundForce;
        [SerializeField] private float m_GravityMultiplier;
        [SerializeField] public MouseLook m_MouseLook;
        [SerializeField] private bool m_UseFovKick;
        [SerializeField] private FOVKick m_FovKick = new FOVKick();
        [SerializeField] private bool m_UseHeadBob;
        [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
        [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
        [SerializeField] private float m_StepInterval;
        [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
        [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
        [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.

        [SerializeField] private Camera m_Camera;
        [SerializeField] private bool m_Jump;
        [SerializeField] private float m_YRotation;
        [SerializeField] private Vector2 m_Input;
        [SerializeField] public Vector3 m_MoveDir = Vector3.zero;
        [SerializeField] private CharacterController m_CharacterController;
        [SerializeField] private CollisionFlags m_CollisionFlags;
        [SerializeField] private bool m_PreviouslyGrounded;
        [SerializeField] private Vector3 m_OriginalCameraPosition;
        [SerializeField] private float m_StepCycle;
        [SerializeField] private float m_NextStep;
        [SerializeField] private bool m_Jumping;
        [SerializeField] private AudioSource m_AudioSource;


        public GameObject PauseMenu;
        public GameObject skillshot;
        public GameObject impulsion;
        public GameObject spell1;
        public GameObject Ulti;
        public GameObject Launcher;
        public Transform shotspawn;
        public float UseRate;
        public float SpellRate;
        public float Ultrate;
        public float DashRate;
        public GameObject Object1;
        public GameObject Object2;
        public GameObject Object3;
        public GameObject Object4;
        
        private float nextDash;
        private float nextUse;
        private float nextSpell;
        private float nextUlt;
        private float mana;

        public bool paused;
        
        // Use this for initialization
        private void Awake()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = GetComponentInChildren<Camera>();
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle/2f;
            m_Jumping = false;
            m_AudioSource = GetComponent<AudioSource>();
			m_MouseLook.Init(transform , m_Camera.transform);
        }


        // Update is called once per frame
        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (!PauseMenu.activeSelf && !paused)
                {
                    Time.timeScale = 0f;
                    PauseMenu.SetActive(true);
                    paused = true;
                    m_MouseLook.SetCursorLock(false);
                }
                else
                {
                    Time.timeScale = 1f;
                    PauseMenu.SetActive(false);
                    m_MouseLook.SetCursorLock(true);
                    paused = false;
                }
            }
            if (!paused && PauseMenu.activeSelf)
            {
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
                m_MouseLook.SetCursorLock(true);
            }
            if (paused)
            {
                return;
            }
            mana = GetComponent<PlayerStatus>().mana;
                
            RotateView();
            

            // the jump state needs to read here to make sure it is not missed
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
            {
                StartCoroutine(m_JumpBob.DoBobCycle());
                PlayLandingSound();
                m_MoveDir.y = 0f;
                m_Jumping = false;
            }
            if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
            {
                m_MoveDir.y = 0f;
            }
            if (Input.GetButtonDown("Fire1") && Time.time > nextUse && mana >= 5f)
            {
                nextUse = Time.time + UseRate;
                GameObject clone = Instantiate(skillshot, shotspawn.position, shotspawn.rotation, transform);
            }
            
            if (Input.GetButton("Fire2") && Time.time > nextDash && mana >= 20f)
            {
                nextDash = Time.time + DashRate;
                if (GetComponent<PlayerStatus>()._basearmor < 30f)
                {
                    Vector3 dash = transform.forward * 2;
                    transform.position += dash;
                    GameObject clone1 = Instantiate(impulsion, transform.position, transform.rotation, transform);
                }
                if (GetComponent<PlayerStatus>()._basearmor == 30f)
                {
                    Vector3 dash = transform.up * 2.5f;
                    transform.position += dash;
                    GameObject clone1 = Instantiate(impulsion, transform.position, transform.rotation, transform);
                }
                else
                {
                    GameObject clone = Instantiate(impulsion, shotspawn.position, shotspawn.rotation, transform);
                }
            }
            
            if (Input.GetButton("Fire3") && Time.time > nextSpell && mana >= 60f)
            {
                nextSpell = Time.time + SpellRate;
                GameObject clone = Instantiate(spell1, shotspawn.position, shotspawn.rotation, transform);
                
            }
            
            if (Input.GetButtonDown("Fire4") && Time.time > nextUlt && mana >= 100f)
            {
                nextUlt = Time.time + Ultrate;
                if (GetComponent<PlayerStatus>()._basearmor < 30)
                {
                    GameObject clone2 = Instantiate(Ulti, transform.position, transform.rotation, transform);
                    if (Launcher != null)
                    {
                        GameObject clone3 = Instantiate(Launcher, shotspawn.position, shotspawn.rotation, transform);
                    }
                }
                else
                {
                    GameObject clone3 = Instantiate(Launcher, transform.position + new Vector3(0, 0.25f, 0), new Quaternion(1, 0, 0, 0),
                        transform);
                }
            }
            m_PreviouslyGrounded = m_CharacterController.isGrounded;
        }


        private void PlayLandingSound()
        {
            m_AudioSource.clip = m_LandSound;
            m_AudioSource.maxDistance = 5f;
            m_AudioSource.minDistance = 2f;
            m_AudioSource.Play();
            m_NextStep = m_StepCycle + .5f;
        }


        private void FixedUpdate()
        {
            if (paused)
            {
                return;
            }
            float speed;
            GetInput(out speed);
            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;

            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                               m_CharacterController.height/2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            m_MoveDir.x = desiredMove.x*speed;
            m_MoveDir.z = desiredMove.z*speed;


            if (m_CharacterController.isGrounded)
            {
                m_MoveDir.y = -m_StickToGroundForce;

                if (m_Jump)
                {
                    m_MoveDir.y = m_JumpSpeed;
                    PlayJumpSound();
                    m_Jump = false;
                    m_Jumping = true;
                }
            }
            else
            {
                m_MoveDir += Physics.gravity*m_GravityMultiplier*Time.fixedDeltaTime;
            }
            m_CollisionFlags = m_CharacterController.Move(m_MoveDir*Time.fixedDeltaTime);
            ProgressStepCycle(speed);
            UpdateCameraPosition(speed);

            m_MouseLook.UpdateCursorLock();
        }


        private void PlayJumpSound()
        {
            m_AudioSource.clip = m_JumpSound;
            m_AudioSource.maxDistance = 2f;
            m_AudioSource.minDistance = 1f;
            m_AudioSource.Play();
        }


        private void ProgressStepCycle(float speed)
        {
            m_AudioSource.maxDistance = 0.5f;
            m_AudioSource.minDistance = 0.1f;
            if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
            {
                m_StepCycle += (m_CharacterController.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                m_AudioSource.maxDistance = 0.5f;
                m_AudioSource.minDistance = 0.1f;
                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;

            PlayFootStepAudio();
        }


        private void PlayFootStepAudio()
        {
            if (!m_CharacterController.isGrounded)
            {
                return;
            }
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip, m_IsWalking ? 0.5f : 1f);
            m_AudioSource.maxDistance = m_IsWalking ? 2f : 5f;
            m_AudioSource.minDistance = m_IsWalking ? 1f : 2f;
            // move picked sound to index 0 so it's not picked next time
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }


        private void UpdateCameraPosition(float speed)
        {
            Vector3 newCameraPosition;
            if (!m_UseHeadBob)
            {
                return;
            }
            if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
            {
                m_Camera.transform.localPosition =
                    m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                      (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
            }
            else
            {
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
            }
            m_Camera.transform.localPosition = newCameraPosition;
        }


        private void GetInput(out float speed)
        {
            // Read input
            float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");

            bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
            // On standalone builds, walk/run speed is modified by a key press.
            // keep track of whether or not the character is walking or running
            m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif
            // set the desired speed to be walking or running
            speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
            m_Input = new Vector2(horizontal, vertical);

            // normalize input if it exceeds 1 in combined length:
            if (m_Input.sqrMagnitude > 1)
            {
                m_Input.Normalize();
            }

            // handle speed change to give an fov kick
            // only if the player is going to a run, is running and the fovkick is to be used
            if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
            {
                StopAllCoroutines();
                StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
            }
        }


        private void RotateView()
        {
            m_MouseLook.LookRotation (transform, m_Camera.transform);
        }


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            //dont move the rigidbody if the character is on top of it
            if (m_CollisionFlags == CollisionFlags.Below)
            {
                return;
            }

            if (body == null || body.isKinematic)
            {
                return;
            }
            body.AddForceAtPosition(m_CharacterController.velocity*0.1f, hit.point, ForceMode.Impulse);
        }
    }
}
