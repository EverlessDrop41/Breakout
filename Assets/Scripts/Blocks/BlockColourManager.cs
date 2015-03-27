using UnityEngine;

public class BlockColourManager : MonoBehaviour {

    public Sprite SuperHardBlock;
    public Sprite HardBlock;
    public Sprite MediumBlock;
	public Sprite WeakBlock;

    public static Sprite SuperHard;
    public static Sprite Hard;
    public static Sprite Medium;
    public static Sprite Weak;

    void Start()
    {
        SuperHard = SuperHardBlock;
        Hard = HardBlock;
        Medium = MediumBlock;
        Weak = WeakBlock;
    }
}
