//using System.Collections;
/* State interface */
public delegate void ChangeState (ITransition transition);
public interface IState {
	event ChangeState OnExitState;
	void Enter ();
	void Exit  ();
	/* metnod Update() calls from StateMachine in its Update() methon */
	void Update();
	void FixedUpdate ();
}

/* Transition interface */
public delegate void TransitionFinishedHandler();
public interface ITransition {
	event TransitionFinishedHandler OnTransitionFinished;
	/* metnod Update() calls from StateMachine in its Update() methon */
	void Update();
	void FixedUpdate ();
	IState desireState { get; }
}

/* Transition abstract class */
public abstract class Transition {
	public Transition (IState state){ desireState = state; }
	IState desireState;
}

/* State Machine interface */
public interface IStateMachine {
	// reciave events of exit state here
	void ChangeState (ITransition transition);
}
