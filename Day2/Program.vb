Imports System.IO

Module Program
    Sub Main(args As String())

        Dim PartOneCount As Integer
        Dim PartTwoCount As Integer

        For Each entry In File.ReadLines("input.txt")
            Dim parts = entry.Split({"-"c, " "c, ":"c}, StringSplitOptions.RemoveEmptyEntries)
            Dim min = Integer.Parse(parts(0))
            Dim max = Integer.Parse(parts(1))
            Dim character = parts(2)
            Dim password = parts(3)

            Dim charCount = password.Count(Function(c) c = character)
            If charCount >= min And charCount <= max Then
                PartOneCount += 1
            End If

            If password(min - 1) = character Xor password(max - 1) = character Then
                PartTwoCount += 1
            End If

        Next
        Console.WriteLine("Part 1: " & PartOneCount.ToString())
        Console.WriteLine("Part 2: " & PartTwoCount.ToString())
    End Sub
End Module
