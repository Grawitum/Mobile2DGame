using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards
{
    internal class ContainerSlotRewardView : MonoBehaviour
    {
        [SerializeField] private Image _originalBackground;
        [SerializeField] private Image _selectBackground;
        [SerializeField] private Image _iconCurrency;
        [SerializeField] private TMP_Text _textDays;
        [SerializeField] private TMP_Text _countReward;

        public void SetData(Reward reward, int countDay, bool isSelect,RewardTimeType rewardTimeType)
        {
            _iconCurrency.sprite = reward.IconCurrency;
            switch (rewardTimeType)
            {
                case RewardTimeType.Day:  _textDays.text = $"Day {countDay}"; break;
                case RewardTimeType.Week: _textDays.text = $"Week {countDay}"; break;
            }
            _countReward.text = reward.CountCurrency.ToString();

            _originalBackground.gameObject.SetActive(!isSelect);
            _selectBackground.gameObject.SetActive(isSelect);
        }
    }
}
