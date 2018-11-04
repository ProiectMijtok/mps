using UnityEngine.UI;
using UnityEngine;
using PlayersRepository;

public class CardModel : MonoBehaviour
{

    SpriteRenderer rnd;
    public Player player;
    public int playerId = 0;
    public int at;
    public Text attack;
    public int def;
    public Text defence;
    public Text name;
    public int countryId;
    public Image playerPhoto;
    public Image flag;
    // Use this for initialization
    void Start()
    {
    }

    void ToggleFace(bool showFace)
    {
        setSprite(++playerId);
    }

    void Awake()
    {

    }

    public void setSprite(int _playerId)
    {
        this.playerId = _playerId;
        this.player = PlayersRepository.PlayersRepository.getPlayerById(_playerId);
        this.attack.text = "Attack: " + player.attack;
        at = player.attack;
        this.defence.text = "Defence: " + player.defence;
        def = player.defence;
        this.name.text = player.name;
        this.countryId = player.countryId;
        playerPhoto.sprite = Resources.Load<Sprite>(name.text);
        flag.sprite = Resources.Load<Sprite>(countryId.ToString());
    }

    void OnMouseDown()
    {
       // setSprite(this.playerId + 1);
    }
}
