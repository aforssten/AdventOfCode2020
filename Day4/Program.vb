Imports System.IO
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())

        Dim validCount1 As Integer = 0
        Dim validCount2 As Integer = 0

        Using reader As New StreamReader("input.txt")
            While Not reader.EndOfStream

                Dim passPortData As String = ""
                Dim line = reader.ReadLine()
                While Not String.IsNullOrWhiteSpace(line)
                    passPortData += line & Environment.NewLine
                    line = reader.ReadLine()
                End While

                If Not String.IsNullOrWhiteSpace(passPortData) Then
                    Dim passPort As New Dictionary(Of String, String)
                    Dim fields = passPortData.Split(New String() {" ", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                    For Each field In fields
                        Dim key = field.Split(":"c).First
                        Dim value = field.Split(":"c).Last
                        passPort.Add(key, value)
                    Next

                    If IsPassPortValidPartOne(passPort) Then
                        validCount1 += 1
                    End If
                    If IsPassPortValidPartTwo(passPort) Then
                        validCount2 += 1
                    End If
                End If
            End While
        End Using

        Console.WriteLine("Part 1: " & validCount1.ToString())
        Console.WriteLine("Part 2: " & validCount2.ToString())
    End Sub

    Function IsPassPortValidPartOne(passPort As Dictionary(Of String, String)) As Boolean

        If Not (passPort.ContainsKey("byr") AndAlso Not String.IsNullOrWhiteSpace(passPort("byr"))) Then Return False
        If Not (passPort.ContainsKey("iyr") AndAlso Not String.IsNullOrWhiteSpace(passPort("iyr"))) Then Return False
        If Not (passPort.ContainsKey("eyr") AndAlso Not String.IsNullOrWhiteSpace(passPort("eyr"))) Then Return False
        If Not (passPort.ContainsKey("hgt") AndAlso Not String.IsNullOrWhiteSpace(passPort("hgt"))) Then Return False
        If Not (passPort.ContainsKey("hcl") AndAlso Not String.IsNullOrWhiteSpace(passPort("hcl"))) Then Return False
        If Not (passPort.ContainsKey("ecl") AndAlso Not String.IsNullOrWhiteSpace(passPort("ecl"))) Then Return False
        If Not (passPort.ContainsKey("pid") AndAlso Not String.IsNullOrWhiteSpace(passPort("pid"))) Then Return False

        Return True

    End Function

    Function IsPassPortValidPartTwo(passPort As Dictionary(Of String, String)) As Boolean

        If Not IsPassPortValidPartOne(passPort) Then Return False
        If Not (Integer.Parse(passPort("byr")) >= 1920 And Integer.Parse(passPort("byr")) <= 2002) Then Return False
        If Not (Integer.Parse(passPort("iyr")) >= 2010 And Integer.Parse(passPort("iyr")) <= 2020) Then Return False
        If Not (Integer.Parse(passPort("eyr")) >= 2020 And Integer.Parse(passPort("eyr")) <= 2030) Then Return False

        Dim format = Strings.Right(passPort("hgt"), 2)
        If Not (format = "in" Or format = "cm") Then Return False
        Dim height = Integer.Parse(Strings.Left(passPort("hgt"), passPort("hgt").Length - 2))
        If Not ((format = "in" And height >= 59 And height <= 76) Or (format = "cm" And height >= 150 And height <= 193)) Then Return False

        If Not Regex.IsMatch(passPort("hcl"), "#[0-9a-f]{6}") Then Return False
        If Not Regex.IsMatch(passPort("ecl"), "amb|blu|brn|gry|grn|hzl|oth") Then Return False
        If Not (IsNumeric(passPort("pid")) And passPort("pid").Length = 9) Then Return False

        Return True

    End Function
End Module
