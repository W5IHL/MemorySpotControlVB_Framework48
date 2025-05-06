# MemorySpotControlVB_Framework48

**Version:** 1.4.0 **

Developed by **Rik (W5IHL)** with assistance from **Mac\*** (AI Assistant)
Thanks Richie (MW0LGE) for bringing the TCI protocol to life in Thetis.
Thanks Ernst  (OE3IDE) for your guidance.

MemorySpotControlVB is a Visual Basic .NET 4.8 application that reads station memories from `memory.xml` used by Thetis SDR software, and sends SPOT commands via TCI (Transceiver Control Interface) to display them on Thetis' panadapter.

## 🚀 Features
- Reads station frequencies and names from `memory.xml`.
- Sends SPOTs to Thetis via WebSocket (TCI Protocol).
- Supports customizable SPOT colors.
- Clear all SPOTs with one click.
- Simple UI for easy control.
- Compatible with Thetis v2.x using Default TCI at `127.0.0.1:50001`.

## 🎨 Supported Spot Colors
- Red
- Green (Dark Green)
- Blue
- Cyan
- Yellow
- Orange
- Magenta
- White
- Black


## ⚙️ Requirements
- Thetis SDR with TCI enabled
- WebSocket4Net library (already included via NuGet)
- Requires Windows 7 SP1 or later, with .NET Framework 4.8 installed

## 📂 How to Use
1. Launch Thetis and ensure TCI is running.
2. Start `MemorySpotControlVB`.
3. Set TCI parameter & save or leave at Default 127.0.0.1:50001
4. Select your desired SPOT color.
5. Click **Send Spots** to display memory spots on the panadapter.
6. Click **Clear Spots** to remove them.

## 📄 Note
- The app parses `memory.xml` located at: (located under %APPDATA%\OpenHPSDR\Thetis-x64\)
- SPOTs remain until cleared manually.

## 🚧 Future Improvements
- Implement XML sorting.
- Auto-refresh spots on `memory.xml` changes.

## 📜 License
This project is released under the MIT License.

---

Feel free to modify/add details like your call sign, screenshots, or specific usage notes!

---

