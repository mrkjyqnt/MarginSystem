Imports System.Reflection.Emit

Public Class ViewMoreForm
    Private Sub BackLabel_MouseEnter(sender As Object, e As EventArgs) Handles BackLabel.MouseEnter

        BackLabel.Font = New Font("Inter Black", 20)
        BackLabel2.Location = New point(390, 0)

        If BackLabel2.Text = ">  Sales Valuation" then

            label1.Location = New point(699, 0)

        ElseIf BackLabel2.Text = ">  Inventory Valuation" then

            label1.Location = New point(764, 0)

        Else

            label1.Location = New point(600, 0)


        End If

    End Sub

    Private Sub BackLabel_MouseLeave(sender As Object, e As EventArgs) Handles BackLabel.MouseLeave

        BackLabel.Font = New Font("Inter SemiBold", 20)
        BackLabel2.Location = New point(375, 0)

        If BackLabel2.Text = ">  Sales Valuation" then

            label1.Location = New point(683, 0)

        ElseIf BackLabel2.Text = ">  Inventory Valuation" then

            label1.Location = New point(748, 0)

        Else

            label1.Location = New point(586, 0)


        End If

    End Sub

    Private Sub BackLabel_Click(sender As Object, e As EventArgs) Handles BackLabel.Click

        If BackLabel.Text = "Valuation and Reports"

            MainForm.ValuationReportsFormPanel.Controls.Clear
            GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", ValuationAndReports, MainForm.ValuationReportsFormPanel)

        End If

    End Sub

    Private Sub BackLabel2_MouseEnter(sender As Object, e As EventArgs) Handles BackLabel2.MouseEnter

        BackLabel2.Font = New Font("Inter Black", 20)

        If BackLabel2.Text = ">  Activities"

            Label1.Location = New Point(598, 0)

        ElseIf BackLabel2.Text = ">  Inventory Valuation"

            Label1.Location = New Point(765, 0)

        ElseIf BackLabel2.Text = ">  Sales Valuation"

            Label1.Location = New Point(695, 0)

        End If

    End Sub

    Private Sub BackLabel2_MouseLeave(sender As Object, e As EventArgs) Handles BackLabel2.MouseLeave

        BackLabel2.Font = New Font("Inter Semibold", 20)

        If BackLabel2.Text = ">  Activities"

            Label1.Location = New Point(588, 0)

        ElseIf BackLabel2.Text = ">  Inventory Valuation"

            Label1.Location = New Point(748, 0)

        ElseIf BackLabel2.Text = ">  Sales Valuation"

            Label1.Location = New Point(683, 0)

        End If

    End Sub

    Private Sub ViewMoreForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BackLabel2_Click(sender As Object, e As EventArgs) Handles BackLabel2.Click

        MainForm.ValuationReportsFormPanel.Controls.Clear

        If BackLabel2.Text = ">  Activities"

            GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", Activities, MainForm.ValuationReportsFormPanel)

        ElseIf BackLabel2.Text = ">  Inventory Valuation"

            GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", InventoryValuation, MainForm.ValuationReportsFormPanel)

        ElseIf BackLabel2.Text = ">  Sales Valuation"

            GeneralModule.ChooseNavigation(MainForm.ValuationAndReportsPanel, MainForm.ValuationAndReportsButton, "Hovered", "Calculator", GeneralModule.ButtonDictionary, "Valuation and Reports", SalesValuation, MainForm.ValuationReportsFormPanel)

        End If

    End Sub
End Class