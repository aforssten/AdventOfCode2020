Imports System.IO

Module Program
    Sub Main(args As String())
        Dim map As List(Of String) = File.ReadLines("input.txt").ToList()
        Dim part1 = CalculateSlope(map, 3, 1)
        Dim part2 = CalculateSlope(map, 1, 1) * CalculateSlope(map, 3, 1) * CalculateSlope(map, 5, 1) * CalculateSlope(map, 7, 1) * CalculateSlope(map, 1, 2)
        Console.WriteLine("Part 1: " & part1.ToString())
        Console.WriteLine("Part 2: " & part2.ToString())
    End Sub

    Function CalculateSlope(map As List(Of String), stepRight As Integer, stepDown As Integer) As Long
        Dim treeCount As Long = 0
        Dim x As Integer = 0
        Dim y As Integer = 0

        While y < map.Count
            If map(y)(x) = "#"c Then
                treeCount += 1
            End If

            x = (x + stepRight) Mod map(0).Length
            y += stepDown
        End While

        Return treeCount
    End Function
End Module
