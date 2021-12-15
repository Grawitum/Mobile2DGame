using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Notifications.Android;
using UnityEngine.UI;


public class NotificationWindow : MonoBehaviour
{
    private const string AndroidNotifierId = "android_notifier_id";

    [SerializeField]
    private Button _buttonNotification;

    private void Start()
    {
        _buttonNotification.onClick.AddListener(CreateMyNewNotification);
    }

    private void OnDestroy()
    {
        _buttonNotification.onClick.RemoveAllListeners();
    }

    private void CreateMyNewNotification()
    {
#if UNITY_ANDROID
        var androidSettingsChanel = new AndroidNotificationChannel
        {
            Id = AndroidNotifierId,
            Name = "MyNotifier",
            Importance = Importance.Low,
            CanBypassDnd = false,
            CanShowBadge = false,
            Description = "MyText",
            EnableLights = false,
            EnableVibration = false,
            LockScreenVisibility = LockScreenVisibility.Private
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);

        var androidSettingsNotification = new AndroidNotification
        {
            Color = Color.red,
            RepeatInterval = TimeSpan.FromSeconds(60),
            FireTime = DateTime.Today
        };

        AndroidNotificationCenter.SendNotification(androidSettingsNotification, AndroidNotifierId);
#elif UNITY_IOS
       var iosSettingsNotification = new iOSNotification
       {
           Identifier = "android_notifier_id",
           Title = "MyNotifier",
           Subtitle = "Subtitle notifier",
           Body = "MyText",
           Badge = 1,
           Data = "12/12/2021",
           ForegroundPresentationOption = PresentationOption.Alert,
           ShowInForeground = false
       };
      
       iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
    }

}
