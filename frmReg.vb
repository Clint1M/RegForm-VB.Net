Imports System.IO
Imports System.Threading
Public Class frmReg
    Private Sub roundEdge(btN As Button)
        Dim radiuS As New Drawing2D.GraphicsPath
        radiuS.StartFigure()

        radiuS.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        radiuS.AddLine(10, 0, btN.Width - 20, 0)

        radiuS.AddArc(New Rectangle(btN.Width - 20, 0, 20, 20), -90, 90)
        radiuS.AddLine(btnSubmit.Width, 20, btN.Width, btN.Height - 10)

        radiuS.AddArc(New Rectangle(btN.Width - 25, btN.Height - 25, 25, 25), 0, 90)

        radiuS.AddLine(btN.Width - 10, btN.Width, 20, btN.Height)
        radiuS.AddArc(New Rectangle(0, btN.Height - 20, 20, 20), 90, 90)

        radiuS.CloseFigure()
        btnSubmit.Region = New Region(radiuS)
        btnCancel.Region = New Region(radiuS)
    End Sub
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
    Private Sub roundPan(panObj As Panel)
        Dim pRad As New Drawing2D.GraphicsPath
        pRad.StartFigure()

        pRad.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        pRad.AddLine(40, 0, panObj.Width - 40, 0)

        pRad.AddArc(New Rectangle(panObj.Width - 40, 0, 40, 40), -90, 90)
        pRad.AddLine(panObj.Width, 40, panObj.Width, panObj.Height - 40)

        pRad.AddArc(New Rectangle(panObj.Width - 40, panObj.Height - 40, 40, 40), 0, 90)
        pRad.AddLine(panObj.Width - 40, panObj.Height, 40, panObj.Height)

        pRad.AddArc(New Rectangle(0, panObj.Height - 40, 40, 40), 90, 90)

        pRad.CloseFigure()
        pnlReg.Region = New Region(pRad)
    End Sub
    Private Sub frmReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundEdge(btnSubmit)
        Thread.Sleep(100)
        roundForm(Me)
        Thread.Sleep(100)
        roundPan(pnlReg)

        Call FadeIn()
    End Sub
    Private Sub FadeIn()
        For ins = 0.0 To 1.0 Step 0.1
            Me.Opacity = ins
            Me.Refresh()
            Threading.Thread.Sleep(1)
        Next
    End Sub
    Private Sub FadeOut()
        For out = 90 To 10 Step -10
            Me.Opacity = out / 100
            Me.Refresh()
            Threading.Thread.Sleep(1)
        Next
    End Sub
    Public Sub FadeNext()
        frmConfirm.Opacity = 0
        frmConfirm.Show()

        For insTwo = 0.0 To 1.0 Step 0.1
            frmConfirm.Opacity = insTwo
            frmConfirm.Refresh()
            Threading.Thread.Sleep(1)
        Next
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call FadeOut()
        Application.Exit()
    End Sub
    Public Sub writeInfo()
        If txtPassword.Text = txtCPassword.Text Then
            Try
                Dim temP As String
                temP = txtName.Text & "," & txtAge.Text & "," & txtAddress.Text & "," & txtPassword.Text
                Dim mystreaM As StreamReader
                mystreaM = New StreamReader("C:\Users\HP\Documents\C\SV\RegistrationForm\Database\dtBase.csv")

                Do While Not mystreaM.EndOfStream
                    mystreaM.ReadLine()
                    If temP = mystreaM.ReadLine Then
                        MsgBox("Account already registered", MsgBoxStyle.OkOnly, "Done registration")

                        Call FadeOut()
                        Environment.Exit(0)
                    Else
                        '
                    End If
                Loop
                mystreaM.Close()
                Thread.Sleep(100)
            Catch ex As Exception
                MsgBox("Please close all Excel Files", vbOKOnly, "Error")
                Call FadeOut()
                Environment.Exit(0)
            End Try

            Dim sW As StreamWriter
            sW = New StreamWriter("C:\Users\HP\Documents\C\SV\RegistrationForm\Database\dtBase.csv", True)
            sW.Write(vbNewLine)
            sW.Write(txtName.Text & "," & txtAge.Text & "," & txtAddress.Text & "," & txtPassword.Text)
            sW.Close()
            txtName.Text = ""
            txtAge.Text = ""
            txtAddress.Text = ""
            txtPassword.Text = ""
            txtCPassword.Text = ""

            Thread.Sleep(100)
            Call FadeOut()
            Me.Hide()
            Call FadeNext()
            frmConfirm.Show()
        Else
            If MsgBox("Review Password?", MsgBoxStyle.YesNo, "Password does not match") = vbYes Then
                    '
                Else
                    txtPassword.Text = ""
                    txtCPassword.Text = ""
                End If
            End If
        End Sub
        Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
            If Not Directory.Exists("C:\Users\HP\Documents\C\SV\RegistrationForm\Database\") Then
                MsgBox("newone")
                Directory.CreateDirectory("C:\Users\HP\Documents\C\SV\RegistrationForm\Database\")

                Dim firStream As StreamWriter
                firStream = New StreamWriter("C:\Users\HP\Documents\C\SV\RegistrationForm\Database\dtBase.csv", True)
                firStream.Write("Accounts")
                Thread.Sleep(100)
                firStream.Close()

                writeInfo()
            Else
                writeInfo()
            End If

            Thread.Sleep(100)
        End Sub
        Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAge.KeyPress
            'If Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 90 _
            '    And Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122 Then
            '    e.Handled = True
            'Else
            '    e.Handled = False
            'End If
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            Else
                e.Handled = False
            End If

            If Asc(e.KeyChar) = 8 Then
                e.Handled = False
            End If
        End Sub
    End Class
