Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports WebSocket4Net
Imports System.Linq
Imports System.Drawing

Public Class MemorySpotForm

    Private ws As WebSocket
    Private spotColor As String = "Red"  ' Default color name
    Private sentSpots As List(Of MemoryRecord) = New List(Of MemoryRecord)()

    ' Thetis-safe BGR color mapping
    Private thetisColorMap As New Dictionary(Of String, Integer) From {
        {"Red", 16711680},
        {"Green", 32768},         ' Dark Green
        {"Blue", 255},
        {"Yellow", 16776960},
        {"Orange", 16753920},
        {"Magenta", 16711935},
        {"White", 16777215},
        {"Black", 0},
        {"Cyan", 16711935}
    }

    ' ==== Form Load ====
    Private Sub MemorySpotForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 🔹 Set manual version number in window title
        Dim version As String = "v1.2"
        Me.Text = "Memory Spot Control " & version

        ' Set version label text
        lblVersion.Text = "Version " & version

        ' Center the version label under the title bar
        lblVersion.Location = New Point((Me.ClientSize.Width - lblVersion.Width) \ 2, 5)

        ' WebSocket setup
        ws = New WebSocket("ws://127.0.0.1:50001")
        AddHandler ws.Opened, AddressOf Ws_Opened
        AddHandler ws.Error, AddressOf Ws_Error
        ws.Open()

        ' Populate color picker
        colorPicker.Items.Clear()
        colorPicker.Items.AddRange(thetisColorMap.Keys.ToArray())
        colorPicker.SelectedIndex = 0
    End Sub




    ' ==== WebSocket Events ====
    Private Sub Ws_Opened(sender As Object, e As EventArgs)
        '   MessageBox.Show("✅ Connected to Thetis TCI!")
    End Sub

    Private Sub Ws_Error(sender As Object, e As SuperSocket.ClientEngine.ErrorEventArgs)
        MessageBox.Show("WebSocket Error: " & e.Exception.Message)
    End Sub

    ' ==== Color Picker Change ====
    Private Sub colorPicker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles colorPicker.SelectedIndexChanged
        spotColor = colorPicker.SelectedItem.ToString()
    End Sub

    ' ==== Send Spots Button ====
    Private Sub btnToggleSpots_Click(sender As Object, e As EventArgs) Handles btnToggleSpots.Click
        Try
            SendAllSpots()
        Catch ex As Exception
            MessageBox.Show("❌ Exception in SendAllSpots: " & ex.Message)
        End Try
    End Sub

    ' ==== Clear Spots Button ====
    Private Sub btnClearSpots_Click(sender As Object, e As EventArgs) Handles btnClearSpots.Click
        ClearAllSpots()
    End Sub

    ' ==== Sort XML Button ====
    Private Sub btnSortXmlSpots_Click(sender As Object, e As EventArgs) Handles btnSortXmlSpots.Click
        MessageBox.Show("🗂️ Sort button clicked! (Sorting not yet implemented)")
    End Sub

    ' ==== Send Spots Logic ====
    Private Sub SendAllSpots()
        Try
            If ws.State = WebSocket4Net.WebSocketState.Open Then
                Dim spots = ParseMemoryXml()

                If spots.Count = 0 Then
                    MessageBox.Show("No spots found in memory.xml.")
                    Return
                End If

                sentSpots = spots

                Dim thetisColor As Integer = If(thetisColorMap.ContainsKey(spotColor), thetisColorMap(spotColor), 255)

                For Each spot In spots
                    Dim freqHz As Long = CLng(spot.Frequency * 1000000)
                    Dim spotMessage = $"SPOT:{spot.Name},{spot.DSPMode}-swl[0],{freqHz},{thetisColor},{spot.Name} (Spotter W5IHL);"

                    ws.Send(spotMessage)
                Next

                '              MessageBox.Show($"✅ Sent {spots.Count} spots to Thetis.")
            Else
                MessageBox.Show("🚫 WebSocket is NOT open!")
            End If
        Catch ex As Exception
            MessageBox.Show("❌ Exception in SendAllSpots(): " & ex.Message)
        End Try
    End Sub

    ' ==== Clear Spots Logic ====
    Private Sub ClearAllSpots()
        Try
            If ws.State = WebSocket4Net.WebSocketState.Open Then
                If sentSpots.Count = 0 Then
                    MessageBox.Show("ℹ️ No spots to clear.")
                    Return
                End If

                For Each spot In sentSpots
                    Dim clearMessage = $"SPOT:{spot.Name},CWU-swl[1],{CLng(spot.Frequency * 1000000)},1,;"
                    ws.Send(clearMessage)
                Next

                ' MessageBox.Show($"🧹 Cleared {sentSpots.Count} spots from Thetis.")
                sentSpots.Clear()
            Else
                MessageBox.Show("🚫 Cannot clear spots. WebSocket is not open.")
            End If
        Catch ex As Exception
            MessageBox.Show("❌ Error while clearing spots: " & ex.Message)
        End Try
    End Sub

    ' ==== Memory Record Class ====
    Private Class MemoryRecord
        Public Property Frequency As String
        Public Property Name As String
        Public Property DSPMode As String
    End Class

    ' ==== Parse memory.xml ====
    Private Function ParseMemoryXml() As List(Of MemoryRecord)
        Dim records As New List(Of MemoryRecord)()
        Dim xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenHPSDR\Thetis-x64\memory.xml")

        If Not File.Exists(xmlPath) Then
            MessageBox.Show("🚫 memory.xml not found at: " & xmlPath)
            Return records
        End If

        Try
            Dim doc As New XmlDocument()
            doc.Load(xmlPath)

            For Each node As XmlNode In doc.SelectNodes("//MemoryRecord")
                Dim freq = node.SelectSingleNode("RXFreq")?.InnerText
                Dim name = node.SelectSingleNode("Name")?.InnerText
                Dim mode = node.SelectSingleNode("DSPMode")?.InnerText

                If Not String.IsNullOrEmpty(freq) AndAlso Not String.IsNullOrEmpty(name) AndAlso Not String.IsNullOrEmpty(mode) Then
                    records.Add(New MemoryRecord With {.Frequency = freq, .Name = name, .DSPMode = mode})
                End If
            Next


        Catch ex As Exception
            MessageBox.Show("❌ Error parsing XML: " & ex.Message)
        End Try

        Return records
    End Function

End Class
