using GameREFACTOR.Data;
using UnityEngine;

namespace GameREFACTOR.Views.Game
{
    public class PlayerView : MonoBehaviour
    {
        public DeckView deck;

        public HandView hand;
        // public TableView table;
        // public HeroView hero;
        public GameObject cardPrefab;
        public Player Player { get; private set; }

        public void SetPlayer(Player player)
        {
            this.Player = player;
            // var heroCard = player.hero [0] as Hero;
            // hero.SetHero (heroCard);
        }
    }
}