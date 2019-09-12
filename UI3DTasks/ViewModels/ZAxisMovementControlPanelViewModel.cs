using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.ViewModels
{
    class ZAxisMovementControlPanelViewModel : BaseViewModel, IZAxisMovementControlPanelViewModel
    {
        private const double ZMINUP = -5;
        private const double ZMINDOWN = -25;

        private const double ZMAXUP = 25;
        private const double ZMAXDOWN = 5;

        public double ZMinUp => ZMINUP;
        public double ZMinDown => ZMINDOWN;

        public double ZMaxUp => ZMAXUP;
        public double ZMaxDown => ZMAXDOWN;

        private double _zMin = ZMINUP;
        public double ZMin
        {
            get => _zMin;
            set
            {
                _zMin = value;
                OnPropertyChanged();
            }
        }

        private double _zMax = ZMAXDOWN;
        public double ZMax
        {
            get => _zMax;
            set
            {
                _zMax = value;
                OnPropertyChanged();
            }
        }

        private bool _isMoveModel3D;
        public bool IsMoveModel3D
        {
            get => _isMoveModel3D;
            set
            {
                if (!_isMoveModel3D ^ value) return;
                _isMoveModel3D = value;
                OnPropertyChanged();
            }
        }

    }
}
