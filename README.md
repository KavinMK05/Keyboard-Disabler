# ⌨️ Keyboard Disabler

![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=flat-square&logo=windows)
![Framework](https://img.shields.io/badge/.NET-Framework%204.7.2-512BD4?style=flat-square&logo=dotnet)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

A lightweight, system-tray utility built with **C#** and **WPF** that allows you to temporarily disable your keyboard input. Perfect for cleaning your keyboard, preventing accidental key presses by pets/kids, or watching media without interruptions.

## ✨ Features

* **🔒 Total Lockdown:** Blocks all low-level keyboard input using Windows API hooks.
* **👻 Background Operation:** Runs silently in the system tray (notification area) without cluttering your taskbar.
* **⚡ Quick Toggle:** Easily enable or disable the keyboard via a simple context menu.
* **🚀 Lightweight:** Built on the .NET Framework 4.7.2 for minimal resource usage.

## 🛠️ Installation

### Pre-requisites
* Windows OS
* .NET Framework 4.7.2 Runtime

### Build from Source
1.  Clone the repository:
    ```bash
    git clone [https://github.com/kavinmk05/keyboard-disabler.git](https://github.com/kavinmk05/keyboard-disabler.git)
    ```
2.  Open `Keyboard_Disabler.sln` in **Visual Studio 2019/2022**.
3.  Restore NuGet packages.
4.  Build the solution in `Release` mode.

## 📖 Usage

1.  Run the application (`Keyboard_Disabler.exe`).
2.  The app will start minimized to the **System Tray** (near your clock).
3.  **Right-click** the tray icon to open the menu:
    * 🚫 **Disable Keyboard**: Locks all key presses.
    * ✅ **Enable Keyboard**: Restores normal keyboard functionality.
    * ❌ **Exit**: Re-enables the keyboard (if disabled) and closes the application.

> **Note:** Since this application uses low-level system hooks to intercept input, it may require Administrator privileges depending on your security settings.

## 💻 Tech Stack

* **Language:** C#
* **UI Framework:** WPF (Windows Presentation Foundation)
* **System API:** `user32.dll` (Win32 API for `SetWindowsHookEx`)
* **Libraries:**
    * `System.Reactive`
    * `System.Drawing.Common`

## 🤝 Contributing

Contributions are welcome! Please follow these steps:
1.  Fork the project.
2.  Create your feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE.txt) file for details.

---

<p align="center">
  Made with ❤️ by <a href="https://github.com/kavinmk05">kavinmk05</a>
</p>
