Module Module1
    Dim usr(4) As Integer
    Dim comp(4) As Integer
    Dim OutcomeUser(4) As String
    Dim OutcomeComp(4) As String
    Dim OutcomeOfBoth(4) As String
    Dim win, winPercent As Double
    Dim loss, lossPercent As Double
    Dim tied, tiedPercent As Double
    ''' <summary>
    ''' Runs the game
    ''' </summary>
    Sub Main()
        PrintTitle()
        For i As Integer = 0 To 4
            usr(i) = GetValidInput()
            OutcomeUser(i) = ConvertNumToWord(usr(i))
            Console.WriteLine("Round {0}", i + 1)
            Console.WriteLine("You chose {0}.", OutcomeUser(i))
            comp(i) = ComputerMove()
            OutcomeComp(i) = ConvertNumToWord(comp(i))
            Console.WriteLine("The computer chose {0}.", OutcomeComp(i))
            OutcomeOfBoth(i) = DetermineOutcome(usr(i), comp(i))
            Console.WriteLine("You {0} to the computer.", OutcomeOfBoth(i))
            Percentages(OutcomeOfBoth(i))
        Next
        PrintReport()
        PrintPercentages()
    End Sub
    ''' <summary>
    ''' Prints out what the user and computer chose and the outcome of these choices. It also prints out what round it was.
    ''' </summary>
    ''' <param name="str1"></param>
    ''' <param name="str2"></param>
    ''' <param name="str3"></param>
    ''' <param name="str4"></param>
    Sub PrintReportLine(str1 As String, str2 As String, str3 As String, str4 As String)
        Console.WriteLine("| {0} | {1} | {2} | {3} |", str1.PadRight(6), str2.PadRight(19), str3.PadRight(17), str4.PadRight(20))
    End Sub
    ''' <summary>
    ''' Creates out the table.
    ''' </summary>
    Sub PrintReport()
        Console.WriteLine("".PadRight(75, "#"))
        Console.WriteLine("".PadRight(40, "#") & "Results" & "".PadLeft(28, "#"))
        Console.WriteLine("".PadRight(75, "#"))
        Console.WriteLine("".PadRight(75, "-"))
        Console.WriteLine("| Round ".PadRight(10) & "| User Played ".PadRight(20) & " | Computer Played ".PadRight(20) & " | Outcome              |".PadRight(20))
        Console.WriteLine("".PadRight(75, "-"))
        For i As Integer = 0 To 4
            PrintReportLine(i + 1, OutcomeUser(i), OutcomeComp(i), OutcomeOfBoth(i))
            Console.WriteLine("".PadRight(75, "-"))
        Next

    End Sub
    ''' <summary>
    ''' Counts up how many wins, losses, and ties you got.
    ''' </summary>
    ''' <param name="Str"></param>
    Sub Percentages(Str As String)
        If Str = "Win" Then
            win = win + 1
        ElseIf Str = "Loss" Then
            loss = loss + 1
        ElseIf Str = "Tie" Then
            tied = tied + 1
        End If
    End Sub
    ''' <summary>
    ''' Calculates and prints out your percentages for win, losses, and ties based on how many wins, losses, and ties based on how many you got.
    ''' </summary>
    Sub PrintPercentages()
        winPercent = win / 5
        lossPercent = loss / 5
        tiedPercent = tied / 5
        Console.WriteLine("Your win percentage is: {0}", winPercent.ToString("P2"))
        Console.WriteLine("Your loss percentage is: {0}", lossPercent.ToString("P2"))
        Console.WriteLine("Your tied percentage is: {0}", tiedPercent.ToString("P2"))
    End Sub
    ''' <summary>
    ''' Gets valid input from the user.
    ''' </summary>
    ''' <returns></returns>
    Function GetValidInput() As String
        Dim input As String
        Dim pass As Boolean = False
        Do
            Console.Write("Please enter a 1 for Rock, a 2 for Paper, and a 3 for Scissors -> ")
            input = Console.ReadLine
            If input = "1" Or input = "2" Or input = "3" Then
                Return input
                pass = True
            Else
                Console.WriteLine("Invalid input, please try again")
            End If
        Loop While pass = False

    End Function
    ''' <summary>
    ''' Randomly choses a number between 1 and 3 inclusively. It then outputs the number it chose.
    ''' </summary>
    ''' <returns></returns>
    Function ComputerMove() As Integer
        Dim Rand As New Random
        Dim num As Integer
        num = Rand.Next(1, 4)
        Return num.ToString
    End Function
    ''' <summary>
    ''' Prints out the ASCII title.
    ''' </summary>
    Sub PrintTitle()
        Console.WriteLine(".-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
    _______           _______               _______
---'   ____)      ---'   ____)____     ---'    ____)____
      (_____)               ______)               ______)
      (_____)               _______)           __________)
      (____)               _______)           (____)
---.__(___)       ---.__________)      ---.__(___)
")
    End Sub
    ''' <summary>
    ''' Determines if you winned, lossed, or tied based on what you and the computer chose.
    ''' </summary>
    ''' <param name="int1"></param>
    ''' <param name="int2"></param>
    ''' <returns></returns>
    Function DetermineOutcome(int1 As Integer, int2 As Integer) As String
        Dim WinLossOrTie As String = ""
        If int1 = 2 And int2 = 1 Then
            WinLossOrTie = "Win"
        ElseIf int1 = 2 And int2 = 3 Then
            WinLossOrTie = "Loss"
        ElseIf int1 = 3 And int2 = 2 Then
            WinLossOrTie = "Win"
        ElseIf int1 = 1 And int2 = 2 Then
            WinLossOrTie = "Loss"
        ElseIf int1 = 3 And int2 = 1 Then
            WinLossOrTie = "Loss"
        ElseIf int1 = 1 And int2 = 2 Then
            WinLossOrTie = "Loss"
        ElseIf int1 = 1 And int2 = 3 Then
            WinLossOrTie = "Win"
        ElseIf int1 = 3 And int2 = 1 Then
            WinLossOrTie = "Loss"
        ElseIf int1 = int2 Then
            WinLossOrTie = "Tie"
        End If
        Return WinLossOrTie
    End Function
    ''' <summary>
    ''' Converts the integer you inputted into the corrisponding word value.
    ''' </summary>
    ''' <param name="num"></param>
    ''' <returns></returns>
    Function ConvertNumToWord(num As Integer) As String
        Dim Word As String
        If num = 1 Then
            Word = "Rock"
        ElseIf num = 2 Then
            Word = "Paper"
        ElseIf num = 3 Then
            Word = "Scissors"
        End If
        Return Word
    End Function

End Module
