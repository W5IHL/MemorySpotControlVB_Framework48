' Memory Spot Control for Thetis
' Sends spots to panadapter from memory.xml via TCI
' 2025/4
' Rik Herdell (W5IHL) & Mac*
' Thank you Richie (MW0LGE) for implementing TCI in Thetis
'
'
'
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports WebSocket4Net
Imports System.Linq
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class MemorySpotForm

    Private ws As WebSocket
    Private spotColor As String = "Red"
    Private sentSpots As New List(Of MemoryRecord)()

    ' Color Mapping
    Private thetisColorMap As New Dictionary(Of String, Integer) From {
        {"Red", 16711680},
        {"Green", 32768},
        {"Blue", 255},
        {"Cyan", 65535},
        {"Yellow", 16776960},
        {"Orange", 16753920},
        {"Magenta", 16711935},
        {"White", 16777215},
        {"Black", 0}
    }

    ' ▶️ On Form Load
    Private Sub MemorySpotForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim version As String = "v1.3"
        Me.Text = "Memory Spot Control " & version


        txtIpAddress.Text = My.Settings.TciIpAddress
        txtPort.Text = My.Settings.TciPort

        colorPicker.Items.Clear()
        colorPicker.Items.AddRange(thetisColorMap.Keys.ToArray())
        colorPicker.SelectedIndex = 0

        ReconnectWebSocket()
    End Sub

    ' 🔌 Reconnect WebSocket
    Private Sub ReconnectWebSocket()
        Try
            If ws IsNot Nothing Then
                ws.Dispose()
            End If

            ws = New WebSocket($"ws://{txtIpAddress.Text}:{txtPort.Text}")
            AddHandler ws.Opened, AddressOf Ws_Opened
            AddHandler ws.Error, AddressOf Ws_Error
            ws.Open()

            LogMessage($"Attempting connection to {txtIpAddress.Text}:{txtPort.Text}...", False)

        Catch ex As Exception
            LogMessage("❌ Reconnect failed: " & ex.Message, True)
            UpdateConnectionStatus("Reconnect Failed", Color.Red)
        End Try
    End Sub

    ' ✅ WebSocket Opened
    Private Sub Ws_Opened(sender As Object, e As EventArgs)
        UpdateConnectionStatus("Connected", Color.Green)
        LogMessage("✅ WebSocket connected!", False)
    End Sub

    ' ❌ WebSocket Error
    Private Sub Ws_Error(sender As Object, e As SuperSocket.ClientEngine.ErrorEventArgs)
        LogMessage("⚠️ WebSocket Error: " & e.Exception.Message, True)
        UpdateConnectionStatus("Error", Color.Red)
    End Sub

    ' ✏️ Color Picker Change
    Private Sub colorPicker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles colorPicker.SelectedIndexChanged
        spotColor = colorPicker.SelectedItem.ToString()
    End Sub

    ' 🚀 Send Spots
    Private Sub btnToggleSpots_Click(sender As Object, e As EventArgs) Handles btnToggleSpots.Click
        Try
            SendAllSpots()
        Catch ex As Exception
            LogMessage("❌ Exception in SendAllSpots: " & ex.Message, True)
            UpdateConnectionStatus("Send Error", Color.Red)
        End Try
    End Sub

    ' 🧹 Clear Spots
    Private Sub btnClearSpots_Click(sender As Object, e As EventArgs) Handles btnClearSpots.Click
        ClearAllSpots()
    End Sub

    ' 📂 Sort XML (not yet implemented)
    Private Sub btnSortXmlSpots_Click(sender As Object, e As EventArgs) Handles btnSortXmlSpots.Click
        LogMessage("🗂️ Sort button clicked. (Not implemented)", False)
    End Sub

    ' 🛟 Save Settings
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Try
            My.Settings.TciIpAddress = txtIpAddress.Text
            My.Settings.TciPort = txtPort.Text
            My.Settings.Save()

            LogMessage("✅ Settings saved successfully.", False)
            ReconnectWebSocket()

        Catch ex As Exception
            LogMessage("❌ Failed to save settings: " & ex.Message, True)
        End Try
    End Sub

    ' 🔥 Send All Spots
    '   SPOT:arg1,arg2,arg3,arg4,arg5; 
    '   arg1 - callsign, arg2 - mode type, arg3 - frequency, Hz, arg4 - ARGB color, arg5 - additional text 
    '
    Private Sub SendAllSpots()
        If ws.State = WebSocket4Net.WebSocketState.Open Then
            Dim spots = ParseMemoryXml()

            If spots.Count = 0 Then
                LogMessage("ℹ️ No spots found in memory.xml.", False)
                Return
            End If

            sentSpots = spots
            Dim thetisColor As Integer = If(thetisColorMap.ContainsKey(spotColor), thetisColorMap(spotColor), 255)

            For Each spot In spots
                Dim freqHz As Long = CLng(Double.Parse(spot.Frequency) * 1000000)
                '    Dim spotMessage = $"SPOT:{spot.Name},CWU-swl[0],{freqHz},{thetisColor},{spot.Name} (Spotter W5IHL);"
                '    Dim spotMessage = $"SPOT:{spot.Name},CWU-swl[0],{freqHz},{thetisColor},{spot.Name} (M.I.);"

                Dim spotMessage = $"SPOT:{spot.Name},{spot.Mode}-swl[0],{freqHz},{thetisColor},{spot.Name} (M.I.);"
                LogMessage($"Parsed spot: {spot.Name}, {spot.Frequency} MHz, Mode: {spot.Mode}")


                ws.Send(spotMessage)
            Next

            LogMessage($"✅ Sent {spots.Count} spots.", False)

        Else
            LogMessage("🚫 WebSocket is NOT open!", True)
        End If
    End Sub

    ' 🧹 Clear All Spots
    Private Sub ClearAllSpots()
        If ws.State = WebSocket4Net.WebSocketState.Open Then
            If sentSpots.Count = 0 Then
                LogMessage("ℹ️ No spots to clear.", False)
                Return
            End If

            For Each spot In sentSpots
                '          Dim freqHz As Long = CLng(Double.Parse(spot.Frequency) * 1000000)
                '          Dim clearMessage = $"SPOT:{spot.Name},CWU-swl[1],{freqHz},1,;"

                Dim clearMessage = $"SPOT_DELETE:{spot.Name};"

                ws.Send(clearMessage)
            Next

            LogMessage($"🧹 Cleared {sentSpots.Count} spots.", False)
            sentSpots.Clear()

        Else
            LogMessage("🚫 Cannot clear spots. WebSocket is not open.", True)
        End If
    End Sub

    ' 📂 Parse memory.xml
    Private Function ParseMemoryXml() As List(Of MemoryRecord)
        Dim records As New List(Of MemoryRecord)()
        Dim xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenHPSDR\Thetis-x64\memory.xml")

        If Not File.Exists(xmlPath) Then
            LogMessage("🚫 memory.xml not found at: " & xmlPath, True)
            Return records
        End If

        Try
            Dim doc As New XmlDocument()
            doc.Load(xmlPath)

            For Each node As XmlNode In doc.SelectNodes("//MemoryRecord")
                Dim freq = node.SelectSingleNode("RXFreq")?.InnerText
                Dim name = node.SelectSingleNode("Name")?.InnerText
                Dim mode = node.SelectSingleNode("DSPMode")?.InnerText

                If Not String.IsNullOrEmpty(freq) AndAlso Not String.IsNullOrEmpty(name) Then
                    records.Add(New MemoryRecord With {
                        .Frequency = freq,
                        .Name = name,
                        .Mode = If(String.IsNullOrEmpty(mode), "CWU", mode)   ' default to CWU if missing
                    })
                End If
            Next

        Catch ex As Exception
            LogMessage("❌ Error parsing memory.xml: " & ex.Message, True)
        End Try

        Return records
    End Function

    ' 🔹 Log Message (thread-safe)
    Private Sub LogMessage(message As String, Optional isError As Boolean = False)
        If txtLog.InvokeRequired Then
            txtLog.Invoke(Sub() LogMessage(message, isError))
        Else
            Dim prefix As String = If(isError, "❌ ", "ℹ️ ")
            txtLog.AppendText(prefix & message & Environment.NewLine)
        End If
    End Sub

    ' 🔹 Update Connection Status Label (thread-safe)
    Private Sub UpdateConnectionStatus(statusText As String, color As Color)
        If lblConnectionStatus.InvokeRequired Then
            lblConnectionStatus.Invoke(Sub() UpdateConnectionStatus(statusText, color))
        Else
            lblConnectionStatus.Text = statusText
            lblConnectionStatus.ForeColor = color
        End If
    End Sub

    ' 📄 Memory Record class
    Private Class MemoryRecord
        Public Property Frequency As String
        Public Property Name As String
        Public Property Mode As String
    End Class

End Class
