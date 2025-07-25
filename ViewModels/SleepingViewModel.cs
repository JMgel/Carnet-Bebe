﻿using CarnetBebe.Models;
using CarnetBebe.Services;
using System.Collections.ObjectModel;

namespace CarnetBebe.ViewModels
{
    public class SleepingViewModel
    {
        public string ArrayName { get; init; }
        public ObservableCollection<SleepingData> SleepingDatas { get; set; }

        public SleepingViewModel(IDatabaseService databaseService)
        {
            ArrayName = $"Phases d'éveil du {DateTime.Today:dd/MM}";
            var dailySleepingEvents = databaseService.GetDailyEntries(EventType.WakingUp);
            dailySleepingEvents = dailySleepingEvents.OrderBy(dl => dl.Timestamp).ToArray();
            SleepingDatas = ExtractSleepingDatas(dailySleepingEvents);
        }

        private static ObservableCollection<SleepingData> ExtractSleepingDatas(ReadOnlySpan<EventLogEntry> elements)
        {
            var awake = new List<DateTime>();
            var sleeping = new List<DateTime>();

            foreach (var entry in elements)
            {
                if (entry.EventType == EventType.WakingUp)
                { 
                    awake.Add(entry.Timestamp);
                }
                else
                {
                    sleeping.Add(entry.Timestamp);
                }
            }

            int maxCount = Math.Max(awake.Count, sleeping.Count);
            int minCount = Math.Min(awake.Count, sleeping.Count);


            ObservableCollection<SleepingData> sleepinDatas = [];

            for (int i = 0; i < minCount; i++)
            {
                double diffMinutes = (sleeping[i] - awake[i]).TotalMinutes;
                sleepinDatas.Add(new SleepingData
                {
                    AwakeTime = awake[i].ToString("HH:mm"),
                    SleepingTime = sleeping[i].ToString("HH:mm"),
                    Difference = diffMinutes.ToString("F0") + " min"
                });
            }
            for (int i = minCount; i < maxCount; i++)
            {
                string awakingHour = string.Empty;
                string sleepingHour = string.Empty;
                if (i < awake.Count) 
                {
                    awakingHour = awake[i].ToString("HH:mm");
                }
                else
                {
                    sleepingHour = sleeping[i].ToString("HH:mm");
                }
                sleepinDatas.Add(new SleepingData
                {
                    AwakeTime = awakingHour,
                    SleepingTime = sleepingHour,
                    Difference = "00 min"
                });
            }
            return sleepinDatas;
        }
    }
}

