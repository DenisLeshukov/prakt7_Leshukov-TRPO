using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt7_Leshukov.Models
{
    public class Event :INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        private string? _location;
        public string? Location
        {
            get => _location;
            set { _location = value;  }
        }

        public DateTime EventDate { get; set; }

        public decimal TicketPrice { get; set; }

        public bool IsActive { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
