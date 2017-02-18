//using System.Collections;
/* State interface */
public delegate void ChangeState (ITransition transition);
public interface IState {
	void Enter ();
	event ChangeState OnExitState;
	//void Exit  (); private
	/* Update() calls from StateMachine in its Update() method */
	void Update();
	void FixedUpdate ();
}

/* Transition interface */
public delegate void TransitionFinishedHandler();
public interface ITransition {
	void Begin();
	event TransitionFinishedHandler OnFinished;
	/* Update() calls from StateMachine in its Update() method */
	void Update();
	void FixedUpdate ();
	IState desireState { get; }
}

/* State Machine interface */
public interface IStateMachine {
	// reciave events of exit state here
	void ChangeState (ITransition transition);
}
