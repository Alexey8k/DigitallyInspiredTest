using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UI3DTasks.ViewModels;

namespace UI3DTasks.DataTemplateSelectors
{
    internal class Task3DDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Task3DataTemplate { get; set; }
        public DataTemplate Task4DataTemplate { get; set; }
        public DataTemplate Task5DataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Task3DViewModel task3DViewModel)
                switch (task3DViewModel.Name)
                {
                    case "Task 3":
                        return Task3DataTemplate;
                    case "Task 4":
                        return Task4DataTemplate;
                    case "Task 5":
                        return Task5DataTemplate;                        
                }
            return null;
        }
    }
}
