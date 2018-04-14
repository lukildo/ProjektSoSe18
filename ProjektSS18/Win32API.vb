Imports System.Runtime.InteropServices

'user32 Funktion zur Fenstererkennung importieren
Module Win32API
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Friend Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Friend Function GetDlgItem(ByVal hDlg As IntPtr, id As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Friend Function SetForegroundWindow(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Friend Function SetActiveWindow(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Friend Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function

    Friend Const BM_CLICK As Integer = &HF5
End Module
