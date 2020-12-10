Imports System.IO

Module Program
    Sub Main(args As String())
        Dim adapters As New List(Of Integer)
        For Each line In File.ReadAllLines("input.txt")
            If Not String.IsNullOrWhiteSpace(line) Then adapters.Add(Integer.Parse(line))
        Next
        adapters.Sort()

        Console.WriteLine("Part One: " & PartOne(adapters).ToString())
        Console.WriteLine("Part Two: " & PartTwo(adapters).ToString())
    End Sub

    Function PartOne(adapters As List(Of Integer)) As Integer
        Dim ones As Integer = 0
        Dim threes As Integer = 1
        If adapters(0) = 1 Then ones += 1
        If adapters(0) = 3 Then threes += 1

        For i = 0 To adapters.Count - 2
            If adapters(i + 1) - adapters(i) = 1 Then ones += 1
            If adapters(i + 1) - adapters(i) = 3 Then threes += 1
        Next

        Return ones * threes
    End Function

    Function PartTwo(adapters As List(Of Integer)) As Long
        Dim total As Long = 1
        Dim index As Integer
        Dim counter As Integer = 2

        While index < adapters.Count - 1
            If adapters(index + 1) - adapters(index) = 1 Then
                counter += 1
            Else
                If counter = 3 Then total *= 2
                If counter = 4 Then total *= 4
                If counter = 5 Then total *= 7
                counter = 1
            End If
            index += 1
        End While

        Return total
    End Function
End Module
