Imports System
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        Dim tempNum As String
        Dim exiting As Boolean = False
        Console.WriteLine("Welcome to my calculator")
1:      Do While True
            Console.WriteLine("Please input a calculation in the form x operation y ie 3 + 2")
            tempNum = Console.ReadLine()
            If Regex.IsMatch(tempNum, "^[-]?[0-9]+\.*[0-9]*\s*[\*\/\+\-\^]\s*[-]?[0-9]+\.*[0-9]*$") Then
                Dim mat As Match = Regex.Match(tempNum, "[-]?[0-9]+\.*[0-9]*")
                Dim numMatch As Match = mat.NextMatch()

                Dim numStr As String = mat.ToString
                Dim num2Str As String = numMatch.ToString

                Dim num1 As Double = CDbl(numStr)
                Dim num2 As Double = CDbl(num2Str)

                Dim op As String = Regex.Replace(tempNum, "\s*[-]?[0-9]+\.*[0-9]*\s*", "")

                Console.WriteLine(op)

                Dim ans As Double
                Select Case op
                    Case "+"
                        ans = num1 + num2
                    Case "-"
                        ans = num1 + num2
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
