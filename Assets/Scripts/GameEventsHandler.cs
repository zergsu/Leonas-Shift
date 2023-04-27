using System;


public static class GameEventsHandler
{
	public static event Action onNextLevel;
	public static event Action<bool> onDialog;
	public static event Action onRespawn;

	public static void NextLevel() {
		onNextLevel?.Invoke();
	}

	public static void Dialog(bool dialog) {
		onDialog?.Invoke(dialog);
	} 

	public static void Respawn() {
		onRespawn?.Invoke();
	}

}
