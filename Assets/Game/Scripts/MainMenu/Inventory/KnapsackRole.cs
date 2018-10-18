using UnityEngine;
using UnityEngine.UI;

public class KnapsackRole : MonoBehaviour {

    public static KnapsackRole Instance;

    public Text playerName;
    public KnapsackRoleEquipt helmet;
    public KnapsackRoleEquipt cloth;
    public KnapsackRoleEquipt weapon;
    public KnapsackRoleEquipt shoes;
    public KnapsackRoleEquipt necklace;
    public KnapsackRoleEquipt bracelet;
    public KnapsackRoleEquipt ring;
    public KnapsackRoleEquipt wing;

    public Text hp;
    public Text attack;
    public Text exp;
    public Slider expSlider;

    private void Awake()
    {
        Instance = this;
        PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }

    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    private void Start()
    {
        UpdateShow();
    }

    private void OnPlayerInfoChanged(PlayerInfoType type)
    {     
        switch (type)
        {
            case PlayerInfoType.Name:             
            case PlayerInfoType.Exp:             
            case PlayerInfoType.HP:            
            case PlayerInfoType.Attack:              
            case PlayerInfoType.Equipt:
            case PlayerInfoType.All:
                UpdateShow();
                break;
            default:
                break;
        }
    }

    private void UpdateShow()
    {        
        playerName.text = PlayerInfo.Instance.Name.ToString();
        helmet.UpdateImgByInventoryItem(PlayerInfo.Instance.Helmet);
        cloth.UpdateImgByInventoryItem(PlayerInfo.Instance.Cloth);
        weapon.UpdateImgByInventoryItem(PlayerInfo.Instance.Weapon);
        shoes.UpdateImgByInventoryItem(PlayerInfo.Instance.Shoes);
        bracelet.UpdateImgByInventoryItem(PlayerInfo.Instance.Bracelet);
        necklace.UpdateImgByInventoryItem(PlayerInfo.Instance.Necklace);
        ring.UpdateImgByInventoryItem(PlayerInfo.Instance.Ring);
        wing.UpdateImgByInventoryItem(PlayerInfo.Instance.Wing);

        hp.text = GetMaxHP().ToString();
        attack.text = GetMaxAttack().ToString();
        float expNeed = GameController.GetRequiredExpByLevel(PlayerInfo.Instance.Level + 1) * 1.0f;
        exp.text = PlayerInfo.Instance.Exp + "/" + expNeed;
        expSlider.value = PlayerInfo.Instance.Exp * 1.0f / expNeed;
    }

    private int GetMaxHP()
    {
        PlayerInfo pifo = PlayerInfo.Instance;
        return pifo.Level * 100 + helmet.HP + cloth.HP + weapon.HP + shoes.HP + necklace.HP + necklace.HP + wing.HP + ring.HP + bracelet.HP;
    }

    private int GetMaxAttack()
    {
        PlayerInfo pifo = PlayerInfo.Instance;
        return pifo.Level * 50 + helmet.Attack + cloth.Attack + weapon.Attack + shoes.Attack + necklace.Attack + necklace.Attack + wing.Attack + ring.Attack + bracelet.Attack;
    }


}
