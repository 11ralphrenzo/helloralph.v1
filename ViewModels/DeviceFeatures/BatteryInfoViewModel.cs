using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace helloralph.ViewModels
{
    public partial class BatteryInfoViewModel : BaseViewModel
    {
        public BatteryInfoViewModel()
        {
            Title = Constants.BATTERY_INFO;
            Setup();

            ToggledCommand = new Command(
                execute: (object t) => Check(t));
        }

        [ObservableProperty]
        ObservableCollection<BatteryInfoModel> batteryInfos = new ObservableCollection<BatteryInfoModel>();

        public ICommand ToggledCommand { get; set; }

        [ObservableProperty]
        FormattedString formattedStatus = new FormattedString();

        [ObservableProperty]
        FormattedString formattedLowPower = new FormattedString();

        [ObservableProperty]
        FormattedString formattedPowerSource = new FormattedString();

        [ObservableProperty]
        private bool isBatteryChecking;

        [ObservableProperty]
        private bool isOnPowerSavingMode;

        [ObservableProperty]
        private string powerSource;

        void Setup()
        {
            batteryInfos.Add(new BatteryInfoModel { Name = "Toggle to Check", Value = "Battery Status", HasToggle = true, Tag = Enums.BatteryFeatureType.Status });
            batteryInfos.Add(new BatteryInfoModel { Name = "Toggle to Check", Value = "Low-power Mode", HasToggle = true, Tag = Enums.BatteryFeatureType.LowPower });
            batteryInfos.Add(new BatteryInfoModel { Name = "Toggle to Check", Value = "Power Source", HasToggle = true, Tag = Enums.BatteryFeatureType.PowerSource });
        }

        void Check(object t)
        {
            switch ((Enums.BatteryFeatureType)t)
            {
                case Enums.BatteryFeatureType.Status:
                    {
                        if (!isBatteryChecking)
                            Battery.Default.BatteryInfoChanged += Battery_BatteryInfoChanged;
                        else
                            Battery.Default.BatteryInfoChanged -= Battery_BatteryInfoChanged;
                        isBatteryChecking = !isBatteryChecking;
                    }
                    break;
                case Enums.BatteryFeatureType.LowPower:
                    {
                        IsOnPowerSavingMode = Battery.Default.EnergySaverStatus == EnergySaverStatus.On;
                        UpdateFormattedString(Enums.BatteryFeatureType.LowPower);
                        Battery.Default.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
                    }
                    break;
                case Enums.BatteryFeatureType.PowerSource:
                    {
                        PowerSource = Battery.Default.PowerSource switch
                        {
                            BatteryPowerSource.Wireless => "Wireless charging",
                            BatteryPowerSource.Usb => "USB cable charging",
                            BatteryPowerSource.AC => "Device is plugged in to a power source",
                            BatteryPowerSource.Battery => "Device isn't charging",
                            _ => "Unknown"
                        };
                        UpdateFormattedString(Enums.BatteryFeatureType.PowerSource);
                    }
                    break;
            }
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            var newString = new FormattedString();
            var state = e.State switch
            {
                BatteryState.Charging => "Battery is currently charging.",
                BatteryState.Discharging => "Charger is not connected and the battery is discharging.",
                BatteryState.Full => "Battery is full.",
                BatteryState.NotCharging => "The battery isn't charging.",
                BatteryState.NotPresent => "Battery is not available.",
                BatteryState.Unknown => "Battery is unknown.",
                _ => "Battery is unknown"
            };
            newString.Spans.Add(new Span { Text = state + Constants.NEWLINE });
            newString.Spans.Add(new Span { Text = $"Battery is {e.ChargeLevel * 100}% charged." });
            FormattedStatus = newString;
        }

        void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
        {
            // Update the variable based on the state
            IsOnPowerSavingMode = Battery.Default.EnergySaverStatus == EnergySaverStatus.On;
            UpdateFormattedString(Enums.BatteryFeatureType.LowPower);
        }

        void UpdateFormattedString(Enums.BatteryFeatureType type)
        {
            var newString = new FormattedString();
            switch (type)
            {
                case Enums.BatteryFeatureType.LowPower:
                    newString.Spans.Add(new Span { Text = $"Power Saving is { (IsOnPowerSavingMode ? "enabled" : "disabled") }." });
                    FormattedLowPower = newString;
                    break;
                case Enums.BatteryFeatureType.PowerSource:
                    newString.Spans.Add(new Span { Text = PowerSource });
                    FormattedPowerSource = newString;
                    break;
            }
        }
    }
}
