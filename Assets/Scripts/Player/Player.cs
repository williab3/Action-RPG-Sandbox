using UnityEngine;

public class Player : MonoBehaviour
{
    StateController stateController;
    EntityState Idle;

    void Awake()
    {
        stateController = new StateController();
    }
    
    void Start()
    {
        stateController.Initialize(Idle);
    }
    // Update is called once per frame
    void Update()
    {
        stateController.CurrentState.Update();
    }
}
