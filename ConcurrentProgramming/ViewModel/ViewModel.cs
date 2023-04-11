﻿using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ViewModel
{

  
    public class ViewModel : INotifyPropertyChanged
    {
        public int windowWidth { get; }
        public int windowHeight { get; }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    }
