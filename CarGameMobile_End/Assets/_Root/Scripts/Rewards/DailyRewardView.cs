using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards
{
    internal class DailyRewardView : MonoBehaviour
    {
        private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
        private const string TimeGetRewardKey = nameof(TimeGetRewardKey);
        private const float DayTimeCooldown = 86400;
        private const float DayTimeDeadline = 172800;
        private const float WeekTimeCooldown = 604800;
        private const float WeekTimeDeadline = 1209600;

        [field: Header("Settings Time Get Reward")]
        [field: SerializeField] public RewardTimeType RewardTimeType { get; private set; } = RewardTimeType.Day;
        [field: HideInInspector] public float TimeCooldown { get; private set; } = DayTimeCooldown;
        [field: HideInInspector] public float TimeDeadline { get; private set; } = DayTimeDeadline;

        [field: Header("Settings Rewards")]
        [field: SerializeField] public List<Reward> Rewards { get; private set; }

        [field: Header("Ui Elements")]
        [field: SerializeField] public TMP_Text TimerNewReward { get; private set; }
        [field: SerializeField] public Transform MountRootSlotsReward { get; private set; }
        [field: SerializeField] public ContainerSlotRewardView ContainerSlotRewardPrefab { get; private set; }
        [field: SerializeField] public Button GetRewardButton { get; private set; }
        [field: SerializeField] public Button ResetButton { get; private set; }

        private void Start()
        {
            switch (RewardTimeType)
            {
                case RewardTimeType.Day: 
                    TimeCooldown = DayTimeCooldown;
                    TimeDeadline = DayTimeDeadline;
                    break;
                case RewardTimeType.Week:
                    TimeCooldown = WeekTimeCooldown;
                    TimeDeadline = WeekTimeDeadline;
                    break;
            }
        }

        public int CurrentSlotInActive
        {
            get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
            set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
        }

        public DateTime? TimeGetReward
        {
            get
            {
                string data = PlayerPrefs.GetString(TimeGetRewardKey, null);
                return !string.IsNullOrEmpty(data) ? (DateTime?)DateTime.Parse(data) : null;
            }
            set
            {
                if (value != null)
                    PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(TimeGetRewardKey);
            }
        }
    }
}
