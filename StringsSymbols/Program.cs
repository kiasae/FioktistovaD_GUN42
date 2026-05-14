

using System.Text;

//1
Console.WriteLine(ConcatenateStrings("Hello,", " World!"));

//2
Console.WriteLine(GreetUser("Tom", 23));

//3
Console.WriteLine(Info("Hello, my name is Oleg"));

//4
Console.WriteLine(Substring("I have a dog"));

//5
string[] array = { "Aboba", "Ababa", "Abiba" }; 
Console.WriteLine(GetStringBuilder(array).ToString());

//6
Console.WriteLine(ReplaceWords("My name is Olga","Olga", "Dima"));

//Задание 1
string ConcatenateStrings(string str1, string str2)
{
    return str1 + str2;
}


//Задание 2
string GreetUser(string name, int age)
{
    return $"Hello, {name}!\nYou are {age} years old.";
}

//Задание 3
string Info(string str1)
{
    return $"{str1.Length}, {str1.ToUpper()}, {str1.ToLower()}";
}

//Задание 4
string Substring(string str1)
{
    return str1.Substring(0, 5);
}

//Задание 5
StringBuilder GetStringBuilder(string[] str1)
{
    StringBuilder sb = new StringBuilder();
    sb.Append(string.Join(' ', str1));
    return sb;
}

//Задание 6
string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
{
    return inputString.Replace(wordToReplace, replacementWord);
}