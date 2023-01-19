using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace helloralph.Models
{
    [ObservableObject]
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public int PendingTasks { get; set; }
        public float Percentage { get; set; }
        public bool IsSelected { get; set; }
    }
}

