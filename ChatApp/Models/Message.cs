using System;

namespace ChatApp.Models;
public class Message
{
    public string? Content { get; set; }
    public string Time { get; set; }
    public Message()
    {
        
    }

    public Message(string? content)
    {
        Content = content;
        Time = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
    }
}

