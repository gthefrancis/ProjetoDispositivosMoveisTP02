using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TarefasApp.Models
{
    public class Tarefa : INotifyPropertyChanged
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _titulo = string.Empty;
        public string Titulo
        {
            get => _titulo;
            set { _titulo = value; OnPropertyChanged(); }
        }

        private string _descricao = string.Empty;
        public string Descricao
        {
            get => _descricao;
            set { _descricao = value; OnPropertyChanged(); }
        }

        private DateTime? _dataCriacao;
        public DateTime? DataCriacao
        {
            get => _dataCriacao;
            set { _dataCriacao = value; OnPropertyChanged(); }
        }

        private string _prioridade = string.Empty;
        public string Prioridade
        {
            get => _prioridade;
            set { _prioridade = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
                    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
