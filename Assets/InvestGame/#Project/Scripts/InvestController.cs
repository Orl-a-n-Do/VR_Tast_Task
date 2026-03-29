public class InvestController : Singletone<InvestController> {
	public QuestListAsset asset;
	public StatValueAsset startMoney;

	private QuestAsset _quest;

	public QuestAsset Quest => _quest;

	protected override void Awake() {
		base.Awake();
		_quest = asset.GetAsset();
	}

	public void SelectType(StatType type) {
		CurrencySystem.instance.BuyProduct(type);
	}
}
