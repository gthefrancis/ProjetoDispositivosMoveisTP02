using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TarefasApp
{
    public class PrioridadeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var prioridade = value as string;

            // Retorna a cor dependendo da prioridade
            return prioridade switch
            {
                "Alta" => Color.FromArgb("#ffcdd2"),  // Vermelho claro
                "Média" => Color.FromArgb("#fff9c4"), // Amarelo claro
                "Baixa" => Color.FromArgb("#c8e6c9"),  // Verde claro
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Não precisamos fazer o caminho inverso (da cor pro texto)
            throw new NotImplementedException();
        }
    }
}
