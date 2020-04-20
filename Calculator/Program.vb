Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        Dim tempNum As String
        Dim exiting As Boolean = False
        Dim ans As Double = 0
        Console.WriteLine("Welcome to my calculator")
1:      Do While True
            Console.WriteLine("Please input a calculation in the form x operation y ie 3 + 2, and then press enter")
            Console.WriteLine("Input ans to use last answer")
            tempNum = Console.ReadLine()
            If Regex.IsMatch(tempNum, "^(\s*[-]?[0-9]+\.*[0-9]*|ans)\s*[\*\/\+\-\^]\s*([-]?[0-9]+\.*[0-9]*|ans)\s*$") Then
                Dim num1 As Double
                Dim num2 As Double
                Dim mat As Match
                Dim numStr As String
                Dim op As String
                If Regex.IsMatch(tempNum, "\s*ans\s*[\+\-\*\/]\s*ans\s*") Then
                    num1 = ans
                    num2 = ans
                    tempNum = Regex.Replace(tempNum, "\s*ans\s*", "")
                ElseIf Regex.IsMatch(tempNum, "\s*ans\s*[\+\-\/\*]") Then
                    num1 = ans
                    mat = Regex.Match(tempNum, "[-]?[0-9]+\.*[0-9]*")
                    numStr = mat.ToString
                    num2 = CDbl(numStr)
                    tempNum = Regex.Replace(tempNum, "\s*ans\s*", "")

                ElseIf Regex.IsMatch(tempNum, "\s*[\+\-\/\*]\s*ans\s*") Then
                    num2 = ans
                    mat = Regex.Match(tempNum, "[-]?[0-9]+\.*[0-9]*")
                    numStr = mat.ToString
                    num1 = CDbl(numStr)
                    tempNum = Regex.Replace(tempNum, "\s*ans\s*", "")

                Else
                    mat = Regex.Match(tempNum, "[-]?[0-9]+\.*[0-9]*")
                    Dim numMatch As Match = mat.NextMatch()

                    numStr = mat.ToString
                    Dim num2Str As String = numMatch.ToString

                    num1 = CDbl(numStr)
                    num2 = CDbl(num2Str)
                End If

                op = Regex.Replace(tempNum, "\s*[-]?[0-9]+\.*[0-9]*\s*", "")
                If op = "" Then
                    op = "-"
                    num2 *= -1
                End If
                Select Case op
                    Case "+"
                        ans = num1 + num2
                    Case "-"
                        ans = num1 - num2
                    Case "*"
                        ans = num1 * num2
                    Case "/"
                        If Not num2 = 0 Then
                            ans = num1 / num2
                        Else
                            Console.WriteLine("Cannot Divide by 0")
                            GoTo 1
                        End If
                    Case "^"
                        ans = Math.Pow(num1, num2)
                End Select
                Console.WriteLine(num1 & op & num2 & "=" & ans)
            ElseIf Regex.IsMatch(tempNum, "[Ee]xit") Then
                Console.WriteLine("Thank you for using my calculator, have a good day")
                GoTo 2

            End If

        Loop
2:
    End Sub
End Module
