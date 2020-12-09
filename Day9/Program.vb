Imports System.IO

Module Program
    Sub Main(args As String())

        Dim input As New List(Of Long)
        For Each line In File.ReadAllLines("input.txt")
            If Not String.IsNullOrWhiteSpace(line) Then input.Add(Long.Parse(line))
        Next

        Dim partOne = input(FindInvalidIndex(25, input))
        Dim partTwo = FindContiguous(FindInvalidIndex(25, input), input)

        Console.WriteLine("Part 1: " & partOne.ToString())
        Console.WriteLine("Part 2: " & partTwo.ToString())

    End Sub

    Function FindContiguous(index As Integer, input As List(Of Long)) As Long

        For i = 0 To index - 1
            Dim sum As Integer = input(i)
            For j = i + 1 To index - 1
                sum += input(j)
                If sum = input(index) Then Return input(i) + input(j)
            Next
        Next
        Return 0

    End Function

    Function FindInvalidIndex(preamble As Integer, input As List(Of Long)) As Long

        For i = preamble To input.Count - 1
            If Not isValid(preamble, input, i) Then Return i
        Next
        Return 0

    End Function

    Function isValid(preamble As Integer, input As List(Of Long), indexToTest As Integer)

        For i = indexToTest - (preamble) To indexToTest - 1
            For j = i + 1 To indexToTest - 1
                If input(i) + input(j) = input(indexToTest) Then Return True
            Next
        Next
        Return False

    End Function
End Module
