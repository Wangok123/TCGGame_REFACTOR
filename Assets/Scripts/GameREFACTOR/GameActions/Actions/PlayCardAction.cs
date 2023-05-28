using GameREFACTOR.Data.Cards;

namespace GameREFACTOR.GameActions.Actions
{
	public class PlayCardAction : GameAction {
		
		public Card card;

		public PlayCardAction(Card card) {
			this.card = card;
		}
	}
}
