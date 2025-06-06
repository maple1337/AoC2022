using System;

static void Main()
{
    string[] input = new string[2500];
    string[] temp;
    int score = 0;

    try
    {
        input = File.ReadAllLines("..\\..\\..\\input.txt");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("ERROR: File was not found.");
    }
    catch (IOException)
    {
        Console.WriteLine($"Error reading the file");
    }

    foreach (string line in input)
    {
        temp = line.Split(' ');

        if (temp[1] == "X") // make me lose
        {
            if (temp[0] == "A")
            {
                temp[1] = "C";
            }
            else if (temp[0] == "B")
            {
                temp[1] = "A";
            }
            else
            {
                temp[1] = "B";
            }
        }

        else if (temp[1] == "Y") // make me draw
        {
            temp[1] = temp[0];
        }

        else // make me win
        {
            if (temp[0] == "A")
            {
                temp[1] = "B";
            }
            else if (temp[0] == "B")
            {
                temp[1] = "C";
            }
            else
            {
                temp[1] = "A";
            }
        }

        // add value for chosen sign
        if (temp[1] == "B")
        {
            score += 2;
        }
        else if (temp[1] == "C")
        {
            score += 3;
        }
        else
        {
            score++;
        }

        if (temp[0] == temp[1])
        {
            score += 3;
        }
        else if (temp[0] == "A" && temp[1] == "B" || temp[0] == "B" && temp[1] == "C" || temp[0] == "C" && temp[1] == "A")
        {
            score += 6;
        }

        Console.WriteLine("Ergebnis: {0}", score);
    }
}