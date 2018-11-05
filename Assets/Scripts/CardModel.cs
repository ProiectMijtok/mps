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
    internal DropArea area;
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
        if(GameMaster.isRedCard)
            GetComponent<Draggable>().dp.remove(area);
        else if(GameMaster.yellowCardActive)
        {
            if (area == null)
                return;
            this.def -= 2;
            this.defence.text = "Defence: " + this.def;
            GetComponent<Draggable>().dp.changed(0, -2, area);
        }
        else if(GameMaster.isChange)
        {
            GetComponent<Draggable>().dp.change(this.gameObject);
        }
        else if(GameMaster.isFoul)
        {
            if (area == null)
                return;
            this.def -= 1;
            this.defence.text = "Defence: " + this.def;
            this.at -= 1;
            this.defence.text = "Attack: " + this.at;
            GetComponent<Draggable>().dp.changed(-1, -1, area);
        }
    }
}
