using System;
public class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }
    public ScriptureReference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
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