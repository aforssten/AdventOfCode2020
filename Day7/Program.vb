Imports System.IO

Module Program
    Sub Main(args As String())

        Dim partOneCount As Integer = 0
        Dim bags As New List(Of Bag)

        For Each rule In File.ReadLines("input.txt")
            Dim colorAndContents = rule.Split("bags contain")
            Dim contents = colorAndContents.Last().Split(","c)
            bags.Add(New Bag(colorAndContents(0).Trim(), contents))
        Next

        For Each bag In bags
            If ContainsColor(bag, "shiny gold", bags, False) Then partOneCount += 1
        Next

        Dim partTwoCount = BagCount(bags.Find(Function(b) b.Color = "shiny gold"), bags)

        Console.WriteLine("Part 1: " & partOneCount)
        Console.WriteLine("Part 2: " & partTwoCount)
    End Sub

    Function ContainsColor(currentBag As Bag, color As String, bags As List(Of Bag), includeOwnColor As Boolean)

        If currentBag.Color = color And includeOwnColor Then Return True

        Dim bagsToSearch As New List(Of Bag)
        For Each bag In currentBag.Contents
            Dim bagColor = bag.Split(" "c)(1) & " " & bag.Split(" "c)(2)
            If ContainsColor(bags.Find(Function(b) b.Color = bagColor), "shiny gold", bags, True) Then Return True
        Next
        Return False
    End Function

    Function BagCount(currentBag As Bag, bags As List(Of Bag)) As Integer
        Dim contentCount As Integer = 0
        For Each item In currentBag.Contents
            Dim numBags = Integer.Parse(item.Split(" "c)(0))
            Dim bagColor = item.Split(" "c)(1) & " " & item.Split(" "c)(2)
            contentCount += numBags
            For i = 1 To numBags
                contentCount += BagCount(bags.Find(Function(b) b.Color = bagColor), bags)
            Next
        Next
        Return contentCount
    End Function

    Class Bag
        Public ReadOnly Property Color As String
        Public ReadOnly Property Contents As List(Of String)

        Public Sub New(color As String, contents As String())
            Me.Color = color
            Me.Contents = New List(Of String)
            For Each bag In contents
                If bag.Trim() <> "no other bags." Then
                    Me.Contents.Add(bag.Trim())
                End If
            Next
        End Sub
    End Class
End Module
