using System;
public class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public ScriptureReference()
    {
        _book = "John";
        _chapter = 17;
        _verse = 3;
        _endVerse = 0;
    }

    public void Display()
    {
        if (_endVerse == 0)
        {
            Console.Write($"{_book} {_chapter}:{_verse} ");
        }
        else
        {
            Console.Write($"{_book} {_chapter}:{_verse}-{_endVerse} ");
        }
    }
}