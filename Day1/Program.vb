Imports System.IO

Module Program
    Sub Main(args As String())

        Dim expenseReport As New List(Of Integer)
        For Each entry In File.ReadLines("input.txt")
            expenseReport.Add(Integer.Parse(entry))
        Next

        Console.WriteLine("Part 1: " & CalculatePart1(expenseReport).ToString())
        Console.WriteLine("Part 2: " & CalculatePart2(expenseReport).ToString())

    End Sub

    Function CalculatePart1(expenseReport As List(Of Integer)) As Integer

        For Each entry In expenseReport
            For Each entry2 In expenseReport
                If entry + entry2 = 2020 Then
                    Return entry * entry2
                End If
            Next
        Next

        Return 0

    End Function

    Function CalculatePart2(expenseReport As List(Of Integer)) As Integer

        For Each entry In expenseReport
            For Each entry2 In expenseReport
                For Each entry3 In expenseReport
                    If entry + entry2 + entry3 = 2020 Then
                        Return entry * entry2 * entry3
                    End If
                Next
            Next
        Next
        Return 0

    End Function
End Module
