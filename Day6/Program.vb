Imports System.IO

Module Program
    Sub Main(args As String())

        Dim partOneCount As Integer = 0
        Dim partTwoCount As Integer = 0

        Using reader As New StreamReader("input.txt")
            While Not reader.EndOfStream
                Dim groupAnswers As String = ""
                Dim groupMemberCount As Integer = 0

                Dim line = reader.ReadLine()
                While Not String.IsNullOrWhiteSpace(line)
                    groupMemberCount += 1
                    groupAnswers += line
                    line = reader.ReadLine()
                End While

                Dim anyoneYes As New HashSet(Of Char)
                For i = 0 To groupAnswers.Length - 1
                    anyoneYes.Add(groupAnswers(i))
                Next
                partOneCount += anyoneYes.Count

                For Each question In anyoneYes
                    If groupMemberCount = groupAnswers.Count(Function(q) q = question) Then
                        partTwoCount += 1
                    End If
                Next
            End While
        End Using

        Console.WriteLine("Part 1: " & partOneCount.ToString())
        Console.WriteLine("Part 2: " & partTwoCount.ToString())
    End Sub
End Module
