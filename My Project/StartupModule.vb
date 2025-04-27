Imports System.Windows.Forms

Module StartupModule
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MemorySpotForm())
    End Sub
End Module

