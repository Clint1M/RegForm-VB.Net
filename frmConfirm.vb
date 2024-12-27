Imports System.Threading
Public Class frmConfirm
    Private Sub roundForm(obJ As Form)
        Dim fRad As New Drawing2D.GraphicsPath
        fRad.StartFigure()

        fRad.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        fRad.AddLine(40, 0, obJ.Width - 40, 0)

        fRad.AddArc(New Rectangle(obJ.Width - 40, 0, 40, 40), -90, 90)
        fRad.AddLine(obJ.Width, 40, obJ.Width, obJ.Height - 40)

        fRad.AddArc(New Rectangle(obJ.Width - 40, obJ.Height - 40, 40, 40), 0, 90)
        fRad.AddLine(obJ.Width - 40, obJ.Height, 40, obJ.Height)

        fRad.AddArc(New Rectangle(0, obJ.Height - 40, 40, 40), 90, 90)

        fRad.CloseFigure()
        Me.Region = New Region(fRad)
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Call FadeOut()
        Application.Exit()
    End Sub
    Private Sub roundEdge(btN As Button)
        Dim radiuS As New Drawing2D.GraphicsPath
        radiuS.StartFigure()

        radiuS.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        radiuS.AddLine(10, 0, btN.Width - 20, 0)

        radiuS.AddArc(New Rectangle(btN.Width - 20, 0, 20, 20), -90, 90)
        radiuS.AddLine(btnExit.Width, 20, btN.Width, btN.Height - 10)

        radiuS.AddArc(New Rectangle(btN.Width - 25, btN.Height - 25, 25, 25), 0, 90)

        radiuS.AddLine(btN.Width - 10, btN.Width, 20, btN.Height)
        radiuS.AddArc(New Rectangle(0, btN.Height - 20, 20, 20), 90, 90)

        radiuS.CloseFigure()
        btnExit.Region = New Region(radiuS)
    End Sub
    Private Sub frmConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmReg.Hide()
        Thread.Sleep(100)
        roundForm(Me)
        Thread.Sleep(100)
        roundEdge(btnExit)
        Thread.Sleep(100)
    End Sub
    Private Sub FadeOut()
        For out = 90 To 10 Step -10
            Me.Opacity = out / 100
            Me.Refresh()
            Threading.Thread.Sleep(1)
        Next
    End Sub
End Class