using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Upgrade Config")]
public class UpgradeConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    [SerializeField] private int _price;
    [SerializeField] private int _value;

    [SerializeField] private UpgradeType _type;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public string Description => _description;

    public int Price 
    {
        get { return _price; }
        set 
        {
            if (value < 0)
                throw new System.Exception("Price cannot be a negative");

            _price = value;
        }
    }

    public int Value => _value;

    public UpgradeType Type => _type;
    public Sprite Icon => _icon;
}
