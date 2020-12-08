Imports System.IO

Module Program
    Sub Main(args As String())

        Dim instructionSet = File.ReadAllLines("input.txt")
        Dim partOne As Integer = 0
        Dim partTwo As Integer = 0

        IsInfiniteLoop(instructionSet, partOne)

        Dim correctFound As Boolean = False
        Dim index As Integer = 0
        While Not correctFound And index < instructionSet.Length
            Dim instructionSetToTest(instructionSet.Length - 1) As String
            For i = 0 To instructionSet.Length - 1
                instructionSetToTest(i) = instructionSet(i).Clone()
            Next
            Dim instruction = instructionSetToTest(index).Split(" "c)
            If instruction(0) = "jmp" Then
                instructionSetToTest(index) = "nop " & instruction(1)
            ElseIf instruction(0) = "nop" Then
                instructionSetToTest(index) = "jmp " & instruction(1)
            End If
            If Not IsInfiniteLoop(instructionSetToTest, partTwo) Then correctFound = True
            index += 1
        End While

        Console.WriteLine("Part 1: " & partOne)
        Console.WriteLine("Part 2: " & partTwo)
    End Sub

    Function IsInfiniteLoop(instructionSet As String(), ByRef acc As Integer) As Boolean
        Dim hasBeenRun(instructionSet.Length - 1) As Boolean
        Dim infiniteLoopFound As Boolean = False
        Dim internalAcc As Integer = 0
        Dim index As Integer = 0

        While Not infiniteLoopFound And index < instructionSet.Length
            hasBeenRun(index) = True

            Dim instruction = instructionSet(index).Split(" "c)
            Dim code = instruction(0)
            Dim increment = instruction(1)

            If code = "acc" Then
                If increment(0) = "+"c Then internalAcc += Integer.Parse(increment.Substring(1))
                If increment(0) = "-"c Then internalAcc -= Integer.Parse(increment.Substring(1))
                index += 1
            End If
            If code = "jmp" Then
                If increment(0) = "+"c Then index += Integer.Parse(increment.Substring(1))
                If increment(0) = "-"c Then index -= Integer.Parse(increment.Substring(1))
            End If
            If code = "nop" Then
                index += 1
            End If

            If index < instructionSet.Length AndAlso hasBeenRun(index) Then infiniteLoopFound = True
        End While

        acc = internalAcc
        Return infiniteLoopFound
    End Function

End Module
