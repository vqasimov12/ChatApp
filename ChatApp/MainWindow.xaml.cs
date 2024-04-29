using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace ChatApp;
public partial class MainWindow : Window
{
    public List<Message> Messages { get; set; } = new List<Message>();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        if (File.Exists("Messages.json"))
        {
            var text = File.ReadAllText("Messages.json");
            Messages = JsonSerializer.Deserialize<List<Message>>(text)!;
        }
    }

    private void Send_Click(object ?sender, RoutedEventArgs ?e)
    {
        if (Text.Text != "")
        {
            Messages.Add(new(Text.Text));
            MessageList.Items.Refresh();
            Text.Text = "";
            var json = JsonSerializer.Serialize(Messages, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Messages.json", json);
        }
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            Send_Click(null, null);
    }
}

