using System;
using System.Linq;

using Xunit.Sdk;

public class CircularBuffer<T>
{
    int[] buffer;
    int writePositionIndex = 0;
    int readPositionIndex = 0;
    int overwritePositionIndex = 0;
    int clearPositionIndex = 0;
    int stage = 0;

    public CircularBuffer(int capacity) 
    {
        buffer = new int[capacity];
    }
    public int Read()
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

    public void Write(int value)
    {
        if (writePositionIndex - readPositionIndex >= buffer.Length) throw new InvalidOperationException();
        int index = writePositionIndex % buffer.Length;
        buffer[index] = value;
        writePositionIndex++;
        overwritePositionIndex++;
        stage++;
    }

    public void Overwrite(int value)
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