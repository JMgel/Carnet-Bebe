# Carnet-Bebe.MAUI

A lightweight and minimalist cross-platform mobile app built with .NET MAUI for tracking daily baby events such as feeding, sleep, and diaper changes. Designed for simplicity and speed, with an intuitive interface and local data persistence using SQLite.

## ✨ Features

Track six key baby-related events:

- Diaper change (💩, 💧)
- Sleep (🛏️)
- Wake up (🌞)
- Breastfeeding (🤱 Left / Right)

Additional features:

- Timestamp each event using a time picker  
- Events are stored locally using SQLite  
- View all logged events in a scrollable `CollectionView`  
- Swipe left on an event to delete it  
- A secondary page displays a tabular summary of sleep periods  

## 📱 UI Overview

**Main Screen:**  
Six buttons represent different baby events. Users can log an event at the current or selected time using the built-in time picker.

**History List:**  
A scrollable list (`CollectionView`) showing all logged events in chronological order. Swipe left to remove an entry.

**Dodo Infos:**  
A separate page providing a structured overview of sleep and wake events in a table format.

## 🛠️ Technologies

- .NET MAUI (Multi-platform App UI)  
- SQLite via `sqlite-net`  
- MVVM architecture  

## 🧠 Data Model

Minimalist schema:

- `EventLogEntry` — stores: `EventType` (enum), `Timestamp` (DateTime)  
- `SleepingData` — stores: `AwakeTime` (string), `SleepingTime` (string), `Difference` (string)  

## 📂 Project Structure

```plaintext
App.MAUI/
│
├── Components/
│   └── ButtonsAndLine.xaml
│
├── Models/
│   ├── EventLogEntry.cs
│   └── SleepingData.cs
│
├── Views/
│   ├── MainPage.xaml
│   └── SleepingPage.xaml
│
├── ViewModels/
│   ├── MainViewModel.cs
│   └── SleepingViewModel.cs
│
├── Services/
│   ├── DatabaseService.cs
│   └── ImagePaths.cs (static)
│
└── App.xaml
```
## 🖼️ Screenshots

<div align="center">
  <img src="https://github.com/user-attachments/assets/158b1bd8-ca89-42c3-bf27-60fe33a3dbac" alt="MainView" width="45%" />
  <img src="https://github.com/user-attachments/assets/f43a32d3-9c47-4a0f-9506-a78b8a65dc39" alt="Dodo" width="45%" />
</div>
