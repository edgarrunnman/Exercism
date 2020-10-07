using System;
using System.Linq;

using Xunit.Sdk;

public class CircularBuffer<T>
{
    T[] buffer;
    int writePositionIndex = 0;
    int readPositionIndex = 0;
    int overwritePositionIndex = 0;
    int clearPositionIndex = 0;
    int stage = 0;

    public CircularBuffer(int capacity) 
    {
        buffer = new T[capacity];
    }
    public T Read()
    {
        int index = readPositionIndex % buffer.Length;
        if (index >= buffer.Length) throw new InvalidOperationException();
        if (buffer[index].Equals(0)) throw new InvalidOperationException();
        var value = buffer[index];
        buffer.SetValue(null, index);
        readPositionIndex++;
        clearPositionIndex++;
        return value;
    }

    public void Write(T value)
    {
        if (writePositionIndex - readPositionIndex >= buffer.Length) throw new InvalidOperationException();
        int index = writePositionIndex % buffer.Length;
        buffer[index] = value;
        writePositionIndex++;
        overwritePositionIndex++;
        stage++;
    }

    public void Overwrite(T value)
    {
        int index = overwritePositionIndex % buffer.Length;
        buffer[index] = value;
        
        if (overwritePositionIndex - readPositionIndex >= buffer.Length) readPositionIndex++;
        overwritePositionIndex++;
        stage++;
    }

    public void Clear()
    {
        buffer.SetValue(null, readPositionIndex);
        if (stage != 0)
        {
            overwritePositionIndex--;
            writePositionIndex--;
        }
        clearPositionIndex++;
        stage++;
    }
}