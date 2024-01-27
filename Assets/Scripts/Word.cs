using System;

[Serializable]
public class Word
{
    public string value;

    public Word(string value)
    {
        this.value = value;
    }

    public override bool Equals(object obj)
    {
        return obj is Word word &&
               value.Equals(word.value);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(value);
    }
}
