using UnityEngine;

public class BowBehavior : MonoBehaviour
{
	public GameObject arrowPrefab;
	public GameObject currentActiveArrow;
	public Transform arrowPoint;
	public float power;

	enum ShootingStages { Load, Pull, Release, Null }
	ShootingStages shootingStage = ShootingStages.Null;

	private void Update()
	{
		shootingStage = GetStage();

		switch (shootingStage)
		{
			case ShootingStages.Null:
				Debug.Log("No input was read");
				return;
			case ShootingStages.Load:
				Load();
				Debug.Log("Spawned Arrow");
				return;
			case ShootingStages.Pull:
				BuildPower(0.1f);
				Debug.Log("building power");
				return;
			case ShootingStages.Release:
				//Release();
				Debug.Log("shooting");
				return;
		}

	}

	ShootingStages GetStage()
	{
		if (Input.GetMouseButtonDown(0)){
			return ShootingStages.Load;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			return ShootingStages.Release;
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			return ShootingStages.Pull;
		}

		return ShootingStages.Null;
	}

	/// <summary>
	/// Adds to the "power" value to determine arrow launch force
	/// </summary>
	/// <param name="buildUpRate">Rate at which power should be built per tick</param>
	public void BuildPower(float buildUpRate)
	{
		power += buildUpRate;
	}

	/// <summary>
	/// Sets values and adds physics to the arrow
	/// </summary>
	public void Release()
	{
		////Apply force to arrow
		currentActiveArrow.GetComponent<Rigidbody>().AddForce(Vector3.forward * power, ForceMode.VelocityChange);

		////turn on arrow physics
		currentActiveArrow.GetComponent<Rigidbody>().useGravity = true;
	}

	/// <summary>s
	/// Resets values and spawns new arrow.
	/// </summary>
	public void Load()
	{
		//reset values
		power = 0;

		//spawn arrow
		currentActiveArrow = Instantiate(arrowPrefab, arrowPoint.position, arrowPoint.rotation);
	}
}
