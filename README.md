# MemorySpotControlVB_Framework48

**Version:** 1.2 **

Developed by **Rik (W5IHL)** with assistance from **Mac\*** (AI Assistant)
Thanks Richie (MW0LGE) for bringing the TCI protocol to life on Thetis.

MemorySpotControlVB is a Visual Basic .NET 4.8 application that reads station memories from `memory.xml` used by Thetis SDR software, and sends SPOT commands via TCI (Transceiver Control Interface) to display them on Thetis' panadapter.

## 🚀 Features
- Reads station frequencies and names from `memory.xml`.
- Sends SPOTs to Thetis via WebSocket (TCI Protocol).
- Supports customizable SPOT colors.
- Clear all SPOTs with one click.
- Simple UI for easy control.
- Compatible with Thetis v2.x using TCI at `127.0.0.1:50001`.

## 🎨 Supported Spot Colors
- Red
- Green (Dark Green)
- Blue
- Yellow
- Magenta
- Cyan
- White
- Black
- Orange

## ⚙️ Requirements
- .NET Framework 4.8
- Thetis SDR with TCI enabled (`Settings` > `TCI` > Port 50001)
- WebSocket4Net library (already included via NuGet)

## 📂 How to Use
1. Launch Thetis and ensure TCI is running.
2. Start `MemorySpotControlVB`.
3. Select your desired SPOT color.
4. Click **Send Spots** to display memory spots on the panadapter.
5. Click **Clear Spots** to remove them.

## 📄 Note
- The app parses `memory.xml` located at: C:\Users<YourUsername>\AppData\Roaming\OpenHPSDR\Thetis-x64\memory.xml


- SPOTs remain until cleared manually.

## 🚧 Future Improvements
- Implement XML sorting.
- Auto-refresh spots on `memory.xml` changes.
- Configurable TCI settings.

## 📜 License
This project is released under the MIT License.

---

Feel free to modify/add details like your call sign, screenshots, or specific usage notes!

---

