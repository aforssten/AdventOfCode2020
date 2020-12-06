Imports System.IO

Module Program
    Sub Main(args As String())

        Dim seats As New List(Of Integer)

        For Each boardingPass In File.ReadLines("input.txt")
            seats.Add(CalculateSeatId(boardingPass))
        Next
        seats.Sort()

        Console.WriteLine("Part 1: " & seats.Last.ToString())
        Console.WriteLine("Part 2: " & FindMissingSeat(seats).ToString())
    End Sub

    Function CalculateSeatId(boardingPass As String)

        Dim front As Integer = 0
        Dim back As Integer = 127
        Dim left As Integer = 0
        Dim right As Integer = 7

        For i = 0 To 9
            If boardingPass(i) = "F"c Then back = Math.Floor((back + front) / 2)
            If boardingPass(i) = "B"c Then front = Math.Ceiling((back + front) / 2)
            If boardingPass(i) = "L"c Then right = Math.Floor((left + right) / 2)
            If boardingPass(i) = "R"c Then left = Math.Ceiling((left + right) / 2)
        Next

        Return front * 8 + left
    End Function

    Function FindMissingSeat(seats As List(Of Integer)) As Integer

        Dim seatToCheck = seats.First
        For i = 0 To seats.Count
            If seatToCheck <> seats(i) Then Return seatToCheck
            seatToCheck += 1
        Next

        Return 0
    End Function
End Module
